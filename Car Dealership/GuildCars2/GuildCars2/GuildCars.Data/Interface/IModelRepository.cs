﻿using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface IModelRepository
    {
        List<VehicleModels> ReadAllModel();
        VehicleModels ReadByModelId(int makeId);
        void CreateModel(VehicleModels model);
        void UpdateModel(VehicleModels model);
    }
}
