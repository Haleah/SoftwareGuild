using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model.Tables
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int VehicleId { get; set; }
        public string Vin { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
