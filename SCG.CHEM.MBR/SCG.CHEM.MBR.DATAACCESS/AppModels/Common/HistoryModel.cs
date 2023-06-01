using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Common
{
    public class HistoryModel
    {
        public long? InterfaceId { get; set; }
        public string? ServicePath { get; set; }
        public string? PlanType { get; set; }
        public string? Cycle { get; set; }
        public string? Case { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string Inbound { get; set; }
        public string? Outbound { get; set; }
        public string? ErrorMessage { get; set; }
        public string? CustomMessage { get; set; }
        public string UserAD { get; set; }
        public DateTime? InboundDate { get; set; }
        public DateTime? OutboundDate { get; set; }
        public int? Status { get; set; }
        public string? Criteria { get; set; }
        public bool? IsValidationSuccess { get; set; }

        public List<string>? PlanningGroupName
        {
            get
            {
                if (!String.IsNullOrEmpty(Criteria) && (TypeId == 2 || TypeId == 3))
                {
                    var model = JsonConvert.DeserializeObject<List<string>>(JObject.Parse(Criteria).Property("PlanningGroupName").Value.ToString()).Select(s => s);
                    var list = model.Select(s => s).ToList();
                    if (list.Count() == 0)
                    {
                        list.Add("ALL");
                    }
                    return list;
                }
                else
                    return null;
            }
        }

        public List<string> ScenarioDesc
        {
            get
            {
                if (!String.IsNullOrEmpty(Criteria) && TypeId == 3)
                {
                    var model = JsonConvert.DeserializeObject<List<string>>(JObject.Parse(Criteria).Property("ScenarioDesc").Value.ToString()).Select(s => s);
                    var list = model.Select(s => s).ToList();
                    if (list.Count() == 0)
                    {
                        list.Add("ALL");
                    }
                    return list;
                }
                else
                    return null;
            }
        }

        public List<string> SalesGroupName
        {
            get
            {
                if (!String.IsNullOrEmpty(Criteria) && TypeId == 3)
                {
                    var model = JsonConvert.DeserializeObject<List<string>>(JObject.Parse(Criteria).Property("SalesGroupName").Value.ToString()).Select(s => s);
                    var list = model.Select(s => s).ToList();
                    if (list.Count() == 0)
                    {
                        list.Add("ALL");
                    }
                    return list;
                }
                else
                    return null;
            }
        }

        public List<string> NewProductFlagName
        {
            get
            {
                if (!String.IsNullOrEmpty(Criteria) && TypeId == 3)
                {
                    var model = JsonConvert.DeserializeObject<List<string>>(JObject.Parse(Criteria).Property("NewProductFlagName").Value.ToString()).Select(s => s);
                    var list = model.Select(s => s).ToList();
                    if (list.Count() == 0)
                    {
                        list.Add("ALL");
                    }
                    return list;
                }
                else
                    return null;
            }
        }

        public List<string> MatGroup
        {
            get
            {
                if (!String.IsNullOrEmpty(Criteria) && TypeId == 3)
                {
                    var model = JsonConvert.DeserializeObject<List<string>>(JObject.Parse(Criteria).Property("MatGroup").Value.ToString()).Select(s => s);
                    var list = model.Select(s => s).ToList();
                    if (list.Count() == 0)
                    {
                        list.Add("ALL");
                    }
                    return list;
                }
                else
                    return null;
            }
        }

        public List<string> Product
        {
            get
            {
                if (!String.IsNullOrEmpty(Criteria) && TypeId == 3)
                {
                    var model = JsonConvert.DeserializeObject<List<string>>(JObject.Parse(Criteria).Property("Product").Value.ToString()).Select(s => s);
                    var list = model.Select(s => s).ToList();
                    if (list.Count() == 0)
                    {
                        list.Add("ALL");
                    }
                    return list;
                }
                else
                    return null;
            }
        }

        public List<string> ProductSub
        {
            get
            {
                if (!String.IsNullOrEmpty(Criteria) && TypeId == 3)
                {
                    var model = JsonConvert.DeserializeObject<List<string>>(JObject.Parse(Criteria).Property("ProductSub").Value.ToString()).Select(s => s);
                    var list = model.Select(s => s).ToList();
                    if (list.Count() == 0)
                    {
                        list.Add("ALL");
                    }
                    return list;
                }
                else
                    return null;
            }
        }

        public DateTime? Date
        {
            get
            {
                if (InboundDate is not null)
                {
                    return InboundDate.Value;
                }
                return null;
            }
        }
    }
}