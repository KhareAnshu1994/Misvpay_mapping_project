using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class VymoDistributorMappingDetail
    {
        public int id { get; set; }

        public string lead_code { get; set; }
        public string assigned_to { get; set; }
        public string user_id { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? last_updated_date { get; set; }
        public string distributor_name { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public int primary_phone_number { get; set; }
        public char status { get; set; }
        public string category { get; set; }
        public DateTime? partner_recruitment_date { get; set; }
        public int engagement_frequency { get; set; }
        public string arn_number { get; set; }
        public int sub_arn { get; set; }
        public string sub_arn_name { get; set; }
        public string group_name { get; set; }
        public string group_arn { get; set; }
        public string commission_category { get; set; }
        public string tier { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string home_location { get; set; }
        public DateTime? arn_validity { get; set; }
        public string channel { get; set; }
        public string distributor_pan { get; set; }
        public string distributor_type { get; set; }
        public DateTime? effective_date { get; set; }
        public int secondary_contact_number { get; set; }
        public int residential_contact_number { get; set; }
        public int pincode { get; set; }
        public DateTime? birth_date { get; set; }
        public string dist_key { get; set; }
        public string mapping_city { get; set; }
        public string tagged_uti_branch { get; set; }
        public int tagged_uti_branch_code { get; set; }
        public int tagged_misvpay_branch_code { get; set; }
        public string alternate_address_line_1 { get; set; }
        public string alternate_address_line_2 { get; set; }
        public string alternate_city { get; set; }
        public string alternate_state { get; set; }
        public int alternate_pincode { get; set; }
        public DateTime? anniversary_date { get; set; }
        public string distributor_arn { get; set; }
        public string alternate_email { get; set; }
        public char distributor_segment { get; set; }
        public int alternate_contact_number { get; set; }

        //Update 
        public string New_rmcode { get; set; }  //For Set Rm Code
        public string Old_rmcode { get; set; }

    }
    public class VymoDistributorMappingSearch
    {
        public string quarter { get; set; }
        public string search_text { get; set; }
        public string ufc_name { get; set; }
    }
}