using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class RiaDetail
    {
        public int id { get; set; }
        public string riacode { get; set; }
        public string arn_code { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_from { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_upto { get; set; }
        public string channel_code { get; set; }
        public char? multicity { get; set; }
        public string ria_name { get; set; }
        public string arn_name { get; set; }
    }
    public class RiaMasterSearch
    {

        public string riacode { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }

    }
}