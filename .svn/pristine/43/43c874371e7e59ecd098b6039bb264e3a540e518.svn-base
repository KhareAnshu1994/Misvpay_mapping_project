using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class ExceptionsMasterDetails
    {
        public string case_id { get; set; }
        public string remarks { get; set; }
        public string case_name { get; set; }
        public string fields { get; set; }
        public string attribute { get; set; }
        public string p_seq { get; set; }
        public string exception_attribute { get; set; }
        public int srno { get; set; }

        [DataType(DataType.Date)]
        public DateTime? valid_from { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_upto { get; set; }

        public string case_no { get; set; }
        public string case_type { get; set; }
        public string applicability { get; set; }
        public string flag_retrospective { get; set; }
        public DateTime? lstupdt { get; set; }
    }
    public class ExceptionsMasterSearch
    {
        public string case_id { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }
    }

}