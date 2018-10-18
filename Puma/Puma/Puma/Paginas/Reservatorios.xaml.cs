using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Puma.Modelo;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reservatorios : ContentPage
    {
        //private Picker _picker;
        private List<ComboBox> simples = new List<ComboBox>();
        private List<ComboBox> nomeclatura = new List<ComboBox>();
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
        public Reservatorios()
        {
            InitializeComponent();


            //simples.Add(new ComboBox(1, "Sim", "#99FF99"));
            //simples.Add(new ComboBox(2, "Não", "#FF4D4D"));
            //simples.Add(new ComboBox(3, "N/A", "#CCCCCC"));

            simples.Add(new ComboBox(1, "Sim", "#008000"));
            simples.Add(new ComboBox(2, "Não", "#FF0000"));
            simples.Add(new ComboBox(3, "N/A", "#000000"));

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
            PickerApontamentos.ItemsSource = simples;
            PickerApontamentos.SelectedIndexChanged += this.PickerSimplesApontamentosChanged;

            PickerExecutado.ItemsSource = simples;
            PickerExecutado.SelectedIndexChanged += this.PickerSimplesExecutadoChanged;

            PickerPlanejado.ItemsSource = simples;
            PickerPlanejado.SelectedIndexChanged += this.PickerSimplesPlanejadoChanged;

            PickerAuditado.ItemsSource = simples;
            PickerAuditado.SelectedIndexChanged += this.PickerSimplesAuditadosChanged;

            //Pickers Especificos

            PickerTipo.ItemsSource = tipo;
            PickerTipo.SelectedIndexChanged += this.PickerTipoChanged;

            PickerNomenclatura.ItemsSource = nomeclatura;
            PickerAuditado.SelectedIndexChanged += this.PickerNomenclaturaChanged;

            PickerFechamento.ItemsSource = nomeclatura;
            PickerFechamento.SelectedIndexChanged += this.PickerFechamentoChanged;

            PickerHermetico.ItemsSource = nomeclatura;
            PickerHermetico.SelectedIndexChanged += this.PickerHermeticoChanged;

            PickerStatusGeral.ItemsSource = statusgeral;
            PickerStatusGeral.SelectedIndexChanged += this.PickerStatusGeralChanged;

            PickerNotaPortinhola.ItemsSource = nota;
            PickerNotaPortinhola.SelectedIndexChanged += this.PickerNotaPortinholaChanged;

            PickerNotaIper.ItemsSource = nota;
            PickerNotaIper.SelectedIndexChanged += this.PickerNotaIperChanged;

            PickerStatusGeralIper.ItemsSource = statusIper;
            PickerStatusGeralIper.SelectedIndexChanged += this.PickerStatusGeralIperChanged;

            PickerEstruturaIper.ItemsSource = estruturaIper;
            PickerEstruturaIper.SelectedIndexChanged += this.PickerEstruturaIperChanged;

            PickerTipoIper.ItemsSource = tipoIper;
            PickerTipoIper.SelectedIndexChanged += this.PickerTipoIperChanged;


            PickerAguaLimp.ItemsSource = aguaLimp;
            PickerAguaLimp.SelectedIndexChanged += this.PickerAguaLimpChanged;


            PickerBoiaLimp.ItemsSource = boiaLimp;
            PickerBoiaLimp.SelectedIndexChanged += this.PickerBoiaLimpChanged;

            PickerStatusGeralLimp.ItemsSource = statusLimp;
            PickerStatusGeralLimp.SelectedIndexChanged += this.PickerStatusGeralLimpChanged;

            PickerNotaLimp.ItemsSource = nota;
            PickerNotaLimp.SelectedIndexChanged += this.PickerNotaLimpChanged;


            PickerNivelRisco.ItemsSource = nivelRisco;
            PickerNivelRisco.SelectedIndexChanged += this.PickerNivelRiscoChange;


            this.CalculaNotaFinal();

        }
        public void PickerSimplesApontamentosChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(simples[index].Color);
                PickerApontamentos.TextColor = Color;
            }
        }
        public void PickerSimplesExecutadoChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(simples[index].Color);
                PickerExecutado.TextColor = Color;
            }
        }
        public void PickerSimplesPlanejadoChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(simples[index].Color);
                PickerPlanejado.TextColor = Color;
            }
        }
        public void PickerSimplesAuditadosChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(simples[index].Color);
                PickerAuditado.TextColor = Color;
            }
        }
        public void PickerTipoChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(tipo[index].Color);
                PickerTipo.TextColor = Color;
            }
        }
        public void PickerNomenclaturaChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(nomeclatura[index].Color);
                PickerNomenclatura.TextColor = Color;
            }
        }
        public void PickerFechamentoChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(fechamento[index].Color);
                PickerFechamento.TextColor = Color;
            }
        }
        public void PickerHermeticoChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(hermetico[index].Color);
                PickerHermetico.TextColor = Color;
            }
        }
        public void PickerStatusGeralChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(statusgeral[index].Color);
                PickerStatusGeral.TextColor = Color;
            }
        }
        public void PickerNotaPortinholaChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(nota[index].Color);
                PickerNotaPortinhola.TextColor = Color;
            }
            this.CalculaNotaFinal();
        }
        public void PickerNotaIperChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(nota[index].Color);
                PickerNotaIper.TextColor = Color;
            }
            this.CalculaNotaFinal();
        }
        public void PickerStatusGeralIperChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(statusIper[index].Color);
                PickerStatusGeralIper.TextColor = Color;
            }
        }
        public void PickerEstruturaIperChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(estruturaIper[index].Color);
                PickerEstruturaIper.TextColor = Color;
            }
        }
        public void PickerTipoIperChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(tipoIper[index].Color);
                PickerTipoIper.TextColor = Color;
            }
        }
        public void PickerAguaLimpChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(aguaLimp[index].Color);
                PickerAguaLimp.TextColor = Color;
            }
        }
        public void PickerBoiaLimpChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(boiaLimp[index].Color);
                PickerBoiaLimp.TextColor = Color;
            }
        }
        public void PickerStatusGeralLimpChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(statusLimp[index].Color);
                PickerStatusGeralLimp.TextColor = Color;
            }
        }

        public void PickerNotaLimpChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(nota[index].Color);
                PickerNotaLimp.TextColor = Color;
            }
            this.CalculaNotaFinal();
        }
        public void PickerNivelRiscoChange(object sender, EventArgs e)
        {
            this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            //var items = sender.GetType().GetProperty("ItemsSource").GetValue(sender, null);
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(nivelRisco[index].Color);
                PickerNivelRisco.TextColor = Color;
            }
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
                // Adicionar um novo no carroseel
            }

        }

        public void OpaCliclouNaFoto(object sender, EventArgs e)
        {
            var selectedIndex = sender.GetType().GetProperty("Source").GetValue(sender, null);
            var file = selectedIndex.GetType().GetProperty("File").GetValue(selectedIndex, null).ToString();
            Navigation.PushAsync(new ImagemFull(file));
        }

        public void AdicionarFotoIper(object sender, EventArgs e)
        {
            var index = GridFotosIper.Children.Count;
            var colum = GridFotosIper.ColumnDefinitions.Count;
            var row = GridFotosIper.RowDefinitions.Count;
            var multiplicacao = colum * row;

            if (multiplicacao > index)
            {
                row = index / colum;
                colum = index % colum;

            }
            else
            {
                GridFotosIper.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                colum = 0;
            }


            var image = new Image { Source = "pumoLogo300.png", HeightRequest = 50, WidthRequest = 50 };
            GridFotosIper.Children.Add(image, colum, row);



        }

        public void RemoverUltimaFotoIper(object sender, EventArgs e)
        {
            var index = GridFotosIper.Children.Count;
            if (index > 0)
            {
                index = index - 1;
                GridFotosIper.Children.RemoveAt(index);
            }
        }


        //private async void CameraButton_Clicked(object sender, EventArgs e)
        //{
        //    var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

        //    if (photo != null)
        //        PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
        //}

        public void Save()
        {

        }









    }
}