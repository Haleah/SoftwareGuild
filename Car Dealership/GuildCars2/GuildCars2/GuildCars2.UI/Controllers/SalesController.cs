using GuildCars.Data.ADO;
using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using GuildCars2.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars2.UI.Controllers
{
    //[Authorize(Roles = "Sales")]

    public class SalesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            SalesIndexVM VM = new SalesIndexVM();
            var repo = new VehicleRepositoryADO();
            VehicleSearchCM form = new VehicleSearchCM();
            VM.Vehicles = repo.Search(form, null);
            VM.SetYear();
            VM.SetPrice();

            return View(VM);
        }

        [HttpPost]
        public ActionResult Index(VehicleSearchCM form)
        {
            if (ModelState.IsValid)
            {
                SalesIndexVM VM = new SalesIndexVM();
                var repo = new VehicleRepositoryADO();
                VM.Vehicles = repo.Search(form, null);
                VM.SetYear();
                VM.SetPrice();

                VM.Form = form;
                return View(VM);
            }
            else
            {
                SalesIndexVM VM = new SalesIndexVM();
                var repo = new VehicleRepositoryADO();
                VM.Vehicles = repo.Search(form, null);
                VM.SetYear();
                VM.SetPrice();

                VM.Form = form;
                return View(VM);
                
            }
        }

        [HttpGet]
        public ActionResult Purchase(int id)
        {
            SalesIndexPuchaseVM VM = new SalesIndexPuchaseVM();
            var vehicle = new VehicleRepositoryADO();
            var vehicles = vehicle.ReadByVehicleId(id);
            VM.Make = vehicles.MakeId.ToString();
            VM.Make = vehicles.Make;
            VM.Model = vehicles.ModelId.ToString();
            VM.Model = vehicles.Model;
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
            VM.States();
            VM.PurchaseTypes();

            return View(VM);
        }

        [HttpPost]
        public ActionResult Purchase(SalesIndexPuchaseCM form)
        {
            if (ModelState.IsValid)
            {

                Purchases purchase = new Purchases();
                var repo = new PurchaseRepositoryADO();
                var vRepo = new VehicleRepositoryADO();
                purchase.VehicleId = form.VehicleId;
                purchase.Phone = form.Phone;
                purchase.Email = form.Email;
                purchase.StreetOne = form.StreetOne;
                purchase.StreetTwo = form.StreetTwo;
                purchase.City = form.City;
                purchase.ZipCode = form.Zipcode;
                purchase.State = form.State;
                purchase.PurchasePrice = form.PurchasePrice;
                purchase.PurchaseType = form.PurchaseType;
                purchase.EmployeeId = form.EmployeeId;
                repo.CreatePurchase(purchase);

                return RedirectToAction("Index");
            }
            else
            {
                SalesIndexPuchaseVM VM = new SalesIndexPuchaseVM();
                var vehicle = new VehicleRepositoryADO();
                VM.Vehicles = vehicle.ReadAllVehicle();

                VM.Form = form;
                return View(VM);

            }
        }

        [HttpGet]
        public ActionResult AddMake()
        {
            SalesIndexMakesVM VM = new SalesIndexMakesVM();
            var makes = new MakeRepositoryADO();
            VM.Makes = makes.ReadAllMakes();
            //User.Identity.Name;
            return View(VM);
        } 

        [HttpPost]
        public ActionResult AddMake(SalesIndexMakesCM form)
        {
            if (ModelState.IsValid)
            {
                Makes make = new Makes();
                var repo = new MakeRepositoryADO();
                make.Make = form.Make;
                make.DateAdded = form.DateAdded;
                make.EmployeeId = form.EmployeeId;
                form.EmployeeId = 1;

                repo.CreateMake(make);

                return RedirectToAction("Index");
            }
            else
            {
                SalesIndexMakesVM VM = new SalesIndexMakesVM();
                var makes = new MakeRepositoryADO();
                VM.Makes = makes.ReadAllMakes();

                VM.Form = form;
                return View(VM);

            }
        }

        [HttpGet]
        public ActionResult AddModel()
        {
            SalesIndexModelsVM VM = new SalesIndexModelsVM();
            var models = new VehicleModelRepositoryADO();
            var makeRepo = new MakeRepositoryADO();
            VM.SetAvailableMakes(makeRepo.ReadAllMakes());
            VM.Models = models.ReadAllModel();

            return View(VM);
        }

        [HttpPost]
        public ActionResult AddModel(SalesIndexModelsCM form)
        {
            if (ModelState.IsValid)
            {
                VehicleModels model = new VehicleModels();
                var repo = new VehicleModelRepositoryADO();
                model.Model = form.Model;
                model.Make = form.Make;
                model.DateAdded = form.DateAdded;
                model.EmployeeId = form.EmployeeId;
                repo.CreateModel(model);

                return RedirectToAction("Index");
            }
            else
            {
                SalesIndexModelsVM VM = new SalesIndexModelsVM();
                var models = new VehicleModelRepositoryADO();
                VM.Models = models.ReadAllModel();

                VM.Form = form;
                return View(VM);

            }
        }
    }
}