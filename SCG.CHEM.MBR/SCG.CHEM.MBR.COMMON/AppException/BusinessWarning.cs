using System;

namespace SCG.CHEM.MBR.COMMON.AppException
{
    public class BusinessWarning : SystemException
    {
        public BusinessWarning(string msg, Exception ex = null) : base(msg, ex)
        {

        }
    }
}

