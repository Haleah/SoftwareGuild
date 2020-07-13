using GuildCars.Data.Interface;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.QA
{
    public class ModelRepositoryQA : IModelRepository
    {
        public void CreateModel(VehicleModels model)
        {
            throw new NotImplementedException();
        }

        public List<VehicleModels> ReadAllModel()
        {
            throw new NotImplementedException();
        }

        public VehicleModels ReadByModelId(int makeId)
        {
            throw new NotImplementedException();
        }

        public void UpdateModel(VehicleModels model)
        {
            throw new NotImplementedException();
        }
    }
}
