using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mapping_Solution.CustomHelper;
using Mapping_Solution.DataAccessLayer.DAL;
using Mapping_Solution.DataAccessLayer.InterfaceDAL;
using Mapping_Solution.Models;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;

namespace Mapping_Solution.Controllers
{
    public class LoginController : Controller
    {
        IdalLogin login = new DalLogin();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        #region For Employee Login
        [HttpPost]
        public ActionResult LoginCheck(LoginDetails e, MappingAceesEditDetails map)
        {
            var a = login.GetEmpLogin(e);

            foreach (var item in a)
            {

                if (item.UserName != null)
                {
                    map.employee_code = item.Employee_id;
                    var mapdetails = login.GetMappingAceessEditDetails(map);
                    item.mapping_details_edit = mapdetails;

                    item.Login_Time = DateTime.Now;
                    string UserDetails = JsonConvert.SerializeObject(item);
                    Session["UserDetails"] = UserDetails;

                    return RedirectToAction("Index", "Main");
                }
            }


            TempData["Error"] = "Invalid Employee Id or Password";
            return RedirectToAction("Index", "Login");
        }

    }
    #endregion

}
