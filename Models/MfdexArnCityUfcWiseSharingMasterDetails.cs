using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class MfdexArnCityUfcWiseSharingMasterDetails
    {
        public string krv_code { get; set; }
        public string new_city { get; set; }
        public string ufc_code { get; set; }
        public string city_type { get; set; }
        public string multicity { get; set; }
        public string arn_name { get; set; }
        public string arn_channel { get; set; }
        public string t5b5_status { get; set; }
        public string mfdex_city { get; set; }
        public string schannel { get; set; }
        public string region_code { get; set; }
        public string sap_ufc_code { get; set; }
        public string zone { get; set; }
        public string sow_ehs_perc_share { get; set; }
        public string sow_income_perc_share { get; set; }
        public string sow_lqnmm_perc_share { get; set; }
    }

    public class MfdexArnCityUfcWiseSharingMasterSearch
    {
        public string krv_code { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }
    }

}