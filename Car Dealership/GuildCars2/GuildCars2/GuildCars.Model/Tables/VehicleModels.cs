using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model.Tables
{
    public class VehicleModels
    {
        public int ModelId { get; set; }
        public string Model { get; set; }
        public DateTime DateAdded { get; set; }
        public string Make { get; set; }
        [Required]
        public int MakeId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
