using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementCore.ValueObjects
{
    public class Email : Notifiable
    {
        public Email()
        {

        }
        public Email(string adress)
        {
            Address = adress;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "O E-mail é inválido")
                .HasMinLen(Address, 8, "Email", "O Email deve conter pelo menos 8 caracteres")
                .HasMaxLen(Address, 40, "Email", "O Email deve conter até 40 caracteres")
                );
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
