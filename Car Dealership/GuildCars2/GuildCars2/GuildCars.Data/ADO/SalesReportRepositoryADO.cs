using GuildCars.Data.Interface;
using GuildCars.Model.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class SalesReportRepositoryADO : ISalesReportRepository
    {

        public List<SalesReportRecord> GetSalesReport(SalesReportCM form)
        {
            List<SalesReportRecord> report = new List<SalesReportRecord>();

            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                var sql = "SELECT lastName, firstName,purchaseDate, SUM(ISNULL(purchasePrice, 0))AS 'total', COUNT(ISNULL(Purchase, 0)) AS 'count'  " +
                "FROM Employee" +
                "LEFT JOIN Purchase ON Employee.employeeId = Purchase.employeeId" +
                " WHERE 1 = 1";

                SqlCommand cmd = new SqlCommand(sql, conn);
                if (form.StartDate.HasValue)
                {
                    sql += " AND purchaseDate >= @startDate";
                    cmd.Parameters.AddWithValue("@startDate", form.StartDate);
                }
                if (form.EndDate.HasValue)
                {
                    sql += " AND purchaseDate <= @endDate";
                    cmd.Parameters.AddWithValue("@startDate", form.StartDate);
                }
                if (form.EmployeeId.HasValue)
                {
                    sql += " AND employee = @employeeId";
                    cmd.Parameters.AddWithValue("@employeeId", form.EmployeeId);
                }
                sql += " GROUP BY firstName, lastName";


                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        SalesReportRecord currentRow = new SalesReportRecord();

                        currentRow.FirstName = dr["firstName"].ToString();
                        currentRow.LastName = dr["lastName"].ToString();
                        currentRow.TotalSales = (decimal)dr["total"];
                        currentRow.Count = (int)dr["count"];

                        report.Add(currentRow);
                    }
                }
                conn.Close();
            }
            return report;
        }
    }
}
