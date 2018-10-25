using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Puma.Paginas;
using Puma.Paginas.Hidraulica;
using Puma.Paginas.InstalacoesEletricas;
using Puma.Paginas.Relatorios;
using Puma.Paginas.HvacArCondicionado;
using Puma.Paginas.Elevadores;
using Puma.Paginas.Edificacoes;
using Puma.Paginas.CombateIncendio;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarroselSubItems : CarouselPage
    {
        public CarroselSubItems(string page, string id)
        {
            //InitializeComponent();
            switch (page)
            {
                case "1":
                    switch (id)
                    {
                        case "1":
                            this.Title = "Quadros elétricos";
                            Children.Add(new InstaEletQuadrosEltricos());
                            break;
                        case "2":
                            this.Title = "Gerador de energia";
                            Children.Add(new InstaEletGeradorEnergia());
                            break;
                        case "3":
                            this.Title = "Cabine Primária";
                            Children.Add(new InstaEletCabinePrimaria());
                            break;
                        case "4":
                            this.Title = "Sistema de para raios";
                            Children.Add(new InstaEletParaRaio());
                            break;
                        case "5":
                            this.Title = "Cabeamento";
                            Children.Add(new InstaEletCabeamento());
                            break;
                        case "6":
                            this.Title = "Eletrodutos / Eletrocalhas";
                            Children.Add(new InstaEletEletrodutos());
                            break;
                    }
                    break;
                case "2":
                    switch (id)
                    {
                        case "1":
                            this.Title = "Chiller";
                            Children.Add(new HvacChiller());
                            break;
                        case "2":
                            this.Title = "Torre de resfriamento";
                            Children.Add(new HvacTorreResfriamento());
                            break;
                        case "3":
                            this.Title = "Bombas";
                            Children.Add(new HvacBombas());
                            break;
                        case "4":
                            this.Title = "Tubulação água gelada";
                            Children.Add(new HvacTubAguaGelada());
                            break;
                        case "5":
                            this.Title = "Tubulação de gás refrigerante";
                            Children.Add(new HvacTubGasRefri());
                            break;
                        case "6":
                            this.Title = "Isolamento da tubulação";
                            Children.Add(new HvacIsolamentoTub());
                            break;
                        case "7":
                            this.Title = "Condensadora";
                            Children.Add(new HvacIsolamentoTub());
                            break;
                        case "8":
                            this.Title = "Evaporadora";
                            Children.Add(new HvacEvaporadora());
                            break;
                        case "9":
                            this.Title = "Ventilação / Exaustão";
                            Children.Add(new HvacVentilacao());
                            break;
                    }
                    break;
                case "3":
                    switch (id)
                    {
                        case "1":
                            this.Title = "Reservatórios";
                            Children.Add(new Reservatorios(this));
                            //Children.Add(new Reservatorios(this));
                            break;
                        case "2":
                            this.Title = "Barrilete";
                            Children.Add(new HidraBarrilhete(this));
                            //Children.Add(new HidraBarrilhete(this));
                            break;
                        case "3":
                            this.Title = "Gerador de água quente";
                            Children.Add(new HidraGeradorAguaQuente(this));
                            //Children.Add(new HidraGeradorAguaQuente());
                            break;
                        case "4":
                            this.Title = "Rede hidráulica - Tubulações";
                            Children.Add(new HidraRede(this));
                            //Children.Add(new HidraRede());
                            break;
                        case "5":
                            this.Title = "Bombas em geral";
                            Children.Add(new HidraBombas(this));
                            //Children.Add(new HidraBombas());
                            break;
                        case "6":
                            this.Title = "Rede de gás";
                            Children.Add(new HidraRedeGas(this));
                            //Children.Add(new HidraRedeGas());
                            break;
                        case "7":
                            this.Title = "ETA - Reuso";
                            Children.Add(new HidraEtaReuso());
                            //Children.Add(new HidraEtaReuso());
                            break;
                        case "8":
                            this.Title = "ETE - Esgoto";
                            Children.Add(new HidraEtaEsgoto());
                            // Children.Add(new HidraEtaEsgoto());
                            break;
                    }
                    break;
                case "4":
                    switch (id)
                    {
                        case "1":
                            this.Title = "Salas Administrativas";
                            Children.Add(new EdificacoesSalasAdministrativas());
                            break;
                        case "2":
                            this.Title = "Salas técnicas";
                            Children.Add(new EdificacoesSalasTecnicas());
                            break;
                        case "3":
                            this.Title = "Fachada";
                            Children.Add(new EdificacoesFachada());
                            break;
                        case "4":
                            this.Title = "Áreas externas";
                            Children.Add(new EdificacoesAreasExternas());
                            break;
                        case "5":
                            this.Title = "Cobertura";
                            Children.Add(new EdificacoesCobertura());
                            break;
                        case "6":
                            this.Title = "Estacionamentos";
                            Children.Add(new EdificacoesEstacionamentos());
                            break;
                        case "7":
                            this.Title = "Áreas operacionais";
                            Children.Add(new EdificacoesAreasOperacionais());
                            break;
                        case "8":
                            this.Title = "Sanitários";
                            Children.Add(new EdificacoesSanitarios());
                            break;
                        case "9":
                            this.Title = "Piscina";
                            Children.Add(new EdificacoesPiscina());
                            break;
                        case "10":
                            this.Title = "Cozinha";
                            Children.Add(new EdificacoesCozinha());
                            break;
                        case "11":
                            this.Title = "Apartamento Hotel";
                            Children.Add(new EdificacoesApartamentoHote());
                            break;
                        case "12":
                            this.Title = "Banheiros";
                            Children.Add(new EdificacoesBanheiro());
                            break;
                    }

                    break;
                case "5":
                    switch (id)
                    {
                        case "1":
                            this.Title = "Rede de Sprinklers";
                            Children.Add(new EdificacoesSalasAdministrativas());
                            break;
                        case "2":
                            this.Title = "Rede de hidrante";
                            Children.Add(new EdificacoesSalasTecnicas());
                            break;
                        case "3":
                            this.Title = "Central de Alarme";
                            Children.Add(new EdificacoesFachada());
                            break;
                        case "4":
                            this.Title = "Iluminação de emergência";
                            Children.Add(new EdificacoesAreasExternas());
                            break;
                        case "5":
                            this.Title = "Sinalização de emergência";
                            Children.Add(new EdificacoesCobertura());
                            break;
                        case "6":
                            this.Title = "Escadas de emergência";
                            Children.Add(new EdificacoesEstacionamentos());
                            break;
                        case "7":
                            this.Title = "Extintores";
                            Children.Add(new EdificacoesAreasOperacionais());
                            break;
                    }
                    break;
                case "6":
                    switch (id)
                    {
                        case "1":
                            this.Title = "Casa de Máquinas";
                            Children.Add(new ElevadoresMaquina());
                            break;
                        case "2":
                            this.Title = "Cabine dos elevadores";
                            Children.Add(new ElevadoresCabineElevadores());
                            break;
                    }
                    break;
                case "7":
                    switch (id)
                    {
                        case "1":
                            this.Title = "Ar Condicionado - PMOC";
                            Children.Add(new RelatorioArCondicionado());
                            break;
                        case "2":
                            this.Title = "Elevadores";
                            Children.Add(new RelatoriosElevadores());
                            break;
                        case "3":
                            this.Title = "Cabine Primária";
                            Children.Add(new RelatoriosCabinePrimaria());
                            break;
                        case "4":
                            this.Title = "Limpeza de caixa de água";
                            Children.Add(new RelatoriosLimpezaCaixa());
                            break;
                        case "5":
                            this.Title = "Sistema Combate a incêndio";
                            Children.Add(new RelatoriosCombateInc());
                            break;
                        case "6":
                            this.Title = "Desintetização";
                            Children.Add(new RelatorioDetetizacao());
                            break;
                        case "7":
                            this.Title = "Para raio";
                            Children.Add(new RelatorioParaRaio());
                            break;
                        case "8":
                            this.Title = "Geradora de água quente";
                            Children.Add(new RelatorioGeradorAguaQuente());
                            break;
                        case "9":
                            this.Title = "Laudo da NR 13";
                            Children.Add(new RelatorioLaudoNR13());
                            break;
                    }
                    break;
            }
        }
    }
}