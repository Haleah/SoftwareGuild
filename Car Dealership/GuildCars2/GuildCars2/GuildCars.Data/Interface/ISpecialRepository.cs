using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface ISpecialRepository
    {
        List<Specials> ReadAllSpecials();
        Specials ReadBySpecialId(int SpecialId);
        void CreateSpecial(Specials special);
        void UpdateSpecial(Specials special);
        void DeleteSpecial(Specials special);
    }
}
