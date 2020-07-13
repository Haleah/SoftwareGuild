using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars2.UI.ViewModel
{
    public class AdminEditEmployeeVM
    {
            public AdminEditEmployeeVM()
            {
                Form = new AdminEditUserCM();
                AvailableRole = new List<SelectListItem>();
            }

        public AdminEditUserCM Form { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public IEnumerable<SelectListItem> AvailableRole { get; set; }

        public void Roles()
        {
            AvailableRole = new List<SelectListItem>
            {
                new SelectListItem{ Text = "--", Value = "" },
                new SelectListItem{ Text="Admin", Value = "True" },
                new SelectListItem{ Text="Sales", Value = "False" },
            };
        }
    }

    public class AdminEditUserCM
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public bool Role { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}