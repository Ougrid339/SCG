using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Entities.Master
{
    [Table("SSP_MST_Channel")]
    public class SSP_MST_CHANNEL
    {
        [Key]
        [StringLength(2)]
        public string ChannelCode { get; set; }

        [StringLength(20)]
        public string ChannelName { get; set; }

        [StringLength(20)]
        public string ChannelGroup { get; set; }

        [StringLength(20)]
        public string ChannelForPrice { get; set; }

        [StringLength(50)]
        public string ChannelOrg { get; set; }
    }
}