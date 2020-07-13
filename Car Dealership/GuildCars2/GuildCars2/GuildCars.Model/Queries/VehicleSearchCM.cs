using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model.Queries
{
    public class VehicleSearchCM
    {
            public string Input { get; set; }
            //public string Make { get; set; }
            //public string Model { get; set; }
            //public string Year { get; set; }
            public int? PriceMin { get; set; }
            public int? PriceMax { get; set; }
            public int? YearMin { get; set; }
            public int? YearMax { get; set; }
    }
}
