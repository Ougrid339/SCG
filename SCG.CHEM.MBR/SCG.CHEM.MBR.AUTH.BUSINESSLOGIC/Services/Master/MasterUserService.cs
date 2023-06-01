using Microsoft.EntityFrameworkCore;
using SCG.CHEM.MBR.COMMON.AppException;
using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.MBR.COMMON.Utilities;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Common;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SCG.CHEM.MBR.COMMON.Constants.AppConstant;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Master;

namespace SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Master
{
    public class MasterUserService : IMasterUserService
    {
        #region Inject

        private readonly UnitOfWork _unit;

        public MasterUserService(UnitOfWork unitOfWork)
        {
            this._unit = unitOfWork;
        }

        #endregion Inject

        public void EditMasterUser(UserDetailModel userModel, AccountTokenModel currentUser)
        {
            var updateItem = _unit.MasterUserProfileRepo.FindOne(userModel.UserId);
            if (updateItem == null) throw new BusinessException("Couldn't find User to update.");

            userModel.UpdateBy = currentUser.UserId;
            updateItem.Update(userModel, currentUser.UserId);
            _unit.Save();
        }

        public void DeleteMasterUser(UserDetailModel userModel, AccountTokenModel currentUser)
        {
            var updateItem = _unit.MasterUserProfileRepo.FindOne(userModel.UserId);
            if (updateItem == null) throw new BusinessException("Couldn't find User to delete.");
            if (currentUser.UserId.ToLowerInvariant() == updateItem.UserId.ToLowerInvariant())
            {
                throw new UnauthorizedActionException("Unauthorized to update user profile ID: " + userModel.UserId);
            }

            updateItem.Delete(currentUser.UserId);
            _unit.Save();
        }

        public UserDetailModel GetUser(string userId, AccountTokenModel currentUser)
        {
            if (string.IsNullOrEmpty(userId)) throw new BusinessException("Unable to find user because userId is null or empty.");
            var dbUser = _unit.MasterUserProfileRepo.FindOne(userId);
            if (dbUser == null) throw new BusinessException($"Could not find user ID: {userId} .");
            if (dbUser.UserId != currentUser.UserId)
            {
                if (!currentUser.IsRole(ROLE.SYSTEM_ADMIN))
                {
                    throw new UnauthorizedActionException("Unauthorized to access user profile ID: " + userId);
                }
            }
            var result = SetupUserDetail(dbUser);
            if (currentUser.IsRole(ROLE.SYSTEM_ADMIN))
            {
                result.ShowActiveFlag = dbUser.UserId != currentUser.UserId;
            }
            else
            {
                result.ShowActiveFlag = false;
            }
            return result;
        }

        public UserDetailModel SetupUserDetail(MST_USER_PROFILE dbUser, bool isForLogin = true)
        {
            var result = new UserDetailModel(dbUser);

            return result;
        }

        public UserDetailModel CreateAndGetUser(string userId, string firstName, string lastName, string email, bool isForLogin = true)
        {
            var dbUser = _unit.MasterUserProfileRepo.FindOne(userId);
            if (dbUser == null)
            {
                if (string.IsNullOrEmpty(email)) email = userId;
                dbUser = MST_USER_PROFILE.Create(userId, firstName, lastName, email);
                _unit.MasterUserProfileRepo.Add(dbUser);
                _unit.Save();
            }
            else
            {
                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                {
                    if (firstName != dbUser.FirstName || lastName != dbUser.LastName)
                    {
                        dbUser.UpdateName(firstName, lastName);
                        _unit.Save();
                    }
                }
            }
            if (dbUser.DeleteFlag)
            {
                throw new UnauthorizedAccessException("User was inactive, Please contact Admin");
            }
            var result = SetupUserDetail(dbUser, isForLogin);

            return result;
        }
    }
}