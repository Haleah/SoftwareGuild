using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars2.UI.Models
{
    public class InventoryDetailsVM
    {
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
    }
}