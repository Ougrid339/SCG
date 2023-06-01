using System;

namespace SCG.CHEM.MBR.COMMON.AppException
{
    public class UnauthorizedActionException : SystemException
    {
        public UnauthorizedActionException(string msg, Exception ex = null) : base(msg, ex)
        {

        }
    }
}
