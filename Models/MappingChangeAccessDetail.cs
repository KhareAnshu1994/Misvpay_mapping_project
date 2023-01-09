using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class MappingChangeAccessDetail
    {
        public int id { get; set; }
        public string reason_codes { get; set; }
        public string channel_code { get; set; }

        public string region { get; set; }
        public string selected_ufc { get; set; }
        public string ufc_name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? access_start_date { get; set; }
        [DataType(DataType.Date)]
        public DateTime? access_end_date { get; set; }
        [DataType(DataType.Date)]
        public DateTime? kra_valid_from { get; set; }
        [DataType(DataType.Date)]
        public DateTime? vymo_valid_from { get; set; }
        public string employee_code { get; set; }
        public string alternate_employee_code { get; set; }

        public string remark { get; set; }

    }
}