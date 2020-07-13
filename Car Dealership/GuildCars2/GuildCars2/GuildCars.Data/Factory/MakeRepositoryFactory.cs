using GuildCars.Data.ADO;
using GuildCars.Data.Interface;
using GuildCars.Data.QA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factory
{
    public class MakeRepositoryFactory
    {
        public static IMakeRepository ChooseRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "QA":
                    return new MakeRepositoryQA();
                case "PROD":
                    return new MakeRepositoryADO();
                default:
                    throw new Exception("ERROR: No key in AppSettings.");
            }
        }
    }
}
