﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class LoginDetails
    {
        [Required]
        public string EmpID { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 6)]
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Location { get; set; }
        public string Region { get; set; }
        public string Role { get; set; }
        public string Employee_id { get; set; }
        public DateTime Login_Time { get; set; }
        public List<MappingAceesTableDetails> mapping_details_edit { get; set; }

    }

    public class MappingAceesEditDetails
    {
        public int mapping_access_id { get; set; }
        public int mapping_trans_id { get; set; }
        public string employee_code { get; set; }
        public string channel_code { get; set; }
        public string alternate_employee_code { get; set; }
        public string ufc_code { get; set; }
        public string region { get; set; }
        public string mapping_table { get; set; }
        public DateTime? access_start_date { get; set; }
        public DateTime? access_end_date { get; set; }
        public bool complete_status { get; set; }
        public bool edit_window { get; set; }
    }

    public class MappingAceesTableDetails
    {

        public string mapping_table { get; set; }
        public bool complete_status { get; set; }
        public List<MappingAceesUFCDetails> ufc_details { get; set; }
        public List<MappingAceesRegionDetails> region_details { get; set; }
    }

    public class MappingAceesUFCDetails
    {
        public int mapping_access_id { get; set; }
        public int mapping_trans_id { get; set; }
        public string employee_code { get; set; }
        public string alternate_employee_code { get; set; }
        public string ufc_code { get; set; }
        public bool complete_status { get; set; }
        public bool edit_window { get; set; }

        public DateTime? access_start_date { get; set; }
        public DateTime? access_end_date { get; set; }
    }

    public class MappingAceesRegionDetails
    {
        public int mapping_access_id { get; set; }
        public int mapping_trans_id { get; set; }
        public string employee_code { get; set; }
        public string alternate_employee_code { get; set; }
        public string region { get; set; }
        public bool complete_status { get; set; }
        public bool edit_window { get; set; }
        public DateTime? access_start_date { get; set; }
        public DateTime? access_end_date { get; set; }
    }
}