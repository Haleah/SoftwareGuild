using DvdLibrary2.Data;
using DvdLibrary2.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DvdLibrary2.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var testfact = DvdRepositoryFactory.ChooseRepo();
            List<Dvd> currentDvd = new List<Dvd>();
            try
            {
                currentDvd = testfact.ReadAllDvd();
            }
            catch
            {
                throw new Exception("Wrong!");
            }
            return View(currentDvd);
        }

    }
}