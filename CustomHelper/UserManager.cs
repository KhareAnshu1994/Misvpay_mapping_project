using Mapping_Solution.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mapping_Solution.CustomHelper
{
    public class UserManager
    {
        public static LoginDetails User
        {
            get
            {
                return JsonConvert.DeserializeObject<LoginDetails>(Convert.ToString(HttpContext.Current.Session["UserDetails"]));
            }
        }
    }
}