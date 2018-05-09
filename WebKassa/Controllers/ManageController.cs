using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebKassa.Models;
using WebKassa.Models.DataSetKassaTableAdapters;

namespace WebKassa.Controllers
{
    public class ManageController : Controller
    {
        ENERGO_GREntities energo = new ENERGO_GREntities();

        // GET: Manage
        public ActionResult Payment(int v_abon_id)
        {
            DataSetKassa dsKassa = new DataSetKassa();
            PROC_CASHIER_SERVICESTableAdapter procTabAdap = new PROC_CASHIER_SERVICESTableAdapter();
            procTabAdap.Fill(dsKassa.PROC_CASHIER_SERVICES, v_abon_id, null, null);
            var kassa = dsKassa.PROC_CASHIER_SERVICES.AsEnumerable().Select(k => new KassaModel { RIS_ACTIVE= k.RIS_ACTIVE, RNAME= k.RNAME, RTARIFSTR= k.RTARIFSTR, BALANCE= k.BALANCE, RSUPPLIER_NAME= k.RSUPPLIER_NAME });
            return View(kassa);
        }
    }
}