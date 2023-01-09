using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class PincodeMasterDetail
    {
        public int id { get; set; }
        public int pincode { get; set; }
        public string ufc_code { get; set; }
        public string dist_cd { get; set; }
        public string dist_name { get; set; }
        public string city_as_per_cams { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_from { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_upto { get; set; }
        public string city_as_per_amfi { get; set; }
       /* public string district { get; set; }*/
        public string t30b30 { get; set; }
        public string t5b5 { get; set; }
        public string t15b15 { get; set; }
        public string t8b8 { get; set; }
        public string dofa_pin_category { get; set; }
        public string ufc_location { get; set; }
        public string sap_ufc_code { get; set; }
        public string sap_region_code { get; set; }
        public string sap_zone_code { get; set; }

    }
    public class PincodeMasterSearch
    {
        public int pincode { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }
    }
}