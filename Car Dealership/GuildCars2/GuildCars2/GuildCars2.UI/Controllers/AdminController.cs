using GuildCars.Data.ADO;
using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using GuildCars2.UI.Models;
using GuildCars2.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars2.UI.Controllers
{
    //[Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Vehicle()
        {
            AdminVehiclesVM VM = new AdminVehiclesVM();
            var repo = new VehicleRepositoryADO();
            VehicleSearchCM form = new VehicleSearchCM();
            VM.Vehicles = repo.Search(form, null);
            VM.SetYear();
            VM.SetPrice();

            return View(VM);
        }

        [HttpPost]
        public ActionResult Vehicle(VehicleSearchCM form)
        {
            if (ModelState.IsValid)
            {
                AdminVehiclesVM VM = new AdminVehiclesVM();
                var repo = new VehicleRepositoryADO();
                VM.Vehicles = repo.Search(form, null);
                VM.SetYear();
                VM.SetPrice();

                VM.Form = form;
                return View(VM);
                
            }
            else
            {
                AdminVehiclesVM VM = new AdminVehiclesVM();
                var repo = new VehicleRepositoryADO();
                VM.Vehicles = repo.Search(form, null);
                VM.SetYear();
                VM.SetPrice();

                VM.Form = form;
                return View(VM);

            }
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            AdminAddVehicleVM VM = new AdminAddVehicleVM();
            var repo = new VehicleRepositoryADO();
            var modelRepo = new VehicleModelRepositoryADO();
            var makeRepo = new MakeRepositoryADO();
            VM.SetAvailableMakes(makeRepo.ReadAllMakes());
            VM.SetAvailableModels(modelRepo.ReadAllModel());
            VM.BodyStyles();
            VM.Colors();
            VM.Interiors();
            VM.Type();
            return View(VM);
        }

        [HttpPost]
        public ActionResult AddVehicle(AdminAddVehicleCM form)
        {
            if (ModelState.IsValid)
            {
                Vehicles vehicle = new Vehicles();
                var repo = new VehicleRepositoryADO();
                var modelRepo = new VehicleModelRepositoryADO();
                var makeRepo = new MakeRepositoryADO();
                AdminAddVehicleVM VM = new AdminAddVehicleVM();
                vehicle.MakeId = form.MakeId;
                //vehicle.Make = form.Make;
                vehicle.ModelId = form.ModelId;
                //vehicle.Model = form.Model;
                vehicle.Vin = form.Vin;
                vehicle.Year = form.Year;
                vehicle.BodyStyle = form.BodyStyle;
                vehicle.Transmission = form.Transmission;
                vehicle.Type = form.Type == "new";
                vehicle.Mileage = form.Mileage;
                vehicle.Color = form.Color;
                vehicle.Interior = form.Interior;
                vehicle.Msrp = form.Msrp;
                vehicle.Description = form.Description;
                vehicle.SalePrice = form.SalePrice;
                VM.SetAvailableMakes(makeRepo.ReadAllMakes());
                VM.SetAvailableModels(modelRepo.ReadAllModel());
                VM.BodyStyles();
                VM.Colors();
                VM.Interiors();
                VM.Type();
                repo.CreateVehicle(vehicle);


                return RedirectToAction("Vehicle");
            }
            else
            {
                AdminAddVehicleVM VM = new AdminAddVehicleVM();
                var modelRepo = new VehicleModelRepositoryADO();
                var makeRepo = new MakeRepositoryADO();
                VM.SetAvailableMakes(makeRepo.ReadAllMakes());
                VM.SetAvailableModels(modelRepo.ReadAllModel());
                VM.BodyStyles();
                VM.Colors();
                VM.Interiors();
                VM.Type();

                VM.Form = form;
                return View(VM);

            }
        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            AdminEditVehicleVM VM = new AdminEditVehicleVM();
            var repo = new VehicleRepositoryADO();
            var modelRepo = new VehicleModelRepositoryADO();
            var makeRepo = new MakeRepositoryADO();
            var vehicles = repo.ReadByVehicleId(id);
            VM.Form.VehicleId = vehicles.VehicleId;
            VM.Form.Make = vehicles.Make;
            VM.Form.Model = vehicles.Model;
            VM.Form.Type = vehicles.Type;
            VM.Form.BodyStyle = vehicles.BodyStyle;
            VM.Form.Year = vehicles.Year;
            VM.Form.Transmission = vehicles.Transmission;
            VM.Form.Color = vehicles.Color;
            VM.Form.Interior = vehicles.Interior;
            VM.Form.Mileage = vehicles.Mileage;
            VM.Form.Vin = vehicles.Vin;
            VM.Form.Msrp = vehicles.Msrp;
            VM.Form.SalePrice = vehicles.SalePrice;
            VM.Form.Description = vehicles.Description;
            VM.SetAvailableMakes(makeRepo.ReadAllMakes());
            VM.SetAvailableModels(modelRepo.ReadAllModel());
            VM.BodyStyles();
            VM.Colors();
            VM.Interiors();
            VM.Types();

            return View(VM);
        }

        [HttpPost]
        public ActionResult EditVehicle(AdminEditVehicleCM form)
        {
            if (ModelState.IsValid)
            {
                AdminEditVehicleVM VM = new AdminEditVehicleVM();
                var repo = new VehicleRepositoryADO();
                var modelRepo = new VehicleModelRepositoryADO();
                var makeRepo = new MakeRepositoryADO();
                var vehicle = repo.ReadByVehicleId(form.VehicleId);
                vehicle.MakeId = form.MakeId;
                vehicle.ModelId = form.ModelId;
                vehicle.Vin = form.Vin;
                vehicle.Year = form.Year;
                vehicle.BodyStyle = form.BodyStyle;
                vehicle.Transmission = form.Transmission;
                vehicle.Type = form.Type;
                vehicle.Mileage = form.Mileage;
                vehicle.Color = form.Color;
                vehicle.Interior = form.Interior;
                vehicle.Interior = form.Interior;
                vehicle.Msrp = form.Msrp;
                vehicle.Description = form.Description;
                vehicle.SalePrice = form.SalePrice;
                VM.SetAvailableMakes(makeRepo.ReadAllMakes());
                VM.SetAvailableModels(modelRepo.ReadAllModel());
                VM.BodyStyles();
                VM.Colors();
                VM.Interiors();
                VM.Types();
                repo.UpdateVehicle(vehicle);
                return RedirectToAction("Vehicle");
            }
            else
            {
                AdminEditVehicleVM VM = new AdminEditVehicleVM();
                var vehicle = new VehicleRepositoryADO();
                var make = new MakeRepositoryADO();
                var model = new VehicleModelRepositoryADO();

                VM.Form = form;
                return View(VM);

            }
        }

        [HttpGet]
        public ActionResult Employee()
        {
            AdminEmployeeVM VM = new AdminEmployeeVM();
            var repo = new EmployeeRepositoryADO();
            VM.Users = repo.ReadAllEmployees();
            return View(VM);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            AdminAddEmployeeVM VM = new AdminAddEmployeeVM();
            var repo = new EmployeeRepositoryADO();
            VM.Roles();

            return View(VM);
        }

        [HttpPost]
        public ActionResult AddEmployee(AdminAddUserCM form)
        {
            if (ModelState.IsValid)
            {
                Employees employee = new Employees();
                var repo = new EmployeeRepositoryADO();
                employee.FirstName = form.FirstName;
                employee.LastName = form.LastName;
                employee.Email = form.Email;
                employee.Role = form.Role.ToString() == "Admin";
                repo.CreateEmployee(employee);

                return RedirectToAction("Employee");
            }
            else
            {
                AdminAddEmployeeVM VM = new AdminAddEmployeeVM();
                var repo = new EmployeeRepositoryADO();

                VM.Form = form;
                return View(VM);

            }
        }

        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            AdminEditEmployeeVM VM = new AdminEditEmployeeVM();
            var repo = new EmployeeRepositoryADO();
            var currentEmployee = repo.ReadByEmployeeId(id);
            VM.Form.EmployeeId = currentEmployee.EmployeeId;
            VM.Form.LastName = currentEmployee.LastName;
            VM.Form.FirstName = currentEmployee.FirstName;
            VM.Form.Email = currentEmployee.Email;
            VM.Form.Role = currentEmployee.Role;

            return View(VM);
        }

        [HttpPost]
        public ActionResult EditEmployee(AdminEditUserCM form)
        {
            if (ModelState.IsValid)
            {

                var repo = new EmployeeRepositoryADO();
                var employee = repo.ReadByEmployeeId(form.EmployeeId);
                employee.FirstName = form.FirstName;
                employee.LastName = form.LastName;
                employee.Email = form.Email;
                employee.Role = form.Role;
                repo.UpdateEmployee(employee);
                return RedirectToAction("Vehicle");
            }
            else
            {
                AdminEditEmployeeVM VM = new AdminEditEmployeeVM();
                var repo = new EmployeeRepositoryADO();

                VM.Form = form;
                return View(VM);

            }
        }

        [HttpGet]
        public ActionResult Specials()
        {
            AdminSpecialsVM VM = new AdminSpecialsVM();
            var repo = new SpecialRepositoryADO();
            VM.Specials = repo.ReadAllSpecials();
            return View(VM);
        }

        [HttpPost]
        public ActionResult Specials(AdminSpecialsCM form, int id)
        {
            if (ModelState.IsValid)
            {

                AdminSpecialsVM VM = new AdminSpecialsVM();
                Specials special = new Specials();
                var repo = new SpecialRepositoryADO();
                special.Title = form.Title;
                special.Description = form.Description;
                repo.CreateSpecial(special);
                repo.DeleteSpecial(special);

                //return View(VM);
                return RedirectToAction("Specials");
            }
            else
            {
                AdminSpecialsVM VM = new AdminSpecialsVM();
                var repo = new SpecialRepositoryADO();

                VM.Form = form;
                return View(VM);

            }
        }
    }
}