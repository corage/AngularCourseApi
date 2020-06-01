using AngularCourse.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularCourse.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IUserRepository User { get; }
        ISupplierRepository Supplier { get; }
        IOrderRepository Order { get; }
    }
}
