using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo.ApiConnector.Model.Reservatorio
{
    public class GeradoraAguaQuente
    {
        public string nomeclatura { get; set; }
        public string sistema { get; set; }
        public string alimentacao { get; set; }
        public string itemAuditado { get; set; }
        public string planejado { get; set; }
        public string executado { get; set; }
        public string apontamentos { get; set; }
        public string boilMaterial { get; set; }
        public string boilIsolamentoTermico { get; set; }
        public string boilIsolamentoMecanico { get; set; }
        public string boilPortaInspecao { get; set; }
        public string boilTermDigital { get; set; }
        public string boilTermAnalogico { get; set; }
        public string boilValvulaAlivio { get; set; }
        public string boilStatusGeral { get; set; }
        public List<Imagem> boilFotos { get; set; } = new List<Imagem>();
        public string boilComentario { get; set; }
        public string boilNota { get; set; }
        public string aqueInstalacao { get; set; }
        public string aqueAcabamento { get; set; }
        public string aqueDetectorGas { get; set; }
        public string aqueFixacao { get; set; }
        public List<Imagem> aqueFotos { get; set; } = new List<Imagem>();
        public string aqueComentario { get; set; }
        public string aqueNota { get; set; }
        public string bombcInstalacao { get; set; }
        public string bombcAcabamento { get; set; }
        public string bombcFixacao { get; set; }

        public List<Imagem> bombcFotos { get; set; } = new List<Imagem>();
        public string bombcComentario { get; set; }
        public string bombcNota { get; set; }
        public string placsPlacasSolares { get; set; }
        public string placsTubulacao { get; set; }
        public string placsFixacao { get; set; }
        public List<Imagem> placsFotos { get; set; } = new List<Imagem>();
        public string placsComentario { get; set; }
        public string placsNota { get; set; }
        public string bombRolamento { get; set; }
        public string bombAcoplamento { get; set; }
        public string bombSeloMecanico { get; set; }
        public string bombAquecimento { get; set; }
        public string bombPintura { get; set; }
        public string bombStatusGeral { get; set; }
        public List<Imagem> bombFotos { get; set; } = new List<Imagem>();
        public string bombComentario { get; set; }
        public string bombNota { get; set; }
        public string bfelFixacao { get; set; }
        public string bfelVibraStop { get; set; }
        public string bfelInstalacaoEletrica { get; set; }
        public string bfelStatusGeral { get; set; }
        public List<Imagem> bfelFotos { get; set; } = new List<Imagem>();
        public string bfelComentario { get; set; }
        public string bfelNota { get; set; }
        public string tubuMaterial { get; set; }
        public string tubuAcabamento { get; set; }
        public string tubuVazamento { get; set; }
        public string tubuFixacao { get; set; }
        public List<Imagem> tubuFotos { get; set; } = new List<Imagem>();
        public string tubuComentario { get; set; }
        public string tubuNota { get; set; }
        public string regiInstalacao { get; set; }
        public string regiAcabamento { get; set; }
        public string regiFixacao { get; set; }
        public List<Imagem> regiFotos { get; set; } = new List<Imagem>();
        public string regiComentario { get; set; }
        public string regiNota { get; set; }
        public string notaFinal { get; set; }
        public string nivelRisco { get; set; }

    }
}
