using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Transaction
{
    [Table("SSP_TRN_NewProjectRegistration")]
    public class SSP_TRN_NEW_PROJECT_REGIS : BaseContext
    {
        [Key]
        [StringLength(50)]
        public string ProjectID { get; set; }

        public int ProjectStatus { get; set; }

        [StringLength(200)]
        public string ProjectName { get; set; }

        [StringLength(20)]
        public string PlanningGroup { get; set; }

        [StringLength(50)]
        public string TrialGradeCode { get; set; }

        [StringLength(50)]
        public string? StandardGradeCode { get; set; }

        [StringLength(10)]
        public string TrialStart { get; set; }

        [StringLength(10)]
        public string? StandardizeStart { get; set; }

        [StringLength(100)]
        public string UserAD { get; set; }

        [StringLength(200)]
        public string? FirstName { get; set; }

        [StringLength(200)]
        public string? LastName { get; set; }

        [StringLength(200)]
        public string? SCGEmail { get; set; }

        [StringLength(50)]
        public string? Telephone { get; set; }

        [StringLength(1)]
        public string DeletedFlag { get; set; }

        [StringLength(50)]
        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public SSP_TRN_NEW_PROJECT_REGIS(string projectID, int projectStatus, string projectName, string planningGroup, string trialGradeCode, string? standardGradeCode, string trialStart, string? standardizeStart, string userAD, string? firstName, string? lastName, string? sCGEmail, string? telephone)
        {
            ProjectID = projectID;
            ProjectStatus = projectStatus;
            ProjectName = projectName;
            PlanningGroup = planningGroup;
            TrialGradeCode = trialGradeCode;
            StandardGradeCode = standardGradeCode;
            TrialStart = trialStart;
            StandardizeStart = standardizeStart;
            UserAD = userAD;
            FirstName = firstName;
            LastName = lastName;
            SCGEmail = sCGEmail;
            Telephone = telephone;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
            this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
        }

        public void Update(int projectStatus, string projectName, string planningGroup, string trialGradeCode, string? standardGradeCode, string trialStart, string? standardizeStart, string userAD, string? firstName, string? lastName, string? sCGEmail, string? telephone, string deletedFlag)
        {
            ProjectStatus = projectStatus;
            ProjectName = projectName;
            PlanningGroup = planningGroup;
            TrialGradeCode = trialGradeCode;
            StandardGradeCode = standardGradeCode;
            TrialStart = trialStart;
            StandardizeStart = standardizeStart;
            UserAD = userAD;
            FirstName = firstName;
            LastName = lastName;
            SCGEmail = sCGEmail;
            Telephone = telephone;

            if (deletedFlag == APPCONSTANT.DELETE_FLAG.YES)
            {
                this.MarkDelete();
            }
            else
            {
                this.UnMarkDelete();
            }
        }

        public void MarkDelete()
        {
            if (this.DeletedFlag != APPCONSTANT.DELETE_FLAG.YES)
            {
                this.DeletedFlag = APPCONSTANT.DELETE_FLAG.YES;
                this.DeletedBy = UserUtilities.GetADAccount()?.UserId ?? "";
                this.DeletedDate = DateTime.Now;
            }
        }

        public void UnMarkDelete()
        {
            if (this.DeletedFlag == APPCONSTANT.DELETE_FLAG.YES)
            {
                this.DeletedFlag = APPCONSTANT.DELETE_FLAG.NO;
                this.DeletedBy = UserUtilities.GetADAccount()?.UserId ?? "";
                this.DeletedDate = DateTime.Now;
            }
        }
    }
}