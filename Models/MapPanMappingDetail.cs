using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class MapPanMappingDetail
    {
        public int id { get; set; }
        public string pan_no { get; set; }
        public string name { get; set; }
        public string rm_code { get; set; }
        public string rm_name { get; set; }

        public string client_group { get; set; }
        public string source { get; set; }
        public string group_code { get; set; }
        public string group_name { get; set; }
        public string region_code { get; set; }
        public string region_name { get; set; }
        public string zone { get; set; }
        public string sap_ufc_code { get; set; }
        public string sap_region_code { get; set; }
        public string sap_zone_code { get; set; }
        public string channel_code { get; set; }

        public string New_rmcode { get; set; }  //For Set Rm Code
        public string Old_rmcode { get; set; }

    }
}