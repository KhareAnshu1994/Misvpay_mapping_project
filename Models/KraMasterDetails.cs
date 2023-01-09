using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class KraMasterDetails
    {
        public int id { get; set; }
        public int bscyear { get; set; }
        public string channel { get; set; }
        public string emp_role { get; set; }
        public int kra_code { get; set; }
        public string kra_description { get; set; }
        public int wtgs { get; set; }
        public char kra_freq { get; set; }
        public string kra_type{ get; set; }
        public string created_by { get; set; }
        public DateTime? created_date { get; set; }
        public char is_active { get; set; }
    }

    public class KraMasterSearch
    {
        public int kra_code { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }
    }

}