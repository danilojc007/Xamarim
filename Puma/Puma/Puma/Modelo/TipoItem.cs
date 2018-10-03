using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo
{
    public class TipoItem
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }
        public string Status { get; set; }

        public TipoItem(string Codigo, string Nome, string Icone, string Status)
        {
            this.Codigo = Codigo;
            this.Nome = Nome;
            this.Icone = Icone;
            this.Status = Status;
        }
    }
}
