using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class ReasonMasterDetail
    {
        public string reason_codes { get; set; }
        public string reason_code_description { get; set; }
    }
    public class ReasonMasterSearch
    {
       /* public int pincode { get; set; }
        public string quarter { get; set; }*/
        public string search_text { get; set; }
    }
    public class AddReasonMaster
    {
        public string reason_codes { get; set; }
        public string reason_code_description { get; set; }
      //  public string is_active { get; set; }
    }
}