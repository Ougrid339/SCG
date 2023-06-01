using Microsoft.AspNetCore.WebUtilities;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.COMMON.API.AppModels.DataFactory;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using SCG.CHEM.MBR.COMMON.API.AppModels.Datafactory;
using SCG.CHEM.MBR.DATAACCESS.Entities.Logging;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Datafacetory.Interface;
using SCG.CHEM.MBR.DATAACCESS.Entities.Temp;

namespace SCG.CHEM.MBR.COMMON.API.BusinessLogic.Datafacetory
{
    public class DataFactoryService : IDataFactoryService
    {
        private readonly UnitOfWork _unit;
        private readonly AppSettings _appSettings;

        public DataFactoryService(UnitOfWork unitOfWork, AppSettings appSettings)
        {
            this._unit = unitOfWork;
            this._appSettings = appSettings;
        }

        public async Task<string> GetAccessToken()
        {
            using (var client = new HttpClient())
            {
                var tenant = _appSettings.azureService.tenant_id;
                var client_id = _appSettings.azureService.client_id;
                var client_secret = _appSettings.azureService.client_secret;
                var baseUrl = $"https://login.microsoftonline.com/{tenant}/oauth2/token";

                Dictionary<string, string> formUrlEncodedDict = new Dictionary<string, string>()
                {
                    { "client_id" , client_id},
                    { "client_secret" ,client_secret },
                    { "grant_type", "client_credentials" },
                    { "resource","https://management.azure.com" },
                };
                var content = new FormUrlEncodedContent(formUrlEncodedDict);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "App Services SSP");

                HttpResponseMessage response = await client.PostAsync(baseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<ResponseGetTokenBearerModel>();
                    return result.Access_Token;
                }

                throw new Exception("Cannot get access token");
            }
        }

        public string GetTokenBearer()
        {
            HttpClient client = new HttpClient();

            string result = "";
            var tenant = _appSettings.azureService.tenant_id;
            var client_id = _appSettings.azureService.client_id;
            var client_secret = _appSettings.azureService.client_secret;
            //var baseUrl = "https://scgchem-api-test.scg.com/azure-login/5db8bf0e-8592-4ed0-82b2-a6d4d77933d4/oauth2/token";
            var baseUrl = $"https://login.microsoftonline.com/{tenant}/oauth2/token";
            Dictionary<string, string> queryString = new Dictionary<string, string>()
            {
                { "client_id" , client_id},
                { "client_secret" ,client_secret },
                { "grant_type", "client_credentials" },
                { "resource","https://management.azure.com" },
            };

            // Add an Accept header for JSON format.
            //client.DefaultRequestHeaders.Accept.Add(
            //new MediaTypeWithQualityHeaderValue("application/json"));
            //urce", "https://management.azure.com"}
            //});
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "App Services SSP");

