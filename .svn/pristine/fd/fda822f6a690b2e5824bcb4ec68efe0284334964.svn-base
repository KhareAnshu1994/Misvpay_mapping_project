using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class RegionMasterDetails
    {
        public int id { get; set; }

        public string umr_region_code { get; set; }

        public string umr_region_name { get; set; }

        public string umr_region_channel { get; set; }

        public int umr_order_no { get; set; }

        [DataType(DataType.Date)]
        public DateTime? umr_file_date { get; set; }

        [DataType(DataType.Date)]
        public DateTime? umr_action_date { get; set; }

        [DataType(DataType.Date)]
        public DateTime? umr_valid_from { get; set; }

        [DataType(DataType.Date)]
        public DateTime? umr_valid_upto { get; set; }

        public DateTime? umr_creation_date { get; set; }

        public string umr_created_by { get; set; }

        public DateTime? umr_modification_date { get; set; }

        public string umr_modified_by { get; set; }
        public char umr_upd_type { get; set; }

        public char is_active { get; set; }
    }


    public class RegionMasterSearch
    {
        public string umr_region_code { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }
    }
}