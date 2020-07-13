using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model.Tables
{
    public class Vehicles
    {
        public int VehicleId { get; set; }
        public string Vin { get; set; }
        public string Year { get; set; }
        public string BodyStyle { get; set; }
        public string Transmission { get; set; }
        public bool Type { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public string Description { get; set; }
        public decimal Msrp { get; set; }
        public decimal SalePrice { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        [Required]
        public int MakeId { get; set; }
        [Required]
        public int ModelId { get; set; }
    }
}
