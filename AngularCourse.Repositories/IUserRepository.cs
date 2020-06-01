using AngularCourse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularCourse.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
