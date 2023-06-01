using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Common;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Logging;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Logging
{
    public class LogApiRepo : RepositoryBase<LOG_API>, ILogApiRepo
    {
        #region Inject

        public LogApiRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public LOG_API FindbyId(long id)
        {
            var result = _context.LOG_APIs.Where(w => w.InterfaceId == id).FirstOrDefault();
            return result;
        }

        public IQueryable<HistoryModel> GetHistory()
        {
            IQueryable<HistoryModel> subquery;

            subquery = from LOG in _context.LOG_APIs
                       where LOG.Type != null
                       orderby LOG.InboundTime descending
                       select new HistoryModel()
                       {
                           InterfaceId = LOG.InterfaceId,
                           TypeId = LOG.Type.Value, // TypeId Cannot Be Null!
                           PlanType = LOG.PlanType,
                           Cycle = LOG.Cycle,
                           Criteria = LOG.Criteria,
                           IsValidationSuccess = LOG.IsValidationSuccess,
                           UserAD = LOG.CreatedBy,
                           Status = LOG.InterfaceStatus != null ? LOG.InterfaceStatus.Value : null,
                           InboundDate = LOG.InboundTime,
                           OutboundDate = LOG.OutboundTime,
                           ServicePath = LOG.ServicePath
                       };

            IQueryable<HistoryModel> result = from SUB in subquery
                                              join TYPE in _context.SSP_MST_HISTORY_TYPEs on SUB.TypeId equals TYPE.Id
                                              select new HistoryModel()
                                              {
                                                  InterfaceId = SUB.InterfaceId,
                                                  TypeId = SUB.TypeId,
                                                  PlanType = SUB.PlanType,
                                                  Cycle = SUB.Cycle,
                                                  TypeName = TYPE.Name,
                                                  Criteria = SUB.Criteria,
                                                  IsValidationSuccess = SUB.IsValidationSuccess,
                                                  UserAD = SUB.UserAD,
                                                  Status = SUB.Status,
                                                  InboundDate = SUB.InboundDate,
                                                  OutboundDate = SUB.OutboundDate,
                                                  ServicePath = SUB.ServicePath
                                              };
            return result;
        }

        public IQueryable<HistoryModel> DownloadHistoryByInterfaceId(long interfaceId)
        {
            IQueryable<HistoryModel> query =
                from LOG in _context.LOG_APIs
                where LOG.InterfaceId == interfaceId
                join TYPE in _context.SSP_MST_HISTORY_TYPEs on LOG.Type equals TYPE.Id
                select new HistoryModel()
                {
                    InterfaceId = LOG.InterfaceId,
                    CustomMessage = LOG.CustomMessage,
                    IsValidationSuccess = LOG.IsValidationSuccess,
                    TypeName = TYPE.Name,
                    TypeId = TYPE.Id,
                    ServicePath = LOG.ServicePath,
                    ErrorMessage = LOG.ErrorMessage,
                    Status = LOG.InterfaceStatus,
                    InboundDate = LOG.InboundTime
                };
            return query;
        }
    }
}