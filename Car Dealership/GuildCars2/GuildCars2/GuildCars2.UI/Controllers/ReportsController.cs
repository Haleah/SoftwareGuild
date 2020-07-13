using GuildCars.Data.ADO;
using GuildCars.Model.Queries;
using GuildCars2.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars2.UI.Controllers
{
    public class ReportsController : Controller
    {
        [HttpGet]
        public ActionResult Sales()
        {
            ReportsSalesVM VM = new ReportsSalesVM();
            var repo = new SalesReportRepositoryADO();

            return View(VM);
        }

        [HttpPost]
        public ActionResult Sales(SalesReportCM form)
        {
            if (ModelState.IsValid)
            {
                ReportsSalesVM VM = new ReportsSalesVM();
                var repo = new SalesReportRepositoryADO();

                VM.Form = form;
                return View(VM);
            }
            else
            {
                ReportsSalesVM VM = new ReportsSalesVM();
                var repo = new SalesReportRepositoryADO();

                VM.Form = form;
                return View(VM);

            }

        }


        [HttpGet]
        public ActionResult Inventory()
        {
            ReportsInventoryVM VM = new ReportsInventoryVM();
            var vehicle = new VehicleRepositoryADO();
            VM.NewVehicles = vehicle.ReadAllVehicle().Where(m => m.Type == true).ToList();
            VM.UsedVehicles = vehicle.ReadAllVehicle().Where(m => m.Type == false).ToList();
            return View(VM);
        }
    }
}