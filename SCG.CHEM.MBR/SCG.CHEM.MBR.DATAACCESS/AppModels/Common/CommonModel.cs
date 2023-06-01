using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Common
{
    public class ResponseModel
    {
        public long? Id { get; set; }
        public bool? IsSuccess { get; set; }
        //public string Message { get; set; }

        public string Error { get; set; }
        public List<string> Errors { get; set; }
        public int? Status { get; set; }
        public Object Data { get; set; }
        public int Total { get; set; }
    }
}