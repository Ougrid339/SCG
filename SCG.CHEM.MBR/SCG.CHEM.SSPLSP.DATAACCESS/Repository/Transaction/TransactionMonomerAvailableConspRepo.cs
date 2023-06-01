using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Transaction
{
    public class TransactionMonomerAvailableConspRepo : RepositoryBase<SSP_TRN_MONOMER_AVAILABLE_CONSP>, ITransactionMonomerAvailableConspRepo
    {
        #region Inject

        public TransactionMonomerAvailableConspRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        //public List<SSP_TRN_MONOMER_AVAILABLE_CONSP> GetByKey(string versionName,string tier, int monomerType, string companyCode,string matCodeMst, string inputM1, string monthNo)
        //{
        //    var result = _context.SSP_TRN_MONOMER_AVAILABLE_CONSPs.Where(w => w.VersionName == versionName
        //                                                    && w.CompanyCode == companyCode
        //                                                    && w.MonomerType == monomerType
        //                                                    && w.MatCodeMst == matCodeMst
        //                                                    && w.InputM1 == inputM1
        //                                                    && w.MonthNo == monthNo
        //                                                    && w.Tier == tier).ToList();
        //    return result;
        //}

        public List<SSP_TRN_MONOMER_AVAILABLE_CONSP> GetByKeyWithoutDataPart(string versionName, string tier, int monomerType, int priceUnitId, string matCodeMst, string inputM1, string monthNo)
        {
            var result = _context.SSP_TRN_MONOMER_AVAILABLE_CONSPs.Where(w => w.VersionName == versionName
                                                            && w.PriceUnitId == priceUnitId
                                                            && w.MonomerType == monomerType
                                                            && w.MatCodeMst == matCodeMst
                                                            && w.InputM1 == inputM1
                                                            && w.MonthNo == monthNo
                                                            && w.Tier == tier).ToList();
            return result;
        }

        public List<MonomerAvailableConsModel> GetMonomerAvailable(string planType, string versionname, int monomerType)
        {
            var result = new List<MonomerAvailableConsModel>();
            result = (from MONO in _context.SSP_TRN_MONOMER_AVAILABLE_CONSPs
                      join MAT in _context.SSP_FCT_MATERIALs on MONO.MatCodeMst equals MAT.Material into mat_left
                      from MAT in mat_left.DefaultIfEmpty()
                      join UNIT in _context.SSP_MST_PRICE_UNITs on MONO.PriceUnitId equals UNIT.PriceUnitId into unit_left
                      from UNIT in unit_left.DefaultIfEmpty()
                      where MONO.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && MONO.MonomerType == monomerType && MONO.PlanType == planType && MONO.VersionName == versionname
                      group MONO by new
                      {
                          MONO.CompanyCode,
                          MONO.MatCodeMst,
                          MAT.Description,
                          MONO.DataPart,
                          MONO.Tier,
                          UNIT.PriceUnitDesc
                      } into FINAL
                      select new MonomerAvailableConsModel()
                      {
                          Company = FINAL.Key.CompanyCode,
                          MaterialCode = FINAL.Key.MatCodeMst,
                          MaterialName = FINAL.Key.Description,
                          DataPart = FINAL.Key.DataPart,
                          Tier = FINAL.Key.Tier,
                          Source = "Company",
                          Unit = FINAL.Key.PriceUnitDesc,
                          M1 = FINAL.Where(w => w.MonthIndex == "M1").FirstOrDefault().Qty,
                          M2 = FINAL.Where(w => w.MonthIndex == "M2").FirstOrDefault().Qty,
                          M3 = FINAL.Where(w => w.MonthIndex == "M3").FirstOrDefault().Qty,
                          M4 = FINAL.Where(w => w.MonthIndex == "M4").FirstOrDefault().Qty,
                          M5 = FINAL.Where(w => w.MonthIndex == "M5").FirstOrDefault().Qty,
                          M6 = FINAL.Where(w => w.MonthIndex == "M6").FirstOrDefault().Qty,
                          M7 = FINAL.Where(w => w.MonthIndex == "M7").FirstOrDefault().Qty,
                          M8 = FINAL.Where(w => w.MonthIndex == "M8").FirstOrDefault().Qty,
                          M9 = FINAL.Where(w => w.MonthIndex == "M9").FirstOrDefault().Qty,
                          M10 = FINAL.Where(w => w.MonthIndex == "M10").FirstOrDefault().Qty,
                          M11 = FINAL.Where(w => w.MonthIndex == "M11").FirstOrDefault().Qty,
                          M12 = FINAL.Where(w => w.MonthIndex == "M12").FirstOrDefault().Qty,
                          M13 = FINAL.Where(w => w.MonthIndex == "M13").FirstOrDefault().Qty,
                          M14 = FINAL.Where(w => w.MonthIndex == "M14").FirstOrDefault().Qty,
                          M15 = FINAL.Where(w => w.MonthIndex == "M15").FirstOrDefault().Qty,
                          M16 = FINAL.Where(w => w.MonthIndex == "M16").FirstOrDefault().Qty,
                          M17 = FINAL.Where(w => w.MonthIndex == "M17").FirstOrDefault().Qty,
                          M18 = FINAL.Where(w => w.MonthIndex == "M18").FirstOrDefault().Qty,
                          PriceM1 = FINAL.Where(w => w.MonthIndex == "M1").FirstOrDefault().Price,
                          PriceM2 = FINAL.Where(w => w.MonthIndex == "M2").FirstOrDefault().Price,
                          PriceM3 = FINAL.Where(w => w.MonthIndex == "M3").FirstOrDefault().Price,
                          PriceM4 = FINAL.Where(w => w.MonthIndex == "M4").FirstOrDefault().Price,
                          PriceM5 = FINAL.Where(w => w.MonthIndex == "M5").FirstOrDefault().Price,
                          PriceM6 = FINAL.Where(w => w.MonthIndex == "M6").FirstOrDefault().Price,
                          PriceM7 = FINAL.Where(w => w.MonthIndex == "M7").FirstOrDefault().Price,
                          PriceM8 = FINAL.Where(w => w.MonthIndex == "M8").FirstOrDefault().Price,
                          PriceM9 = FINAL.Where(w => w.MonthIndex == "M9").FirstOrDefault().Price,
                          PriceM10 = FINAL.Where(w => w.MonthIndex == "M10").FirstOrDefault().Price,
                          PriceM11 = FINAL.Where(w => w.MonthIndex == "M11").FirstOrDefault().Price,
                          PriceM12 = FINAL.Where(w => w.MonthIndex == "M12").FirstOrDefault().Price,
                          PriceM13 = FINAL.Where(w => w.MonthIndex == "M13").FirstOrDefault().Price,
                          PriceM14 = FINAL.Where(w => w.MonthIndex == "M14").FirstOrDefault().Price,
                          PriceM15 = FINAL.Where(w => w.MonthIndex == "M15").FirstOrDefault().Price,
                          PriceM16 = FINAL.Where(w => w.MonthIndex == "M16").FirstOrDefault().Price,
                          PriceM17 = FINAL.Where(w => w.MonthIndex == "M17").FirstOrDefault().Price,
                          PriceM18 = FINAL.Where(w => w.MonthIndex == "M18").FirstOrDefault().Price,
                      }).ToList();

            return result;
        }
    }
}