using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class ProductsResponse : Response
    {
        public List<Product> Data { get; set; }
    }
}
