using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars2.UI.ViewModel
{
    public class HomeIndexVM
    {
        public List<Specials> Specials { get; set; }
        public List<Vehicles> Vehicles { get; set; }
    }

}