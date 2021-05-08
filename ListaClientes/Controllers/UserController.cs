using ListaClientes.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaClientes.Controllers
{
    [ApiController]
    [Route("listaClientes")]
    public class UserController : ControllerBase
    {
        private IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public User Post(User user)
        {
            var userResult = _userServices.Create(user);
            return userResult;
        }

        [HttpGet]
        public List<User> Get([FromQuery] FilterUser filterUser)
        {
            return _userServices.Get(filterUser);
        }

        [HttpGet]
        [Route("{userId}")]
        public User UserGetById(string userId)
        {
            return _userServices.Get(userId);
        }

        [HttpDelete]
        [Route("{userId}")]
        public long DeleteById(string userId)
        {
            return _userServices.Remove(userId);
        }

        [HttpPut]
        [Route("{userId}")]
        public long UpdateById(string userId, [FromBody] User user)
        {
            return _userServices.Update(userId, user);
        }
    }
}
