using Flooring.Data;
using Flooring.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrderRepository orderRepo = new OrderRepository();
            IProductRepository ProductRepo = new ProductRepository();
            ITaxRepository TaxRepo = new TaxRepository();
            IOrderService oS = new OrderService(orderRepo, ProductRepo, TaxRepo);
            OrderView oV = new OrderView();
            OrderController oC = new OrderController(oS, oV);
            oC.Run();
        }
    }
}
