using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XepLenh
{
    public class PH_Info
    {
        public int ID { get; set; }
        public string CodeId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? CurrentAmount { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }        
    }
}