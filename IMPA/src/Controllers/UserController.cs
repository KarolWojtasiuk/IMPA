using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMPA
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly DatabaseController _databaseController;

        public UserController(DatabaseController databaseController)
        {
            _databaseController = databaseController;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser(string username, string password)
        {
            try
            {
                var user = new User(username, password);
                _databaseController.Users.Insert(user);
                return Ok(new CreateResult(user.Id, user.CreationDate));
            }
            catch (ModelVerificationException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public IActionResult GetUser([FromRoute] Guid id)
        {
            try
            {
                return Ok(_databaseController.Users.Get(id));
            }
            catch (ModelVerificationException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }
    }

    public record ErrorResult(string ExceptionType, string ExceptionMessage);
    public record CreateResult(Guid Id, DateTime CreationDate);
}
