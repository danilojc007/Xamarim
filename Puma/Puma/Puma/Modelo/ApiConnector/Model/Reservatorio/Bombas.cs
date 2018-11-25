using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo.ApiConnector.Model.Reservatorio
{
    public class Bombas
    {
        public string nomeclatura { get; set; } = "";
        public string localizacao { get; set; } = "";
        public string itemAuditado { get; set; } = "";
        public string planejado { get; set; } = "";
        public string executado { get; set; } = "";
        public string apontamentos { get; set; } = "";
        public string bombRolamento { get; set; } = "";
        public string bombAcoplamento { get; set; } = "";
        public string bombSeloMecanico { get; set; } = "";
        public string bombAquecimento { get; set; } = "";
        public string bombPintura { get; set; } = "";
        public string bombStatusGeral { get; set; } = "";

        //public Imagem bombFotos { get; set; }
        public List<Imagem> bombFotos { get; set; } = new List<Imagem>();

        public string bombComentario { get; set; } = "";
        public string bombNota { get; set; } = "";

        public string bfelFixacao { get; set; } = "";
        public string bfelVibraStop { get; set; } = "";
        public string bfelInstalacaoEletrica { get; set; } = "";
        public string bfelStatusGeral { get; set; } = "";

        //public Imagem bfelFotos { get; set; }
        public List<Imagem> bfelFotos { get; set; } = new List<Imagem>();

        public string bfelComentario { get; set; } = "";
        public string bfelNota { get; set; } = "";
        public string notaFinal { get; set; } = "";
        public string nivelRisco { get; set; } = "";

    }
}
