using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.COMMON.API.Swagger;
using SCG.CHEM.SSPLSP.DATAACCESS;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SCG.CHEM.MBR.COMMON.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IWebHostEnvironment CurrentEnvironment { get; set; }
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if ((!Environment.MachineName.StartsWith("CPX-") && CurrentEnvironment.IsDevelopment()) || CurrentEnvironment.IsProduction())
            {
                services.AddApplicationInsightsTelemetry();
                services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, o) => { module.EnableSqlCommandTextInstrumentation = true; });
            }

            var commandTimeout = Configuration["CommandTimeout"];
            int timeoutValue = 30;
            if (commandTimeout != null)
                timeoutValue = Convert.ToInt32(commandTimeout);

            var appSettings = new AppSettings();
            Configuration.Bind("AppSettings", appSettings);

            #region set GlobalDiagnosticsContext for Nlog

            GlobalDiagnosticsContext.Set("connectionString", Configuration.GetConnectionString("EntitiesContext"));
            GlobalDiagnosticsContext.Set("nlogCommand", appSettings.NLogCommand);

            #endregion set GlobalDiagnosticsContext for Nlog

            services.AddCors(o =>
            o.AddPolicy(MyAllowSpecificOrigins, builder =>
            {
                builder.WithOrigins("*")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            })
            );
            //.AllowAnyOrigin() //.WithOrigins(appSettings.AllowedHosts)
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddControllers().AddNewtonsoftJson();
            services.AddHttpContextAccessor();

            #region Database MySQL

            services.AddDbContext<EntitiesContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("EntitiesContext"), opt => opt.CommandTimeout(timeoutValue)));
            services.AddDbContext<EntitiesMBRContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("EntitiesMBRContext"), opt =>
               {
                   opt.CommandTimeout(timeoutValue);
                   opt.MigrationsHistoryTable("__EFMigrationsHistory", appSettings.databaseSchema.mbr);
               }));
            services.AddDbContext<EntitiesMBRReadContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("EntitiesMBRReadContext"), opt =>
               {
                   opt.CommandTimeout(timeoutValue);
                   opt.MigrationsHistoryTable("__EFMigrationsHistory", appSettings.databaseSchema.mbr);
               }));
            //.EnableSensitiveDataLogging());

            services.AddDbContext<EntitiesReadContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EntitiesReadContext"), opt => opt.CommandTimeout(timeoutValue)));

            #endregion Database MySQL

            services
            .AddSingleton(appSettings)
            //.AddSingleton<ICacheProvider, CacheProvider>()
            //.AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
            .AddScoped<UnitOfWork>()
            .AddScoped<SCG.CHEM.SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork>()
            .AddScoped<EntitiesContext>()
            .AddScoped<EntitiesReadContext>()
            .AddScoped<EntitiesMBRContext>()
            .AddScoped<EntitiesMBRReadContext>()
            .AddHttpClient();
            //services.AddControllers();

            #region business logic

            services.AddScoped<AUTH.BUSINESSLOGIC.Authentication.Interface.ITokenManager, AUTH.BUSINESSLOGIC.Authentication.TokenManager>();
            services.AddScoped<COMMON.Authentication.Interface.IUserLocalService, COMMON.Authentication.UserLocalService>();

            var authAppserviceTypes = typeof(AUTH.BUSINESSLOGIC.Services.IBaseService).Assembly
                .GetTypes()
                .Where(t => typeof(AUTH.BUSINESSLOGIC.Services.IBaseService).IsAssignableFrom(t))
                .Where(t => t != null);
            var authAppserviceTypesClass = authAppserviceTypes.Where(x => x.IsClass && x.IsPublic);
            var aauthAppserviceTypesInf = authAppserviceTypes.Where(t => t.IsInterface);

            //add to service
            foreach (var item in authAppserviceTypesClass)
            {
                var itemInf = aauthAppserviceTypesInf.FirstOrDefault(t => t.Name.Equals($"I{item.Name}"));
                if (itemInf != null)
                {
                    services.AddTransient(itemInf, item);
                }
            }

            var appserviceTypes = typeof(BusinessLogic.Services.IBaseService).Assembly
                .GetTypes()
                .Where(t => typeof(BusinessLogic.Services.IBaseService).IsAssignableFrom(t))
                .Where(t => t != null);
            var appserviceTypesClass = appserviceTypes.Where(x => x.IsClass && x.IsPublic);
            var appserviceTypesInf = appserviceTypes.Where(t => t.IsInterface);

            //add to service
            foreach (var item in appserviceTypesClass)
            {
                var itemInf = appserviceTypesInf.FirstOrDefault(t => t.Name.Equals($"I{item.Name}"));
                if (itemInf != null)
                {
                    services.AddTransient(itemInf, item);
                }
            }

            #endregion business logic

            #region swagger

            if (Environment.MachineName.StartsWith("CPX-") || CurrentEnvironment.IsDevelopment())
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "API-SCGP, ENV :" + CurrentEnvironment.EnvironmentName + ", ConfigENV : " + (appSettings?.ENVIRONMENT ?? "-"),
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "ITONE Co.,Ltd",
                        },
                    });

                    c.IgnoreObsoleteProperties();

                    c.OperationFilter<AppOperationFilter>();
                });
            }

            #endregion swagger

            #region Max Length of Requested Json Object

            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = 10; //default 1024
                options.ValueLengthLimit = int.MaxValue; //not recommended value
                options.MultipartBodyLengthLimit = long.MaxValue; //not recommended value
                options.MemoryBufferThreshold = Int32.MaxValue;
            });
            services.AddMvc(options =>
            {
                options.MaxModelBindingCollectionSize = int.MaxValue;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });

            #endregion Max Length of Requested Json Object
        }

        public void Configure(IApplicationBuilder app)
        {
            if (CurrentEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (Environment.MachineName.StartsWith("CPX-") || CurrentEnvironment.IsDevelopment())
            {
                app.UseSwagger(c => UseSwagger(c));
                app.UseSwaggerUI(c => UseSwaggerUI(c, CurrentEnvironment));
            }

            UserUtilities.Configure(app.ApplicationServices);
        }

        public void UseSwagger(SwaggerOptions c)
        {
            //c.RouteTemplate = "swagger/{documentName}/swagger.json";
            c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
            {
                //swaggerDoc.Servers = new List<OpenApiServer> {
                //    new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{httpReq.PathBase}" }
                //};

                //if (!Environment.MachineName.StartsWith("CPX-"))
                //{
                //    swaggerDoc.Servers.Add(new OpenApiServer { Url = $"{Configuration["SwaggerBaseUrl"]}" });
                //    swaggerDoc.Servers.Add(new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Host}{Configuration["VirtualDirectory"]}" });
                //}
            });
        }

        public void UseSwaggerUI(SwaggerUIOptions c, IWebHostEnvironment env)
        {
            c.SwaggerEndpoint("v1/swagger.json", "IT One Web API:" + env.EnvironmentName);
            c.DocExpansion(DocExpansion.None);
            c.OAuthClientId("");
            c.OAuthClientSecret("");
        }
    }
}