using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Puma.ModelosBanco
{
    [Table("Subitemsetor")]
    public class Subitemsetor
    {
        [Indexed]
        public int Idrelatorio { get; set; }

        [Indexed]
        public int Idsetor { get; set; }

        [Indexed]
        public int Id { get; set; }

        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
