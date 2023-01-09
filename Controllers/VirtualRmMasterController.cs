﻿using Mapping_Solution.CustomHelper;
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

    public class VirtualRmMasterController : Controller
    {
        // GET: VirtualRmMaster
        IDalVirtualRmMaster vm = new DalVirtualRmMaster();
        IdalChannelmaster m = new DalChannelmaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();


        public ActionResult Index(VirtualRmMasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = m.GetChannelCode();
            ViewBag.channelcode = new SelectList(re, "channel_code", "channel_code");

            var a = vm.GetVirtualMasterDetails(e);
            return View(a);
        }
        public ActionResult _VirtualRmMasterView(VirtualRmMasterSearch e)
        {
            var a = vm.GetVirtualMasterDetails(e);
            return PartialView("_VirtualRmMasterView", a);
        }
    }
}