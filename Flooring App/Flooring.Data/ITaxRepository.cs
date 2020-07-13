using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public interface ITaxRepository
    {
        List<Tax> ReadAll();
        Tax ReadByName(string name);
    }
}
