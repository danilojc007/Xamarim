﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo.ApiConnector.Model.Reservatorio
{
    public class RedeGas
    {
        public string nomeclatura { get; set; } = "";
        public string localizacao { get; set; } = "";
        public string itemAuditado { get; set; } = "";
        public string planejado { get; set; } = "";
        public string executado { get; set; } = "";
        public string apontamentos { get; set; } = "";
        public string tubuMaterial { get; set; } = "";
        public string tubuAcabamento { get; set; } = "";
        public string tubuVazamento { get; set; } = "";
        public string tubuFixacao { get; set; } = "";

        //public Imagem tubuFotos { get; set; }
        public List<Imagem> tubuFotos { get; set; } = new List<Imagem>();

        public string tubuComentario { get; set; } = "";
        public string tubuNota { get; set; } = "";
        public string regiInstalacao { get; set; } = "";
        public string regiAcabamento { get; set; } = "";
        public string regiFixacao { get; set; } = "";

        //public Imagem regiFotos { get; set; }
        public List<Imagem> regiFotos { get; set; } = new List<Imagem>();

        public string regiComentario { get; set; } = "";
        public string regiNota { get; set; } = "";
        public string gasSistema { get; set; } = "";
        public string gasTanques { get; set; } = "";
        public string gasDetectorGas { get; set; } = "";
        public string gasExtintores { get; set; } = "";
        public string gasLocalInstalacao { get; set; } = "";

        //public Imagem gasFotos { get; set; }
        public List<Imagem> gasFotos { get; set; } = new List<Imagem>();

        public string gasComentario { get; set; } = "";
        public string gasNota { get; set; } = "";
        public string notaFinal { get; set; } = "";
        public string nivelRisco { get; set; } = "";
    }
}
