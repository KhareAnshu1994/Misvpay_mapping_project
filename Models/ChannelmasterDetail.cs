using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class ChannelmasterDetail
    {
        public int id { get; set; }
        public string channel_code { get; set; }
        public string channel_name { get; set; }
        public string chn_sap_code { get; set; }
        public string mis_menu_cd { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_from { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_upto { get; set; }

    }

    public class ChannelmasterSearch
    {
        public string channel_code { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }
    }

}