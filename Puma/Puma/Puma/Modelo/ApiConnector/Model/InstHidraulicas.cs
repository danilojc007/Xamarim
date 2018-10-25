using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo.ApiConnector.Model
{
    public class InstHidraulicas
    {
        public List<Reservatorio> reservatorio { get; set; } = new List<Reservatorio>();
        public List<Barrilete> barrilete { get; set; } = new List<Barrilete>();
        public List<GeradoraAguaQuente> geradoraAguaQuente { get; set; } = new List<GeradoraAguaQuente>();
        public List<Tubulacoes> tubulacoes { get; set; } = new List<Tubulacoes>();
        public List<Bombas> bombas { get; set; } = new List<Bombas>();
        public List<RedeGas> redeGas { get; set; } = new List<RedeGas>();
    }
}
