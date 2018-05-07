using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebKassa.Models;

namespace WebKassa.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        ENERGO_GREntities energo = new ENERGO_GREntities();

        public ActionResult Index()
        {
            //создаю selectlist для формирования dropdownlist
            SelectList regions = new SelectList(energo.PAS_RREGION, "ID", "NAME");
            ViewBag.Regions = regions;
            return View();
        }


        //возвращает список нас.пунктов в зависимости от района
        [HttpPost]
        public ActionResult Town(int region)
        {
            SelectList towns = new SelectList(energo.PAS_RTOWN.Where(t=>t.CODE== region).Select(t=>t), "ID", "NAME");
            return PartialView(towns);
        }

        //возвращает список улиц в зависимости от нас.пункта
        [HttpPost]
        public ActionResult Street(int town)
        {
            SelectList streets = new SelectList(energo.RSTREETS.Where(s => s.TOWN_ID == town).Select(t => t), "ID", "STREET");
            return PartialView(streets);
        }
    }
}