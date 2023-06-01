using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.Entities.Logging;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Logging.Interface;
using Newtonsoft.Json.Linq;
using SCG.CHEM.MBR.COMMON.Utilities;
using Newtonsoft.Json;
using SCG.CHEM.MBR.COMMON.API.AppModels.History;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.History.Interface;

namespace SCG.CHEM.MBR.COMMON.API.BusinessLogic.History
{
    public sealed class HistoryService : IHistoryService
    {
        private readonly UnitOfWork _unit;

        public HistoryService(UnitOfWork unitOfWork)
        {
            this._unit = unitOfWork;
        }

        public List<ReponseHistoryModel> GetHistory(RequesHistoryModel data)
        {
            List<ReponseHistoryModel> result = new List<ReponseHistoryModel>();

            #region get DB Filter

            var listType = new List<int>();
            var query = _unit.LogApiRepo.GetHistory();
            // Filter Group Data
            if (data.GroupData != 0)
            {
                switch (data.GroupData)
                {
                    case 1:
                        listType.AddRange(new List<int> { 1, 2, 3, 4 });
                        break;
                    case 2:
                        listType.AddRange(new List<int> { 5});
                        break;
                    case 3:
                        listType.AddRange(new List<int> { 6,7,8,9 });
                        break;
                    case 4:
                        listType.AddRange(new List<int> { 10 });
                        break;
                    case 5:
                        listType.AddRange(new List<int> { 11 });
                        break;
                    default:
                        // code block
                        break;
                }

                query = query.Where(w => listType.Contains(w.TypeId));
            }

            // Filter Type
            if (data.Type != null && data.Type.Any())
            {
                query = query.Where(w => data.Type.Contains(w.TypeId));
            }

            // Filter PlanType
            if (data.Scenario != null && data.Scenario.Any())
            {
                query = query.Where(w => data.Scenario.Contains(w.PlanType));
            }

            // Filter Cycle
            if (data.Cycle != null && data.Cycle.Any())
            {
                query = query.Where(w => data.Cycle.Contains(w.Cycle));
            }
            // Filter Case
            if (data.Case != null && data.Case.Any())
            {
                query = query.Where(w => data.Case.Contains(w.Case));
            }
            // Filter UserAD
            if (data.UserAD != null && data.UserAD.Any())
            {
                query = query.Where(w => data.UserAD.Contains(w.UserAD));
            }

            // Filter Date
            if (!string.IsNullOrEmpty(data.StartDate))
            {
                query = query.Where(w => w.InboundDate.Value.Date >= DateTime.Parse(data.StartDate).Date);
            }
            if (!string.IsNullOrEmpty(data.EndDate))
            {
                query = query.Where(w => w.InboundDate.Value.Date <= DateTime.Parse(data.EndDate).Date);
            }

            var dataDB = query.ToList();

            #endregion get DB Filter

            #region Set Model Respone

            result = dataDB.Select(s => new ReponseHistoryModel()
            {
                InterfaceId = s.InterfaceId,
                Type = s.TypeName,
                Criteria = (new List<CriteriaHistory>()
                {
                    new CriteriaHistory{ Name = "Scenario",Value = s.PlanType},
                    new CriteriaHistory{ Name = "Cycle",Value = s.Cycle},
                    new CriteriaHistory{ Name = "Case",Value = s.Case}
                }).Where(w => w.Value != null).ToList(),
                UserAD = s.UserAD,
                Date = s.Date,
                Status = s.Status,
                IsValidationSuccess = s.IsValidationSuccess,
                ServicePath = s.ServicePath
            }).ToList();

            #endregion Set Model Respone

            #region Delete History 60 Days

            // Get delete day from config
            var configDeleteHistDay = _unit.MasterConfigRepo.FindById(APPCONSTANT.CONFIG_ID.DELETE_HISTORY_DAY).ConfigValue;

            int deleteHistDay = 0;
            bool IsParseSuccess = int.TryParse(configDeleteHistDay, out deleteHistDay);
            deleteHistDay = (-1) * deleteHistDay;
            var last60date = DateTime.Today.AddDays(deleteHistDay);
            var dataDeleteDB = _unit.LogApiRepo.Query().Where(w => last60date >= w.CreatedDate).ToList();
            _unit.LogApiRepo.Delete(dataDeleteDB);

            #endregion Delete History 60 Days

            return result;
        }

