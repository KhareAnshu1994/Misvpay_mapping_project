﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class TeamSatMappingDetail
    {
        public int id { get; set; }
        public string arn_code { get; set; }

        public string distributors_name { get; set; }
        public string multicity_am { get; set; }
        public string channel { get; set; }
        public string family_arn_code { get; set; }
        public string family_arn_name { get; set; }
        public string group_type { get; set; }
        public string mfd_group { get; set; }
        public string segment { get; set; }
        public string strategic_team_rm_1 { get; set; }
        public string employee_code_rm_1 { get; set; }

        public string strategic_team_rm_2 { get; set; }
        public string employee_code_rm_2 { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_from { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_upto { get; set; }
        public string arn_channel { get; set; }
    }
}