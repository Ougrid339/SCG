using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Logging
{
    [Table("LOG_SEND_DWH")]
    public class LOG_SEND_DWH : BaseContext
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long InterfaceId { get; set; }

        public string? InterfaceStatus { get; set; }

        [StringLength(100)]
        public string? ServicePath { get; set; }

        public DateTime? InboundTime { get; set; }

        public DateTime? OutboundTime { get; set; }

        public string? InboundMessage { get; set; }

        public string? OutboundMessage { get; set; }

        public string? ErrorMessage { get; set; }

        [StringLength(100)]
        public string? PlanType { get; set; }

        [StringLength(100)]
        public string? Cycle { get; set; }

        [StringLength(100)]
        public string? PlanningGroup { get; set; }

        [StringLength(100)]
        public string? SalesGroupCode { get; set; }

        public LOG_SEND_DWH(string interfaceStatus, string servicePath, DateTime? inboundTime, DateTime? outboundTime, string inboundMessage, string outboundMessage, string planType, string cycle, string planningGroup, string salesGroupCode)
        {
            InterfaceStatus = interfaceStatus;
            ServicePath = servicePath;
            InboundTime = inboundTime;
            OutboundTime = outboundTime;
            InboundMessage = inboundMessage;
            OutboundMessage = outboundMessage;
            PlanType = planType;
            Cycle = cycle;
            PlanningGroup = planningGroup;
            SalesGroupCode = salesGroupCode;

            this.CreatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.CreatedDate = DateTime.Now;
        }

        public void UpdateStatusAndOutboundMessage(string interfaceStatus, string outboundMessage)
        {
            InterfaceStatus = interfaceStatus;
            OutboundMessage = outboundMessage;
            OutboundTime = DateTime.Now;

            this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.UpdatedDate = DateTime.Now;
        }

        public void UpdateStatusAndErrorMessage(string interfaceStatus, string errMessage)
        {
            InterfaceStatus = interfaceStatus;
            ErrorMessage = errMessage;
            OutboundTime = DateTime.Now;

            this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.UpdatedDate = DateTime.Now;
        }

        public void SetCreatedBy(string createdBy)
        {
            this.CreatedBy = createdBy;
        }

        public void UpdateLog(string servicePath)
        {
            this.ServicePath = servicePath;

            this.UpdatedBy = UserUtilities.GetADAccount()?.UserId ?? "";
            this.UpdatedDate = DateTime.Now;
        }
    }
}