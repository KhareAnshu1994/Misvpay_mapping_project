using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class CamsCityUfcMasterDetails
    {

        public int id { get; set; }
        public string city_mfdex_plus { get; set; }
        public string region { get; set; }
        public string amfi_category { get; set; }

        [DataType(DataType.Date)]
        public DateTime? valid_from { get; set; }

        [DataType(DataType.Date)]
        public DateTime? valid_upto { get; set; }
        public string amfi_t30_b30 { get; set; }
        public string t5_b5 { get; set; }
        public string group_city { get; set; }
        public string mis_city_category { get; set; }
        public string ufc_code { get; set; }
        public string ufc_name { get; set; }
        public string new_zone { get; set; }
        public string region_code { get; set; }
        public string dofa_cat { get; set; }
        public string t15_b15_mis { get; set; }
        public string bnd_city { get; set; }
        public string name_of_state { get; set; }
        public string dofa_sub_cat { get; set; }
        public string zone { get; set; }
        public string imc_location { get; set; }
        public string bnd_region { get; set; }
        public string imc_region { get; set; }
        public string city_group { get; set; }
        public string ufcnames { get; set; }
        public string ufccodes { get; set; }
        public string group_name { get; set; }
        public string dofa_sub_category { get; set; }
        public string ufc_location { get; set; }
        public string citygroup { get; set; }

    }

    public class CamsCityUfcMasterSearch
    {
        public string city_mfdex_plus { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }
    }

}
