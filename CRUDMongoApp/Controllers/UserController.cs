using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDMongoApp.Models;
using CRUDMongoApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoApp.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("api/users")]
        public List<User> GetAllUsers() => _userRepository.GetAll();

        [HttpPost]
        [Route("api/users")]
        [Consumes("application/json")]
        public User CreateUser(User user)
        {
            return _userRepository.Add(user);
        }

        [HttpPut]
        [Route("api/users")]
        [Consumes("application/json")]
        public bool UpdateUser(string id, User user)
        {
            return _userRepository.Update(id, user);
        }

        [HttpDelete]
        [Route("api/users")]
        public bool DeleteUser(string id)
        {
            return _userRepository.Delete(id);
        }
    }
}
