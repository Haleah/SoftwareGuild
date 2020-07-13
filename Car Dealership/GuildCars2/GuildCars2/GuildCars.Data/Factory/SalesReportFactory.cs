using GuildCars.Data.ADO;
using GuildCars.Data.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factory
{
    public class SalesReportFactory
    {

        public static ISalesReportRepository ChooseRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                //case "QA":
                //    return new SalesReportRepositoryQA();
                case "PROD":
                    return new SalesReportRepositoryADO();
                default:
                    throw new Exception("ERROR: No key in AppSettings.");
            }
        }

    }
}
