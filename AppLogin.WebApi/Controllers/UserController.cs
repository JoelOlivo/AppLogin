using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppLogin.Application;
using AppLogin.Domain.Entities;
using AppLogin.Domain.Interfaces;
using AppLogin.Domain.ValueObjects;
using AppLogin.Application.UserGetById;
using AppLogin.Application.UserAdd;
using AppLogin.Application.UserUpdate;
using AppLogin.Application.UserDelete;
using AppLogin.Application.UserGetAll;
using AppLogin.WebApi.Models;

namespace AppLogin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserAdd _userAdd;
        private readonly UserUpdate _userUpdate;
        private readonly UserDelete _userDelete;
        private readonly UserGetById _userGetById;
        private readonly UserGetAll _userGetAll;

        public UserController(
            UserAdd userAdd,
            UserUpdate userUpdate,
            UserDelete userDelete,
            UserGetById userGetById,
            UserGetAll userGetAll)
        {
            _userAdd = userAdd;
            _userUpdate = userUpdate;
            _userDelete = userDelete;
            _userGetById = userGetById;
            _userGetAll = userGetAll;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío");
            }

            try
            {
                var user = await _userAdd.Execute(userDto.Email, userDto.Password, userDto.FirstName, userDto.LastName);
                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío");
            }

            // Llamar al caso de uso para actualizar el usuario
            var userUpdated = await _userUpdate.Execute(
                id,  
                userDto.Email,  
                userDto.Password,
                userDto.FirstName,
                userDto.LastName
            );

            if (!userUpdated)
            {
                return BadRequest("Error al actualizar el usuario");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userDeleted = await _userDelete.Execute(id);
            
            if (!userDeleted)
            {
                return BadRequest("Error al eliminar el usuario");
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var user = await _userGetById.Execute(id);
                return Ok(user);
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userGetAll.Execute();

            if (users == null)
            {
                return NotFound("No se ha encontrado usuarios");
            }

            var userDtos = users.Select(user => new UserDto
            {
                Email = user.Email.Value,
                FirstName = user.FirstName.Value,
                LastName = user.LastName.Value
            }).ToList();

            return Ok(users);
        }


    }
}
