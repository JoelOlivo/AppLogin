using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogin.Domain.ValueObjects
{
    public class UserId //Object value
    {
        public Guid Value { get; }

        public UserId() { }

        public UserId(Guid value)
        {
            EnsureIsValid(value);
            Value = value;
        }

        //Valida que el valor de id no sea nulo
        private void EnsureIsValid(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("El id no puede ser nulo");
            }
        }

        //Retorna el valor de id en string
        public override string ToString() => Value.ToString();
    }
}
