using Microsoft.AspNetCore.WebUtilities;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.MASTER.API.AppModels.DataFactory;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master.Interface;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Master
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

        public async Task<string> RunAssumptionPipeLineAsync(RequestCreateRunPipeline req)
        {
            using var client = new HttpClient();
            // Get access token in order to run pipeline
            string accessToken = await GetAccessToken();

            // Prepare url
            string subscriptionId = _appSettings.datafactory.subscriptionId;
            string resourceGroup = _appSettings.datafactory.resourceGroup;
            string datafactory = _appSettings.datafactory.datafactory;
            string pipeline = _appSettings.datafactory.assumptionPipeline;
            string baseUrl = $"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.DataFactory/factories/{datafactory}/pipelines/{pipeline}/createRun?api-version=2018-06-01";

            // Prepare payload/body
            var stringPayload = JsonSerializer.Serialize(req);
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            // Add header
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            // Run pipeline
            HttpResponseMessage response = await client.PostAsync(baseUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResponseCreateRunPipeline>();

                if (result != null)
                {
  
                    MBR_MST_DATAFACTORY_RUN datafactoryRun = new MBR_MST_DATAFACTORY_RUN(result.runId, "In-Progress", req.masterName, "");
                    _unit.DataFactoryRunRepo.Add(datafactoryRun);
                    _unit.SaveTransaction();
                    return result.runId;
                }

                throw new Exception("Pipeline doesn't return a runId.");
            }

            throw new Exception("Cannot run pipeline.");
        }

        public string RunPipeline(string masterName, string createBy)
        {
            HttpClient client = new HttpClient();

            string result = "";
            string master = masterName.Split("|")[0];
            var bearerToken = GetTokenBearer();

            var subscriptionId = _appSettings.datafactory.subscriptionId;
            var resourceGroup = _appSettings.datafactory.resourceGroup;
            var pipeline = _appSettings.datafactory.masterPipeline;
            var datafactory = _appSettings.datafactory.datafactory;

            //var bearerToken = GetTokenBearer();
            //var subscriptionId = "bb8a721e-06cf-46e3-835d-7f2c0b9396b2";
            //var resourceGroup = "App-Modernization-SSP-Non-Prod-EA-RG";
            //var pipeline = "PL_COPY_DWH_FREIGHT";
            //var datafactory = "azchemssp-adf-nonprod";
            //var baseUrl = $"https://scgchem-apim-test.scg.com/azure-management/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.DataFactory/factories/{datafactory}/pipelines/{pipeline}/createRun?api-version=2018-06-01";
            var baseUrl = $"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.DataFactory/factories/{datafactory}/pipelines/{pipeline}/createRun?api-version=2018-06-01";

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            var mst = _unit.MasterRepo.GetMasterFromName(master).FirstOrDefault();
            RequestCreateRunPipeline request = new RequestCreateRunPipeline(master, mst.MasterTemp);
            var jsonobj = JsonSerializer.Serialize<RequestCreateRunPipeline>(request);
            var content = new StringContent(JsonSerializer.Serialize<RequestCreateRunPipeline>(request), Encoding.UTF8, "application/json");
            // List data response.
            HttpResponseMessage response = client.PostAsync(baseUrl, content).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<ResponseCreateRunPipeline>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                if (dataObjects.runId != null)
                {
                    MBR_MST_DATAFACTORY_RUN datafactoryRun = new MBR_MST_DATAFACTORY_RUN(dataObjects.runId, "In-Progress", masterName, createBy);
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

        public string RunPipelineImportFormula(string masterName, string createBy)
        {
            HttpClient client = new HttpClient();

            string result = "";
            string master = masterName.Split("|")[0];
            var bearerToken = GetTokenBearer();

            string subscriptionId = _appSettings.webDatafactory.SubscriptionId;
            string resourceGroup = _appSettings.webDatafactory.ResourceGroup;
            string datafactory = _appSettings.webDatafactory.Datafactory;
            string pipeline = _appSettings.webDatafactory.ImportFormulaPipeline;

            var baseUrl = $"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.DataFactory/factories/{datafactory}/pipelines/{pipeline}/createRun?api-version=2018-06-01";

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            // List data response.
            HttpResponseMessage response = client.PostAsync(baseUrl, null).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadFromJsonAsync<ResponseCreateRunPipeline>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                if (dataObjects.runId != null)
                {
                    MBR_MST_DATAFACTORY_RUN datafactoryRun = new MBR_MST_DATAFACTORY_RUN(dataObjects.runId, "In-Progress", masterName, createBy);
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

        public string DWHImportCompleteStatus(string runId, string status)
        {
            var DataFactoryRun = _unit.DataFactoryRunRepo.GetByRunId(runId);
            if (DataFactoryRun != null)
            {
                if (status == "Succeeded")
                {
                    DataFactoryRun.UpdateStatus("DWH-Complete");
                }
                else
                {
                    DataFactoryRun.UpdateStatus("DWH-Fail");
                    _unit.SaveTransaction();

                    throw new Exception("Receive fail status from DWH");
                }
                _unit.SaveTransaction();
            }
            else
            {
                throw new Exception("Cannot Find Master or RunId");
            }
            return "success";
        }

        public string DWHImportCompleteStatus(string runId, string status, int masterId)
        {
            var DataFactoryRun = _unit.DataFactoryRunRepo.GetByRunId(runId);
            var Master = _unit.MasterRepo.GetMaster(masterId).FirstOrDefault();
            if (Master != null && DataFactoryRun != null)
            {
                if (status == "Succeeded")
                {
                    DataFactoryRun.UpdateStatus("DWH-Complete");
                    //Master.UpdateStatus(DataFactoryRun.CreatedBy);
                }
                else
                {
                    DataFactoryRun.UpdateStatus("DWH-Fail");
                    _unit.SaveTransaction();

                    throw new Exception("Receive fail status from DWH");
                }
                _unit.SaveTransaction();
            }
            else
            {
                throw new Exception("Cannot Find Master or RunId");
            }
            return "success";
        }

        public string WebImportCompleteStatus(string runId, int masterId)
        {
            var DataFactoryRun = _unit.DataFactoryRunRepo.GetByRunId(runId);
            var Master = _unit.MasterRepo.GetMaster(masterId).FirstOrDefault();
            if (Master != null && DataFactoryRun != null)
            {
                DataFactoryRun.UpdateStatus("Complete");
                Master.UpdateStatus(DataFactoryRun.CreatedBy);
                _unit.SaveTransaction();
            }

            else
            {
                throw new Exception("Cannot Find Master or RunId");
            }
            return "success";
        }

        public string WebImportCompleteStatus(string runId)
        {
            var DataFactoryRun = _unit.DataFactoryRunRepo.GetByRunId(runId);
            if  (DataFactoryRun != null)
            {
                DataFactoryRun.UpdateStatus("Complete");
                _unit.SaveTransaction();
            }
            else
            {
                throw new Exception("Cannot Find Master or RunId");
            }
            return "success";
        }
    }
}