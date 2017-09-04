using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Insala.Domain.Abstract;
using Insala.Infra.DataContext;
using System.Linq;
using Insala.Infra.Repositories;
using Insala.Domain.Entities;
using Insala.Domain.Enum;



namespace Insala.Test.Test_Repositories
{
    [TestClass]
    public class UserRepositoryTest
    {
        private IUserRepository _userRepository;
        Context _context = new Context();

        [TestInitialize]
        public void InicializaTeste()
        {
            _userRepository = new UserRepository(_context);
        }

        
        [TestMethod]
        public void DeleteAllUsers()
        {
            var users = from c in _context.Users select c;
            if (users.Count() > 0)
            {
                foreach (var user in users)
                {
                    _context.Users.Remove(user);
                }
                _context.SaveChanges();
            }
        }

        [TestMethod]
        public void InitialLoadUsers()
        {

            var userAdmin = new User
            {
                Email = "Admin",
                Password = "Admin123",
                Picture = String.Empty,
                Type = UserType.Admin,
                isActive = true
                ,CreatedAt = DateTime.Now
            };

            _userRepository.AddUser(userAdmin);

            var user1 = new User
            {
                Email = "marcusfcbarbosa@hotmail.com",
                Password = "123456",
                Picture = String.Empty,
                Type = UserType.Member,
                isActive = true
                ,
                CreatedAt = DateTime.Now
            };
            _userRepository.AddUser(user1);
            var user2 = new User
            {
                Email = "rebecca@consultoriacontato.com",
                Password = "123456",
                Picture = String.Empty,
                Type = UserType.Member,
                isActive = true
                ,
                CreatedAt = DateTime.Now
            };
            _userRepository.AddUser(user2);
            var user3 = new User
            {
                Email = "teste@teste.com",
                Password = "123456",
                Picture = String.Empty,
                Type = UserType.Member,
                isActive = true,
                CreatedAt = DateTime.Now
            };
            _userRepository.AddUser(user3);
        }


        //I could implement several kind´s of tests in here, but the purpose of this demonstration is to give you what you ask for it!!!
        //=)
    }
}
