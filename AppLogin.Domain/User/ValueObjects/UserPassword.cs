using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogin.Domain.User.ValueObjects
{
    public class UserPassword //Object value 
    {
        public string Value { get; }

        public UserPassword(string value)
        {
            EnsureIsValid(value);
            Value = value;
        }

        //Valida que el valor de contraseña no sea nulo
        private void EnsureIsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("La contraseña no puede ser nula");
            }

            if (value.Length < 8)
            {
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres");
            }

            if (value.Length > 100)
            {
                throw new ArgumentException("La contraseña no puede tener más de 100 caracteres");
            }
        }
    }
}
