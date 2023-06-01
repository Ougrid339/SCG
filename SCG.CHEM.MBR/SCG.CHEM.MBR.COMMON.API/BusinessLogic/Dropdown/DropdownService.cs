using SCG.CHEM.MBR.COMMON.API.AppModels.HistoryType;
using SCG.CHEM.MBR.COMMON.API.BusinessLogic.Dropdown.Interfaces;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SSPUnitOfWork = SCG.CHEM.SSPLSP.DATAACCESS.UnitOfWork.UnitOfWork;

namespace SCG.CHEM.MBR.COMMON.API.BusinessLogic.Dropdown
{
    public class DropdownService : IDropdownService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly SSPUnitOfWork _sspUnitOfWork;

        #region Injection
        public DropdownService(UnitOfWork unitOfWork, SSPUnitOfWork sspUnitOfWork)
        {
            _unitOfWork = unitOfWork;
            _sspUnitOfWork = sspUnitOfWork;
        }
        #endregion

        public List<DropdownModel> GetCase()
        {
            var result = _sspUnitOfWork.MasterRevisionRepo.GetAll().Select(x => new DropdownModel()
            {
                value = x.RevisionId,
                text = x.OleRevisionDesc
            }).ToList();
            return result;
        }

        public List<DropdownModel> GetScenario()
        {
            var result = _unitOfWork.MasterPlanTypeRepo.GetPlanType().Select(x => new DropdownModel()
            {
                value = x.PlanTypeId,
                text = x.PlanTypeName
            }).ToList();
            return result;
        }

        public List<DropdownModel> GetScenarioWithActual()
        {
            var result = _unitOfWork.MasterPlanTypeRepo.GetPlanTypeWithActual().Select(x => new DropdownModel()
            {
                value = x.PlanTypeId,
                text = x.PlanTypeName
            }).ToList();
            return result;
        }

