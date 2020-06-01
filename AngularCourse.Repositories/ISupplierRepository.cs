using AngularCourse.Models;
using System.Collections.Generic;

namespace AngularCourse.Repositories
{
    public interface ISupplierRepository: IRepository<Supplier>
    {
        IEnumerable<Supplier> SupplierPagedList(int page, int rows, string searchTerm);
    }
}
