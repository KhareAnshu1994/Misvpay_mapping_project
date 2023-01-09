using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class ImcPanGroupcodeMasterDetail
    {
        public int id { get; set; }

        public string groupcode { get; set; }
        public string pan_no { get; set; }
        public string type { get; set; }
        public string region_code { get; set; }
        public string name { get; set; }
        public string clientgroup { get; set; }
        public int group_no { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_from { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_upto { get; set; }
        [DataType(DataType.Date)]
        public DateTime? creationdt { get; set; }
        [DataType(DataType.Date)]
        public DateTime? lstupddt { get; set; }


    }

    public class ImcPanGroupcodeMasterSearch
    {
        public string groupcode { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }
    }


}