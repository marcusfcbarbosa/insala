using Insala.Domain.Abstract;
using Insala.Domain.Entities;
using Insala.Infra.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insala.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        Context _context;
        public UserRepository(Context context)
        {
            this._context = context;
        }

        public User AddUser(User user)
        {
            if (user == null)
            {
                throw new Exception("Error");
            }
            this._context.Users.Add(user);
            this._context.SaveChanges();
            return this._context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
        }

        public void Delete(Guid id)
        {
            var user = this._context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user != null)
            {

                this._context.Users.Remove(user);
                this._context.SaveChanges();
            }
        }

        public User GetById(Guid id)
        {
            return this._context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<User> Users
        {
            get { return _context.Users.AsQueryable(); }
        }


        public User Update(User user)
        {
            this._context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
            return this._context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
        }
    }
}
