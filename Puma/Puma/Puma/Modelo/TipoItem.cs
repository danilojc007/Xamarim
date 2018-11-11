using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo
{
    public class TipoItem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Icone { get; set; }
        public string Status { get; set; }

        public TipoItem(int Id, string Nome, string Icone, string Status)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Icone = Icone;
            this.Status = Status;
        }
    }
}
