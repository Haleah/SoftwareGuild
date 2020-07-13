using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public interface IOrderRepository
    {

        Order Create(Order model);

        List<Order> ReadAll(DateTime date);

        Order ReadById(DateTime date, int id);

        void Update(Order model);

        void Delete(DateTime date, int id);

    }
}
