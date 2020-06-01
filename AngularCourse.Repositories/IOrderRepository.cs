using AngularCourse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularCourse.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {
        IEnumerable<OrderList> getPaginatedOrderList(int page, int rows);
        OrderList GetOrderById(int orderId);

    }
}
