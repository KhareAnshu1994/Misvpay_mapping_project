using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class CrcaExclusionDetail
    {
        public int id { get; set; }

        public string acno { get; set; }
        public string pan { get; set; }
        public string crcacode { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_from { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_upto { get; set; }
        public string cacode { get; set; }
        public string arnno { get; set; }

        public string status { get; set; }
        public string scheme_code { get; set; }

    }
    public class CrcaExclusionSearch
    {
        public string acno { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }
    }
}