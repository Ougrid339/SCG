using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.COMMON.Authentication.Interface
{
    public interface IUserLocalService
    {
        HttpContext GetHttpContext();



    }
}
