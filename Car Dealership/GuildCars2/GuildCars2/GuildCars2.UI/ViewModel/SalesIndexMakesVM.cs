using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars2.UI.ViewModel
{
    public class SalesIndexMakesVM
    {
        public SalesIndexMakesVM()
        {
            Form = new SalesIndexMakesCM();
        }


        public List<Makes> Makes { get; set; }
        public SalesIndexMakesCM Form { get; set; }
        public string Make { get; set; }
        public DateTime DateAdded { get; set; }
        public string Employee { get; set; }
    }
    public class SalesIndexMakesCM
    {
        public string Make { get; set; }
        public DateTime DateAdded { get; set; }
        public int EmployeeId { get; set; }
    }
}