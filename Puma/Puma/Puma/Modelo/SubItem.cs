using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo
{
    public class SubItem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public SubItem(int Id, string Nome, int Quantidade)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Quantidade = Quantidade;
        }
    }
}
