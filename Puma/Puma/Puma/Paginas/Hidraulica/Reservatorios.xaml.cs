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
        private CarouselPage carousel = null;
        public Reservatorios(CarouselPage carousel)
        {
            InitializeComponent();
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


            this.CalculaNotaFinal();

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

            }
            else
            {
                ContentPage reservatorio = new Reservatorios(this.carousel);
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
        }

        public void RemoverUltimaFotoIper(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosIper);
        }

        public void AdicionarFotoProt(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosPort);
        }

        public void RemoverUltimaFotoPort(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosPort);
        }

        public void AdicionarFotoLimp(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosLimp);
        }

        public void RemoverUltimaFotoLimp(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosLimp);
        }

        public async void CameraButton_Clicked(Image image, Grid grid, int colum, int row)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported && !CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Message", "Captura e seleção de foto não suportada", "ok");
            }
            else
            {
                StoreCameraMediaOptions store = new StoreCameraMediaOptions
                {
                    Directory = "Images",
                    Name = DateTime.Now + "_.jpg"
                };

                var file = await CrossMedia.Current.TakePhotoAsync(store);
                if (file == null)
                    return;
                //await DisplayAlert("File Path", file.Path, "Ok");
                image.Source = ImageSource.FromStream(() => { return file.GetStream(); });
                grid.Children.Add(image, colum, row);
            }

        }

        public async void Save()
        {

        }



    }
}