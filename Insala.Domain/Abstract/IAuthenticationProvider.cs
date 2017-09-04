using Insala.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insala.Domain.Abstract
{
    public interface IAuthenticationProvider
    {
       User Login(string login, string password);
    }
}
