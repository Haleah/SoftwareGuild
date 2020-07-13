using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model.Tables
{
    public class Makes
    {
        public int MakeId { get; set; }
        public string Make { get; set; }
        public DateTime DateAdded { get; set; }
        //[Required]
        //public virtual VehicleModels ModelId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
