using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class ArnMasterDetails
    {
        public string krv_code { get; set; }
        public string channel_code { get; set; }
        public string new_br_code { get; set; }
        public string region_code { get; set; }
        public string name { get; set; }
        public string dist { get; set; }
        public string multicity_flag { get; set; }
        public string categoty { get; set; }
        public string group_cd { get; set; }
        public string rm_code { get; set; }
        public string zone { get; set; }
        public string arn_group_name { get; set; }
        public string sub_channel { get; set; }
        public string arn_type { get; set; }

        [DataType(DataType.Date)]
        public DateTime? valid_from { get; set; }

        [DataType(DataType.Date)]
        public DateTime? valid_upto { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? lstupddt { get; set; }
        public string active_flag { get; set; }
        public string owner_type { get; set; }
        public string sap_ufc_code { get; set; }
        public string prm_code { get; set; }
        public string channel_group { get; set; }
        public string sap_region_code { get; set; }
        public string sap_zone_code { get; set; }
    }


    public class ArnMasterSearch
    {

        public string krv_code { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }

    }
}