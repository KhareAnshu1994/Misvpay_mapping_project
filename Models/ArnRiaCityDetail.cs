﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class ArnRiaCityDetail
    {
        public int id { get; set; }
        public string arnno_ref { get; set; }
        public string ria { get; set; }
        public string city { get; set; }
        public string distributor_name { get; set; }
        public string rm_code { get; set; }
        public string rm_name { get; set; }
        public string region_code { get; set; }
        public string region_name { get; set; }
        public string ufc_code { get; set; }
        public string ufc_name { get; set; }
        public string zone { get; set; }
        public string sap_ufc_code { get; set; }
        public string sap_region_code { get; set; }
        public string sap_zone_code { get; set; }
        public string channel_code { get; set; }

        public string New_rmcode { get; set; }  //For Set Rm Code
        public string Old_rmcode { get; set; }

    }
}