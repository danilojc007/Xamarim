using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo.ApiConnector.Model
{
    public class Reservatorio
    {
        public string nomeclatura { get; set; }
        public string tipo { get; set; }
        public string localizacao { get; set; }
        public string itemAuditado { get; set; }
        public string planejado { get; set; }
        public string executado { get; set; }
        public string apontamentos { get; set; }
        public string portFechamento { get; set; }
        public string portHermetico { get; set; }
        public string portStatusGeral { get; set; }

        public List<Imagem> portFotos { get; set; } = new List<Imagem>();

        public string portComentario { get; set; }
        public string portNota { get; set; }
        public string impTipo { get; set; }
        public string impEstrutura { get; set; }
        public string impStatusGeral { get; set; }

        //public Imagem impFotos { get; set; }
        public List<Imagem> impFotos { get; set; } = new List<Imagem>();

        public string impComentario { get; set; }
        public string impNota { get; set; }
        public string limpAgua { get; set; }
        public string limpBoiaNivel { get; set; }
        public string limpStatusGeral { get; set; }

        //public Imagem limpFotos { get; set; }
        public List<Imagem> limpFotos { get; set; } = new List<Imagem>();

        public string limpComentario { get; set; }
        public string limpNota { get; set; }
        public string notaFinal { get; set; }
        public string nivelRisco { get; set; }

    }
}
