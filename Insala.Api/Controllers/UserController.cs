using Insala.Domain.Abstract;
using Insala.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
namespace Insala.Api.Controllers
{
    [RoutePrefix("api/v1")]
    public class UserController : ApiController
    {

        IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
            : base()
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        [Route("users")]
        [AllowAnonymous]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage GetUsers()
        {
            var result = this._userRepository.Users;
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("user")]
        [AllowAnonymous]
        public HttpResponseMessage CreateUser(User user)
        {
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                var result = this._userRepository.AddUser(user);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao criar um usuário");
            }
        }

        [HttpPut]
        [Route("user")]
        [AllowAnonymous]
        public HttpResponseMessage UpdateUser(User user)
        {
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                var result = this._userRepository.Update(user);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao editar usuário");
            }
        }

        [HttpDelete]
        [Route("user/{userId}")]
        [AllowAnonymous]
        public HttpResponseMessage DeleteUser(Guid userId)
        {
            if (String.IsNullOrEmpty(Convert.ToString(userId)))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            try
            {
                this._userRepository.Delete(userId);
                return Request.CreateResponse(HttpStatusCode.OK, "Produto excluido");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao deletar usário");
            }
        }
    }
}
