using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Puma.ModelosBanco
{
    [Table("FotosItem")]
    public class FotosItem
    {
        [Indexed]
        public int Idrelatorio { get; set; }

        [Indexed]
        public int Idsetor { get; set; }

        [Indexed]
        public int Idsubitem { get; set; }
        [Indexed]
        public int Iditemsubitem { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //Name
        public string Name { get; set; }
        public string Base64 { get; set; }
    }
}
