using GuildCars.Data.ADO;
using GuildCars.Model.Queries;
using GuildCars2.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GuildCars2.UI.Controllers
{
    public class InventoryController : Controller
    {
        [HttpGet]
        public ActionResult Details(int id)
        {
            InventoryDetailsVM VM = new InventoryDetailsVM();
            var repo =  new VehicleRepositoryADO();
            var vehicles = repo.ReadByVehicleId(id);
            VM.VehicleId = vehicles.VehicleId;
            VM.Make = vehicles.MakeId.ToString();
            VM.Model = vehicles.ModelId.ToString();
            VM.Type = vehicles.Type;
            VM.BodyStyle = vehicles.BodyStyle;
            VM.Year = vehicles.Year;
            VM.Transmission = vehicles.Transmission;
            VM.Color = vehicles.Color;
            VM.Interior = vehicles.Interior;
            VM.Mileage = vehicles.Mileage;
            VM.Vin = vehicles.Vin;
            VM.Msrp = vehicles.Msrp;
            VM.SalePrice = vehicles.SalePrice;
            VM.Description = vehicles.Description;

            return View(VM);
        }

        [HttpGet]
        public ActionResult New()
        {
            InventoryNewVM VM = new InventoryNewVM();
            var repo = new VehicleRepositoryADO();
            VehicleSearchCM form = new VehicleSearchCM();
            VM.Vehicles = repo.Search(form, true);
            VM.SetYear();
            VM.SetPrice();

            return View(VM);
        }

        [HttpPost]
        public ActionResult New(VehicleSearchCM form)
        {
            if (ModelState.IsValid)
            {
                InventoryNewVM VM = new InventoryNewVM();
                var repo = new VehicleRepositoryADO();
                VM.Vehicles = repo.Search(form, true);
                VM.SetYear();
                VM.SetPrice();

                VM.Form = form;
                return View(VM);
            }
            else
            {
                InventoryNewVM VM = new InventoryNewVM();
                var repo = new VehicleRepositoryADO();
                VM.Vehicles = repo.Search(form, true);
                VM.SetYear();
                VM.SetPrice();

                VM.Form = form;
                return View(VM);

            }
        }

        [HttpGet]
        public ActionResult Used()
        {
            InventoryUsedVM VM = new InventoryUsedVM();
            VehicleSearchCM form = new VehicleSearchCM();
            var repo = new VehicleRepositoryADO();
            VM.Vehicles = repo.Search(form, false);
            VM.SetYear();
            VM.SetPrice();

            return View(VM);
        }

        [HttpPost]
        public ActionResult Used(VehicleSearchCM form)
        {
            if (ModelState.IsValid)
            {
                InventoryUsedVM VM = new InventoryUsedVM();
                var repo = new VehicleRepositoryADO();
                VM.Vehicles = repo.Search(form, false);
                VM.SetYear();
                VM.SetPrice();


                VM.Form = form;
                return View(VM);
            }
            else
            {
                InventoryUsedVM VM = new InventoryUsedVM();
                var repo = new VehicleRepositoryADO();
                VM.Vehicles = repo.Search(form, false);
                VM.SetYear();
                VM.SetPrice();

                VM.Form = form;
                return View(VM);

            }
        }
    }
    
}