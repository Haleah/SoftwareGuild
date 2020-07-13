﻿using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars2.UI.Models
{
    public class AdminAddVehicleVM
    {
        public AdminAddVehicleVM()
        {
            Form = new AdminAddVehicleCM();
            AvailableMakes = new List<SelectListItem>();
            AvailableModels = new List<SelectListItem>();
            AvailableBodyStyle = new List<SelectListItem>();
            AvailableColor = new List<SelectListItem>();
            AvailableInterior = new List<SelectListItem>();
            AvailableType = new List<SelectListItem>();
        }

        public AdminAddVehicleCM Form { get; set; }
        public List<SelectListItem> AvailableMakes { get; set; }
        public List<SelectListItem> AvailableModels { get; set; }
        public List<SelectListItem> AvailableBodyStyle { get; set; }
        public List<SelectListItem> AvailableColor { get; set; }
        public List<SelectListItem> AvailableInterior { get; set; }
        public List<SelectListItem> AvailableType { get; set; }

        public void Type()
        {
            AvailableType = new List<SelectListItem>
            {
                new SelectListItem{ Text = "--", Value = "" },
                new SelectListItem{ Text="New", Value = "True" },
                new SelectListItem{ Text="Used", Value = "False" },
            };
        }

        public void BodyStyles()
        {
            AvailableBodyStyle = new List<SelectListItem>
            {
                new SelectListItem{ Text = "--", Value = "" },
                new SelectListItem{ Text="Car", Value = "Car" },
                new SelectListItem{ Text="SUV", Value = "SUV" },
                new SelectListItem{ Text="Truck", Value = "Truck"},
                new SelectListItem{ Text="Van", Value = "Van"},
            };
        }

        public void Colors()
        {
            AvailableColor = new List<SelectListItem>
            {
                new SelectListItem{ Text = "--", Value = "" },
                new SelectListItem{ Text="Black", Value = "Black" },
                new SelectListItem{ Text="Grey", Value = "Grey" },
                new SelectListItem{ Text="White", Value = "White"},
                new SelectListItem{ Text="Blue", Value = "Blue"},
                new SelectListItem{ Text="Red", Value = "Red"},
            };
        }

        public void Interiors()
        {
            AvailableInterior = new List<SelectListItem>
            {
                new SelectListItem{ Text = "--", Value = "" },
                new SelectListItem{ Text="Black", Value = "Black" },
                new SelectListItem{ Text="Grey", Value = "Grey" },
                new SelectListItem{ Text="White", Value = "White"},
                new SelectListItem{ Text="Beige", Value = "Beige"},
                new SelectListItem{ Text="Tan", Value = "Tan"},
            };
        }

        public void SetAvailableMakes(List<Makes> makes)
        {
            AvailableMakes.Add(new SelectListItem() { Text = "--", Value = "" });
            foreach (var make in makes)
            {
                AvailableMakes.Add(new SelectListItem() { Text = make.Make, Value = make.MakeId.ToString() });
            }
        }

        public void SetAvailableModels(List<VehicleModels> models)
        {
            AvailableModels.Add(new SelectListItem() { Text = "--", Value = "" });
            foreach (var model in models)
            {
                AvailableModels.Add(new SelectListItem { Text = model.Model, Value = model.ModelId.ToString() });
            }
        }
    }

    public class AdminAddVehicleCM
    {
        public string Make { get; set; }
        public int MakeId { get; set; }
        public string Model { get; set; }
        public int ModelId { get; set; }
        public string Type { get; set; }
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
        //public byte[] Image { get; set; } Is this right?
    }
}