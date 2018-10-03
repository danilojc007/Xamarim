using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo
{
    public class SubItem
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public SubItem(string Codigo, string Nome, int Quantidade)
        {
            this.Codigo = Codigo;
            this.Nome = Nome;
            this.Quantidade = Quantidade;
        }
    }
}
