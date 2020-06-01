using AngularCourse.Models;
using AngularCourse.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AngularCourse.DataAcces
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(string connectionString) : base(connectionString)
        {

        }
        public IEnumerable<OrderList> getPaginatedOrderList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            using (var connection = new SqlConnection(_connectionString))
            {
                var reader =  connection.QueryMultiple("dbo.get_paginated_orders",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
                var orderList = reader.Read<OrderList>().ToList();
                var orderItemList = reader.Read<OrderItemList>().ToList();
                foreach (var item in orderList)
                {
                    item.SetDetails(orderItemList);
                }
                return orderList;

            }
        }

        public OrderList GetOrderById(int orderId)
        {
            var perameters = new DynamicParameters();
            perameters.Add("@orderid", orderId);

            using (var connection = new SqlConnection(_connectionString))
            {
                var reader = connection.QueryMultiple("dbo.get_orders_by_id",
                                                       perameters,
                                                       commandType: System.Data.CommandType.StoredProcedure);
                var orderList = reader.Read<OrderList>().ToList();
                var orderItemList = reader.Read<OrderItemList>().ToList();

                foreach (var item in orderList) item.SetDetails(orderItemList);

                return orderList.FirstOrDefault();
            }
        }
    }
}
