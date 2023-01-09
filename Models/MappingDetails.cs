using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class MappingDetails
    {
        
        public DateTime? valid_from { get; set; }
        public int roll { get; set; }
        public string name{ get; set; }
        public string address { get; set; }
        public long crcacode { get; set; }
        public long acno { get; set; }
        public string pan { get; set; }
        public DateTime valid_upto { get; set; }
        public string investor { get; set; }
        public string name_cr { get; set; }



    }
}