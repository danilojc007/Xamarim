using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Puma.ModelosBanco
{
    [Table("Setores")]
    public class Setores
    {
        [Indexed]
        public int Idrelatorio { get; set; }

        [Indexed]
        public int Id { get; set; }
        public string Nome { get; set; }
        //status OK e R
        public string Status { get; set; }
        public string Icone { get; set; }
    }
}
