using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars2.UI.ViewModel
{
    public class AdminEmployeeVM
    {
        
        public List<Employees> Users { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

    }
}