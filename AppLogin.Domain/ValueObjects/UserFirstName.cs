using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogin.Domain.ValueObjects
{
    public class UserFirstName //Object value
    {
        public string Value { get; }

        public UserFirstName() { }

        public UserFirstName(string value)
        {
            EnsureIsValid(value);
            Value = value;
        }

        //Valida que el valor de nombre no sea nulo, tenga al menos 2 caracteres y no tenga más de 50 caracteres
        private void EnsureIsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("El nombre no puede ser nulo");
            }

            if (value.Length < 2)
            {
                throw new ArgumentException("El nombre debe tener al menos 2 caracteres");
            }

            if (value.Length > 50)
            {
                throw new ArgumentException("El nombre no puede tener más de 50 caracteres");
            }
        }

        //Retorna el valor de nombre en string
        public override string ToString() => Value;
    }
}
