using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Temp
{
    public class MasterTempAdditionalByGradePackRepo : RepositoryBase<SSP_TMP_ADDITIONAL_BY_GRADEPACK>, IMasterTempAdditionalByGradePackRepo
    {
        #region Inject

        public MasterTempAdditionalByGradePackRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_TMP_ADDITIONAL_BY_GRADEPACK> GetByKey(string productionSite, string plantType, string matPrefix, string grade, string package, string channelGroup, decimal deliveryCostByGrade, string startMonth)
        {
            var result = _context.SSP_TMP_ADDITIONAL_BY_GRADEPACKs.Where(s => s.ProductionSite == productionSite && s.PlanType == plantType && s.MatPrefix == matPrefix && s.Grade == grade
                        && s.Package == package && s.ChannelGroup == channelGroup && s.DeliveryCostByGrade == deliveryCostByGrade && s.StartMonth == startMonth).ToList();
            return result;
        }

        public void Truncate()
        {
            var data = _context.SSP_TMP_ADDITIONAL_BY_GRADEPACKs.ToList();
            _context.RemoveRange(data);
        }
    }
}