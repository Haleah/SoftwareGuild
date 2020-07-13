using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model.Queries
{
    public class SalesReportRecord
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? TotalSales { get; set; }
        public int? Count { get; set; }
    }
}
