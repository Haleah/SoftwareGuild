using Flooring.BLL;
using Flooring.Data;
using Flooring.Models;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.UI
{
    public class OrderController
    {
        private IOrderService orderService;
        private OrderView orderView;
        public OrderController(IOrderService os, OrderView ov)
        {
            orderService = os;
            this.orderView = ov;
        }
        public void Run()
        {
            while (true)
            {

                switch (this.orderView.getMenuChoice())
                {

                    case 1:
                        ReadAll();
                        break;
                    case 2:
                        Create();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;
                    case 5:
                        return;
                }
            }
        }
        private void Create()
        {
            ProductsResponse pr = this.orderService.ReadAllProducts();
            Order order = this.orderView.GetOrderNewInfo(pr.Data);
            Response response = this.orderService.ValidateOrder(order);
            if (response.Success && this.orderView.GetAnswer("Do you want to save this order?"))
            {
                OrderResponse orderResponse = this.orderService.Create(order);
            }
            else if (response.Success ==false)
            {
                this.orderView.DisplayError(response.Message);
                this.Create();
            }
        }

        private void Delete()
        {
            throw new NotImplementedException();
        }

        private void ReadAll()
        {
            throw new NotImplementedException();
        }

        private void ReadById()
        {
            throw new NotImplementedException();
        }

        private void Update()
        {
            throw new NotImplementedException();
        }
    }
}
