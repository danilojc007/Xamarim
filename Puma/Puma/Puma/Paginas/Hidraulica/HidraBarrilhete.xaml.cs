using Plugin.Media;
using Plugin.Media.Abstractions;
using Puma.Modelo;
using Puma.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HidraBarrilhete : ContentPage
    {
        private List<ComboBox> simples = new List<ComboBox>();
        public List<ComboBox> nomeclatura = new List<ComboBox>();
        private List<ComboBox> apontamentos = new List<ComboBox>();
        private List<ComboBox> nota = new List<ComboBox>();
        private List<ComboBox> nivelRisco = new List<ComboBox>();
        private List<ComboBox> bomba_rolamentos = new List<ComboBox>();
        private List<ComboBox> bomba_acoplamentos = new List<ComboBox>();
        private List<ComboBox> bomba_selomecanico = new List<ComboBox>();
        private List<ComboBox> bomba_aquecimento = new List<ComboBox>();
        private List<ComboBox> bomba_pintura = new List<ComboBox>();
        private List<ComboBox> bomba_statusgeral = new List<ComboBox>();
        private List<ComboBox> bfe_fixacao = new List<ComboBox>();
        private List<ComboBox> bfe_vibrastop = new List<ComboBox>();
        private List<ComboBox> bfe_insteltrica = new List<ComboBox>();
        private List<ComboBox> bfe_statusgeral = new List<ComboBox>();
        private List<ComboBox> tub_material = new List<ComboBox>();
        private List<ComboBox> tub_acabemento = new List<ComboBox>();
        private List<ComboBox> tub_vazamento = new List<ComboBox>();
        private List<ComboBox> tub_fixacao = new List<ComboBox>();
        private List<ComboBox> reg_instalacoes = new List<ComboBox>();
        private List<ComboBox> reg_acabamentos = new List<ComboBox>();
        private List<ComboBox> reg_fixacao = new List<ComboBox>();
        private char editado = 'N';
        private Manipulacao manipulacao = new Manipulacao();
        private CarroselSubItems carousel = null;

        //Parte das Fotos 
        public List<Puma.ModelosBanco.FotosItem> FotosItem = new List<Puma.ModelosBanco.FotosItem>();
        public List<Puma.ModelosBanco.FotosItem> DeleteFotosItem = new List<Puma.ModelosBanco.FotosItem>();
        // parte do Banco
        public List<Puma.ModelosBanco.DetalhesItem> detalhesItem = null;
        public Puma.ModelosBanco.ItemSubItem itemSubItem = null;
        public Puma.Banco.AcessoBanco database = null;

        public HidraBarrilhete(CarroselSubItems carousel, Puma.ModelosBanco.ItemSubItem itemSubItem, Puma.Banco.AcessoBanco conexao)
        {

            this.database = conexao;
            this.itemSubItem = itemSubItem;
            this.carousel = carousel;
            InitializeComponent();

            simples.Add(new ComboBox(1, "Sim", "#008000"));
            simples.Add(new ComboBox(2, "Não", "#FF0000"));
            simples.Add(new ComboBox(3, "N/A", "#000000"));

            apontamentos.Add(new ComboBox(1, "Sim", "#FF0000"));
            apontamentos.Add(new ComboBox(2, "Não", "#008000"));
            apontamentos.Add(new ComboBox(3, "N/A", "#000000"));

            nomeclatura.Add(new ComboBox(1, "Caixa inferior", "#000000"));
            nomeclatura.Add(new ComboBox(2, "Caixa Superior", "#000000"));
            nomeclatura.Add(new ComboBox(3, "Caixa Reuso", "#000000"));

            nota.Add(new ComboBox(1, "35%", "#FF0000"));
            nota.Add(new ComboBox(2, "75%", "#FF9933"));
            nota.Add(new ComboBox(3, "100%", "#008000"));

            nivelRisco.Add(new ComboBox(1, "BAIXO", "#008000"));
            nivelRisco.Add(new ComboBox(2, "MÉDIO", "#FF9933"));
            nivelRisco.Add(new ComboBox(3, "ALTO", "#FF0000"));

            bomba_rolamentos.Add(new ComboBox(1, "Com ruídos", "#FF0000"));
            bomba_rolamentos.Add(new ComboBox(2, "Com vibrações", "#FF0000"));
            bomba_rolamentos.Add(new ComboBox(3, "Ok", "#008000"));
            bomba_rolamentos.Add(new ComboBox(4, "Irregular", "#FF0000"));

            bomba_acoplamentos.Add(new ComboBox(1, "Ok", "#008000"));
            bomba_acoplamentos.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bomba_acoplamentos.Add(new ComboBox(3, "Alinhado", "#008000"));
            bomba_acoplamentos.Add(new ComboBox(4, "Não Alinhado", "#FF0000"));
            bomba_acoplamentos.Add(new ComboBox(5, "Gaxeta irregular", "#FF0000"));

            bomba_selomecanico.Add(new ComboBox(1, "Ok", "#008000"));
            bomba_selomecanico.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bomba_selomecanico.Add(new ComboBox(3, "Vazando", "#FF0000"));

            bomba_aquecimento.Add(new ComboBox(1, "Sim", "#FF0000"));
            bomba_aquecimento.Add(new ComboBox(2, "Não", "#008000"));

            bomba_pintura.Add(new ComboBox(1, "Ok", "#008000"));
            bomba_pintura.Add(new ComboBox(2, "Oxidada", "#FF0000"));
            bomba_pintura.Add(new ComboBox(3, "Irregular", "#FF0000"));

            bomba_statusgeral.Add(new ComboBox(1, "Ok", "#008000"));
            bomba_statusgeral.Add(new ComboBox(2, "irregular", "#FF0000"));
            bomba_statusgeral.Add(new ComboBox(3, "Crítica", "#FF0000"));


            bfe_fixacao.Add(new ComboBox(1, "Ok", "#008000"));
            bfe_fixacao.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bfe_fixacao.Add(new ComboBox(3, "Não tem", "#FF0000"));

            bfe_vibrastop.Add(new ComboBox(1, "Ok", "#008000"));
            bfe_vibrastop.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bfe_vibrastop.Add(new ComboBox(3, "Não tem", "#FF0000"));

            bfe_insteltrica.Add(new ComboBox(1, "Ok", "#008000"));
            bfe_insteltrica.Add(new ComboBox(2, "Irregular", "#FF0000"));

            bfe_statusgeral.Add(new ComboBox(1, "Ok", "#008000"));
            bfe_statusgeral.Add(new ComboBox(2, "Solto", "#FF0000"));
            bfe_statusgeral.Add(new ComboBox(3, "Com corrosão", "#000000"));
            bfe_statusgeral.Add(new ComboBox(4, "NA", "#008000"));
            bfe_statusgeral.Add(new ComboBox(5, "Irregular", "#FF0000"));

            tub_material.Add(new ComboBox(1, "Ferro", "#000000"));
            tub_material.Add(new ComboBox(2, "Aço Carbono", "#000000"));
            tub_material.Add(new ComboBox(3, "PVC marron", "#000000"));
            tub_material.Add(new ComboBox(4, "CPVC Branco", "#000000"));
            tub_material.Add(new ComboBox(5, "Ferro Fundido", "#000000"));
            tub_material.Add(new ComboBox(6, "Mangueira Pex", "#000000"));
            tub_material.Add(new ComboBox(7, "PVC Branco", "#000000"));
            tub_material.Add(new ComboBox(8, "Cobre", "#000000"));
            tub_material.Add(new ComboBox(9, "PPR", "#000000"));
            tub_material.Add(new ComboBox(10, "Aço fundido", "#000000"));
            tub_material.Add(new ComboBox(11, "Concreto", "#000000"));

            tub_acabemento.Add(new ComboBox(1, "Isolada", "#008000"));
            tub_acabemento.Add(new ComboBox(2, "Sem pintura", "#FF0000"));
            tub_acabemento.Add(new ComboBox(3, "Sem isolação", "#FF0000"));
            tub_acabemento.Add(new ComboBox(4, "Pintura Ok", "#008000"));
            tub_acabemento.Add(new ComboBox(5, "Ok", "#008000"));
            tub_acabemento.Add(new ComboBox(6, "Envelopada", "#008000"));

            tub_vazamento.Add(new ComboBox(1, "Sim", "#FF0000"));
            tub_vazamento.Add(new ComboBox(2, "Não", "#008000"));
            tub_vazamento.Add(new ComboBox(3, "Irregular", "#FF0000"));


            tub_fixacao.Add(new ComboBox(1, "Ok", "#008000"));
            tub_fixacao.Add(new ComboBox(2, "Irregular", "#FF0000"));
            tub_fixacao.Add(new ComboBox(3, "Vazando", "#FF0000"));
            tub_fixacao.Add(new ComboBox(4, "Corrosão", "#FF0000"));
            tub_fixacao.Add(new ComboBox(5, "Sem Canopla", "#FF0000"));
            tub_fixacao.Add(new ComboBox(6, "Travado", "#FF0000"));

            reg_instalacoes.Add(new ComboBox(1, "Ok", "#008000"));
            reg_instalacoes.Add(new ComboBox(2, "Irregular", "#FF0000"));
            reg_instalacoes.Add(new ComboBox(3, "Sem identificação", "#FF0000"));

            reg_acabamentos.Add(new ComboBox(1, "Ok", "#008000"));
            reg_acabamentos.Add(new ComboBox(2, "Irregular", "#FF0000"));
            reg_acabamentos.Add(new ComboBox(3, "Sem identificação", "#FF0000"));

            reg_fixacao.Add(new ComboBox(1, "Ok", "#008000"));
            reg_fixacao.Add(new ComboBox(2, "Irregular", "#FF0000"));

            //PickerApontamentos.ItemsSource = simples;
            //PickerApontamentos.SelectedIndexChanged += this.PickerSimplesApontamentosChanged;

            PickerNomenclatura.ItemsSource = nomeclatura;
            PickerNomenclatura.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerAuditado.ItemsSource = simples;
            PickerAuditado.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerPlanejado.ItemsSource = simples;
            PickerPlanejado.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerExecutado.ItemsSource = simples;
            PickerExecutado.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerApontamentos.ItemsSource = apontamentos;
            PickerApontamentos.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerRolamentos.ItemsSource = bomba_rolamentos;
            PickerRolamentos.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerAcoplamento.ItemsSource = bomba_acoplamentos;
            PickerAcoplamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerSeloMecanico.ItemsSource = bomba_selomecanico;
            PickerSeloMecanico.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBombaAquecimento.ItemsSource = bomba_aquecimento;
            PickerBombaAquecimento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBombaPintura.ItemsSource = bomba_pintura;
            PickerBombaPintura.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBombaStatusGeral.ItemsSource = bomba_statusgeral;
            PickerBombaStatusGeral.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNotaBomba.ItemsSource = nota;
            PickerNotaBomba.SelectedIndexChanged += this.PickerNotaChanged;

            PickerBfeFixacao.ItemsSource = bfe_fixacao;
            PickerBfeFixacao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBfeVibStop.ItemsSource = bfe_vibrastop;
            PickerBfeVibStop.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBfeInstaEletrica.ItemsSource = bfe_insteltrica;
            PickerBfeInstaEletrica.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBfeStatusGeral.ItemsSource = bfe_statusgeral;
            PickerBfeStatusGeral.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNotaBfe.ItemsSource = nota;
            PickerNotaBfe.SelectedIndexChanged += this.PickerNotaChanged;

            PickerTubMaterial.ItemsSource = tub_material;
            PickerTubMaterial.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerTubAcabamento.ItemsSource = tub_acabemento;
            PickerTubAcabamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerTubVazamento.ItemsSource = tub_vazamento;
            PickerTubVazamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerTubFixacao.ItemsSource = tub_fixacao;
            PickerTubFixacao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNotaTub.ItemsSource = nota;
            PickerNotaTub.SelectedIndexChanged += this.PickerNotaChanged;

            PickerRegInstalacao.ItemsSource = reg_instalacoes;
            PickerRegInstalacao.SelectedIndexChanged += PickerSimpleChanged;

            PickerRegAcabamento.ItemsSource = reg_acabamentos;
            PickerRegAcabamento.SelectedIndexChanged += PickerSimpleChanged;

            PickerRegFixacao.ItemsSource = reg_fixacao;
            PickerRegFixacao.SelectedIndexChanged += PickerSimpleChanged;

            PickerNotaReg.ItemsSource = nota;
            PickerNotaReg.SelectedIndexChanged += PickerNotaChanged;

            PickerNivelRisco.ItemsSource = nivelRisco;
            PickerNivelRisco.SelectedIndexChanged += this.PickerSimpleChanged;

            this.CarregaDoBanco();
        }
        public int GetContador()
        {
            return itemSubItem.Contador;
        }
        public Boolean GetEditado()
        {
            if (this.editado == 'S')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CarregaDoBanco()
        {
            detalhesItem = database.GetDetalhesItems(this.itemSubItem);
            //string teste = PickerNivelRisco.ToString();
            //PickerNivelRisco.SelectedIndex = 1;
            //var teste = this.FindByName<Picker>("PickerNivelRisco");
            if (detalhesItem.Count != 0)
            {
                for (var i = 0; i < detalhesItem.Count; i++)
                {
                    if (detalhesItem[i].Tipo == "Picker")
                    {
                        this.FindByName<Picker>(detalhesItem[i].Name).SelectedIndex = detalhesItem[i].Index;
                    }
                    else
                    {
                        if (detalhesItem[i].Tipo == "Entry")
                        {
                            this.FindByName<Entry>(detalhesItem[i].Name).Text = detalhesItem[i].Text;
                        }
                        else
                        {
                            if (detalhesItem[i].Tipo == "Editor")
                            {
                                this.FindByName<Editor>(detalhesItem[i].Name).Text = detalhesItem[i].Text;
                            }
                        }
                    }
                }
                this.CarregaPictures();

            }
            else
            {
                this.editado = 'S';
            }
        }
        public void CarregaPictures()
        {
            this.FotosItem = database.GetFotosItems(this.itemSubItem);

            for (var i = 0; i < this.FotosItem.Count; i++)
            {
                Grid grid = (Grid)this.FindByName<Grid>(this.FotosItem[i].Name);
                this.AdicionarFotoCarregada(grid, FotosItem[i].Base64);
            }
        }
        public void AdicionarFotoCarregada(Grid grid, string base64)
        {
            var index = grid.Children.Count;
            var colum = grid.ColumnDefinitions.Count;
            var row = grid.RowDefinitions.Count;
            var multiplicacao = colum * row;

            if (multiplicacao > index)
            {
                row = index / colum;
                colum = index % colum;

            }
            else
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = 150 });
                colum = 0;
            }

            var image = new Image { Source = "", HeightRequest = 100 };

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += this.OpaCliclouNaFoto;
            image.GestureRecognizers.Add(tap);

            byte[] Base64Stream = Convert.FromBase64String(base64);
            image.Source = ImageSource.FromStream(() => new System.IO.MemoryStream(Base64Stream));

            grid.Children.Add(image, colum, row);

        }
        public void SavePictures()
        {
            for (var i = 0; i < FotosItem.Count; i++)
            {

                if (database.GetFotoItem(FotosItem[i]) == null)
                {
                    //create
                    database.CreateFotosItem(FotosItem[i]);
                }
            }
            for (var o = 0; o < DeleteFotosItem.Count; o++)
            {
                database.DeleteFotosItem(DeleteFotosItem[o]);
            }
        }

        public void Save()
        {
            this.SavePictures();
            if (detalhesItem.Count != 0)
            {
                for (var i = 0; i < detalhesItem.Count; i++)
                {
                    if (detalhesItem[i].Tipo == "Picker")
                    {
                        //this.FindByName<Picker>(detalhesItem[i].Name).SelectedIndex = detalhesItem[i].Index;
                        detalhesItem[i].Index = this.FindByName<Picker>(detalhesItem[i].Name).SelectedIndex;
                    }
                    else
                    {
                        if (detalhesItem[i].Tipo == "Entry")
                        {
                            detalhesItem[i].Text = this.FindByName<Entry>(detalhesItem[i].Name).Text;
                        }
                        else
                        {
                            if (detalhesItem[i].Tipo == "Editor")
                            {
                                detalhesItem[i].Text = this.FindByName<Editor>(detalhesItem[i].Name).Text;
                            }
                            else
                            {
                                if (detalhesItem[i].Tipo == "Label")
                                {
                                    detalhesItem[i].Text = this.FindByName<Label>(detalhesItem[i].Name).Text;
                                }

                            }
                        }
                    }

                    database.UpdateDetalheItem(detalhesItem[i]);
                }

            }
            else
            {
                //create
                Puma.ModelosBanco.DetalhesItem detalhe = null;

                //1
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNomenclatura, "PickerNomenclatura");
                database.CreateDetalheItem(detalhe);
                //2
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerAuditado, "PickerAuditado");
                database.CreateDetalheItem(detalhe);
                //3
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerPlanejado, "PickerPlanejado");
                database.CreateDetalheItem(detalhe);
                //4
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerExecutado, "PickerExecutado");
                database.CreateDetalheItem(detalhe);
                //5
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerApontamentos, "PickerApontamentos");
                database.CreateDetalheItem(detalhe);
                //6
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerRolamentos, "PickerRolamentos");
                database.CreateDetalheItem(detalhe);
                //7
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerAcoplamento, "PickerAcoplamento");
                database.CreateDetalheItem(detalhe);
                //8
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerSeloMecanico, "PickerSeloMecanico");
                database.CreateDetalheItem(detalhe);
                //9
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBombaAquecimento, "PickerBombaAquecimento");
                database.CreateDetalheItem(detalhe);
                //10
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBombaPintura, "PickerBombaPintura");
                database.CreateDetalheItem(detalhe);
                //11
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBombaStatusGeral, "PickerBombaStatusGeral");
                database.CreateDetalheItem(detalhe);
                //12
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNotaBomba, "PickerNotaBomba");
                database.CreateDetalheItem(detalhe);
                //13
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBfeFixacao, "PickerBfeFixacao");
                database.CreateDetalheItem(detalhe);
                //14
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBfeVibStop, "PickerBfeVibStop");
                database.CreateDetalheItem(detalhe);
                //15
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBfeInstaEletrica, "PickerBfeInstaEletrica");
                database.CreateDetalheItem(detalhe);
                //16
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBfeStatusGeral, "PickerBfeStatusGeral");
                database.CreateDetalheItem(detalhe);
                //17
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNotaBfe, "PickerNotaBfe");
                database.CreateDetalheItem(detalhe);
                //18
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerTubMaterial, "PickerTubMaterial");
                database.CreateDetalheItem(detalhe);
                //19
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerTubAcabamento, "PickerTubAcabamento");
                database.CreateDetalheItem(detalhe);
                //20
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerTubVazamento, "PickerTubVazamento");
                database.CreateDetalheItem(detalhe);
                //21
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerTubFixacao, "PickerTubFixacao");
                detalhe.Tipo = "Picker";
                database.CreateDetalheItem(detalhe);
                //22
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNotaTub, "PickerNotaTub");
                database.CreateDetalheItem(detalhe);
                //23
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerRegInstalacao, "PickerRegInstalacao");
                database.CreateDetalheItem(detalhe);
                //24
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerRegAcabamento, "PickerRegAcabamento");
                database.CreateDetalheItem(detalhe);
                //25
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerRegFixacao, "PickerRegFixacao");
                database.CreateDetalheItem(detalhe);
                //26
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNotaReg, "PickerNotaReg");
                database.CreateDetalheItem(detalhe);
                //27
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNivelRisco, "PickerNivelRisco");
                database.CreateDetalheItem(detalhe);

                /// Entry

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEntry(detalhe, EntryLocalizacao, "EntryLocalizacao");
                database.CreateDetalheItem(detalhe);


                //Editor

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioBombaFixEle, "EditorComentarioBombaFixEle");
                database.CreateDetalheItem(detalhe);

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioBomba, "EditorComentarioBomba");
                database.CreateDetalheItem(detalhe);

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioTubulacao, "EditorComentarioTubulacao");
                database.CreateDetalheItem(detalhe);

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioRegistros, "EditorComentarioRegistros");
                database.CreateDetalheItem(detalhe);

                //LabelNotaFiscal

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloLabel(detalhe, txtNotaFinal, "txtNotaFinal");
                database.CreateDetalheItem(detalhe);


            }
        }


        public void PickerSimpleChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            Picker pick = (Picker)sender;
            List<ComboBox> items = (List<ComboBox>)sender.GetType().GetProperty("ItemsSource").GetValue(sender, null);
            manipulacao.ChangePicker(sender, pick, items);
        }
        public void PickerNotaChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            Picker pick = (Picker)sender;
            List<ComboBox> items = (List<ComboBox>)sender.GetType().GetProperty("ItemsSource").GetValue(sender, null);
            manipulacao.ChangePicker(sender, pick, items);
            this.CalculaNotaFinal();
        }


        public void ChangeForSave()
        {
            this.editado = 'S';
            buttonAddSave.Text = "Salvar";
            buttonAddSave.Image = "arrow20.png";
        }


        public void OpaCliclouNaFoto(object sender, EventArgs e)
        {
            var imageSource = (StreamImageSource)sender.GetType().GetProperty("Source").GetValue(sender, null);
            Navigation.PushAsync(new ImagemFull(imageSource));
        }

        public void AdicionarFoto(Grid grid)
        {
            var index = grid.Children.Count;
            var colum = grid.ColumnDefinitions.Count;
            var row = grid.RowDefinitions.Count;
            var multiplicacao = colum * row;

            if (multiplicacao > index)
            {
                row = index / colum;
                colum = index % colum;

            }
            else
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = 150 });
                colum = 0;
            }

            var image = new Image { Source = "", HeightRequest = 100 };

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += this.OpaCliclouNaFoto;
            image.GestureRecognizers.Add(tap);
            this.CameraButton_Clicked(image, grid, colum, row);

        }
        public void AdicionarFotoBomba(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosBomba);
            this.ChangeForSave();
        }
        public void RemoverUltimaFotoBomba(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosBomba);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            }
        }

        public void AdicionarFotoBfe(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosBfe);
            this.ChangeForSave();
        }
        public void RemoverUltimaFotoBfe(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosBfe);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            }
        }

        public void AdicionarFotoTub(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosTub);
            this.ChangeForSave();
        }
        public void RemoverUltimaFotoTub(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosTub);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            }
        }

        public void AdicionarFotoReg(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosReg);
            this.ChangeForSave();
        }
        public void RemoverUltimaFotoReg(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosReg);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            }
        }
        public async void CameraButton_Clicked(Image image, Grid grid, int colum, int row)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported && !CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Alerta!", "Captura e seleção de foto não suportada", "ok");
            }
            else
            {
                StoreCameraMediaOptions store = new StoreCameraMediaOptions
                {
                    Directory = "Images",
                    Name = DateTime.Now + "_.jpg",
                    CompressionQuality = 30
                };

                var file = await CrossMedia.Current.TakePhotoAsync(store);
                if (file == null)
                    return;
                //await DisplayAlert("File Path", file.Path, "Ok");
                image.Source = ImageSource.FromStream(() => { return file.GetStream(); });
                grid.Children.Add(image, colum, row);

                var stream = file.GetStream();
                var bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                string base64 = System.Convert.ToBase64String(bytes);
                Puma.ModelosBanco.FotosItem foto = new Puma.ModelosBanco.FotosItem();
                foto.Idrelatorio = this.itemSubItem.RelatoriosId;
                foto.Idsetor = this.itemSubItem.Idsetor;
                foto.Idsubitem = this.itemSubItem.Idsubitem;
                foto.Iditemsubitem = this.itemSubItem.Id;
                if (grid == GridFotosBomba)
                {
                    foto.Name = "GridFotosBomba";
                }
                if (grid == GridFotosBfe)
                {
                    foto.Name = "GridFotosBfe";
                }
                if (grid == GridFotosTub)
                {
                    foto.Name = "GridFotosTub";
                }
                if (grid == GridFotosReg)
                {
                    foto.Name = "GridFotosReg";
                }

                foto.Base64 = base64;
                this.FotosItem.Add(foto);
            }

        }
        public void PressSaveAdd(EventHandler press)
        {
            if (this.editado == 'S')
            {
                //Salvar
                this.Save();
                this.editado = 'N';
                buttonAddSave.Text = "Adicionar";
                buttonAddSave.Image = "plusIcon30.png";
            }
            else
            {
                Puma.ModelosBanco.ItemSubItem subItem = new Puma.ModelosBanco.ItemSubItem();
                subItem.RelatoriosId = this.itemSubItem.RelatoriosId;
                subItem.Idsetor = this.itemSubItem.Idsetor;
                subItem.Idsubitem = this.itemSubItem.Idsubitem;
                subItem.Contador = this.itemSubItem.Contador + 1;

                Puma.ModelosBanco.Subitemsetor subSetor = new Puma.ModelosBanco.Subitemsetor();
                subSetor = database.GetSubItemSetor(subItem.RelatoriosId, subItem.Idsetor, subItem.Idsubitem);
                if (subSetor != null)
                {
                    subSetor.Quantidade = subItem.Contador;
                    database.UpdateeSubItemSetor(subSetor);
                }

                ContentPage barrilete = new HidraBarrilhete(this.carousel, subItem, database);
                this.database.CreateItemSubItem(subItem);
                this.carousel.Children.Add(barrilete);
                this.carousel.CurrentPage = barrilete;
            }

        }


        public void CalculaNotaFinal()
        {
            int nota1 = 0;
            int nota2 = 0;
            int nota3 = 0;
            int nota4 = 0;
            try
            {

                switch (this.nota[PickerNotaBfe.SelectedIndex].Id)
                {
                    case 1:
                        nota1 = 35;
                        break;
                    case 2:
                        nota1 = 75;
                        break;
                    case 3:
                        nota1 = 100;
                        break;
                }

            }
            catch (ArgumentOutOfRangeException e)
            {

            }

            try
            {

                switch (this.nota[PickerNotaBomba.SelectedIndex].Id)
                {
                    case 1:
                        nota2 = 35;
                        break;
                    case 2:
                        nota2 = 75;
                        break;
                    case 3:
                        nota2 = 100;
                        break;
                }

            }
            catch (ArgumentOutOfRangeException e)
            {

            }

            try
            {

                switch (this.nota[PickerNotaReg.SelectedIndex].Id)
                {
                    case 1:
                        nota3 = 35;
                        break;
                    case 2:
                        nota3 = 75;
                        break;
                    case 3:
                        nota3 = 100;
                        break;
                }

            }
            catch (ArgumentOutOfRangeException e)
            {

            }
            try
            {

                switch (this.nota[PickerNotaTub.SelectedIndex].Id)
                {
                    case 1:
                        nota4 = 35;
                        break;
                    case 2:
                        nota4 = 75;
                        break;
                    case 3:
                        nota4 = 100;
                        break;
                }

            }
            catch (ArgumentOutOfRangeException e)
            {

            }

            int valorfinal = (nota1 + nota2 + nota3 + nota4) / 4;

            string stringfinal = valorfinal.ToString() + "%";
            var Color = new Color();

            if (valorfinal < 75)
            {
                Color = Color.FromHex("#FF0000");
                txtNotaFinal.TextColor = Color;
            }
            else
            {
                if (valorfinal == 100)
                {
                    Color = Color.FromHex("#008000");
                    txtNotaFinal.TextColor = Color;
                }
                else
                {
                    Color = Color.FromHex("#FF9933");
                    txtNotaFinal.TextColor = Color;
                }
            }
            txtNotaFinal.Text = stringfinal;
        }



    }
}