using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace Puma.ModelosBanco
{
    [Table("Relatorios")]
    public class Relatorios
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Ct { get; set; }
        public string Data { get; set; }
        public string Gerente { get; set; }
        public string Auditor { get; set; }
        public string Endereco { get; set; }
    }
}
