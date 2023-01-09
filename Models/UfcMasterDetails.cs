using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class UfcMasterDetails
    {
        public string sap_ufc_code { get; set; }
        public string ufc_code { get; set; }
        public string ufc_name { get; set; }
        public DateTime? ufc_start_date { get; set; }
        public string region_code { get; set; }
        public string region_cd_chnl { get; set; }
        public string zone { get; set; }
        public string state { get; set; }
        public string imc_city { get; set; }
        public string region_sap_code { get; set; }
        public string zone_sap_code { get; set; }
        public int latitude { get; set; }
        public int longitude { get; set; }
        public string ufc_address { get; set; }
        public string pincode { get; set; }
        public string ufc_type { get; set; }
        public DateTime? valid_from { get; set; }
        public DateTime? valid_upto { get; set; }
    }
    public class UfcMasterSearch
    {

        public string sap_ufc_code { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }
        public string region_code { get; set; }
    }
}