using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars2.UI.ViewModel
{
    public class SalesIndexModelsVM
    {
        public SalesIndexModelsVM()
        {
            Form = new SalesIndexModelsCM();
            AvailableMakes = new List<SelectListItem>();
        }

        public List<VehicleModels> Models { get; set; }
        public SalesIndexModelsCM Form { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime DateAdded { get; set; }
        public string Employee { get; set; }
        public List<SelectListItem> AvailableMakes { get; set; }


        public void SetAvailableMakes(List<Makes> makes)
        {
            AvailableMakes.Add(new SelectListItem() { Text = "--", Value = "" });
            foreach (var make in makes)
            {
                AvailableMakes.Add(new SelectListItem() { Text = make.Make, Value = make.MakeId.ToString() });
            }
        }
    }

    public class SalesIndexModelsCM
    {
        public List<string> Makes { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int MakeId { get; set; }
        public DateTime DateAdded { get; set; }
        public int EmployeeId { get; set; }
    }
}