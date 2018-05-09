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
        DataSetKassa dsKassa = new DataSetKassa();

        // GET: Manage
        public ActionResult Payment(int v_abon_id)
        {
            
            PROC_CASHIER_SERVICESTableAdapter procTabAdap = new PROC_CASHIER_SERVICESTableAdapter();
            procTabAdap.Fill(dsKassa.PROC_CASHIER_SERVICES, v_abon_id, null, null);
            var kassa = dsKassa.PROC_CASHIER_SERVICES.AsEnumerable().Select(k => new KassaModel {ID=k.ID, RIS_ACTIVE= k.RIS_ACTIVE, RNAME= k.RNAME, RTARIFSTR = k.RTARIFSTR?.ToString(), BALANCE= k.BALANCE, RSUPPLIER_NAME= k.RSUPPLIER_NAME });
            return View(kassa);
        }

        public ActionResult SavePrint()
        {
            return View();
        }

        //Ниже идут методы для Модуля Показания

        public ActionResult Meters(int dogovor_id)
        {
            MetersTableAdapter mtr = new MetersTableAdapter();
            mtr.Fill(dsKassa.Meters, dogovor_id);
            SelectList metersList = new SelectList(dsKassa.Meters.AsEnumerable(), "METER_ID", "METER_NUM");
            ViewBag.MetersList = metersList;
            ViewBag.DogovorId = dogovor_id;
            return View();
        }

        public ActionResult PaysInd(int? dogovor_id, int? meter_id)
        {
            PROC_CASHIER_PAYSINDTableAdapter paysInd = new PROC_CASHIER_PAYSINDTableAdapter();
            paysInd.Fill(dsKassa.PROC_CASHIER_PAYSIND, dogovor_id, meter_id);
            
            return PartialView(dsKassa.PROC_CASHIER_PAYSIND.AsEnumerable());
        }
    }
}