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

    public class AuthenticationProviderRepository : IAuthenticationProvider
    {
        Context _context;
        public AuthenticationProviderRepository(Context context)
        {
            this._context = context;
        }
        public User Login(string login, string password)
        {
           return this._context.Users.Where(x => x.Email == login && x.Password == password).FirstOrDefault();
        }
    }
}
