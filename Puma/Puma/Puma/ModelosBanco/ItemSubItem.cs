using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Puma.ModelosBanco
{
    [Table("ItemSubItem")]
    public class ItemSubItem
    {
        [Indexed]
        public int RelatoriosId { get; set; }

        [Indexed]
        public int Idsetor { get; set; }

        [Indexed]
        public int Idsubitem { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Contador { get; set; }
    }
}