        public ResponseDownloadHistoryModel DownloadHistory(RequestDownloadHistoryModel data)
        {
            Func<JObject?, string?> extractErrorMessage = (errorMessage) =>
            {
                if (errorMessage == null)
                {
                    return null;
                }
                else
                {
                    var message = errorMessage.Property("Error");
                    if (message != null)
                    {
                        return message.Value.ToString();
                    }
                    return null;
                }
            };

            Func<int?, List<MBR_MST_MASTER_MAPPING>> getMasterMapping = (typeId) =>
            {
                if (typeId == HISTORY_MBR_TYPE.PRODUCT_MAPPING) // ProductMapping
                {
                    return _unit.MasterMappingRepo.GetMapping(1).ToList();
                }
                else if (typeId == HISTORY_MBR_TYPE.LSP_PRICE_FORMULA) // LSPPriceFormula
                {
                    return _unit.MasterMappingRepo.GetMapping(2).ToList();
                }
                else if (typeId == HISTORY_MBR_TYPE.CUSTOMER_VENDOR_MAPPING) // CustomerVendorMapping
                {
                    return _unit.MasterMappingRepo.GetMapping(3).ToList();
                }
                else if (typeId == HISTORY_MBR_TYPE.MARKET_PRICE_MAPPING) // MarketPriceMapping
                {
                    return _unit.MasterMappingRepo.GetMapping(4).ToList();
                }

                return new List<MBR_MST_MASTER_MAPPING>();
            };

            Func<int?, string?, List<MBR_MST_MASTER_EXCEL_MAPPING>> getExcelMapping = (typeId, servicePath) =>
            {
                if (typeId == HISTORY_MBR_TYPE.MARKET_PRICE_FORECAST) // Market Price Forecaset
                {
                    return _unit.MasterExcelMappingRepo.GetMapping(1).ToList();
                }
                else if (typeId == HISTORY_MBR_TYPE.PRODUCTION_VOLUME) // Production volume
                {
                    return _unit.MasterExcelMappingRepo.GetMapping(2).ToList();
                }
                else if (typeId == HISTORY_MBR_TYPE.FEED_CONSUMPTION) // Feed Consumption
                {
                    return _unit.MasterExcelMappingRepo.GetMapping(3).ToList();
                }
                else if (typeId == HISTORY_MBR_TYPE.BEGINNING_INVENTORY) // Beginning Inventory
                {
                    return _unit.MasterExcelMappingRepo.GetMapping(4).ToList();
                }
                else if (typeId == HISTORY_MBR_TYPE.FEED_PURCHASE) // Feed Purchase
                {
                    return _unit.MasterExcelMappingRepo.GetMapping(5).ToList();
                }
                else if (typeId == HISTORY_MBR_TYPE.FEED_DATA) // Feed Info
                {
                    return _unit.MasterExcelMappingRepo.GetMapping(6).ToList();
                }
                else if (typeId == HISTORY_MBR_TYPE.SALE_VOLUME) // Sale Volume
                {
                    return _unit.MasterExcelMappingRepo.GetMapping(7).ToList();
                }

                return new List<MBR_MST_MASTER_EXCEL_MAPPING>();
            };

            var result = _unit.LogApiRepo.DownloadHistoryByInterfaceId(data.InterfaceId)
                .Select(s => new ResponseDownloadHistoryModel
                {
                    InterfaceId = s.InterfaceId,
                    UploadedData = JsonUtil.StringToJsonObject(s.CustomMessage),
                    ExcelMapping = null,
                    IsValidationSuccess = s.IsValidationSuccess,
                    TypeName = s.TypeName,
                    TypeId = s.TypeId,
                    ServicePath = s.ServicePath,
                    ErrorMessage = extractErrorMessage(JsonUtil.StringToJsonObject(s.ErrorMessage)),
                    Status = s.Status,
                    InboundDate = s.InboundDate
                })
                .FirstOrDefault();

            if (result != null)
            {
                result.ExcelMapping = result.TypeId <= 4 ? getMasterMapping(result.TypeId) : getExcelMapping(result.TypeId, result.ServicePath);
            }

            return result;
        }

        public List<DropdownModel> GetHistoryType()
        {
            List<DropdownModel> result = new List<DropdownModel>();
            var dataDB = _unit.MasterHistoryTypeRepo.GetAll().Select(s => new DropdownModel()
            {
                value = s.Id,
                text = s.Name,
            }).Distinct().ToList();

            dataDB.ForEach(s => result.Add(new DropdownModel()
            {
                value = s.value,
                text = s.text,
            }));

            return result;
        }
    }
}