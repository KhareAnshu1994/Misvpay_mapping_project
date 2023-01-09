using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class ZoneMasterDetails
    {

        public string umz_zone_code { get; set; }
        public string umz_zone_description { get; set; }
        public string umz_zone_channel { get; set; }
        public int umz_order_no { get; set; }

        [DataType(DataType.Date)]
        public DateTime? umz_file_date { get; set; }

        [DataType(DataType.Date)]
        public DateTime? umz_action_date { get; set; }

        [DataType(DataType.Date)]
        public DateTime? umz_valid_from { get; set; }

        [DataType(DataType.Date)]
        public DateTime? umz_valid_upto { get; set; }
        public DateTime? umz_creation_date { get; set; }
        public string umz_created_by { get; set; }
        public DateTime? umz_modification_date { get; set; }
        public string umz_modified_by { get; set; }
        public char umz_upd_type { get; set; }

    }
    public class ZoneMasterSearch
    {
        public string umz_zone_code { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }
    }


}