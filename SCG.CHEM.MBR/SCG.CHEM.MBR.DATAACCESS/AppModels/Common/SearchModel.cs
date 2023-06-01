using System;
using System.Collections.Generic;
using System.Text;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Common
{
    public class SearchReqModel
    {
        public int? PageIndex { get; set; } = 1;
        public int? PageSize { get; set; }
        public string? SortField { get; set; }
        public int? SortOrder { get; set; }
    }

    public class SearchResModel<T>
    {
        public int TotalRecord { get; set; } = 0;
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; }
        public List<T> DataList { get; set; } = new List<T>();

        public SearchResModel(SearchReqModel req)
        {
            this.PageSize = req.PageSize.Value;
        }
    }
}