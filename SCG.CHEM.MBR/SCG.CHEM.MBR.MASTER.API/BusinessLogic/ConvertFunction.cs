using SCG.CHEM.MBR.DATAACCESS;

namespace SCG.CHEM.MBR.MASTER.API.BusinessLogic
{
    public class ConvertFunction
    {
        public static string GetMaterialCode(string matPrefix, string grade, string package, string scenarioDesc, string planningGroupName)
        {
            string materialCode = null;

            string matClass = "";
            if (scenarioDesc == APPCONSTANT.SCENARIO.NON_PRIME)
            {
                if (String.Equals(planningGroupName, APPCONSTANT.PLANNING_GROUP_NAME.PVC_PASTE, StringComparison.OrdinalIgnoreCase)
                    || String.Equals(planningGroupName, APPCONSTANT.PLANNING_GROUP_NAME.PVC_RESIN, StringComparison.OrdinalIgnoreCase))
                    matClass = APPCONSTANT.MATERIAL.POSTFIX.NONPRIME_PVC;
                else
                    matClass = APPCONSTANT.MATERIAL.POSTFIX.NONPRIME_NOT_PVC;
            }
            else
                matClass = APPCONSTANT.MATERIAL.POSTFIX.OTHER;

            materialCode = matPrefix + grade + package + matClass;

            return materialCode;
        }

        public static string GetMaterialCodePPRCost(string matPrefix, string grade, string package, string scenarioDesc, string planningGroupName)
        {
            string materialCode = null;

            string matClass = "";
            matClass = APPCONSTANT.MATERIAL.POSTFIX.OTHER;

            materialCode = matPrefix + grade + package + matClass;

            return materialCode;
        }

        public static string GetMatPrefixByPlanningGroup(string planningGroupName)
        {
            string matPrefix = "";

            if (String.Equals(planningGroupName, APPCONSTANT.PLANNING_GROUP_NAME.PVC_PASTE, StringComparison.OrdinalIgnoreCase)
                || String.Equals(planningGroupName, APPCONSTANT.PLANNING_GROUP_NAME.PVC_RESIN, StringComparison.OrdinalIgnoreCase))
            {
                matPrefix = APPCONSTANT.MATERIAL.PREFIX.Z12;
            }
            else
            {
                matPrefix = APPCONSTANT.MATERIAL.PREFIX.Z10;
            }

            return matPrefix;
        }
    }
}