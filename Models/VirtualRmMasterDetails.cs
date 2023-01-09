using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class VirtualRmMasterDetails
    {
        public string channel_code { get; set; }
        public string virtual_rmcode_str { get; set; }
        public string ufc_code { get; set; }
        public string sap_ufc_code { get; set; }
        public string ufc_name { get; set; }
    }

    public class VirtualRmMasterSearch
    {
        public string channel_code { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }
    }
}