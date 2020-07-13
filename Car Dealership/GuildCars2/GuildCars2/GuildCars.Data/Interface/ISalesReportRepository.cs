using GuildCars.Model.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface ISalesReportRepository
    {
        List<SalesReportRecord> GetSalesReport(SalesReportCM form);
    }
}
