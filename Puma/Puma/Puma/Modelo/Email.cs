using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo
{
    public class Email
    {
        public string email { get; set; }

        public Email(string endereco)
        {
            this.email = endereco;
        }

    }
}
