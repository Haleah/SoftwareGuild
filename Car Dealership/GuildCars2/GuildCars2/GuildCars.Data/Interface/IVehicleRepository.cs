using GuildCars.Model.Queries;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface IVehicleRepository
    {
        List<Vehicles> ReadAllVehicle();
        Vehicles ReadByVehicleId(int vehicleId);
        void CreateVehicle(Vehicles vehicle);
        void UpdateVehicle(Vehicles vehicle);
        void DeleteVehicle(Vehicles vehicle);
        List<Vehicles> Search(VehicleSearchCM form, bool? isUsed = null);
    }
}
