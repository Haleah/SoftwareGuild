using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars2.UI.ViewModel
{
    public class ReportsInventoryVM
    {
        public List<Vehicles> NewVehicles { get; set; }
        public List<Vehicles> UsedVehicles { get; set; }
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Count { get; set; }
        public decimal StockValue { get; set; }
        public bool Type { get; set; }
    }
}