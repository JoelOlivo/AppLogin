using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Domain.Entities;
using AppLogin.Domain.Interfaces;
using AppLogin.Domain.ValueObjects;

namespace AppLogin.Application.UserAdd
{
    public class UserAdd
    {
        private readonly IUserRepository _userRepository;

        public UserAdd(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Execute(string email, string password, string firstName, string lastName)
        {
            //Verifica si el correo ya está registrado
            var userExists = await _userRepository.GetByEmail(new UserEmail(email));
            if (userExists != null)
            {
                throw new InvalidOperationException("El correo ya está registrado");
            }

            //Crea un nuevo usuario
            var user = new User
                (
                    new UserId(Guid.NewGuid()),
                    new UserEmail(email),
                    new UserPassword(password),
                    new UserFirstName(firstName),
                    new UserLastName(lastName)
                );
            await _userRepository.Add(user);
            return user;
        }
    }
}
