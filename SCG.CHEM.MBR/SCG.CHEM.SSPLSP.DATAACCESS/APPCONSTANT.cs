using System.ComponentModel;

namespace SCG.CHEM.SSPLSP.DATAACCESS
{
    public class APPCONSTANT
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
            public const string DELETE_HISTORY_DAY = "DELETE_HISTORY_DAY";
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
            public const string YEAR = "yyyy";
            public const string DECIMAL = "{0:#,0.####}";
            public const string YEARMONTH = "yyyyMM";
            public const string YEAR_MONTH = "yyyy-MM";
        }

        public class INTERFACE_STATUS
        {
            public const string SUCCESS = "SUCCESS";
            public const string FAIL = "FAIL";
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

        public class UNCONSTRAINT
        {
            public class DEFAULT_VALUE
            {
                public const string END_YEAR_MONTH = "9999-12";
                public const int PRICE_UNIT_ID = 1;
                public const int UNIT_ID = 0;
                public const string UNIT = "TON";
                public const int PROJECT_STATUS = 1;
            }
        }

        public class CONSTRAINT
        {
            public class DEFAULT_VALUE
            {
                public const string END_YEAR_MONTH = "9999-12";
                public const int PRICE_UNIT_ID = 1;
                public const int UNIT_ID = 0;
                public const string UNIT = "TON";
                public const int STOCK_TYPE_ID = 1;
            }

            public class CONVERT_BETWEEN_COMPANY
            {
                public class LSP_TO_TPE
                {
                    public const string FROM_SALES_GROUP_START = "J";
                    public const string FROM_CUSTOMER_TPE = "0000000101";
                    public const string FROM_CUSTOMER_ICO = "0000002221";
                }

                public class TPE_TO_LSP
                {
                    public const string FROM_SALES_GROUP_START = "G";
                    public const string FROM_CUSTOMER_CODE_LSP = "0000005931";
                }

                public class COMPANY
                {
                    public const string TPE = "0100";
                    public const string LSP = "5930";
                    public const string ICO = "2220";
                }

                //public const string CONV_CHANNEL = "30";
            }

            public class PRODUCTION_LINE
            {
                public const string LL = "LL";
                public const string LD = "LD";
            }
        }

        public class CHANNEL
        {
            public const string DIRECT = "10";
            public const string DEALER = "20";
            public const string EXPORT = "30";
            public const string RE_EXPORT = "40";
        }

        public class COUNTRY
        {
            public const string TH = "TH";
            public const string EN = "EN";
            public const string VN = "VN";
        }

        public class REGION
        {
            public const string TH = "TH";
            public const string VN = "VN";
        }

        public class DELETE_FLAG
        {
            public const string YES = "Y";
            public const string NO = "N";
        }

        public class PLANTYPE
        {
            public const string _18M = "18M";
            public const string OPPLAN = "OPPLAN";
            public const string MTP = "MTP";
        }

        public class MOVE_TYPE
        {
            public const string FAST_MOVE = "Fast Move";
            public const string SLOW_MOVE = "Slow Move";
        }

        public class MATERIAL
        {
            public class PREFIX
            {
                public const string Z10 = "Z10";
                public const string Z12 = "Z12";
            }

            public class POSTFIX
            {
                public const string NONPRIME_PVC = "O";
                public const string NONPRIME_NOT_PVC = "N";
                public const string OTHER = "P";
            }
        }

        public class SCENARIO
        {
            public const string NON_PRIME = "NON PRIME";
            public const string MOST_LIKELY = "MOST LIKELY";
            public const string MINIMUM = "MINIMUM";
            public const string FULL_POTENTIAL = "FULL POTENTIAL";
        }

        public class SCENARIO_ID
        {
            public const int NON_PRIME = 4;
        }

        public class MAT_GROUP
        {
            public const string FG00 = "FG00";
        }

        public class PRICE_TYPE
        {
            public const string FOB_TH = "FOB TH";
            public const string FOB_VN = "FOB VN";
        }

        public class PLANNING_GROUP_NAME
        {
            public const string BLANK = "";
            public const string ALL = "ALL";
            public const string PVC_PASTE = "PVC PASTE";
            public const string PVC_CDP = "PVC CPD";
            public const string PVC_RESIN = "PVC RESIN";

            public const string POLY_WAX_TC = "POLY WAX TC";
            public const string POLY_WAX_LP = "POLY WAX LP";
            public const string POLY_TG = "POLY TG";
            public const string POLY_ROTO = "POLY ROTO";
        }

        public class SALES_GROUP_PREFIX
        {
            public const string J = "J";
            public const string G = "G";
            public const string X = "X";
            public const string Y = "Y";
        }

        public class SALES_GROUP_CODE
        {
            public const string BLANK = "";
            public const string G52 = "G52";
            public const string J52 = "J52";
        }

        public class SALES_DISTRICT
        {
            public const string BLANK = "";
            public const string NORTH = "NORTH";
            public const string SOUTH = "SOUTH";
        }

        public class CUSTOEMR_CODE
        {
            public const string MINIMUM_0002026625 = "0002026625";
            public const string MINIMUM_0002028071 = "0002028071";
        }

        public class PLAN_CATEGORY
        {
            public const string CONSTRAINT = "CONSTRAINT";
            public const string UNCONSTRAINT = "UNCONSTRAINT";
            public const string MARKET_PRICE = "MARKET_PRICE";
            public const string MONOMER_MARKET_PRICE = "MONOMER_MARKET_PRICE";
            public const string PRODUCTION_PLAN = "PRODUCTION_PLAN";
        }

        public class HISTORY_TYPE
        {
            public const int MARKET_PRICE = 1;
            public const int CONSTRAINT = 2;
            public const int UNCONSTRAINT = 3;
            public const int MONOMER = 4;
        }

        public class RESPONSE_STATUS
        {
            public const int OK = 200;
            public const int BAD_REQUEST = 400;
        }

        public class NEW_PRODUCT_FLAG
        {
            public const string NEW_PRODUCT = "NEW PRODUCT";
            public const string COMMERCIAL = "COMMERCIAL";

            public const string PIM_GRACE = "PIM GRACE";
        }

        public class ERROR_MSG
        {
            public const string ERROR_REQUIRED_FIELD = "{0} is required field.";
            public const string ERROR_NOT_NULL_FIELD = "{0} field must not null.";
            public const string ERROR_MUST_BLANK_FIELD = "{0} field must be blank null.";
            public const string ERROR_CONVERT_STR_TO_DECIMAL = "Cannot convert {0} to decimal.";
            public const string ERROR_CONVERT_STR_TO_INT = "Cannot convert {0} to int.";
            public const string ERROR_CONVERT_STR_TO_DATETIME = "Cannot convert {0} to datetime.";
        }

        public class DROPDOWN
        {
            public const string ALL = "ALL";
            public const string ALL_PLANNING_GROUP = "P00";
            public const int ALL_NEW_PRODUCT_FLAG = 0;
        }

        public class MASTER_TYPE
        {
            public const string MIN_VOLUME = "MIN VOLUME";
            public const string NON_PRIME = "NON PRIME";
            public const string MASTER_BATCH = "MASTER BATCH";
        }

        public class DOWLOAD_TEMPLATE
        {
            public const string UNCONSTRAINT = "UNCONSTRAINT";
            public const string M2_TO_M1 = "M2_TO_M1";
            public const string BLANK_TEMPLATE = "BLANK_TEMPLATE";
            public const string MIN_TEMPLATE = "MIN_TEMPLATE";
            public const string MOST_TO_BIDDING = "MOST_TO_BIDDING";
            public const string MARK_DELETE = "MARK_DELETE";
            public const string FULL_FILL = "FULL_FILL";
            public const string SOLVER = "SOLVER";
            public const string PRODUCTION_PLAN = "PRODUCTION_PLAN";
            public const int MONOMER_AVAILABLE = 1;
            public const int MONOMER_CONSUMPTION = 2;
        }

        public class HEADER_EXCEL
        {
            public const string MAX_REQ = "Max Requirement";
            public const string PRICE_ADD_SILO = "Price @ Silo";
            public const string PRICE_BY_PRODUCTION_SITE_AT_SILO = "Price by Production Site @Silo";
            public const string INPUT_PRICE = "InputPrice";
            public const string FULL_FILL = "FullFill Volume";
            public const string QUANTITY = "Quantity";
            public const string PRICE_AT_SILO_TH = "Price@silo TH";
            public const string PRICE_AT_SILO_VN = "Price@silo VN";
        }

        public class REVISION
        {
            public const string FINAL = "FINAL";
            public const string REV_OP_2 = "REV_OP_2";
            public const string REV_OP_3 = "REV_OP_3";
        }

        public class MARKETPICETYPE
        {
            public const string MONOMER = "Monomer CFR";
            public const string POLYMER = "Polymer";
            public const string AT_SILO_TH = "@Silo TH";
            public const string AT_SILO_VN = "@Silo VN";
        }

        public class STOCK_TYPE_ID
        {
            public const int NEW_PRODUCTION = 1;
            public const int BEGINNING_STOCK = 2;
        }

        public class STOCK_TYPE_NAME
        {
            public const string NEW_PRODUCTION = "New Production";
            public const string BEGINNING_STOCK = "Beginning Stock";
        }

        public class PRODUCTION_LINE_PREFIX
        {
            public const string BEG_STOCK = "BegStock-";
        }

        public class PRODUCTION_SITE
        {
            public const string TH = "TH";
            public const string VN = "VN";
        }

        public class TRANSACTION_SALESPLAN
        {
            public const string UNCONSTRAINT = "UNCON";
            public const string CONSTRAINT = "CON";
        }

        public class STORE_PROCEDURE_TYPE
        {
            public const string UNCONSTRAINT = "UNCON";
            public const string CONSTRAINT = "CON";
        }
    }
}