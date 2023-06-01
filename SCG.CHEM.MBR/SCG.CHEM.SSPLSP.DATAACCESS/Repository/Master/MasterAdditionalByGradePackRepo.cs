using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Template;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterAdditionalByGradePackRepo : RepositoryBase<SSP_MST_ADDITIONAL_BY_GRADEPACK>, IMasterAdditionalByGradePackRepo
    {
        #region Inject

        public MasterAdditionalByGradePackRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public List<SSP_MST_ADDITIONAL_BY_GRADEPACK> GetByKey(string productionSite, string plantType, string matPrefix, string grade, string package, string channelGroup, decimal deliveryCostByGrade, string startMonth)
        {
            var result = _context.SSP_MST_ADDITIONAL_BY_GRADEPACKs.Where(s => s.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES && s.ProductionSite == productionSite && s.PlanType == plantType && s.MatPrefix == matPrefix && s.Grade == grade
                        && s.Package == package && s.ChannelGroup == channelGroup && s.DeliveryCostByGrade == deliveryCostByGrade && s.StartMonth == startMonth).ToList();
            return result;
        }

        public List<SSP_MST_ADDITIONAL_BY_GRADEPACK> GetAllByKeyAndVersion(string productionSite, string plantType, string matPrefix, string grade, string package, string channelGroup, decimal deliveryCostByGrade, string startMonth, int versionNo)
        {
            var result = _context.SSP_MST_ADDITIONAL_BY_GRADEPACKs.Where(s => s.VersionNo == versionNo && s.ProductionSite == productionSite && s.PlanType == plantType && s.MatPrefix == matPrefix && s.Grade == grade
                        && s.Package == package && s.ChannelGroup == channelGroup && s.DeliveryCostByGrade == deliveryCostByGrade && s.StartMonth == startMonth).ToList();
            return result;
        }
    }
}