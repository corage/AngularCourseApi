using AngularCourse.Models;
using AngularCourse.Repositories;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AngularCourse.DataAcces
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<CustomerList> CustomerPagedList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows",rows);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<CustomerList>("dbo.CustomerPagedList",
                   parameters,commandType: System.Data.CommandType.StoredProcedure );
            }
        }

      
    }
}
