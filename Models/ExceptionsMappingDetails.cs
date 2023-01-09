﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class ExceptionsMappingDetails
    {
        public int id { get; set; }
        public string exception_id { get; set; }
       /* public string Replace_rmcode { get; set; }  //For Set Rm Code
        public string old_rmcode { get; set; }*/

        public string rm_code { get; set; }
        public string rm_name { get; set; }
        public char case_type { get; set; }
        public string region { get; set; }
        public string region_name { get; set; }
        public string ufc_code { get; set; }
        public string ufc_name { get; set; }
        public string zone { get; set; }
        public string sap_ufc_code { get; set; }
        public string sap_region_code { get; set; }
        public string sap_zone_code { get; set; }
        public string channel_code { get; set; }
        public int aum_perc { get; set; }
        public string New_rmcode { get; set; }  //For Set Rm Code
        public string Old_rmcode { get; set; }



    }
}