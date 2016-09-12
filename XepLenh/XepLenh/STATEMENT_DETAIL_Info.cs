using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XepLenh
{
    public class STATEMENT_DETAIL_Info
    {
        public int ID { get; set; }
        public int Statement_ID { get; set; }
        public int PH_ID { get; set; }
        public int GH_ID { get; set; }      
        public string TransactionId { get; set; }
        public DateTime? DateCreate { get; set; }
        public bool? ConfirmGH { get; set; }
        public DateTime? DateConfirmGH { get; set; }
        public bool? ConfirmPH { get; set; }
        public DateTime? DateConfirmPH { get; set; }
        public decimal? Amount { get; set; }
    }
}