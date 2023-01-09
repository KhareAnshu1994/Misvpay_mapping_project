using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class SubbrokerMasterDetails
    {
        public string arn_no { get; set; }
        public int subbroker_code { get; set; } //uPdateD in Database

        public string channel_code { get; set; }
        public string region_code { get; set; }
        public string ufc_code { get; set; }
        
        public string krv_code { get; set; }

        [DataType(DataType.Date)]
        public DateTime? valid_from { get; set; }

        [DataType(DataType.Date)]
        public DateTime? valid_upto { get; set; }
        public DateTime? lst_upddt { get; set; }
        public string zone { get; set; }
      
        public string sap_ufc_code { get; set; }
        public string ufc_location { get; set; }
        public string sap_region_code { get; set; }
        public string sap_zone_code { get; set; }
        public DateTime? creation_date { get; set; }
        public string branch_code { get; set; }
        //public string address { get; set; } //Not uddate in Database
        //public string email_id { get; set; }//Not uddate in Database
        //public string phone_no { get; set; }//Not uddate in Database
    }
    public class SubbrokerMasterSearch
    {
        public string branch_code { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }
    }

}