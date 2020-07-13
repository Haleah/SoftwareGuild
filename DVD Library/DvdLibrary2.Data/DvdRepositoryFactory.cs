using DvdLibrary2.Data.ADO;
using DvdLibrary2.Data.EF;
using DvdLibrary2.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary2.Data
{
    public class DvdRepositoryFactory
    {
        public static IDvdRepository ChooseRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "ADO":
                    return new DvdRepositoryADO();
                case "EF":
                    //TODO: Add EF Repo
                    return new DvdRepositoryEntity();
                case "Mock":
                    //TODO: Add MOCK repo
                    //throw new Exception("ERROR: No key in AppSettings.");
                default:
                    throw new Exception("ERROR: No key in AppSettings.");
            }
        }
    }
}
