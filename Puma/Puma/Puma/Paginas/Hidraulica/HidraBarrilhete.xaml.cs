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
        private List<ComboBox> nomeclatura = new List<ComboBox>();
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
        private CarouselPage carousel = null;
        public HidraBarrilhete(CarouselPage carousel)
        {
            InitializeComponent();
            this.carousel = carousel;

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
        }
        public void RemoverUltimaFotoBomba(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosBomba);
        }

        public void AdicionarFotoBfe(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosBfe);
        }
        public void RemoverUltimaFotoBfe(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosBfe);
        }

        public void AdicionarFotoTub(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosTub);
        }
        public void RemoverUltimaFotoTub(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosTub);
        }

        public void AdicionarFotoReg(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosReg);
        }
        public void RemoverUltimaFotoReg(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosReg);
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
                ContentPage barrilete = new HidraBarrilhete(this.carousel);
                this.carousel.Children.Add(barrilete);
                this.carousel.CurrentPage = barrilete;
            }

        }
        public void Save() { }

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