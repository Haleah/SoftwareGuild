using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars2.UI.ViewModel
{
    public class SalesIndexPuchaseVM
    {
        public SalesIndexPuchaseVM()
        {
            Form = new SalesIndexPuchaseCM();
        }

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

        public List<Vehicles> Vehicles { get; set; }
        public SalesIndexPuchaseCM Form { get; set; }
        public Vehicles Vehicle { get; set; }
        public List<SelectListItem> State { get; set; }
        public List<SelectListItem> PurchaseType { get; set; }


        public void States()
        {
            State = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Alabama", Value = "AL" },
                    new SelectListItem { Text = "Alaska", Value = "AK" },
                    new SelectListItem { Text = "Arizona", Value = "AZ" },
                    new SelectListItem { Text = "Arkansas", Value = "AR" },
                    new SelectListItem { Text = "California", Value = "CA" },
                    new SelectListItem { Text = "Colorado", Value = "CO" },
                    new SelectListItem { Text = "Connecticut", Value = "CT" },
                    new SelectListItem { Text = "Delaware", Value = "DE" },
                    new SelectListItem { Text = "Florida", Value = "FL" },
                    new SelectListItem { Text = "Georgia", Value = "GA" },
                    new SelectListItem { Text = "Idaho", Value = "ID" },
                    new SelectListItem { Text = "Illinois", Value = "IL" },
                    new SelectListItem { Text = "Indiana", Value = "IN" },
                    new SelectListItem { Text = "Iowa", Value = "IA" },
                    new SelectListItem { Text = "Kansas", Value = "KS" },
                    new SelectListItem { Text = "Kentucky", Value = "KY" },
                    new SelectListItem { Text = "Louisiana", Value = "LA" },
                    new SelectListItem { Text = "Maine", Value = "ME" },
                    new SelectListItem { Text = "Maryland", Value = "MD" },
                    new SelectListItem { Text = "Massachusetts", Value = "MA" },
                    new SelectListItem { Text = "Michigan", Value = "MI" },
                    new SelectListItem { Text = "Minnesota", Value = "MN" },
                    new SelectListItem { Text = "Mississippi", Value = "MS" },
                    new SelectListItem { Text = "Missouri", Value = "MO" },
                    new SelectListItem { Text = "Montana", Value = "MT" },
                    new SelectListItem { Text = "Nebraska", Value = "NE" },
                    new SelectListItem { Text = "Nevada", Value = "NV" },
                    new SelectListItem { Text = "NewHampshire", Value = "NH" },
                    new SelectListItem { Text = "NewJersey", Value = "NJ" },
                    new SelectListItem { Text = "NewMexico", Value = "NM" },
                    new SelectListItem { Text = "NewYork", Value = "NY" },
                    new SelectListItem { Text = "NorthCarolina", Value = "NC" },
                    new SelectListItem { Text = "NorthDakota", Value = "ND" },
                    new SelectListItem { Text = "Ohio", Value = "OH" },
                    new SelectListItem { Text = "Oklahoma", Value = "OK" },
                    new SelectListItem { Text = "Oregon", Value = "OR" },
                    new SelectListItem { Text = "Pennsylvania", Value = "PA" },
                    new SelectListItem { Text = "RhodeIsland", Value = "RI" },
                    new SelectListItem { Text = "SouthCarolina", Value = "SC" },
                    new SelectListItem { Text = "SouthDakota", Value = "SD" },
                    new SelectListItem { Text = "Tennessee", Value = "TN" },
                    new SelectListItem { Text = "Texas", Value = "TX" },
                    new SelectListItem { Text = "Utah", Value = "UT" },
                    new SelectListItem { Text = "Vermont", Value = "VT" },
                    new SelectListItem { Text = "Virginia", Value = "VA" },
                    new SelectListItem { Text = "Washington", Value = "WA" },
                    new SelectListItem { Text = "WestVirginia", Value = "WV" },
                    new SelectListItem { Text = "Wisconsin", Value = "WI" },
                    new SelectListItem { Text = "Wyoming", Value = "WY" },
                };
        }

        public void PurchaseTypes()
        {
            PurchaseType = new List<SelectListItem>
            {
                new SelectListItem{ Text="DealerFinance", Value = "Dealer" },
                new SelectListItem{ Text="BankFinance", Value = "Bank" },
                new SelectListItem{ Text="Cash", Value = "Cash"},
            };
        }
    }

    public class SalesIndexPuchaseCM
    {
        public string Name { get; set; }
        public int VehicleId { get; set; }
        public int EmployeeId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StreetOne { get; set; }
        public string StreetTwo { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public List<string> State { get; set; }
        public int PurchasePrice { get; set; }
        public string PurchaseType { get; set; }
    }
}