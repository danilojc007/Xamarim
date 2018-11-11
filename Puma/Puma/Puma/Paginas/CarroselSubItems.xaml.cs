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
        public List<Puma.ModelosBanco.ItemSubItem> listItemSubItem = null;
        public Puma.Banco.AcessoBanco database = null;
        public Puma.ModelosBanco.Subitemsetor subItemSetor = null;

        protected override void OnCurrentPageChanged()
        {
            var pageSelected = this.CurrentPage.ToString();
            switch (pageSelected)
            {
                case "Puma.Paginas.Reservatorios":
                    Puma.Paginas.Reservatorios pageReservatorio = (Puma.Paginas.Reservatorios)this.CurrentPage;
                    this.ChangeTitle(pageReservatorio.GetContador().ToString());
                    break;
                case "Puma.Paginas.HidraBarrilhete":
                    Puma.Paginas.HidraBarrilhete pageBarrilhete = (Puma.Paginas.HidraBarrilhete)this.CurrentPage;
                    this.ChangeTitle(pageBarrilhete.GetContador().ToString());
                    break;
                case "Puma.Paginas.HidraGeradorAguaQuente":
                    Puma.Paginas.HidraGeradorAguaQuente pageGeradorAguaQuente = (Puma.Paginas.HidraGeradorAguaQuente)this.CurrentPage;
                    this.ChangeTitle(pageGeradorAguaQuente.GetContador().ToString());
                    break;
                case "Puma.Paginas.Hidraulica.HidraRede":
                    Puma.Paginas.Hidraulica.HidraRede pageHidraRede = (Puma.Paginas.Hidraulica.HidraRede)this.CurrentPage;
                    this.ChangeTitle(pageHidraRede.GetContador().ToString());
                    break;
                case "Puma.Paginas.Hidraulica.HidraBombas":
                    Puma.Paginas.Hidraulica.HidraBombas pageHidraBombas = (Puma.Paginas.Hidraulica.HidraBombas)this.CurrentPage;
                    this.ChangeTitle(pageHidraBombas.GetContador().ToString());
                    break;
                case "Puma.Paginas.Hidraulica.HidraRedeGas":
                    Puma.Paginas.Hidraulica.HidraRedeGas pageRedeGas = (Puma.Paginas.Hidraulica.HidraRedeGas)this.CurrentPage;
                    this.ChangeTitle(pageRedeGas.GetContador().ToString());
                    break;
            }
        }
        protected override void OnDisappearing()
        {
            //this.Save();
            // atualizar todos os filhos

            base.OnDisappearing();
        }
        public void ChangeTitle(string title)
        {
            this.Title = this.subItemSetor.Nome + " - " + title; ;
        }


        public CarroselSubItems(Puma.ModelosBanco.Subitemsetor subItemSetorSelected, Puma.Banco.AcessoBanco conexao)
        {
            InitializeComponent();
            this.subItemSetor = subItemSetorSelected;
            this.database = conexao;
            this.Title = subItemSetorSelected.Nome;
            listItemSubItem = database.GetListItemsSubItem(subItemSetorSelected);
            switch (subItemSetorSelected.Idsetor)
            {
                case 1:
                    switch (subItemSetorSelected.Id)
                    {
                        case 1:
                            Children.Add(new InstaEletQuadrosEltricos());
                            break;
                        case 2:
                            Children.Add(new InstaEletGeradorEnergia());
                            break;
                        case 3:
                            Children.Add(new InstaEletCabinePrimaria());
                            break;
                        case 4:
                            Children.Add(new InstaEletParaRaio());
                            break;
                        case 5:
                            Children.Add(new InstaEletCabeamento());
                            break;
                        case 6:
                            Children.Add(new InstaEletEletrodutos());
                            break;
                    }
                    break;
                case 2:
                    switch (subItemSetorSelected.Id)
                    {
                        case 1:
                            Children.Add(new HvacChiller());
                            break;
                        case 2:
                            Children.Add(new HvacTorreResfriamento());
                            break;
                        case 3:
                            Children.Add(new HvacBombas());
                            break;
                        case 4:
                            Children.Add(new HvacTubAguaGelada());
                            break;
                        case 5:
                            Children.Add(new HvacTubGasRefri());
                            break;
                        case 6:
                            Children.Add(new HvacIsolamentoTub());
                            break;
                        case 7:
                            Children.Add(new HvacIsolamentoTub());
                            break;
                        case 8:
                            Children.Add(new HvacEvaporadora());
                            break;
                        case 9:
                            Children.Add(new HvacVentilacao());
                            break;
                    }
                    break;
                case 3:
                    switch (subItemSetorSelected.Id)
                    {
                        case 1:
                            if (listItemSubItem.Count != 0)
                            {
                                for (var i = 0; i < listItemSubItem.Count; i++)
                                {
                                    //hidra = new HidraBarrilhete(this, listItemSubItem[i], database);
                                    Children.Add(new Reservatorios(this, listItemSubItem[i], database));
                                }
                            }
                            else
                            {
                                Puma.ModelosBanco.ItemSubItem subItem = new Puma.ModelosBanco.ItemSubItem();
                                subItem.RelatoriosId = subItemSetorSelected.Idrelatorio;
                                subItem.Idsetor = subItemSetorSelected.Idsetor;
                                subItem.Idsubitem = subItemSetorSelected.Id;
                                subItem.Contador = 1;

                                database.CreateItemSubItem(subItem);
                                Children.Add(new Reservatorios(this, subItem, database));
                            }
                            break;
                        case 2:
                            //HidraBarrilhete hidra = null;
                            if (listItemSubItem.Count != 0)
                            {
                                for (var i = 0; i < listItemSubItem.Count; i++)
                                {
                                    //hidra = new HidraBarrilhete(this, listItemSubItem[i], database);
                                    Children.Add(new HidraBarrilhete(this, listItemSubItem[i], database));
                                }
                            }
                            else
                            {
                                Puma.ModelosBanco.ItemSubItem subItem = new Puma.ModelosBanco.ItemSubItem();
                                subItem.RelatoriosId = subItemSetorSelected.Idrelatorio;
                                subItem.Idsetor = subItemSetorSelected.Idsetor;
                                subItem.Idsubitem = subItemSetorSelected.Id;
                                subItem.Contador = 1;

                                database.CreateItemSubItem(subItem);
                                Children.Add(new HidraBarrilhete(this, subItem, database));
                            }
                            break;
                        case 3:
                            if (listItemSubItem.Count != 0)
                            {
                                for (var i = 0; i < listItemSubItem.Count; i++)
                                {
                                    //hidra = new HidraBarrilhete(this, listItemSubItem[i], database);
                                    Children.Add(new HidraGeradorAguaQuente(this, listItemSubItem[i], database));
                                }
                            }
                            else
                            {
                                Puma.ModelosBanco.ItemSubItem subItem = new Puma.ModelosBanco.ItemSubItem();
                                subItem.RelatoriosId = subItemSetorSelected.Idrelatorio;
                                subItem.Idsetor = subItemSetorSelected.Idsetor;
                                subItem.Idsubitem = subItemSetorSelected.Id;
                                subItem.Contador = 1;

                                database.CreateItemSubItem(subItem);
                                Children.Add(new HidraGeradorAguaQuente(this, subItem, database));
                            }
                            break;
                        case 4:
                            if (listItemSubItem.Count != 0)
                            {
                                for (var i = 0; i < listItemSubItem.Count; i++)
                                {
                                    //hidra = new HidraBarrilhete(this, listItemSubItem[i], database);
                                    Children.Add(new HidraRede(this, listItemSubItem[i], database));
                                }
                            }
                            else
                            {
                                Puma.ModelosBanco.ItemSubItem subItem = new Puma.ModelosBanco.ItemSubItem();
                                subItem.RelatoriosId = subItemSetorSelected.Idrelatorio;
                                subItem.Idsetor = subItemSetorSelected.Idsetor;
                                subItem.Idsubitem = subItemSetorSelected.Id;
                                subItem.Contador = 1;

                                database.CreateItemSubItem(subItem);
                                Children.Add(new HidraRede(this, subItem, database));
                            }
                            break;
                        case 5:
                            if (listItemSubItem.Count != 0)
                            {
                                for (var i = 0; i < listItemSubItem.Count; i++)
                                {
                                    //hidra = new HidraBarrilhete(this, listItemSubItem[i], database);
                                    Children.Add(new HidraBombas(this, listItemSubItem[i], database));
                                }
                            }
                            else
                            {
                                Puma.ModelosBanco.ItemSubItem subItem = new Puma.ModelosBanco.ItemSubItem();
                                subItem.RelatoriosId = subItemSetorSelected.Idrelatorio;
                                subItem.Idsetor = subItemSetorSelected.Idsetor;
                                subItem.Idsubitem = subItemSetorSelected.Id;
                                subItem.Contador = 1;

                                database.CreateItemSubItem(subItem);
                                Children.Add(new HidraBombas(this, subItem, database));
                            }
                            break;
                        case 6:
                            if (listItemSubItem.Count != 0)
                            {
                                for (var i = 0; i < listItemSubItem.Count; i++)
                                {
                                    //hidra = new HidraBarrilhete(this, listItemSubItem[i], database);
                                    Children.Add(new HidraRedeGas(this, listItemSubItem[i], database));
                                }
                            }
                            else
                            {
                                Puma.ModelosBanco.ItemSubItem subItem = new Puma.ModelosBanco.ItemSubItem();
                                subItem.RelatoriosId = subItemSetorSelected.Idrelatorio;
                                subItem.Idsetor = subItemSetorSelected.Idsetor;
                                subItem.Idsubitem = subItemSetorSelected.Id;
                                subItem.Contador = 1;

                                database.CreateItemSubItem(subItem);
                                Children.Add(new HidraRedeGas(this, subItem, database));
                            }
                            break;
                        case 7:
                            Children.Add(new HidraEtaReuso());
                            break;
                        case 8:
                            Children.Add(new HidraEtaEsgoto());
                            break;
                    }
                    break;
                case 4:
                    switch (subItemSetorSelected.Id)
                    {
                        case 1:
                            //this.Title = "Salas Administrativas";
                            Children.Add(new EdificacoesSalasAdministrativas());
                            break;
                        case 2:
                            //this.Title = "Salas técnicas";
                            Children.Add(new EdificacoesSalasTecnicas());
                            break;
                        case 3:
                            //this.Title = "Fachada";
                            Children.Add(new EdificacoesFachada());
                            break;
                        case 4:
                            //this.Title = "Áreas externas";
                            Children.Add(new EdificacoesAreasExternas());
                            break;
                        case 5:
                            //this.Title = "Cobertura";
                            Children.Add(new EdificacoesCobertura());
                            break;
                        case 6:
                            //this.Title = "Estacionamentos";
                            Children.Add(new EdificacoesEstacionamentos());
                            break;
                        case 7:
                            //this.Title = "Áreas operacionais";
                            Children.Add(new EdificacoesAreasOperacionais());
                            break;
                        case 8:
                            //this.Title = "Sanitários";
                            Children.Add(new EdificacoesSanitarios());
                            break;
                        case 9:
                            //this.Title = "Piscina";
                            Children.Add(new EdificacoesPiscina());
                            break;
                        case 10:
                            //this.Title = "Cozinha";
                            Children.Add(new EdificacoesCozinha());
                            break;
                        case 11:
                            //this.Title = "Apartamento Hotel";
                            Children.Add(new EdificacoesApartamentoHote());
                            break;
                        case 12:
                            //this.Title = "Banheiros";
                            Children.Add(new EdificacoesBanheiro());
                            break;
                    }

                    break;
                case 5:
                    switch (subItemSetorSelected.Id)
                    {
                        case 1:
                            //this.Title = "Rede de Sprinklers";
                            Children.Add(new EdificacoesSalasAdministrativas());
                            break;
                        case 2:
                            //this.Title = "Rede de hidrante";
                            Children.Add(new EdificacoesSalasTecnicas());
                            break;
                        case 3:
                            //this.Title = "Central de Alarme";
                            Children.Add(new EdificacoesFachada());
                            break;
                        case 4:
                            //this.Title = "Iluminação de emergência";
                            Children.Add(new EdificacoesAreasExternas());
                            break;
                        case 5:
                            //this.Title = "Sinalização de emergência";
                            Children.Add(new EdificacoesCobertura());
                            break;
                        case 6:
                            //this.Title = "Escadas de emergência";
                            Children.Add(new EdificacoesEstacionamentos());
                            break;
                        case 7:
                            //this.Title = "Extintores";
                            Children.Add(new EdificacoesAreasOperacionais());
                            break;
                    }
                    break;
                case 6:
                    switch (subItemSetorSelected.Id)
                    {
                        case 1:
                            //this.Title = "Casa de Máquinas";
                            Children.Add(new ElevadoresMaquina());
                            break;
                        case 2:
                            //this.Title = "Cabine dos elevadores";
                            Children.Add(new ElevadoresCabineElevadores());
                            break;
                    }
                    break;
                case 7:
                    switch (subItemSetorSelected.Id)
                    {
                        case 1:
                            //this.Title = "Ar Condicionado - PMOC";
                            Children.Add(new RelatorioArCondicionado());
                            break;
                        case 2:
                            //this.Title = "Elevadores";
                            Children.Add(new RelatoriosElevadores());
                            break;
                        case 3:
                            //this.Title = "Cabine Primária";
                            Children.Add(new RelatoriosCabinePrimaria());
                            break;
                        case 4:
                            //this.Title = "Limpeza de caixa de água";
                            Children.Add(new RelatoriosLimpezaCaixa());
                            break;
                        case 5:
                            //this.Title = "Sistema Combate a incêndio";
                            Children.Add(new RelatoriosCombateInc());
                            break;
                        case 6:
                            //this.Title = "Desintetização";
                            Children.Add(new RelatorioDetetizacao());
                            break;
                        case 7:
                            //this.Title = "Para raio";
                            Children.Add(new RelatorioParaRaio());
                            break;
                        case 8:
                            //this.Title = "Geradora de água quente";
                            Children.Add(new RelatorioGeradorAguaQuente());
                            break;
                        case 9:
                            //this.Title = "Laudo da NR 13";
                            Children.Add(new RelatorioLaudoNR13());
                            break;
                    }
                    break;
            }
        }
    }
}