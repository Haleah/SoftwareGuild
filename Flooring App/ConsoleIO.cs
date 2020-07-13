using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring
{
    class ConsoleIO
    {
        public static void DisplayOrderDetails(Order order)
        {

            Console.WriteLine($"Order number: {order.OrderNumber} | Order Date: {order.OrderDate}");
            Console.WriteLine($"Name: {order.Name}");
            Console.WriteLine($"State: {order.State}");
            Console.WriteLine($"Product: {order.Product}");
            Console.WriteLine($"Materials: {order.Materials}");
            Console.WriteLine($"Labor: {order.Labor}");
            Console.WriteLine($"Tax: {//tax.txt}");
            Console.WriteLine($"Total: {}");
        }
    }
}
