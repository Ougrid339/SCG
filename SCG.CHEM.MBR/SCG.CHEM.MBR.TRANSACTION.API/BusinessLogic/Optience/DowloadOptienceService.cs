using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS;
using SCG.CHEM.MBR.DATAACCESS.Entities.Transaction;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.MarketPriceForecast;
using SCG.CHEM.MBR.TRANSACTION.API.AppModels.Optience;
using SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience.Interface;
using System.Reflection;
using static SCG.CHEM.MBR.DATAACCESS.APPCONSTANT;

namespace SCG.CHEM.MBR.TRANSACTION.API.BusinessLogic.Optience
{
    public class DowloadOptienceService : IDowloadOptienceService
    {
        private readonly UnitOfWork _unit;

        public DowloadOptienceService(UnitOfWork unitOfWork)
        {
            this._unit = unitOfWork;
        }

        public List<OptienceDownloadResponse> DowloadOptience(OptienceDownloadRequest param)
        {
            var result = new List<OptienceDownloadResponse>();
            if (param.Company == null || param.Company.Count == 0)
            {
                param.Company = _unit.MasterCompanyRepo.GetCompany().Where(w => w.text != APPCONSTANT.DROPDOWN.ALL).Select(s => s.text).ToList();
            }
            foreach (var OptienceTypeId in param.OptienceTypeId)
            {
                if (OptienceTypeId == 2)
                    result.Add(ProductionVolumeResponse(param, OptienceTypeId));
                else if (OptienceTypeId == 3)
                    result.Add(FeedConsumptionResponse(param, OptienceTypeId));
                else if (OptienceTypeId == 4)
                    result.Add(BeginningInventoryResponse(param, OptienceTypeId));
                else if (OptienceTypeId == 5)
                    result.Add(FeedPurchaseResponse(param, OptienceTypeId));
            }
            return result;
        }

        public OptienceDownloadResponse ProductionVolumeResponse(OptienceDownloadRequest param, int OptienceTypeId)
        {
            var oResult = new OptienceDownloadResponse()
            {
                OptienceTypeId = OptienceTypeId,
                OptienceMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId, false)
            };
            List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();

