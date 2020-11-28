using System;
using System.Collections.Generic;
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

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            var currentUser = User.GetUser(_databaseController);
            if (currentUser.Id != id)
            {
                throw new InsufficientPermissionException(currentUser.Id, $"DeleteUser({id})");
            }

            try
            {
                _databaseController.Users.Delete(currentUser.Id);
                return Ok();
            }
            catch (ModelVerificationException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }

        [HttpPatch]
        [Route("{id}/ChangeFullName")]
        public IActionResult ChangeFullName([FromRoute] Guid id, string fullName)
        {
            var currentUser = User.GetUser(_databaseController);
            if (currentUser.Id != id)
            {
                throw new InsufficientPermissionException(currentUser.Id, $"Modify({id})");
            }

            try
            {
                _databaseController.Users.ChangeFullName(currentUser.Id, fullName);
                return Ok();
            }
            catch (ModelVerificationException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }

        [HttpPatch]
        [Route("{id}/ChangeDescription")]
        public IActionResult ChangeDescription([FromRoute] Guid id, string description)
        {
            var currentUser = User.GetUser(_databaseController);
            if (currentUser.Id != id)
            {
                throw new InsufficientPermissionException(currentUser.Id, $"Modify({id})");
            }

            try
            {
                _databaseController.Users.ChangeDescription(currentUser.Id, description);
                return Ok();
            }
            catch (ModelVerificationException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }

        [HttpPatch]
        [Route("{id}/ChangePersonalityType")]
        public IActionResult ChangePersonalityType([FromRoute] Guid id, PersonalityType personalityType)
        {
            var currentUser = User.GetUser(_databaseController);
            if (currentUser.Id != id)
            {
                throw new InsufficientPermissionException(currentUser.Id, $"Modify({id})");
            }

            try
            {
                _databaseController.Users.ChangePersonalityType(currentUser.Id, personalityType);
                return Ok();
            }
            catch (ModelVerificationException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }

        [HttpPatch]
        [Route("{id}/ChangeInterests")]
        public IActionResult ChangeInterests([FromRoute] Guid id, List<Interest> interests)
        {
            var currentUser = User.GetUser(_databaseController);
            if (currentUser.Id != id)
            {
                throw new InsufficientPermissionException(currentUser.Id, $"Modify({id})");
            }

            try
            {
                _databaseController.Users.ChangeInterests(currentUser.Id, interests);
                return Ok();
            }
            catch (ModelVerificationException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }

        [HttpPatch]
        [Route("{id}/AddInterest")]
        public IActionResult AddInterest([FromRoute] Guid id, Interest interest)
        {
            var currentUser = User.GetUser(_databaseController);
            if (currentUser.Id != id)
            {
                throw new InsufficientPermissionException(currentUser.Id, $"Modify({id})");
            }

            try
            {
                _databaseController.Users.AddInterest(currentUser.Id, interest);
                return Ok();
            }
            catch (ModelVerificationException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }

        [HttpPatch]
        [Route("{id}/RemoveInterest")]
        public IActionResult RemoveInterest([FromRoute] Guid id, Interest interest)
        {
            var currentUser = User.GetUser(_databaseController);
            if (currentUser.Id != id)
            {
                throw new InsufficientPermissionException(currentUser.Id, $"Modify({id})");
            }

            try
            {
                _databaseController.Users.RemoveInterest(currentUser.Id, interest);
                return Ok();
            }
            catch (ModelVerificationException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }

        [HttpPatch]
        [Route("{id}/ChangeLocationRecords")]
        public IActionResult ChangeLocationRecords([FromRoute] Guid id, List<LocationRecord> locationRecords)
        {
            var currentUser = User.GetUser(_databaseController);
            if (currentUser.Id != id)
            {
                throw new InsufficientPermissionException(currentUser.Id, $"Modify({id})");
            }

            try
            {
                _databaseController.Users.ChangeLocationRecords(currentUser.Id, locationRecords.AsReadOnly());
                return Ok();
            }
            catch (ModelVerificationException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }

        [HttpPatch]
        [Route("{id}/AddLocationRecord")]
        public IActionResult AddLocationRecord([FromRoute] Guid id, LocationRecord locationRecord)
        {
            var currentUser = User.GetUser(_databaseController);
            if (currentUser.Id != id)
            {
                throw new InsufficientPermissionException(currentUser.Id, $"Modify({id})");
            }

            try
            {
                _databaseController.Users.AddLocationRecord(currentUser.Id, locationRecord);
                return Ok();
            }
            catch (ModelVerificationException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }

        [HttpPatch]
        [Route("{id}/RemoveLocationRecord")]
        public IActionResult RemoveLocationRecord([FromRoute] Guid id, LocationRecord locationRecord)
        {
            var currentUser = User.GetUser(_databaseController);
            if (currentUser.Id != id)
            {
                throw new InsufficientPermissionException(currentUser.Id, $"Modify({id})");
            }

            try
            {
                _databaseController.Users.RemoveLocationRecord(currentUser.Id, locationRecord);
                return Ok();
            }
            catch (ModelVerificationException e)
            {
                return BadRequest(new ErrorResult(e.GetType().Name, e.Message));
            }
        }

        [HttpPatch]
        [Route("{id}/ChangeHabits")]
        public IActionResult ChangeHabits([FromRoute] Guid id, Habits habits)
        {
            var currentUser = User.GetUser(_databaseController);
            if (currentUser.Id != id)
            {
                throw new InsufficientPermissionException(currentUser.Id, $"Modify({id})");
            }

            try
            {
                _databaseController.Users.ChangeHabits(currentUser.Id, habits);
                return Ok();
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