        public MarketPriceForecastMergeScenarioModel GetMergeScenarioMarketPriceForecast()
        {
            return _unitOfWork.MarketPriceForecastRepo.GetMergeScenario();
        }
        public OptienceMergeScenarioModel GetMergeScenarioOptience()
        {
            List<OptienceMergeScenario> scenario = new List<OptienceMergeScenario>();
            scenario.AddRange(_unitOfWork.ProductionVolumeRepo.GetMergeScenario());
            scenario.AddRange(_unitOfWork.FeedConsumptionRepo.GetMergeScenario());
            scenario.AddRange(_unitOfWork.BeginningInventoryRepo.GetMergeScenario());
            scenario.AddRange(_unitOfWork.FeedPurchaseRepo.GetMergeScenario());
            OptienceMergeScenarioModel optienceModel = new OptienceMergeScenarioModel()
            {
                Available = scenario
            };
            return optienceModel;
        }
        public FeedInfoMergeScenarioModel GetMergeScenarioFeedInfo()
        {
            return _unitOfWork.FeedInfoRepo.GetMergeScenario();
        }
        public SalesMergeScenarioModel GetMergeScenarioSales()
        {
            return _unitOfWork.SalesVoiumeRepo.GetMergeScenario();
        }
        public List<DropdownModel> GetOptienceType()
        {
            var result = _unitOfWork.MasterOptienceTypeRepo.GetOptienceType().Select(x => new DropdownModel()
            {
                value = x.ExcelId,
                text = x.MasterName
            }).ToList();
            return result;
        }
        public List<DropdownModel> GetOptienceTypeByToken()
        {
            var result = new List<DropdownModel>();
            var username = UserUtilities.GetADAccount()?.UserId ?? "";
            var userDB = _unitOfWork.MasterUsersRepo.GetAll().Where(w => w.Username == username && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).FirstOrDefault();
            if (userDB is not null)
            {
                var roleLs = _unitOfWork.MasterRoleRepo.GetAll().Where(w => userDB.Roles.Split(",").ToList().Contains(w.Id.ToString())).ToList();
                List<string> optienceLs = new List<string>();
                foreach (var role in roleLs)
                {
                    var optienceDB = role.AvailableOptience.Split(",").Where(w => w != "");
                    optienceLs = optienceLs.Union(optienceDB).ToList();
                }
                var optienceType = _unitOfWork.MasterOptienceRepo.GetAll();
                if (!optienceLs.Contains(APPCONSTANT.DROPDOWN.ALL))
                {
                    optienceType = optienceType.Where(x => optienceLs.Contains(x.ExcelId.ToString())).ToList();
                }
                result = optienceType.Select(x => new DropdownModel()
                {
                    value = x.ExcelId,
                    text = x.OptienceName
                }).OrderBy(o => o.value).ToList();
            }
            return result;
        }
        public List<DropdownModel> GetCompany()
        {
            return _unitOfWork.MasterCompanyRepo.GetCompany();
        }
        public List<DropdownModel> GetCompanyByToken()
        {
            var result = new List<DropdownModel>();
            var username = UserUtilities.GetADAccount()?.UserId ?? "";
            var userDB = _unitOfWork.MasterUsersRepo.GetAll().Where(w => w.Username == username && w.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES).FirstOrDefault();
            if (userDB is not null)
            {
                var roleLs = _unitOfWork.MasterRoleRepo.GetAll().Where(w => userDB.Roles.Split(",").ToList().Contains(w.Id.ToString())).ToList();
                List<string> companyLs = new List<string>();
                foreach (var role in roleLs)
                {
                    var companyDB = role.AvailableCompany.Split(",").Where(w => w != "");
                    companyLs = companyLs.Union(companyDB).ToList();
                }
                result = _unitOfWork.MasterCompanyRepo.GetCompany();
                if (!companyLs.Contains(APPCONSTANT.DROPDOWN.ALL))
                {
                    result = result.Where(x => companyLs.Contains(x.value)).ToList();
                }
            }
            return result;
        }
        public List<DropdownModel> GetHistoryGroup()
        {
            var result = _unitOfWork.MasterHistoryTypeRepo.GetAll().OrderBy(s => s.Id)
                                .DistinctBy(s => s.Description)
                                .Select((s, i) => new DropdownModel { text = s.Description, value = i + 1 }).ToList();
            return result;
        }
        public List<HistoryTypeResponse> GetHistoryType()
        {
            var allHistoryType = _unitOfWork.MasterHistoryTypeRepo.GetAll().ToList();
            var historyGroup = allHistoryType
                                .OrderBy(s => s.Id)
                                .DistinctBy(s => s.Description)
                                .Select((s, i) => new { Description = s.Description, Group = i + 1 }).ToList();
            var result = allHistoryType
                        .OrderBy(s => s.Id)
                        .Select(s => new HistoryTypeResponse
                        {
                            Id = s.Id,
                            Name = s.Name,
                            MasterId = s.MasterId,
                            ExcelId = s.ExcelId,
                            Description = s.Description,
                            Group = historyGroup.FirstOrDefault(h => h.Description == s.Description)?.Group
                        }).ToList();
            return result;
        }
        public List<DropdownModel> GetFeedNameKey()
        {
            var result = _unitOfWork.MasterTempProductMappingRepo.GetAll()
                            .Where(m => m.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
                            .DistinctBy(m => m.ProductShortName)
                            .Select(m => new DropdownModel
                            {
                                text = m.ProductShortName,
                                value = m.ProductShortName
                            }).ToList();
            // Add ALL dropdown
            result.Insert(0, new DropdownModel
            {
                text = APPCONSTANT.DROPDOWN.ALL,
                value = APPCONSTANT.DROPDOWN.ALL
            });
            return result;
        }
        public List<DropdownModel> GetProductGroup()
        {
            var result = _unitOfWork.MasterTempProductMappingRepo.GetAll()
                            .Where(m => m.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
                            .DistinctBy(m => m.ProductGroup)
                            .Select(m => new DropdownModel
                            {
                                text = m.ProductGroup,
                                value = m.ProductGroup
                            }).ToList();

            // Add ALL dropdown
            result.Insert(0, new DropdownModel
            {
                text = APPCONSTANT.DROPDOWN.ALL,
                value = APPCONSTANT.DROPDOWN.ALL
            });
            return result;
        }
        public List<DropdownModel> GetProduct()
        {
            var result = _unitOfWork.MasterTempProductMappingRepo.GetAll()
                            .Where(m => m.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
                            .DistinctBy(m => m.ProductShortName)
                            .Select(m => new DropdownModel
                            {
                                text = m.ProductShortName,
                                value = m.ProductShortName
                            }).ToList();
            // Add ALL dropdown
            result.Insert(0, new DropdownModel
            {
                text = APPCONSTANT.DROPDOWN.ALL,
                value = APPCONSTANT.DROPDOWN.ALL
            });
            return result;
        }
        public List<DropdownModel> GetFeedGeoCategoryKey()
        {
            return new List<DropdownModel>()
            {
                new DropdownModel { text = APPCONSTANT.DROPDOWN.ALL, value = APPCONSTANT.DROPDOWN.ALL },
                new DropdownModel { text = APPCONSTANT.FEED_GEO_CATEGORY_KEY.DOM, value = APPCONSTANT.FEED_GEO_CATEGORY_KEY.DOM },
                new DropdownModel { text = APPCONSTANT.FEED_GEO_CATEGORY_KEY.IMP, value = APPCONSTANT.FEED_GEO_CATEGORY_KEY.IMP }
            };
        }
        public List<DropdownModel> GetChannel()
        {
            return new List<DropdownModel>()
            {
                new DropdownModel { text = APPCONSTANT.DROPDOWN.ALL, value = APPCONSTANT.DROPDOWN.ALL },
                new DropdownModel { text = APPCONSTANT.CHANNEL.DOM, value = APPCONSTANT.CHANNEL.DOM },
                new DropdownModel { text = APPCONSTANT.CHANNEL.EXP, value = APPCONSTANT.CHANNEL.EXP }
            };
        }
        public List<DropdownModel> GetUserAD()
        {
            return _unitOfWork.MasterUsersRepo.GetAll().Select(s => new DropdownModel { value = s.Id, text = s.Username }).ToList();
        }

    }
}
