using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo
{
    public class RelatorioInicial
    {
        public int Id { get; set; }
        public string Ct { get; set; }
        public string Data { get; set; }
        public string Gerente { get; set; }
        public string Auditor { get; set; }
        public string Endereco { get; set; }

        public RelatorioInicial(int Id)
        {
            this.Id = Id;
        }
        public RelatorioInicial(int Id, string Ct, string Data, string Gerente, string Auditor, string Endereco)
        {
            this.Id = Id;
            this.Ct = Ct;
            this.Data = Data;
            this.Gerente = Gerente;
            this.Auditor = Auditor;
            this.Endereco = Endereco;
        }
    }
}
