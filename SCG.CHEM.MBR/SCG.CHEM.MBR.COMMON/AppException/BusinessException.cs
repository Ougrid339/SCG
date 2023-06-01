using System;

namespace SCG.CHEM.MBR.COMMON.AppException
{
    public class BusinessException : SystemException
    {
        public BusinessException(string msg, Exception ex = null) : base(msg, ex)
        {

        }
    }
}

