﻿
using Mapping_Solution.DataAccessLayer.InterfaceDAL;
using Mapping_Solution.DataAccessLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mapping_Solution.Models;
using Mapping_Solution.CustomHelper;

namespace Mapping_Solution.Controllers
{
    [CustomAuthorize]

    public class PincodeMasterController : Controller
    {
        // GET: Pincode_Master
        IdalPincode pin = new DalPincode();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(PincodeMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = pin.GetPinCode();
            ViewBag.pincode = new SelectList(re, "pincode", "pincode");

            var add = pin.ReadAllData(e);
            return View(add);
        }
        public ActionResult _PincodeView(PincodeMasterSearch e)
        {
            var add = pin.ReadAllData(e);
            return PartialView("_PincodeView", add);
        }
    }
}