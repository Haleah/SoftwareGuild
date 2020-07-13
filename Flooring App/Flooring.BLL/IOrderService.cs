using Flooring.Models;
using Flooring.Models.Responses;
using System;

namespace Flooring.BLL
{
    public interface IOrderService
    {
        Response ValidateOrder(Order order);
        OrderResponse Create(Order o);
        OrdersResponse ReadAll(DateTime date);
        OrderResponse ReadById(DateTime date, int orderId);
        Response Update(Order o);
        Response Delete(DateTime date, int order);
        ProductsResponse ReadAllProducts();
    }
}
