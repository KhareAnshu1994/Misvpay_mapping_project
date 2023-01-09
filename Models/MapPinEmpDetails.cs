﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class MapPinEmpDetails
    {
        public int id { get; set; }
        public int pincode { get; set; }
    /*    public string Replace_rmcode { get; set; }  //For Set Rm Code
        public string old_rmcode { get; set; }*/
        public string rm_code { get; set; }
        public string rm_name { get; set; }
        
        public int aum_perc { get; set; }

        [DataType(DataType.Date)]
        public DateTime? valid_from { get; set; }

        public string ufc_code { get; set; }
        public string ufc_name { get; set; }
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