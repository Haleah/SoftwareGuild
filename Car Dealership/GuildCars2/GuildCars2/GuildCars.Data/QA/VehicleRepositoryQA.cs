using GuildCars.Data.Interface;
using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.QA
{
    public class VehicleRepositoryQA : IVehicleRepository
    {
        public void CreateVehicle(Vehicles vehicle)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(Vehicles vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Vehicles> ReadAllVehicle()
        {
            throw new NotImplementedException();
        }

        public Vehicles ReadByVehicleId(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public List<Vehicles> Search(VehicleSearchCM form)
        {
            throw new NotImplementedException();
        }

        public List<Vehicles> Search(VehicleSearchCM form, bool? isUsed = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicle(Vehicles vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
