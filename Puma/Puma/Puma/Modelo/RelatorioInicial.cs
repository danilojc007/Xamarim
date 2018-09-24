using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo
{
    public class RelatorioInicial
    {
        public string Nome { get; set; }
        public string Data { get; set; }

        public RelatorioInicial(string Nome, string Data)
        {
            this.Nome = Nome;
            this.Data = Data;
        }
    }
}
