using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars2.UI.ViewModel
{
    public class AdminVehiclesVM
    {
        public AdminVehiclesVM()
        {
            VehicleSearchCM Form = new VehicleSearchCM();
        }

        public VehicleSearchCM Form { get; set; }
        public List<Vehicles> Vehicles { get; set; }
        public List<SelectListItem> PriceMin { get; set; }
        public List<SelectListItem> PriceMax { get; set; }
        public List<SelectListItem> YearMin { get; set; }
        public List<SelectListItem> YearMax { get; set; }

        public int VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public bool Type { get; set; }
        public string BodyStyle { get; set; }
        public string Year { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public int Mileage { get; set; }
        public string Vin { get; set; }
        public decimal Msrp { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }

        public void SetYear()
        {
            YearMin = new List<SelectListItem>();
            YearMax = new List<SelectListItem>();
            YearMin.Add(new SelectListItem() { Text = "--", Value = "" });
            YearMax.Add(new SelectListItem() { Text = "--", Value = "" });
            for (int i = 2000; i < 2022; i++)
            {
                YearMin.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
                YearMax.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }
        }

        public void SetPrice()
        {
            PriceMin = new List<SelectListItem>();
            PriceMax = new List<SelectListItem>();
            PriceMin.Add(new SelectListItem() { Text = "--", Value = "" });
            PriceMax.Add(new SelectListItem() { Text = "--", Value = "" });
            for (int i = 0; i < 50000; i= i+5000)
            {
                PriceMin.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
                PriceMax.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }
        }
        
    }
}