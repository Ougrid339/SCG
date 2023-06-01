using Microsoft.EntityFrameworkCore;
using SCG.CHEM.MBR.COMMON.AppException;
using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SCG.CHEM.MBR.COMMON.Constants.AppConstant;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Master;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Relate;
using SCG.CHEM.MBR.DATAACCESS.Entities.Relate;

namespace SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Authorization
{
    public class AuthService : IAuthService
    {
        #region Inject

        private readonly UnitOfWork _unit;

        public AuthService(UnitOfWork unitOfWork)
        {
            this._unit = unitOfWork;
        }

        #endregion Inject

        public List<RoleSearchResModel> FindRole(RoleSearchReqModel searchReqModel)
        {
            var dbModel = _unit.MasterRoleRepo.Find(searchReqModel);
            var result = (from x in dbModel
                          select new RoleSearchResModel(x)).ToList();

            return result;
        }

        public List<GroupSearchResModel> FindGroup(GroupSearchReqModel searchReqModel)
        {
            var dbModel = _unit.MasterGroupRepo.Find(searchReqModel);
            var result = (from x in dbModel
                          select new GroupSearchResModel(x)).ToList();

            return result;
        }

        public ResponseModel AddGroupRole(GroupRoleModel req)
        {
            CheckDuplicateGroupRole(req);
            ResponseModel res = new ResponseModel();
            var dbModel = new REL_GROUP_ROLE(req);

            _unit.GroupRoleRepo.Add(dbModel);
            _unit.Save();

            res.Data = "The Group-Role was successfully created.";
            res.IsSuccess = true;

            return res;
        }

        public ResponseModel DeleteGroupRole(GroupRoleModel req)
        {
            var dbModel = _unit.GroupRoleRepo.FindByKey(req);

            if (dbModel == null)
            {
                string msg = "Record is not found.";
                throw new BusinessException(msg);
            }

            ResponseModel res = new ResponseModel();

            _unit.GroupRoleRepo.Delete(dbModel);
            _unit.Save();

            res.Data = "The Group-Role was successfully deleted.";
            res.IsSuccess = true;

            return res;
        }

        #region Private method

        private void CheckDuplicateGroupRole(GroupRoleModel req, bool isUpdate = false)
        {
            bool isExist = _unit.GroupRoleRepo.IsExist(req);
            string msg = isUpdate ? "The Group-Role could not be updated due to duplicate data."
                                  : "The Group-Role could not be added due to duplicate data.";

            if (isExist)
            {
                throw new BusinessWarning(msg);
            }
        }

        #endregion Private method
    }
}