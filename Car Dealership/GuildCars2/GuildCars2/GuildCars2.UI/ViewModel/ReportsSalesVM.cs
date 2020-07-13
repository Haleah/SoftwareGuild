using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars2.UI.ViewModel
{
    public class ReportsSalesVM
    {
        
        public ReportsSalesVM()
        {
             SalesReportCM Form = new SalesReportCM();
        }

        public List<SelectListItem> AvailableEmployees { get; set; }
        public SalesReportCM Form { get; set; }
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
        public decimal TotalSales { get; set; }
        public int Count { get; set; }

        public void SetAvailableUsers(List<Employees> employees)
        {
            AvailableEmployees = new List<SelectListItem>();
            foreach (var employee in employees)
            {
                AvailableEmployees.Add(new SelectListItem { Text = employee.LastName, Value = employee.EmployeeId.ToString() });
            }
        } 

        
    }

    //public class ReportsSalesCM
    //{
    //    public DateTime? StartDate { get; set; }
    //    public DateTime? EndDate { get; set; }
    //    public int? EmployeeId { get; set; }
    //}
}