using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Puma.ModelosBanco
{
    [Table("DetalhesItem")]
    public class DetalhesItem
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
        //tipo picker ou string
        public string Tipo { get; set; }
        //caso Picker Index
        public int Index { get; set; }
        //Texto tanto Picker Quanto escrito
        public string Text { get; set; }

    }
}
