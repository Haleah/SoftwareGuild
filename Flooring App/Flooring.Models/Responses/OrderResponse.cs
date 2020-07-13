using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Responses
{
    public class OrderResponse : Response
    {
        public Order Data { get; set; }
    }
}