            var result = new List<ProductionVolumeModelResponse>();
            var Repo = _unit.ProductionVolumeRepo.FindByCriterias(param.Scenario, param.Case, param.Cycle);
            var excelMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId).OrderBy(o => o.Sequence).ToList();
            var filteredCompany = Repo.Where(o => param.Company.Contains(o.Company));
            var Groups = filteredCompany.GroupBy(g => new { g.ProductName, g.Company }).ToList();
            foreach (var data in Groups)
            {
                var mapData = new ProductionVolumeModelResponse();
                //foreach (var item in group)
                //{
                //    PropertyInfo prop = mapData.GetType().GetProperty(item.MonthIndex, BindingFlags.Public | BindingFlags.Instance);
                //    if (null != prop && prop.CanWrite)
                //    {
                //        prop.SetValue(mapData, item.Price, null);
                //    }
                //}

                mapData.HeaderList = (from g in data
                                      select new HeaderListItem()
                                      {
                                          Cycle = String.IsNullOrEmpty(g.MergedWithCycle) ? g.Cycle : g.MergedWithCycle,
                                          MonthNo = g.MonthNo,
                                          Header = excelMapping.Where(x => x.ExcelHeader == g.MonthIndex).Select(s => s.Variable).FirstOrDefault() ?? g.MonthIndex?.ToLower(),
                                          Value = g.Price
                                      }
                                    ).ToList();

                foreach (var monthIndex in monthIndexs)
                {
                    if (mapData.HeaderList.FirstOrDefault(f => f.Header.ToUpper() == monthIndex) == null)
                    {
                        var monthNo = ConverseMonthNo(param.Scenario, monthIndex, param.Cycle);
                        mapData.HeaderList.Add(new HeaderListItem
                        {
                            Cycle = null,
                            MonthNo = monthNo,
                            Header = monthIndex.ToLower(),
                            Value = null
                        });
                    }
                }
                var lastUpdate = data.OrderByDescending(b => b.UpdatedDate).FirstOrDefault();

                mapData.Company = lastUpdate?.Company;
                mapData.MCSC = lastUpdate?.MCSC;
                mapData.ProductName = lastUpdate?.ProductName;
                mapData.ProductShortName = lastUpdate?.ProductShortName;
                mapData.ElementCode = lastUpdate?.ElementCodeEBA;
                mapData.MaterialCode = lastUpdate?.MaterialCode;

                if (lastUpdate.UpdatedDate != null)
                {
                    mapData.UpdatedBy = lastUpdate.UpdatedBy;
                    mapData.UpdatedDate = lastUpdate.UpdatedDate.HasValue ? lastUpdate?.UpdatedDate : null;
                }
                else
                {
                    var lastCreate = data.OrderByDescending(b => b.CreatedDate).FirstOrDefault();
                    mapData.UpdatedBy = lastCreate.CreatedBy;
                    mapData.UpdatedDate = lastCreate.CreatedDate;
                }
                result.Add(mapData);
            }
            oResult.OptienceData = result;
            return oResult;
        }

        public OptienceDownloadResponse FeedConsumptionResponse(OptienceDownloadRequest param, int OptienceTypeId)
        {
            var oResult = new OptienceDownloadResponse()
            {
                OptienceTypeId = OptienceTypeId,
                OptienceMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId, false)
            };
            List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();

            var result = new List<FeedConsumptionModelResponse>();
            var Repo = _unit.FeedConsumptionRepo.FindByCriterias(param.Scenario, param.Case, param.Cycle);
            var excelMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId).OrderBy(o => o.Sequence).ToList();
            var filteredCompany = Repo.Where(o => param.Company.Contains(o.Company));
            //var Groups = filteredCompany.GroupBy(g => new { g.FeedName, g.Company }).ToList();
            var Groups = filteredCompany.GroupBy(g => new { g.FeedName, g.Company }).ToList();
            foreach (var data in Groups)
            {
                var mapData = new FeedConsumptionModelResponse();
                //foreach (var item in group)
                //{
                //    PropertyInfo prop = mapData.GetType().GetProperty(item.MonthIndex, BindingFlags.Public | BindingFlags.Instance);
                //    if (null != prop && prop.CanWrite)
                //    {
                //        prop.SetValue(mapData, item.Price, null);
                //    }
                //}

                mapData.HeaderList = (from g in data
                                      select new HeaderListItem()
                                      {
                                          Cycle = String.IsNullOrEmpty(g.MergedWithCycle) ? g.Cycle : g.MergedWithCycle,
                                          MonthNo = g.MonthNo,
                                          Header = excelMapping.Where(x => x.ExcelHeader == g.MonthIndex).Select(s => s.Variable).FirstOrDefault() ?? g.MonthIndex?.ToLower(),
                                          Value = g.Price
                                      }
                                     ).ToList();
                foreach (var monthIndex in monthIndexs)
                {
                    if (mapData.HeaderList.FirstOrDefault(f => f.Header.ToUpper() == monthIndex) == null)
                    {
                        var monthNo = ConverseMonthNo(param.Scenario, monthIndex, param.Cycle);
                        mapData.HeaderList.Add(new HeaderListItem
                        {
                            Cycle = null,
                            MonthNo = monthNo,
                            Header = monthIndex.ToLower(),
                            Value = null
                        });
                    }
                }
                var lastUpdate = data.OrderByDescending(b => b.UpdatedDate).FirstOrDefault();

                mapData.Company = lastUpdate?.Company;
                mapData.MCSC = lastUpdate?.MCSC;
                mapData.FeedName = lastUpdate?.FeedName;
                mapData.FeedShortName = lastUpdate?.FeedShortName;
                mapData.SupplierKey = lastUpdate?.SupplierKey;
                mapData.SupplierCode = lastUpdate?.SupplierCode;
                mapData.ElementCode = lastUpdate?.ElementCodeEBA;
                mapData.MaterialCode = lastUpdate?.MaterialCode;

                if (lastUpdate.UpdatedDate != null)
                {
                    mapData.UpdatedBy = lastUpdate.UpdatedBy;
                    mapData.UpdatedDate = lastUpdate.UpdatedDate.HasValue ? lastUpdate?.UpdatedDate : null;
                }
                else
                {
                    var lastCreate = data.OrderByDescending(b => b.CreatedDate).FirstOrDefault();
                    mapData.UpdatedBy = lastCreate.CreatedBy;
                    mapData.UpdatedDate = lastCreate.CreatedDate;
                }
                result.Add(mapData);
            }
            oResult.OptienceData = result;
            return oResult;
        }

        public OptienceDownloadResponse BeginningInventoryResponse(OptienceDownloadRequest param, int OptienceTypeId)
        {
            var oResult = new OptienceDownloadResponse()
            {
                OptienceTypeId = OptienceTypeId,
                OptienceMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId, false)
            };

            var result = new List<BeginningInventoryModelResponse>();
            var Repo = _unit.BeginningInventoryRepo.FindByCriterias(param.Scenario, param.Case, param.Cycle);
            var excelMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId).OrderBy(o => o.Sequence).ToList();
            var filteredCompany = Repo.Where(o => param.Company.Contains(o.Company));
            //var Groups = filteredCompany.GroupBy(g => g.Company).ToList();
            var Groups = filteredCompany.GroupBy(g => new { g.MCSC, g.ProductShortName, g.MaterialCode, g.SupplierKey, g.Company }).ToList();
            foreach (var data in Groups)
            {
                var mapData = new BeginningInventoryModelResponse();
                //foreach (var item in group)
                //{
                //    PropertyInfo prop = mapData.GetType().GetProperty(item.MonthIndex, BindingFlags.Public | BindingFlags.Instance);
                //    if (null != prop && prop.CanWrite)
                //    {
                //        prop.SetValue(mapData, item.Price, null);
                //    }
                //}

                mapData.HeaderList = (from g in data
                                      select new HeaderListItem()
                                      {
                                          Cycle = g.Cycle,
                                          MonthNo = g.MonthNo,
                                          Header = excelMapping.Where(x => x.ExcelHeader == g.MonthIndex).Select(s => s.Variable).FirstOrDefault() ?? g.MonthIndex?.ToLower(),
                                          Value = g.Price
                                      }
                                     ).ToList();

                var lastUpdate = data.OrderByDescending(b => b.UpdatedDate).FirstOrDefault();

                mapData.Company = lastUpdate.Company;
                mapData.MCSC = lastUpdate.MCSC;
                mapData.InventoryName = lastUpdate.InventoryName;
                mapData.TankNumber = lastUpdate.TankNumber;
                mapData.ProductShortName = lastUpdate.ProductShortName;
                mapData.MaterialCode = lastUpdate.MaterialCode;
                mapData.SupplierKey = lastUpdate.SupplierKey;
                mapData.SupplierCode = lastUpdate.SupplierCode;
                mapData.ElementCode = lastUpdate.ElementCodeEBA;

                if (lastUpdate.UpdatedDate != null)
                {
                    mapData.UpdatedBy = lastUpdate.UpdatedBy;
                    mapData.UpdatedDate = lastUpdate.UpdatedDate.HasValue ? lastUpdate?.UpdatedDate : null;
                }
                else
                {
                    var lastCreate = data.OrderByDescending(b => b.CreatedDate).FirstOrDefault();
                    mapData.UpdatedBy = lastCreate.CreatedBy;
                    mapData.UpdatedDate = lastCreate.CreatedDate;
                }
                result.Add(mapData);
            }
            oResult.OptienceData = result;
            return oResult;
        }

        public OptienceDownloadResponse FeedPurchaseResponse(OptienceDownloadRequest param, int OptienceTypeId)
        {
            var oResult = new OptienceDownloadResponse()
            {
                OptienceTypeId = OptienceTypeId,
                OptienceMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId, false)
            };
            List<string> monthIndexs = Enum.GetValues(typeof(MONTH_INDEX)).Cast<MONTH_INDEX>().Select(v => v.ToString()).ToList();

            var result = new List<FeedPurchaseModelResponse>();
            var Repo = _unit.FeedPurchaseRepo.FindByCriteria(param.Scenario, param.Case, param.Cycle);
            var excelMapping = _unit.MasterExcelMappingRepo.GetMapping(OptienceTypeId).OrderBy(o => o.Sequence).ToList();
            var filteredCompany = Repo.Where(o => param.Company.Contains(o.Company));
            var Groups = filteredCompany.GroupBy(g => new { g.FeedName, g.Company }).ToList();
            foreach (var data in Groups)
            {
                var mapData = new FeedPurchaseModelResponse();
                //foreach (var item in group)
                //{
                //    PropertyInfo prop = mapData.GetType().GetProperty(item.MonthIndex, BindingFlags.Public | BindingFlags.Instance);
                //    if (null != prop && prop.CanWrite)
                //    {
                //        prop.SetValue(mapData, item.Price, null);
                //    }
                //}

                mapData.HeaderList = (from g in data
                                      select new HeaderListItem()
                                      {
                                          Cycle = g.Cycle,
                                          MonthNo = g.MonthNo,
                                          Header = excelMapping.Where(x => x.ExcelHeader == g.MonthIndex).Select(s => s.Variable).FirstOrDefault() ?? g.MonthIndex?.ToLower(),
                                          Value = g.Price
                                      }
                                     ).ToList();
                foreach (var monthIndex in monthIndexs)
                {
                    if (mapData.HeaderList.FirstOrDefault(f => f.Header.ToUpper() == monthIndex) == null)
                    {
                        var monthNo = ConverseMonthNo(param.Scenario, monthIndex, param.Cycle);
                        mapData.HeaderList.Add(new HeaderListItem
                        {
                            Cycle = null,
                            MonthNo = monthNo,
                            Header = monthIndex.ToLower(),
                            Value = null
                        });
                    }
                }
                var lastUpdate = data.OrderByDescending(b => b.UpdatedDate).FirstOrDefault();

                mapData.Company = lastUpdate?.Company;
                mapData.MCSC = lastUpdate?.MCSC;
                mapData.FeedName = lastUpdate?.FeedName;
                mapData.FeedShortName = lastUpdate?.FeedShortName;
                mapData.SupplierKey = lastUpdate?.SupplierKey;
                mapData.SupplierCode = lastUpdate?.SupplierCode;
                mapData.ElementCode = lastUpdate?.ElementCodeEBA;
                mapData.MaterialCode = lastUpdate?.MaterialCode;

                if (lastUpdate.UpdatedDate != null)
                {
                    mapData.UpdatedBy = lastUpdate.UpdatedBy;
                    mapData.UpdatedDate = lastUpdate.UpdatedDate.HasValue ? lastUpdate?.UpdatedDate : null;
                }
                else
                {
                    var lastCreate = data.OrderByDescending(b => b.CreatedDate).FirstOrDefault();
                    mapData.UpdatedBy = lastCreate.CreatedBy;
                    mapData.UpdatedDate = lastCreate.CreatedDate;
                }
                result.Add(mapData);
            }
            oResult.OptienceData = result;
            return oResult;
        }

        private string ConverseMonthNo(string scenario, string monthIndex, string cycle)
        {
            var format = "{0}-{1}";
            var month = int.Parse(monthIndex.Substring(1));
            cycle = cycle.Substring(cycle.IndexOf("_") + 1);
            if (scenario == SCENATIO.M18 || scenario == SCENATIO.W1 || scenario == SCENATIO.W3 || scenario.ToUpper() == SCENATIO.WEEKLY.ToUpper())
            {
                var now = new DateTime(int.Parse(cycle.Substring(0, 4)), int.Parse(cycle.Split("-")[1]), 1);
                var date = now.AddMonths(month);
                return string.Format(format, date.Year, date.Month.ToString("00"));
            }
            else if (scenario.ToUpper() == SCENATIO.OPPLAN.ToUpper())
            {
                var now = new DateTime(int.Parse(cycle.Substring(0, 4)), 1, 1);
                var date = now.AddMonths(month);
                return string.Format(format, date.Year, date.Month.ToString("00"));
            }
            else if (scenario.ToUpper() == SCENATIO.MTP.ToUpper())
            {
                var now = new DateTime(int.Parse(cycle.Substring(0, 4)), 1, 1);
                var date = now.AddYears(month);
                return string.Format(format, date.Year, date.Month.ToString("00"));
            }

            return null;
        }
    }
}