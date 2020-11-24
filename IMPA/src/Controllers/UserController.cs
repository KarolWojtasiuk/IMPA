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
            }
            catch (ModelVerificationException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
            return Ok();
        }
    }

    public record ErrorResult(string ExceptionType, string ExceptionMessage);
    public record CreateResult(Guid Id, DateTime CreationDate);
}
