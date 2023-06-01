using Newtonsoft.Json;
using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Logging
{
    [Table("LOG_API")]
    public class LOG_API : BaseContext
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long InterfaceId { get; set; }

        public int? InterfaceStatus { get; set; }

        [StringLength(100)]
        public string? ServicePath { get; set; }

        public DateTime? InboundTime { get; set; }

        public DateTime? OutboundTime { get; set; }

        public string? InboundMessage { get; set; }

        public string? OutboundMessage { get; set; }

        public string? ErrorMessage { get; set; }

        public int? Type { get; set; }

        [StringLength(100)]
        public string? PlanType { get; set; }

        [StringLength(100)]
        public string? Cycle { get; set; }

        [StringLength(100)]
        public string? Case { get; set; }

        public string? CustomMessage { get; set; }

        public bool? IsValidationSuccess { get; set; }

        public string? Criteria { get; set; }

        public LOG_API()
        { }

        public LOG_API(int? interfaceStatus, string servicePath, DateTime? inboundTime, DateTime? outboundTime, string inboundMessage, string outboundMessage, int? type, string planType, string cycle, string caseName)
        {
            InterfaceStatus = interfaceStatus;
            ServicePath = servicePath;
            InboundTime = inboundTime;
            OutboundTime = outboundTime;
            InboundMessage = inboundMessage;
            OutboundMessage = outboundMessage;
            Type = type;
            PlanType = planType;
            Cycle = cycle;
            Case = caseName;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public LOG_API(string servicePath, DateTime? inboundTime, DateTime? outboundTime, string inboundMessage, string outboundMessage, int? type, string? planType, string? cycle, string? caseName)
        {
            ServicePath = servicePath;
            InboundTime = inboundTime;
            OutboundTime = outboundTime;
            InboundMessage = inboundMessage;
            OutboundMessage = outboundMessage;
            Type = type;
            PlanType = planType;
            Cycle = cycle;
            Case = caseName;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public void UpdateStatusAndOutboundMessage(int? interfaceStatus, string outboundMessage, string customMessage)
        {
            InterfaceStatus = interfaceStatus;
            OutboundMessage = outboundMessage;
            OutboundTime = DateTime.Now;

            CustomMessage = customMessage;

            this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.UpdatedDate = DateTime.Now;
        }

        public void UpdateStatusAndErrorMessage(int? interfaceStatus, string errMessage, string customMessage)
        {
            InterfaceStatus = interfaceStatus;
            ErrorMessage = errMessage;
            OutboundTime = DateTime.Now;

            CustomMessage = customMessage;

            this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.UpdatedDate = DateTime.Now;
        }

        public void UpdateValidationStatus(bool? isValidationSuccess)
        {
            IsValidationSuccess = isValidationSuccess;
        }

        public void UpdateCriteria(string? criteria)
        {
            Criteria = criteria;
        }

        public void UpdateLog(int? interfaceStatus, string servicePath, DateTime? inboundTime, DateTime? outboundTime, string inboundMessage, string outboundMessage, int? type, string planType, string cycle, string? caseName)
        {
            this.InterfaceStatus = interfaceStatus;
            this.ServicePath = servicePath;
            this.InboundTime = inboundTime;
            this.OutboundTime = outboundTime;
            this.InboundMessage = inboundMessage;
            this.OutboundMessage = outboundMessage;
            this.Type = type;
            this.PlanType = planType;
            this.Cycle = cycle;
            this.Case = caseName;

            this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.UpdatedDate = DateTime.Now;
        }

        public void UpdateLog(string servicePath, DateTime? inboundTime, DateTime? outboundTime, string inboundMessage, string outboundMessage, int? type, string planType, string cycle, string? caseName)
        {
            this.ServicePath = servicePath;
            this.InboundTime = inboundTime;
            this.OutboundTime = outboundTime;
            this.InboundMessage = inboundMessage;
            this.OutboundMessage = outboundMessage;
            this.Type = type;
            this.PlanType = planType;
            this.Cycle = cycle;
            this.Case = caseName;

            this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.UpdatedDate = DateTime.Now;
        }
    }
}