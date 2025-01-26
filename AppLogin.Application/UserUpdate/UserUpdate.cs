using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Domain.Interfaces;
using AppLogin.Domain.ValueObjects;

namespace AppLogin.Application.UserUpdate
{
    public class UserUpdate
    {
        private readonly IUserRepository _userRepository;

        public UserUpdate(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Execute(Guid id, string email, string password, string firstName, string lastName)
        {
            //Verifica la existencia del usuario
            var userExists = await _userRepository.GetById(new UserId(id));
            if (userExists == null)
            {
                throw new InvalidOperationException("Usuario no encontrado");
            }

            //Verifica si el correo ya está registrado
            var emailExists = await _userRepository.GetByEmail(new UserEmail(email));
            if (emailExists != null && emailExists.Id != userExists.Id)
            {
                throw new InvalidOperationException("El correo ya está registrado");
            }

            //Actualiza los datos del usuario
            userExists.Email = new UserEmail(email);
            userExists.Password = new UserPassword(password);
            userExists.FirstName = new UserFirstName(firstName);
            userExists.LastName = new UserLastName(lastName);

            var result = await _userRepository.Update(userExists);
            if (!result)
            {
                throw new InvalidOperationException("Error al actualizar el usuario");
            }

            return result;
        }
    }
}
