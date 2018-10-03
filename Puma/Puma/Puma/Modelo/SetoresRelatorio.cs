using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo
{
    class SetoresRelatorio
    {
        private int Id { get; set; }
        private string Nome { get; set; }

        private int Quantidade { get; set; }

        public SetoresRelatorio(int Id, string Nome, int Qauntidade)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Quantidade = Quantidade;
        }
    }
}
