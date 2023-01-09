using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mapping_Solution.Models
{
    public class SchemeCatConversionDetail
    {
        public int id { get; set; }
        public string scheme_type { get; set; }
        public string source { get; set; }
        public string mis_sub_category { get; set; }
        public string mis_category { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_from { get; set; }
        [DataType(DataType.Date)]
        public DateTime? valid_upto { get; set; }
    }

    public class SchemeCatConversioSearch
    {
        public string scheme_type { get; set; }
        public string quarter { get; set; }
        public string search_text { get; set; }

    }


}