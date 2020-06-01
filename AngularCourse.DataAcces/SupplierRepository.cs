using AngularCourse.Models;
using AngularCourse.Repositories;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AngularCourse.DataAcces
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {

        }
        public IEnumerable<Supplier> SupplierPagedList(int page, int rows, string searchTerm)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            parameters.Add("@searchTerm", searchTerm);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Supplier>("dbo.SupplierPagedList",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
