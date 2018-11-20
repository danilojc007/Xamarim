using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Puma.Modelo;

using Puma.Service;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reservatorios : ContentPage
    {
        //private Picker _picker;
        private List<ComboBox> simples = new List<ComboBox>();
        private List<ComboBox> nomeclatura = new List<ComboBox>();
        private List<ComboBox> apontamentos = new List<ComboBox>();
        private List<ComboBox> tipo = new List<ComboBox>();
        private List<ComboBox> fechamento = new List<ComboBox>();
        private List<ComboBox> hermetico = new List<ComboBox>();
        private List<ComboBox> statusgeral = new List<ComboBox>();
        private List<ComboBox> nota = new List<ComboBox>();
        private List<ComboBox> tipoIper = new List<ComboBox>();
        private List<ComboBox> estruturaIper = new List<ComboBox>();
        private List<ComboBox> statusIper = new List<ComboBox>();
        private List<ComboBox> aguaLimp = new List<ComboBox>();
        private List<ComboBox> boiaLimp = new List<ComboBox>();
        private List<ComboBox> statusLimp = new List<ComboBox>();
        private List<ComboBox> nivelRisco = new List<ComboBox>();
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
        public Reservatorios(CarroselSubItems carousel, Puma.ModelosBanco.ItemSubItem itemSubItem, Puma.Banco.AcessoBanco conexao)
        {
            InitializeComponent();
            this.database = conexao;
            this.itemSubItem = itemSubItem;
            this.carousel = carousel;


            simples.Add(new ComboBox(1, "Sim", "#008000"));
            simples.Add(new ComboBox(2, "Não", "#FF0000"));
            simples.Add(new ComboBox(3, "N/A", "#000000"));

            apontamentos.Add(new ComboBox(1, "Sim", "#FF0000"));
            apontamentos.Add(new ComboBox(2, "Não", "#008000"));
            apontamentos.Add(new ComboBox(3, "N/A", "#000000"));

            nomeclatura.Add(new ComboBox(1, "Incêndio", "#000000"));
            nomeclatura.Add(new ComboBox(2, "Consumo", "#000000"));
            nomeclatura.Add(new ComboBox(3, "Reuso", "#000000"));
            nomeclatura.Add(new ComboBox(4, "Consumo/Incêndio", "#000000"));

            tipo.Add(new ComboBox(1, "Concreto", "#000000"));
            tipo.Add(new ComboBox(2, "Fibra", "#000000"));
            tipo.Add(new ComboBox(3, "Polietileno", "#000000"));
            tipo.Add(new ComboBox(4, "Metálico", "#000000"));

            fechamento.Add(new ComboBox(1, "Cadeado", "#008000"));
            fechamento.Add(new ComboBox(2, "Não tem", "#FF0000"));
            fechamento.Add(new ComboBox(3, "Irregular", "#FF0000"));
            fechamento.Add(new ComboBox(4, "Ok", "#008000"));

            hermetico.Add(new ComboBox(1, "Sim", "#008000"));
            hermetico.Add(new ComboBox(2, "Não", "#FF0000"));
            hermetico.Add(new ComboBox(3, "Irregular", "#FF0000"));
            hermetico.Add(new ComboBox(4, "N/A", "#000000"));

            statusgeral.Add(new ComboBox(1, "Corrosão", "#FF0000"));
            statusgeral.Add(new ComboBox(2, "Danificada", "#FF0000"));
            statusgeral.Add(new ComboBox(3, "Irregular", "#FF0000"));
            statusgeral.Add(new ComboBox(4, "Ok", "#008000"));

            nota.Add(new ComboBox(1, "35%", "#FF0000"));
            nota.Add(new ComboBox(2, "75%", "#FF9933"));
            nota.Add(new ComboBox(3, "100%", "#008000"));

            tipoIper.Add(new ComboBox(1, "Asfáltica", "#000000"));
            tipoIper.Add(new ComboBox(2, "Rígida", "#000000"));
            tipoIper.Add(new ComboBox(3, "Flexivel", "#000000"));
            tipoIper.Add(new ComboBox(4, "Polimérica", "#000000"));

            estruturaIper.Add(new ComboBox(1, "Corrosão", "#FF0000"));
            estruturaIper.Add(new ComboBox(2, "Ok", "#008000"));
            estruturaIper.Add(new ComboBox(3, "Irregular", "#FF0000"));
            estruturaIper.Add(new ComboBox(4, "Pontos aparente", "#FF0000"));


            statusIper.Add(new ComboBox(1, "Ok", "#008000"));
            statusIper.Add(new ComboBox(2, "Irregular", "#FF0000"));
            statusIper.Add(new ComboBox(3, "Soltando", "#FF0000"));
            statusIper.Add(new ComboBox(4, "Com bolhas", "#FF0000"));
            statusIper.Add(new ComboBox(5, "Com fissuras", "#FF0000"));
            statusIper.Add(new ComboBox(6, "Sem proteção", "#FF0000"));

            aguaLimp.Add(new ComboBox(1, "Limpa", "#008000"));
            aguaLimp.Add(new ComboBox(2, "Turva", "#FF0000"));
            aguaLimp.Add(new ComboBox(3, "Com partículas", "#FF0000"));

            boiaLimp.Add(new ComboBox(1, "Ok", "#008000"));
            boiaLimp.Add(new ComboBox(2, "Irregular", "#FF0000"));
            boiaLimp.Add(new ComboBox(3, "Não Tem", "#FF0000"));
            boiaLimp.Add(new ComboBox(4, "Elétrica irregular", "#FF0000"));

            statusLimp.Add(new ComboBox(1, "Ok", "#008000"));
            statusLimp.Add(new ComboBox(2, "Irregular", "#FF0000"));
            statusLimp.Add(new ComboBox(3, "Critíco", "#FF0000"));

            nivelRisco.Add(new ComboBox(1, "BAIXO", "#008000"));
            nivelRisco.Add(new ComboBox(2, "MÉDIO", "#FF9933"));
            nivelRisco.Add(new ComboBox(3, "ALTO", "#FF0000"));

            //Picker Simples
            PickerApontamentos.ItemsSource = apontamentos;
            PickerApontamentos.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerExecutado.ItemsSource = simples;
            PickerExecutado.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerPlanejado.ItemsSource = simples;
            PickerPlanejado.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerAuditado.ItemsSource = simples;
            PickerAuditado.SelectedIndexChanged += this.PickerSimpleChanged;

            //Pickers Especificos

            PickerTipo.ItemsSource = tipo;
            PickerTipo.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNomenclatura.ItemsSource = nomeclatura;
            PickerAuditado.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerFechamento.ItemsSource = nomeclatura;
            PickerFechamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerHermetico.ItemsSource = nomeclatura;
            PickerHermetico.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerStatusGeral.ItemsSource = statusgeral;
            PickerStatusGeral.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNotaPortinhola.ItemsSource = nota;
            PickerNotaPortinhola.SelectedIndexChanged += this.PickerNotaChanged;

            PickerNotaIper.ItemsSource = nota;
            PickerNotaIper.SelectedIndexChanged += this.PickerNotaChanged;

            PickerStatusGeralIper.ItemsSource = statusIper;
            PickerStatusGeralIper.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerEstruturaIper.ItemsSource = estruturaIper;
            PickerEstruturaIper.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerTipoIper.ItemsSource = tipoIper;
            PickerTipoIper.SelectedIndexChanged += this.PickerSimpleChanged;


            PickerAguaLimp.ItemsSource = aguaLimp;
            PickerAguaLimp.SelectedIndexChanged += this.PickerSimpleChanged;


            PickerBoiaLimp.ItemsSource = boiaLimp;
            PickerBoiaLimp.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerStatusGeralLimp.ItemsSource = statusLimp;
            PickerStatusGeralLimp.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNotaLimp.ItemsSource = nota;
            PickerNotaLimp.SelectedIndexChanged += this.PickerNotaChanged;


            PickerNivelRisco.ItemsSource = nivelRisco;
            PickerNivelRisco.SelectedIndexChanged += this.PickerSimpleChanged;

            this.CarregaDoBanco();
            this.CalculaNotaFinal();



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
        public void CalculaNotaFinal()
        {
            int nota1 = 0;
            int nota2 = 0;
            int nota3 = 0;
            try
            {

                switch (this.nota[PickerNotaLimp.SelectedIndex].Id)
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

                switch (this.nota[PickerNotaIper.SelectedIndex].Id)
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

                switch (this.nota[PickerNotaPortinhola.SelectedIndex].Id)
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

            int valorfinal = (nota1 + nota2 + nota3) / 3;

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

        public void ChangeForSave()
        {
            this.editado = 'S';
            buttonAddSave.Text = "Salvar";
            buttonAddSave.Image = "arrow20.png";
        }

        public void PressSaveAdd(EventHandler press)
        {
            if (this.editado == 'S')
            {
                //Salvar
                this.Save();
                buttonAddSave.Text = "Adicionar";
                buttonAddSave.Image = "plusIcon30.png";
                this.editado = 'N';

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

                ContentPage reservatorio = new Reservatorios(this.carousel, subItem, database);
                this.database.CreateItemSubItem(subItem);
                this.carousel.Children.Add(reservatorio);
                this.carousel.CurrentPage = reservatorio;
            }

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

        public void AdicionarFotoIper(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosIper);
            this.ChangeForSave();
        }

        public void RemoverUltimaFotoIper(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosIper);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            }
        }

        public void AdicionarFotoProt(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosPort);
            this.ChangeForSave();
        }

        public void RemoverUltimaFotoPort(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosPort);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            };
        }

        public void AdicionarFotoLimp(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosLimp);
            this.ChangeForSave();
        }

        public void RemoverUltimaFotoLimp(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosLimp);
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
                if (grid == GridFotosLimp)
                {
                    foto.Name = "GridFotosLimp";
                }
                if (grid == GridFotosIper)
                {
                    foto.Name = "GridFotosIper";
                }
                if (grid == GridFotosPort)
                {
                    foto.Name = "GridFotosPort";
                }

                foto.Base64 = base64;
                this.FotosItem.Add(foto);
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
            image.Source = ImageSource.FromStream(() => new MemoryStream(Base64Stream));

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
                //1.1
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerTipo, "PickerTipo");
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
                //6 -- 1 ° Nivel --
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerFechamento, "PickerFechamento");
                database.CreateDetalheItem(detalhe);
                //7
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerHermetico, "PickerHermetico");
                database.CreateDetalheItem(detalhe);
                //8
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerStatusGeral, "PickerStatusGeral");
                database.CreateDetalheItem(detalhe);
                //9
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNotaPortinhola, "PickerNotaPortinhola");
                database.CreateDetalheItem(detalhe);
                //10 -- 2° Nivel
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerTipoIper, "PickerTipoIper");
                database.CreateDetalheItem(detalhe);
                //11
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerEstruturaIper, "PickerEstruturaIper");
                database.CreateDetalheItem(detalhe);
                //12
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerStatusGeralIper, "PickerStatusGeralIper");
                database.CreateDetalheItem(detalhe);
                //13
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNotaIper, "PickerNotaIper");
                database.CreateDetalheItem(detalhe);
                //14 -- 3 ° Nivel ---
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerAguaLimp, "PickerAguaLimp");
                database.CreateDetalheItem(detalhe);
                //15
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBoiaLimp, "PickerBoiaLimp");
                database.CreateDetalheItem(detalhe);
                //16
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerStatusGeralLimp, "PickerStatusGeralLimp");
                database.CreateDetalheItem(detalhe);
                //17
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNotaLimp, "PickerNotaLimp");
                database.CreateDetalheItem(detalhe);

                //51 -- Fim Nivel de Risco --
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNivelRisco, "PickerNivelRisco");
                database.CreateDetalheItem(detalhe);

                /// Entry

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEntry(detalhe, EntryLocalizacao, "EntryLocalizacao");
                database.CreateDetalheItem(detalhe);


                //Editor

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioPort, "EditorComentarioPort");
                database.CreateDetalheItem(detalhe);

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioIper, "EditorComentarioIper");
                database.CreateDetalheItem(detalhe);

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioLimp, "EditorComentarioLimp");
                database.CreateDetalheItem(detalhe);

                //LabelNotaFiscal

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloLabel(detalhe, txtNotaFinal, "txtNotaFinal");
                database.CreateDetalheItem(detalhe);


            }
        }
    }
}