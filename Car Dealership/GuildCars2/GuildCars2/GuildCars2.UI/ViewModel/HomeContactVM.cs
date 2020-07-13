using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars2.UI.ViewModel
{
    public class HomeContactVM
    {
        public HomeContactVM()
        {
            Form = new HomeContactCM();
        }

        public HomeContactCM Form { get; set; }
    }

    public class HomeContactCM
    {
        public int VehicleId { get; set; }
        public string Vin { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}