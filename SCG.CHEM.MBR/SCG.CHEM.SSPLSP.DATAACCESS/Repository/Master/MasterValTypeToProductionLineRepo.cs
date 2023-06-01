using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterValTypeToProductionLineRepo : RepositoryBase<SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE>, IMasterValTypeToProductionLineRepo
    {
        #region Inject

        public MasterValTypeToProductionLineRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE GetByValuationTypeCode(string data)
        {
            var result = _context.SSP_MST_VAL_TYPE_TO_PRODUCTION_LINEs.Where(w => w.ValuationTypeCode == data).FirstOrDefault();
            return result;
        }

        public List<SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE> GetByValuationTypeCodes(List<string> data)
        {
            var result = _context.SSP_MST_VAL_TYPE_TO_PRODUCTION_LINEs.Where(w => data.Contains(w.ValuationTypeCode)).ToList();
            return result;
        }

        public SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE GetByProductionLineCode(string data)
        {
            var result = _context.SSP_MST_VAL_TYPE_TO_PRODUCTION_LINEs.Where(w => w.ProductionLineCode == data).FirstOrDefault();
            return result;
        }

        public List<SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE> GetByProductionLineCodes(List<string> data)
        {
            var result = _context.SSP_MST_VAL_TYPE_TO_PRODUCTION_LINEs.Where(w => data.Contains(w.ProductionLineCode)).ToList();
            return result;
        }

        public List<SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE> GetByCompanyCode(string data)
        {
            var result = _context.SSP_MST_VAL_TYPE_TO_PRODUCTION_LINEs.Where(w => w.CompanyCode == data).ToList();
            return result;
        }

        public List<SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE> GetByProductionLineCodesAndPlantCodes(List<string> lines, List<string> plants)
        {
            var result = _context.SSP_MST_VAL_TYPE_TO_PRODUCTION_LINEs.Where(w => lines.Contains(w.ProductionLineCode) && plants.Contains(w.SDPlantCode)).ToList();
            return result;
        }

        public List<SSP_MST_VAL_TYPE_TO_PRODUCTION_LINE> GetByCompanyCodes(List<string> company)
        {
            var result = _context.SSP_MST_VAL_TYPE_TO_PRODUCTION_LINEs.Where(w => company.Contains(w.CompanyCode)).ToList();
            return result;
        }
    }
}