            // List data response.
            HttpResponseMessage response = client.PostAsync(baseUrl, new FormUrlEncodedContent(queryString)).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<ResponseGetTokenBearerModel>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                result = dataObjects.Access_Token;
            }
            else
            {
                result = "error";
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return result;
        }

        public MBR_MST_DATAFACTORY_RUN StatusRunId(string runId)
        {
            var DataFactoryRun = _unit.DataFactoryRunRepo.GetByRunId(runId);

            return DataFactoryRun;
        }

        public ResponseLatestUpdate GetLatestUpdate()
        {
            ResponseLatestUpdate result = new ResponseLatestUpdate();
            //var DataFactoryRun = _unit.DataFactoryRunRepo.GetTransactionLatestUpdate();
            //if (DataFactoryRun != null)
            //{
            //    result.createDate = DataFactoryRun.CreatedDate;
            //    result.createBy = DataFactoryRun.CreatedBy;
            //    result.cycleName = DataFactoryRun.MasterName.Split("|")[1];
            //    result.planningGroups = DataFactoryRun.MasterName.Split("|")[2];
            //}
            return result;
        }

        public string RunPipeline(string tableName, string transactionName, string cycleName, string caseName, string planType, string createBy)
        {
            HttpClient client = new HttpClient();

            string result = "";
            string master = tableName.Split("|")[0];
            var bearerToken = GetTokenBearer();

            var subscriptionId = _appSettings.datafactory.subscriptionId;
            var resourceGroup = _appSettings.datafactory.resourceGroup;
            var pipeline = _appSettings.datafactory.marketPricePipline;
            var datafactory = _appSettings.datafactory.datafactory;

            var baseUrl = $"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.DataFactory/factories/{datafactory}/pipelines/{pipeline}/createRun?api-version=2018-06-01";

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            RequestRunPipelineUpdateMarketPrice request = new RequestRunPipelineUpdateMarketPrice(master, cycleName, caseName, planType);
            var jsonobj = JsonSerializer.Serialize<RequestRunPipelineUpdateMarketPrice>(request);
            var content = new StringContent(JsonSerializer.Serialize<RequestRunPipelineUpdateMarketPrice>(request), Encoding.UTF8, "application/json");
            // List data response.
            HttpResponseMessage response = client.PostAsync(baseUrl, content).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<ResponseCreateRunPipeline>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                if (dataObjects.runId != null)
                {
                    MBR_MST_DATAFACTORY_RUN datafactoryRun = new MBR_MST_DATAFACTORY_RUN(dataObjects.runId, "In-Progress", transactionName + "|" + planType + "|" + cycleName + "|" + caseName, planType, cycleName, caseName, false, createBy);
                    _unit.DataFactoryRunRepo.Add(datafactoryRun);
                    _unit.SaveTransaction();
                    result = dataObjects.runId;
                }
            }
            else
            {
                result = "error";
            }

            //if (result == "error")
            //{
            //    throw new Exception("Cannot Run Pipeline");
            //}
            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return result;
        }

        public string RunPipelineOptience(string tableName, string transactionName, string cycleName, string caseName, string planType, List<string> company, string createBy)
        {
            HttpClient client = new HttpClient();
            string result = "";
            string master = tableName.Split("|")[0];
            var bearerToken = GetTokenBearer();
            var subscriptionId = _appSettings.datafactory.subscriptionId;
            var resourceGroup = _appSettings.datafactory.resourceGroup;
            var pipeline = _appSettings.datafactory.transactionPipeline;
            var datafactory = _appSettings.datafactory.datafactory;

            var baseUrl = $"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.DataFactory/factories/{datafactory}/pipelines/{pipeline}/createRun?api-version=2018-06-01";

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            RequestRunPipelineUpdateOptience request = new RequestRunPipelineUpdateOptience(master, cycleName, caseName, planType, string.Join(",", company));
            var jsonobj = JsonSerializer.Serialize<RequestRunPipelineUpdateOptience>(request);
            var content = new StringContent(JsonSerializer.Serialize<RequestRunPipelineUpdateOptience>(request), Encoding.UTF8, "application/json");
            // List data response.
            HttpResponseMessage response = client.PostAsync(baseUrl, content).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<ResponseCreateRunPipeline>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                if (dataObjects.runId != null)
                {
                    MBR_MST_DATAFACTORY_RUN datafactoryRun = new MBR_MST_DATAFACTORY_RUN(dataObjects.runId, "In-Progress", transactionName + "|" + planType + "|" + cycleName + "|" + caseName + "|" + String.Join(",", company), planType, cycleName, caseName, false, createBy);
                    _unit.DataFactoryRunRepo.Add(datafactoryRun);
                    _unit.SaveTransaction();
                    result = dataObjects.runId;
                }
            }
            else
            {
                result = "error";
            }

            //if (result == "error")
            //{
            //    throw new Exception("Cannot Run Pipeline");
            //}
            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return result;
        }

        public string RunPipelineMultiCriteria(string tableName, string transactionName, RequestCriteriaTransaction criteria, string createBy, string submitStatus)
        {
            HttpClient client = new HttpClient();

            string result = "";
            string master = tableName.Split("|")[0];
            var bearerToken = GetTokenBearer();

            var subscriptionId = _appSettings.datafactory.subscriptionId;
            var resourceGroup = _appSettings.datafactory.resourceGroup;
            var pipeline = _appSettings.datafactory.feedPipline;
            var datafactory = _appSettings.datafactory.datafactory;

            var baseUrl = $"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.DataFactory/factories/{datafactory}/pipelines/{pipeline}/createRun?api-version=2018-06-01";

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            RequestRunPipelineDelTransaction request = new RequestRunPipelineDelTransaction(master, criteria, submitStatus);
            var jsonobj = JsonSerializer.Serialize<RequestRunPipelineDelTransaction>(request);
            var content = new StringContent(JsonSerializer.Serialize<RequestRunPipelineDelTransaction>(request), Encoding.UTF8, "application/json");
            // List data response.
            HttpResponseMessage response = client.PostAsync(baseUrl, content).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<ResponseCreateRunPipeline>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                if (dataObjects.runId != null)
                {
                    MBR_MST_DATAFACTORY_RUN datafactoryRun = new MBR_MST_DATAFACTORY_RUN(dataObjects.runId, "In-Progress", transactionName + "|" + criteria.PlaneType + "|" + criteria.Cycle + "|" + criteria.Case + "|" + String.Join(",", criteria.Company) + "|" + String.Join(",", criteria.FeedGeoCategoryKey) + "|" + String.Join(",", criteria.FeedNameKey) + "|" + String.Join(",", criteria.ProductGroup), criteria.PlaneType, criteria.Cycle, criteria.Case, false, createBy);
                    _unit.DataFactoryRunRepo.Add(datafactoryRun);
                    _unit.SaveTransaction();
                    result = dataObjects.runId;
                }
            }
            else
            {
                result = "error";
            }

            if (result == "error")
            {
                throw new Exception("Cannot Run Pipeline");
            }
            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return result;
        }

        public string RunPipelineSalesCriteria(string tableName, string transactionName, RequestCriteriaSales criteria, string submitStatus, string createBy, bool isPreview, Guid webUUID, bool isMerge = false)
        {
            HttpClient client = new HttpClient();

            string result = "";
            string master = tableName.Split("|")[0];
            var bearerToken = GetTokenBearer();

            var subscriptionId = _appSettings.datafactory.subscriptionId;
            var resourceGroup = _appSettings.datafactory.resourceGroup;
            var pipeline = transactionName == "MarketPriceForecast" ? _appSettings.datafactory.marketPricePipline : _appSettings.datafactory.salesPipline;
            var datafactory = _appSettings.datafactory.datafactory;

            var baseUrl = $"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.DataFactory/factories/{datafactory}/pipelines/{pipeline}/createRun?api-version=2018-06-01";

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            RequestRunPipelineDelSales request = new RequestRunPipelineDelSales(master, criteria, submitStatus);
            var jsonobj = JsonSerializer.Serialize<RequestRunPipelineDelSales>(request);
            var content = new StringContent(JsonSerializer.Serialize<RequestRunPipelineDelSales>(request), Encoding.UTF8, "application/json");
            // List data response.
            HttpResponseMessage response = client.PostAsync(baseUrl, content).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<ResponseCreateRunPipeline>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                if (dataObjects.runId != null)
                {
                    //var criteriaString = "";
                    //if (criteria.Company != null && criteria.Company.Count > 0)
                    //{
                    //    criteriaString = criteriaString.ToString() + "|";
                    //    criteriaString += string.Join(",", criteria.Company);
                    //}
                    //if (criteria.Channel != null && criteria.Channel.Count > 0)
                    //{
                    //    criteriaString = criteriaString.ToString() + "|";
                    //    criteriaString += string.Join(",", criteria.Channel);
                    //}
                    //if (criteria.Product != null && criteria.Product.Count > 0)
                    //{
                    //    criteriaString = criteriaString.ToString() + "|";
                    //    criteriaString += string.Join(",", criteria.Product);
                    //}
                    //if (criteria.ProductGroup != null && criteria.ProductGroup.Count > 0)
                    //{
                    //    criteriaString = criteriaString.ToString() + "|";
                    //    criteriaString += string.Join(",", criteria.ProductGroup);
                    //}
                    var salesPreviewSubmitRepo = _unit.MasterTempSalesPreviewSubmitRepo.GetByWebUUID(webUUID);

                    if (!isPreview)
                    {
                        MBR_MST_DATAFACTORY_RUN datafactoryRun = new MBR_MST_DATAFACTORY_RUN(dataObjects.runId, "In-Progress", transactionName + "|" + criteria.PlaneType + "|" + criteria.cycleName + "|" + criteria.caseName, criteria.PlaneType, criteria.cycleName, criteria.caseName, isMerge, createBy);
                        _unit.DataFactoryRunRepo.Add(datafactoryRun);
                        if (salesPreviewSubmitRepo != null)
                        {
                            salesPreviewSubmitRepo.SubmitRunId = dataObjects.runId;
                            salesPreviewSubmitRepo.UpdatedBy = createBy;
                            salesPreviewSubmitRepo.Mode = "Submit-Inprogress";
                            salesPreviewSubmitRepo.UpdatedDate = DateTime.Now;
                            _unit.MasterTempSalesPreviewSubmitRepo.Update(salesPreviewSubmitRepo);
                        }
                        else
                        {
                            var addSalesSubmit = new MBR_TMP_SALES_PREVIEW_SUBMIT()
                            {
                                WebUUID = webUUID,
                                SubmitRunId = dataObjects.runId,
                                CreatedBy = createBy,
                                Mode = "Submit-Inprogress",
                                //UpdateFinalPriceRunId = "In-Progress",
                                CreatedDate = DateTime.Now
                            };

                            _unit.MasterTempSalesPreviewSubmitRepo.Add(addSalesSubmit);
                        }
                    }
                    _unit.SaveTransaction();
                    result = dataObjects.runId;
                }
            }
            else
            {
                result = "error";
            }

            if (result == "error")
            {
                throw new Exception("Cannot Run Pipeline");
            }
            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return result;
        }

        public string DWHImportCompleteStatus(string runId, string status)
        {
            var DataFactoryRun = _unit.DataFactoryRunRepo.GetByRunId(runId);
            if (DataFactoryRun != null && DataFactoryRun.Status != "Complete")
            {
                var statusLog = "Complete";

                if (status == "Succeeded")
                {
                    DataFactoryRun.UpdateStatus("DWH-Complete");
                    //DataFactoryRun.UpdateStatus("Complete");
                    //Master.UpdateStatus(DataFactoryRun.CreatedBy);
                }
                else
                {
                    DataFactoryRun.UpdateStatus("DWH-Fail");
                    statusLog = "FAILED";
                    _unit.SaveTransaction();

                    throw new Exception("Receive fail status from DWH");
                }

                //LOG_SEND_DWH log = new LOG_SEND_DWH(statusLog, runId, DateTime.Now, DateTime.Now, runId, null, cycleName.Split('_')[0], cycleName, item.PlanningGroupName, "");
                //log.SetCreatedBy(createBy);
                //_unit.LogSendDWHRepo.Add(log);
                _unit.SaveTransaction();
            }
            else
            {
                throw new Exception("Cannot Find RunId");
            }
            return "success";
        }

        public string WebImportCompleteStatus(string runId)
        {
            var DataFactoryRun = _unit.DataFactoryRunRepo.GetByRunId(runId);
            if (DataFactoryRun != null && DataFactoryRun.Status != "Complete")
            {
                DataFactoryRun.UpdateStatus("Complete");
                _unit.SaveTransaction();
            }
            else
            {
                throw new Exception("Cannot Find MarketPriceForecast or RunId");
            }
            return "success";
        }

        public string GetNameDatafactory(string runId)
        {
            var DataFactoryRun = _unit.DataFactoryRunRepo.GetByRunId(runId);
            var masterName = "";
            if (DataFactoryRun != null)
            {
                masterName = DataFactoryRun.MasterName.Split("|")[0].ToUpper();
            }
            else
            {
                throw new Exception("Cannot Find RunId");
            }
            return masterName;
        }

        public string GetCompanyDatafactory(string runId)
        {
            var DataFactoryRun = _unit.DataFactoryRunRepo.GetByRunId(runId);
            var masterName = "";
            if (DataFactoryRun != null)
            {
                masterName = DataFactoryRun.MasterName.Split("|")[4].ToUpper();
            }
            else
            {
                throw new Exception("Cannot Find RunId");
            }
            return masterName;
        }
    }
}