using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model.Tables
{
    public class Purchases
    {
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string StreetOne { get; set; }
        public string StreetTwo { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public List<string> State { get; set; }
        public string Phone { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseType { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal SalePrice { get; set; }
        [Required]
        public int VehicleId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
