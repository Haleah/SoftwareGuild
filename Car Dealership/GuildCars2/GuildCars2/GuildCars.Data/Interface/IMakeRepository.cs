using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface IMakeRepository
    {
        List<Makes> ReadAllMakes();
        Makes ReadByMakeId(int makeId);
        void CreateMake(Makes make);
        void UpdateMake(Makes make);
    }
}
