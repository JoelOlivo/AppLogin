using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Domain.Interfaces;
using AppLogin.Domain.ValueObjects;

namespace AppLogin.Application.UserDelete
{
    public class UserDelete
    {
        private readonly IUserRepository _userRepository;

        public UserDelete(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Execute(Guid id)
        {
            //Verifica la existencia del usuario
            var userExists = await _userRepository.GetById(new UserId(id));
            if (userExists == null)
            {
                throw new InvalidOperationException("El usuario no existe");
            }

            var result = await _userRepository.Delete(userExists);
            if (!result)
            {
                throw new InvalidOperationException("Error al eliminar el usuario");
            }

            return result;
        }
    }
}
