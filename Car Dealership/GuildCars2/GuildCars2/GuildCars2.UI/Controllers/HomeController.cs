using GuildCars.Data.ADO;
using GuildCars.Data.Factory;
using GuildCars.Model.Tables;
using GuildCars2.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars2.UI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            HomeIndexVM VM = new HomeIndexVM();

            var repo = new SpecialRepositoryADO();
            VM.Specials = repo.ReadAllSpecials();

            var vRepo = new VehicleRepositoryADO();
            VM.Vehicles = vRepo.ReadAllVehicle();
            


            return View(VM);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            HomeSpecialsVM VM = new HomeSpecialsVM();

            var repo = new SpecialRepositoryADO();
            VM.Specials = repo.ReadAllSpecials();

            return View(VM);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            HomeContactVM VM = new HomeContactVM();
            var repo = new ContactRepositoryADO();
            return View(VM);
        }

        [HttpPost]
        public ActionResult Contact(HomeContactCM form)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact();
                var repo = new ContactRepositoryADO();
                contact.VehicleId = form.VehicleId;
                contact.Vin = form.Vin;
                contact.Email = form.Email;
                contact.Name = form.Name;
                contact.PhoneNumber = form.PhoneNumber;
                contact.Message = form.Message;
                repo.CreateContact(contact);

                return RedirectToAction("Index");
            }
            else
            {
                HomeContactVM VM = new HomeContactVM();
                var repo = new ContactRepositoryADO();
                VM.Form = form;
                return View(VM);
            }



        }
    }
}
