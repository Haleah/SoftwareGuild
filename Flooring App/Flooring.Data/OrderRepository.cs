using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> Orders = new List<Order>();
        public Order Create(Order model)
        {
            throw new NotImplementedException();
        }

        public void Delete(DateTime date, int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> ReadAll(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Order ReadById(DateTime date, int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order model)
        {
            throw new NotImplementedException();
        }
    }
}
