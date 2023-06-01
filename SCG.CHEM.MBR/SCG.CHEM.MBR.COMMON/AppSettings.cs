﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.MBR.COMMON
{
    public class AppSettings
    {
        private static readonly ConcurrentDictionary<string, object> _lock = new ConcurrentDictionary<string, object>();

        public object Locker(string name) => _lock.GetOrAdd(name, _ => new object());

        public string ENVIRONMENT { get; set; }
        public DatabaseSchema databaseSchema { get; set; }
        public string JwtKey { get; set; }
        public string[] AllowedHosts { get; set; }
        public string AppVersion { get; set; }
        public string WepAppUrl { get; set; }
        public string NLogCommand { get; set; }
        public AzureService azureService { get; set; }
        public Datafactory datafactory { get; set; }
        public WebDatafactory webDatafactory { get; set; }
        public AzureServiceSCG azureServiceSCG { get; set; }
        public AzureServiceLSP azureServiceLSP { get; set; }

        public class AzureService
        {
            public string tenant_id { get; set; }
            public string client_id { get; set; }
            public string client_secret { get; set; }
        }

        public class AzureServiceSCG
        {
            public string tenant_id { get; set; }
            public string client_id { get; set; }
            public string client_secret { get; set; }
        }

        public class AzureServiceLSP
        {
            public string tenant_id { get; set; }
            public string client_id { get; set; }
            public string client_secret { get; set; }
        }

        public class Datafactory
        {
            public string subscriptionId { get; set; }
            public string resourceGroup { get; set; }
            public string masterPipeline { get; set; }
            public string datafactory { get; set; }
            public string salesPlanPipeline { get; set; }
            public string transactionPipeline { get; set; }
            public string marketPricePipline { get; set; }
            public string feedPipline { get; set; }
            public string salesPipline { get; set; }
            public string assumptionPipeline { get; set; }
        }

        public class WebDatafactory
        {
            public string SubscriptionId { get; set; }
            public string ResourceGroup { get; set; }
            public string Datafactory { get; set; }
            public string ImportFinalPricePipeline { get; set; }
            public string ImportFormulaPipeline { get; set; }
        }

        public class DatabaseSchema
        {
            public string dbo { get; set; }
            public string mbr { get; set; }
        }
    }
}