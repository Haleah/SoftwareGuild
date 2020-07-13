using GuildCars.Data.Interface;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.QA
{
    public class SpecialRepositoryQA : ISpecialRepository
    {
        public void CreateSpecial(Specials special)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecial(Specials special)
        {
            throw new NotImplementedException();
        }

        public List<Specials> ReadAllSpecials()
        {
            throw new NotImplementedException();
        }

        public Specials ReadBySpecialId(int SpecialId)
        {
            throw new NotImplementedException();
        }

        public void UpdateSpecial(Specials special)
        {
            throw new NotImplementedException();
        }
    }
}
