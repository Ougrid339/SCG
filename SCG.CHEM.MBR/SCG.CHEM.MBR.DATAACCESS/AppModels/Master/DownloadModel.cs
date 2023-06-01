using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Master
{
    public class DownloadModel
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public decimal Value { get; set; }
    }
}