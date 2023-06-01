using Microsoft.EntityFrameworkCore;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Account;
using SCG.CHEM.SSPLSP.DATAACCESS.AppModels.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master;
using SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Master
{
    public class MasterUserProfileRepo : RepositoryBase<MST_USER_PROFILE>, IMasterUserProfileRepo
    {
        #region Inject

        public MasterUserProfileRepo(EntitiesContext context, EntitiesReadContext readConext) : base(context, readConext)
        {
        }

        #endregion Inject

        public MST_USER_PROFILE FindOne(string userId)
        {
            return _context.MST_USER_PROFILEs.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public AccountTokenModel GetUserAccountTokenModel(string userId)
        {
            var dbUser = _readContext.MST_USER_PROFILEs.Where(x => x.UserId == userId).FirstOrDefault();
            var tokenModel = new AccountTokenModel()
            {
                UserId = dbUser.UserId,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                Email = dbUser.Email
            };
            return tokenModel;
        }

        public List<MST_USER_PROFILE> FindById(params string[] userId)
        {
            return _context.MST_USER_PROFILEs.Where(x => userId.Contains(x.UserId)).ToList();
        }

        public List<MST_USER_PROFILE> FindAll()
        {
            return _context.MST_USER_PROFILEs.ToList();
        }
    }
}