using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.AUTH.API.Swagger
{
    public class AppOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            //Authorization Token
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema { Type = "String" },
                Required = false
            });

            //AD Token
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Ad-Authorization",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema { Type = "String" },
                Required = false
            });

            //App token
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "App-Authorization",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema { Type = "String" },
                Required = false
            });
        }
    }
}
