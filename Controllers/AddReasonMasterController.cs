using Mapping_Solution.CustomHelper;
using Mapping_Solution.DataAccessLayer.DAL;
using Mapping_Solution.DataAccessLayer.InterfaceDAL;
using Mapping_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mapping_Solution.Controllers
{
    [CustomAuthorize]
    public class AddReasonMasterController : Controller
    {
        // GET: AddReasonMaster
       /* IdalAddReasonMaster add = new DalAddReasonMaster();*/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult create(AddReasonMaster emp)
        {
            IdalAddReasonMaster add = new DalAddReasonMaster();
            return Json(add.AddReasonMaster(emp));
        }
    }
}