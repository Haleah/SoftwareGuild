using System.Collections.Generic;

namespace Flooring.Models.Responses
{
    public class OrdersResponse : Response
    {
        public List<Order> Data { get; set; }
    }
}
