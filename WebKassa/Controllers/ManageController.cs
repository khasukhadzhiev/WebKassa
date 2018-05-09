using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebKassa.Models;

namespace WebKassa.Controllers
{
    public class ManageController : Controller
    {
        ENERGO_GREntities energo = new ENERGO_GREntities();

        // GET: Manage
        public ActionResult Payment(int v_abon_id)
        {
            return View();
        }
    }
}