using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Account.Interface;
using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Master;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Account;
using SCG.CHEM.MBR.DATAACCESS.Entities.Master;
using SCG.CHEM.MBR.DATAACCESS.UnitOfWork;

using SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Master;

using System.Collections.Generic;
using System.Linq;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Master;
using SCG.CHEM.MBR.DATAACCESS.AppModels.Relate;
using SCG.CHEM.MBR.COMMON.AppModels.Account;

namespace SCG.CHEM.MBR.AUTH.BUSINESSLOGIC.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UnitOfWork _unit;
        private readonly IMasterUserService _masterUserService;

        public AccountService(IMasterUserService masterUserService, UnitOfWork unit)
        {
            _masterUserService = masterUserService;
            _unit = unit;
        }

        public AccountLoggedInResModel GetAccount(SCG.CHEM.MBR.DATAACCESS.AppModels.Account.AccountLoggedInReqModel req, MST_USER_PROFILE dbUser = null, bool isForLogin = true)
        {
            req.UserId = req.UserId?.ToLower();

            var res = new AccountLoggedInResModel();
            //user
            res.UserDetail = dbUser != null
                        ? _masterUserService.SetupUserDetail(dbUser, isForLogin)
                        : _masterUserService.CreateAndGetUser(req.UserId, req.FirstName, req.LastName, req.Email, isForLogin);

            //Role
            UserGroupSearchReqModel criteria = new UserGroupSearchReqModel();
            criteria.UserId = req.UserId;
            var groups = _unit.UserGroupRepo.Find(criteria).ToList();
            var allGroupRole = _unit.GroupRoleRepo.FindAll().ToList();
            List<short> allRoles = new List<short>();
            foreach (var group in groups)
            {
                var groupId = group.GroupId;
                var allRolesInGroup = (from groupRole in allGroupRole
                                       where groupRole.GroupId == groupId
                                       select groupRole.RoleId).ToList();

                allRoles.AddRange(allRolesInGroup);
            }
            allRoles = allRoles.Distinct().ToList();
            res.Roles = allRoles;
            return res;
        }

        public List<MenuModel> GetMenu(List<short> roles)
        {
            var menus = new List<MenuModel>();
            if (roles != null)
            {
                var dbMenus = _unit.MasterMenuRepo.GetMenuByRoles(roles);
                var parents = dbMenus.Where(q => q.ParentId == null).OrderBy(x => x.Order).ToList();
                foreach (var parent in parents)
                {
                    MenuModel menu = new MenuModel
                    {
                        Id = parent.Id,
                        Name = parent.Name,
                        Action = parent.Action,
                        Icon = parent.Icon,
                    };

                    var children = dbMenus.Where(q => q.ParentId == parent.Id)
                        .OrderBy(x => x.Order)
                        .Select(q => new MenuBaseModel
                        {
                            Id = q.Id,
                            Name = q.Name,
                            Action = q.Action,
                            Icon = q.Icon
                        }).ToList();
                    if (children.Count > 0)
                    {
                        menu.ShowItems = true;
                        menu.Items = children;
                    }
                    menus.Add(menu);
                }
            }

            return menus;
        }
    }
}