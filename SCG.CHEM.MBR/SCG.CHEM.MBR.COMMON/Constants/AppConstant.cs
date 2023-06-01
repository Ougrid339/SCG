using System.ComponentModel;

namespace SCG.CHEM.MBR.COMMON.Constants
{
    public class AppConstant
    {

        public enum ROLE
        {
            NONE,
            SYSTEM_ADMIN
        }

        public enum CONFIG
        {


        }

        public class INTERFACE
        {
            public enum MESSAGE_TYPE
            {
                [Description("application/json")]
                JSON,
                [Description("application/xml")]
                XML,
                [Description("application/x-www-form-urlencoded")]
                URL_ENCODE,
            }

            public enum SYSTEMS_CODE
            {

            }

            public enum TOKEN_CODE
            {

            }
        }

        public class CONFIG_ID
        {

        }

        public class APP_USER
        {
            public const string JOB = "system_job";
            public const string SYSTEM = "system_process";
        }

        public class SORT_DIRECTION
        {
            public const string ASCENDING = "A";
            public const string DESCENDING = "D";
        }

        public class FORMAT
        {
            public const string BASIC_DATETIME_SEC = "dd/MM/yyyy HH:mm:ss";
            public const string WEB_DATE = "yyyy-MM-dd";
            public const string WEB_DATETIME = "yyyy-MM-dd HH:mm";
            public const string WEB_DATETIME_SEC = "yyyy-MM-dd HH:mm:ss";
            public const string EMAIL_DATE = "dd/MM/yyyy";
            public const string SAP_DATE = "yyyyMMdd";
            public const string TIME = "HH:mm";
            public const string DECIMAL = "{0:#,0.####}";
        }

        public class CURRENCY
        {
            public const string USD = "USD";
            public const string THB = "THB";
        }

        public class SPLIT_STRING
        {
            public const string EMAIL_ADDRESS = "@";
        }

    }
}
