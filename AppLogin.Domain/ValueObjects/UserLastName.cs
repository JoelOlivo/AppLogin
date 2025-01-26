using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogin.Domain.ValueObjects
{
    public class UserLastName //Object value
    {
        public string Value { get; set; }

        public UserLastName(string value)
        {
            EnsureIsValid(value);
            Value = value;
        }

        //Valida que el valor de apellido no sea nulo, tenga al menos 2 caracteres y no tenga más de 50 caracteres
        private void EnsureIsValid(string value)
        {
            if (value.Length < 2)
            {
                throw new ArgumentException("El apellido debe tener al menos 2 caracteres");
            }

            if (value.Length > 50)
            {
                throw new ArgumentException("El apellido no puede tener más de 50 caracteres");
            }
        }

        //Retorna el valor de apellido en string
        public override string ToString() => Value;
    }
}
