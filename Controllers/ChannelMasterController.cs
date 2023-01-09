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
    public class ChannelMasterController : Controller
    {
        // GET: ChannelMaster
        IdalChannelmaster m = new DalChannelmaster();
        IDALAddEmpDropDown drop = new DALAddEmpDropDown();

        public ActionResult Index(ChannelmasterSearch e)
        {
            var qt = drop.GetQuarter();
            ViewBag.Quarter = new SelectList(qt, "SelectQuarter", "SelectQuarter");

            var re = m.GetChannelCode();
            ViewBag.channelcode = new SelectList(re, "channel_code", "channel_code");

            var a = m.Get_ChannelMaster_AllDetails(e);
            return View(a);
        }
        public ActionResult _ChannelMasterView(ChannelmasterSearch e)
        {
            var a = m.Get_ChannelMaster_AllDetails(e);
            return PartialView("_ChannelMasterView", a);
        }
    }
}