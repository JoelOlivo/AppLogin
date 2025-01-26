using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogin.Domain.User.ValueObjects
{
    public class UserEmail //Object value 
    {
        public string Value { get; }

        public UserEmail(string value)
        {
            EnsureIsValid(value);
            Value = value;
        }

        //Valida que el valor de email contenga un @, un punto y no sea nulo
        private void EnsureIsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("El email no puede ser nulo");
            }

            if (!value.Contains("@") || !value.Contains("."))
            {
                throw new ArgumentException("El email no es válido");
            }
        }

        //Retorna el valor de email en string
        public override string ToString() => Value;
    }
}
