using Flooring.Data;
using Flooring.Models;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL
{
    public class OrderService : IOrderService
    {

        private IOrderRepository OrderRepository;

        private IProductRepository ProductRepository;

        private ITaxRepository TaxRepository;

        public OrderService(IOrderRepository orderRepo, IProductRepository productRepo, ITaxRepository TaxRepo)
        {
            OrderRepository = orderRepo;
            ProductRepository = productRepo;
            TaxRepository = TaxRepo;
        }

        public OrderResponse Create(Order o)
        {
            throw new NotImplementedException();
        }

        public Response Delete(DateTime date, int order)
        {
            throw new NotImplementedException();
        }

        public OrdersResponse ReadAll(DateTime date)
        {
            throw new NotImplementedException();
        }

        public ProductsResponse ReadAllProducts()
        {
            throw new NotImplementedException();
            //List<Product> products = ProductRepository.ReadAll();
        }

        public OrderResponse ReadById(DateTime date, int orderId)
        {
            throw new NotImplementedException();
        }

        public Response Update(Order o)
        {
            throw new NotImplementedException();
        }

        public Response ValidateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
