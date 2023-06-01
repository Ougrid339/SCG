using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SCG.CHEM.MBR.COMMON;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.MASTER.API.AppModels.AD;
using SCG.CHEM.MBR.MASTER.API.AppModels.DataFactory;
using SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services.Interface;
using System.Net.Http.Headers;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic.Services
{
    public sealed class ADService : IADService
    {
        private readonly UnitOfWork _unit;
        private readonly AppSettings _appSettings;

        public ADService(UnitOfWork unitOfWork, AppSettings appSettings)
        {
            this._unit = unitOfWork;
            this._appSettings = appSettings;
        }

        public ResADModel GetADUserResult(ReqADTokenModel req)
        {
            ResADModel res = new ResADModel();
            try
            {
                HttpClientHandler clientHandle = new HttpClientHandler();
                clientHandle.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                using (var client = new HttpClient(clientHandle))
                {
                    var tenant = _appSettings.azureServiceSCG.tenant_id;
                    var client_id = _appSettings.azureServiceSCG.client_id;
                    var client_secret = _appSettings.azureServiceSCG.client_secret;
                    if (req.type == "LSP")
                    {
                        tenant = _appSettings.azureServiceLSP.tenant_id;
                        client_id = _appSettings.azureServiceLSP.client_id;
                        client_secret = _appSettings.azureServiceLSP.client_secret;
                    }
                    var url = $"https://login.microsoftonline.com/{tenant}/oauth2/token";
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    //client.Timeout = TimeSpan.FromSeconds(Utils.Constants.AppConst.HTTP_CLIENT_TIMEOUT);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "48f188847c5f4f99aca4cab31351db63");
                    Dictionary<string, string> queryString = new Dictionary<string, string>()
                    {
                        { "client_id" , client_id},
                        { "client_secret" ,client_secret },
                        { "grant_type", "client_credentials" },
                        { "resource","https://graph.microsoft.com" },
                    };
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsync(url, new FormUrlEncodedContent(queryString)).Result;
                    //var responeContent = Task.Run(() => client.PostAsync(url, Content))
                    //                        .Result.Content.ReadAsStringAsync().Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var dataObjects = response.Content.ReadFromJsonAsync<ResponseGetTokenBearerModel>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                        var token = dataObjects.Access_Token;

                        res.users = GetUserAD(token.ToString(), req.name);
                        client.Dispose();
                        return res;
                    }
                    else
                    {
                        res.message = "error";
                        res.error = true;
                        client.Dispose();
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                res.message = ex.ToString();
                res.error = true;
                return res;
            }
        }

        public ResADModel GetADUsers(ReqADModel req)
        {
            ResADModel respone = new ResADModel();
            try
            {
                ReqADTokenModel reqADSCG = new ReqADTokenModel();
                reqADSCG.type = "SCG";
                reqADSCG.name = req.name;
                var responeSCG = GetADUserResult(reqADSCG);
                if (responeSCG.error)
                {
                    respone.message = responeSCG.message;
                    return respone;
                }
                ReqADTokenModel reqADLSP = new ReqADTokenModel();
                reqADLSP.type = "LSP";
                reqADLSP.name = req.name;
                var responeLSP = GetADUserResult(reqADLSP);
                if (responeLSP.error)
                {
                    respone.message = responeLSP.message;
                    return respone;
                }
                string responseSCGString = System.Text.Json.JsonSerializer.Serialize(responeSCG);
                string responseLSPString = System.Text.Json.JsonSerializer.Serialize(responeSCG);
                var listUserSCG = JsonConvert.DeserializeObject<List<UserDetail>>(JObject.Parse(responseSCGString).Property("users").Value.ToString());
                var listUserLSP = JsonConvert.DeserializeObject<List<UserDetail>>(JObject.Parse(responseLSPString).Property("users").Value.ToString());

                respone.users = listUserSCG.Union(listUserLSP);

                return respone;
            }
            catch (Exception ex)
            {
                respone.message = ex.ToString();
                return respone;
            }
        }

        public string GetUserAD(string token, string name)
        {
            HttpClientHandler clientHandle = new HttpClientHandler();
            clientHandle.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            using (var client = new HttpClient(clientHandle))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var url = "https://graph.microsoft.com/v1.0/users?$filter=startswith(mail,'" + name + "')";
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadFromJsonAsync<ResADUserModel>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    var respone = dataObjects.value;
                    client.Dispose();
                    return respone.ToString();
                }
                else
                {
                    var respone = "error";
                    client.Dispose();
                    return respone.ToString();
                }
            }
        }
    }
}