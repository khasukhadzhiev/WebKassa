using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebKassa.Models;

namespace WebKassa.Controllers
{
    //Данный контроллер нужен лишь для поиска. Все корректирующие действия производятся в контроллере Manage    
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

        //возвращает список домов в зависимости от улицы
        [HttpPost]
        public ActionResult Build(int street)
        {
            SelectList builds = new SelectList(energo.VW_BUILDINGS.Where(s => s.STREET_ID == street).Select(t => t), "ID", "HOUSE");
            return PartialView(builds);
        }

        //Результат поиска
        [HttpPost]
        public ActionResult SearchResult(int region, int town, int street, int build, int kvartira, string licShet, string fio)
        {
            if (licShet != "-1")
            {
                var resultsLicShet = energo.V_ABONS.AsParallel().Where(l => l.G_LICSCHET.ToUpper().Contains(licShet.ToUpper())).Select(l => l);
                return PartialView(resultsLicShet);
            }
            else if(fio != "-1")
            {
                var resultsFio = energo.V_ABONS.AsParallel().Where(f => f.NAME.ToUpper().Contains(fio.ToUpper())).Select(f => f);
                return PartialView(resultsFio);
            }
            else
            {
                var result = energo.V_ABONS.AsQueryable();

                if (region != -1)
                    result = result.Where(r => r.REGION_ID == region);

                if (town != -1)
                    result = result.Where(t => t.TOWN_ID == town);

                if (street != -1)
                    result = result.Where(t => t.STREET_ID == street);

                if (build != -1)
                    result = result.Where(t => t.BUILDING_ID == build);

                if (kvartira != -1)
                    result = result.Where(t => t.APPARTS == kvartira);


                return PartialView(result.OrderBy(o=>o.ID));
            }
        }                                
    }                                    
}                                        
                                         