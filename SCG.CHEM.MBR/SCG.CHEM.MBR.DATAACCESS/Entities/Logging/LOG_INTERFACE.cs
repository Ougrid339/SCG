using SCG.CHEM.MBR.COMMON.Constants;
using SCG.CHEM.MBR.COMMON.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.Entities.Logging
{
    [Table("LOG_INTERFACE")]
    public class LOG_INTERFACE
    {
        [Key]
        [Column("ID")]
        public long ID { get; set; }

        [Column("INTERFACE_SYSTEM_CODE")]
        [StringLength(20)]
        public string InterfaceSystemCode { get; set; }

        [Column("INITIAL_DATE_TIME")]
        public DateTime InitialDateTime { get; set; }

        [Column("STATUS")]
        [StringLength(50)]
        public string Status { get; set; }

        [Column("INBOUND_TIME")]
        public DateTime? InboundTime { get; set; }

        [Column("OUTBOUND_TIME")]
        public DateTime? OutboundTime { get; set; }

        [Column("INBOUND_MESSAGE")]
        public string InboundMessage { get; set; }

        [Column("OUTBOUND_MESSAGE")]
        public string OutboundMessage { get; set; }

        [Column("ERROR_MESSAGE")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Interface Transaction Key
        /// </summary>
        [Column("INTERFACE_ID")]
        [StringLength(50)]
        public string InterfaceId { get; set; }

        /// <summary>
        /// Key of interface e.g. Credit No,Order No
        /// </summary>
        [Column("INTERFACE_KEY")]
        [StringLength(50)]
        public string InterfaceKey { get; set; }

        public static LOG_INTERFACE CreateLog(AppConstant.INTERFACE.SYSTEMS_CODE code)
        {
            var db = new LOG_INTERFACE()
            {
                InitialDateTime = DateTime.Now,
                InterfaceSystemCode = code.ToString(),
            };
            return db;
        }
    }
}