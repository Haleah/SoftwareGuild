using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public interface IProductRepository
    {
        List<Product> ReadAll();
        Product ReadByName(String name);
    }
}
