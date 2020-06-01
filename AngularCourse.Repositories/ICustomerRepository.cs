using AngularCourse.Models;
using System.Collections.Generic;

namespace AngularCourse.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<CustomerList> CustomerPagedList(int page, int rows);
    }
}
