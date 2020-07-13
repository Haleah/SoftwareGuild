using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars2.UI.ViewModel
{
    public class AdminSpecialsVM
    {
        public AdminSpecialsVM()
        {
            Form = new AdminSpecialsCM();
        }

        public int SpecialId { get; set; }
        public AdminSpecialsCM Form { get; set; }
        public List<Specials> Specials { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class AdminSpecialsCM
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}