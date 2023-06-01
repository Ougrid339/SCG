namespace SCG.CHEM.MBR.COMMON.API.AppModels.DataFactory
{
    public class ResponseGetTokenBearerModel
    {
        public string Token_type { get; set; }
        public string Expires_in { get; set; }
        public string Ext_Expires_In { get; set; }
        public string Expires_On { get; set; }
        public string Not_Before { get; set; }
        public string Resource { get; set; }
        public string Access_Token { get; set; }
    }
}