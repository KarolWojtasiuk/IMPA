using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMPA
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class ChannelController : ControllerBase
    {
        private readonly DatabaseController _databaseController;

        public ChannelController(DatabaseController databaseController)
        {
            _databaseController = databaseController;
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetChannel([FromRoute] Guid userId)
        {
            try
            {
                if (_databaseController.Users.Get(userId) is null)
                {
                    throw new ItemDoesNotExistException(userId, typeof(User));
                }

                var callerId = User.GetUser(_databaseController).Id;
                var channel = _databaseController.Channels.Get(callerId, userId);
                return Ok(channel);
            }
            catch (IMPAException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }

        [HttpPost]
        [Route("{userId}")]
        public IActionResult SendMessage([FromRoute] Guid userId, [FromBody] string message)
        {
            try
            {
                if (_databaseController.Users.Get(userId) is null)
                {
                    throw new ItemDoesNotExistException(userId, typeof(User));
                }

                var callerId = User.GetUser(_databaseController).Id;
                var channel = _databaseController.Channels.Get(callerId, userId);
                _databaseController.Channels.AddMessage(channel.Id, new Message(callerId, message));
                return Ok();
            }
            catch (IMPAException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }
    }
}
