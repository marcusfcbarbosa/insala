using Insala.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insala.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        User AddUser(User user);
        void Delete(Guid id);

        User GetById(Guid id);

        User Update(User user);
    }
}
