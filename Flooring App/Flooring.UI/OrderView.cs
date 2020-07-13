using Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI
{
    public class OrderView
    {
        public Order GetOrderNewInfo(List<Product> products)
        {
            Order order = new Order();
            Console.WriteLine("Please enter the Customer name: ");

            string userInputName = Console.ReadLine();
            order.CustomerName = userInputName;

            Console.WriteLine("Please enter the state abbreviation: ");

            string userInputState = Console.ReadLine();
            order.State = userInputState;

            Console.WriteLine("Please enter area being covered: ");

            string userInputArea = Console.ReadLine();
            order.Area = Convert.ToDecimal(userInputArea);

            Console.WriteLine($"{products}");
            Console.WriteLine("Please enter the product type: ");

            string userInputProduct = Console.ReadLine();
            order.ProductType = userInputProduct;
            return order;

        }

        public Order GetOrderEditInfo(Order order, List<Product> products)
        {
            Console.WriteLine($"Please enter the Customer name: {order.CustomerName}");

            string userInputName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInputName))
            {
                order.CustomerName = order.CustomerName;
            }
            else
            {
                order.CustomerName = userInputName;
            }


            Console.WriteLine($"Please enter the state abbreviation:  {order.State}");

            string userInputState = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInputState))
            {
                order.State = order.State;
            }
            else
            {
                order.State = userInputState;
            }


            Console.WriteLine($"Please enter area being covered:  {order.Area}");

            string userInputArea = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInputArea))
            {
                order.Area = order.Area;
            }
            else
            {
                order.Area = Convert.ToDecimal(userInputArea);
            }


            Console.WriteLine($"{products}");
            Console.WriteLine($"Please enter the product type:  {order.ProductType}");

            string userInputProduct = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInputProduct))
            {
                order.ProductType = order.ProductType;
            }
            else
            {
                order.ProductType = userInputProduct;
            }

            return order;
        }

        public DateTime GetOrderDate()
        {
            Console.WriteLine("Please enter the order date");

            Console.Write("\nEnter selection:");

            string userInput = Console.ReadLine();
            DateTime result = Convert.ToDateTime(userInput);
            return result;
        }

        public int GetOrderId()
        {
            Console.WriteLine("Please enter the order Id");

            Console.Write("\nEnter selection:");

            string userInput = Console.ReadLine();
            int result = int.Parse(userInput);
            return result;
        }

        public int getMenuChoice()
        {
            Console.Clear();
            Console.WriteLine("Flooring Program");
            Console.WriteLine("++++++++++++++++++++++++++");
            Console.WriteLine("1. Display Orders");
            Console.WriteLine("2. Add an Order");
            Console.WriteLine("3. Edit an Order");
            Console.WriteLine("4. Remove an Order");
            Console.WriteLine("5. Quit");
            Console.WriteLine("++++++++++++++++++++++++++");

            Console.Write("\nEnter selection:");

            string userInput = Console.ReadLine();
            int result = int.Parse(userInput);
            return result;
        }

        public void DisplayError(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayOrders(List<Order> orders)
        {
            Order order = new Order();
            Console.WriteLine("Please enter the order date : ");

            string userInput = Console.ReadLine();
            DateTime result = Convert.ToDateTime(userInput);
            if (result == order.OrderDate)
            {
                Console.WriteLine($"{order}");
            }
        }

        public void DisplayOrder(Order order)
        {
            Console.WriteLine($"{order}");
            Console.WriteLine($"Order Id: {order.OrderId}");
            Console.WriteLine($"Order Date: {order.OrderDate}");
            Console.WriteLine($"Customer Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.State}");
            Console.WriteLine($"Tax Rate: {order.TaxRate}");
            Console.WriteLine($"Product Type: {order.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Cost per square foot: {order.CostPerSquareFoot}");
            Console.WriteLine($"Labor cost per square foot: {order.LaborCostPerSquareFoot}");
            Console.WriteLine($"Material cost: {order.MaterialCost}");
            Console.WriteLine($"Labor cost: {order.LaborCost}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total: {order.Total}");
        }

        public Boolean GetAnswer(String question)
        {
            Console.WriteLine($"{question}");
            Console.Write("\nEnter selection: Y/N ");

            string userInput = Console.ReadLine().ToUpper();

            if (userInput == "Y")
            {
                return true;
            }
            else if (userInput == "N")
            {
                return false;
            }
            else
            {
                throw new Exception("The data is not in the correct format.");// I googled for this....
            }

        }

    }
}
