using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SCG.CHEM.MBR.MASTER.API.AppModels.Master
{
    public class MasterDownloadRequest
    {
        public List<int> MasterIds { get; set; }

        public DateTime? StartDate { get; set; } 
    }
}