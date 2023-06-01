using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.SSPLSP.DATAACCESS.Repository.Views.Interface
{
    public interface IDownloadRepo
    {
        public List<Object> DownloadMaster(List<string> plantypes = null, string startdate = null, string cycle = null);
    }
}