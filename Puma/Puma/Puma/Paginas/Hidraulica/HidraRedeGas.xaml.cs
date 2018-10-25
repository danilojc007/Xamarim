﻿using Plugin.Media;
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

namespace Puma.Paginas.Hidraulica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HidraRedeGas : ContentPage
    {
        // Paramentros Principais
        private char editado = 'N';
        private Manipulacao manipulacao = new Manipulacao();
        private CarouselPage carousel = null;
        //Listas Comum
        private List<ComboBox> simples = new List<ComboBox>();
        private List<ComboBox> nota = new List<ComboBox>();
        private List<ComboBox> apontamentos = new List<ComboBox>();
        private List<ComboBox> nivelRisco = new List<ComboBox>();
        // Lista Especifivo
        private List<ComboBox> nomenclatura = new List<ComboBox>();
        private List<ComboBox> tubMaterial = new List<ComboBox>();
        private List<ComboBox> tubAcabamento = new List<ComboBox>();
        private List<ComboBox> tubVazamento = new List<ComboBox>();
        private List<ComboBox> tubFixacao = new List<ComboBox>();
        private List<ComboBox> regInstalacao = new List<ComboBox>();
        private List<ComboBox> regAcabamento = new List<ComboBox>();
        private List<ComboBox> regFixacao = new List<ComboBox>();
        private List<ComboBox> centralSistema = new List<ComboBox>();
        private List<ComboBox> centralTanques = new List<ComboBox>();
        private List<ComboBox> centralDetectorGas = new List<ComboBox>();
        private List<ComboBox> centralExtintores = new List<ComboBox>();
        private List<ComboBox> centralLocal = new List<ComboBox>();
        public HidraRedeGas(CarouselPage carousel)
        {
            InitializeComponent();
            this.carousel = carousel;
            //Lista Comum
            simples.Add(new ComboBox(1, "Sim", "#008000"));
            simples.Add(new ComboBox(2, "Não", "#FF0000"));
            simples.Add(new ComboBox(3, "N/A", "#000000"));

            apontamentos.Add(new ComboBox(1, "Sim", "#FF0000"));
            apontamentos.Add(new ComboBox(2, "Não", "#008000"));
            apontamentos.Add(new ComboBox(3, "N/A", "#000000"));

            nota.Add(new ComboBox(1, "35%", "#FF0000"));
            nota.Add(new ComboBox(2, "75%", "#FF9933"));
            nota.Add(new ComboBox(3, "100%", "#008000"));

            nivelRisco.Add(new ComboBox(1, "BAIXO", "#008000"));
            nivelRisco.Add(new ComboBox(2, "MÉDIO", "#FF9933"));
            nivelRisco.Add(new ComboBox(3, "ALTO", "#FF0000"));

            //Lista Especifica
            nomenclatura.Add(new ComboBox(1, "Rede de água quente", "#000000"));
            nomenclatura.Add(new ComboBox(2, "Rede de água fria", "#000000"));


            tubMaterial.Add(new ComboBox(1, "Ferro", "#000000"));
            tubMaterial.Add(new ComboBox(2, "Aço Carbono", "#000000"));
            tubMaterial.Add(new ComboBox(3, "PVC marron", "#000000"));
            tubMaterial.Add(new ComboBox(4, "CPVC Branco", "#000000"));
            tubMaterial.Add(new ComboBox(5, "Ferro Fundido", "#000000"));
            tubMaterial.Add(new ComboBox(6, "Mangueira Pex", "#000000"));
            tubMaterial.Add(new ComboBox(7, "PVC Branco", "#000000"));
            tubMaterial.Add(new ComboBox(8, "Cobre", "#000000"));
            tubMaterial.Add(new ComboBox(9, "PPR", "#000000"));
            tubMaterial.Add(new ComboBox(10, "Aço fundido", "#000000"));
            tubMaterial.Add(new ComboBox(11, "Concreto", "#000000"));

            tubAcabamento.Add(new ComboBox(1, "Isolada", "#008000"));
            tubAcabamento.Add(new ComboBox(2, "Sem pintura", "#FF0000"));
            tubAcabamento.Add(new ComboBox(3, "Sem isolação", "#FF0000"));
            tubAcabamento.Add(new ComboBox(4, "Pintura Ok", "#008000"));
            tubAcabamento.Add(new ComboBox(5, "Ok", "#008000"));
            tubAcabamento.Add(new ComboBox(6, "Envelopada", "#008000"));

            tubVazamento.Add(new ComboBox(1, "Sim", "#FF0000"));
            tubVazamento.Add(new ComboBox(2, "Não", "008000"));
            tubVazamento.Add(new ComboBox(3, "Irregular", "#FF0000"));


            tubFixacao.Add(new ComboBox(1, "Ok", "#008000"));
            tubFixacao.Add(new ComboBox(2, "Irregular", "#FF0000"));
            tubFixacao.Add(new ComboBox(3, "Vazando", "#FF0000"));
            tubFixacao.Add(new ComboBox(4, "Corrosão", "#FF0000"));
            tubFixacao.Add(new ComboBox(5, "Sem Canopla", "#FF0000"));
            tubFixacao.Add(new ComboBox(6, "Travado", "#FF0000"));

            regInstalacao.Add(new ComboBox(1, "Ok", "#008000"));
            regInstalacao.Add(new ComboBox(2, "Irregular", "#FF0000"));
            regInstalacao.Add(new ComboBox(3, "Sem identificação", "#FF0000"));

            regAcabamento.Add(new ComboBox(1, "Ok", "#008000"));
            regAcabamento.Add(new ComboBox(2, "Irregular", "#FF0000"));
            regAcabamento.Add(new ComboBox(3, "Sem identificação", "#FF0000"));

            centralSistema.Add(new ComboBox(1, "Gás Natural", "#000000"));
            centralSistema.Add(new ComboBox(2, "Gás GLP", "#000000"));

            centralTanques.Add(new ComboBox(1, "Ok", "#008000"));
            centralTanques.Add(new ComboBox(2, "Irregular", "#FF0000"));
            centralTanques.Add(new ComboBox(3, "Corrosão", "#FF0000"));
            centralTanques.Add(new ComboBox(4, "NA", "#000000"));

            centralDetectorGas.Add(new ComboBox(1, "Ok", "#008000"));
            centralDetectorGas.Add(new ComboBox(2, "Não tem", "#FF0000"));
            centralDetectorGas.Add(new ComboBox(3, "Corrosão", "#FF0000"));

            centralExtintores.Add(new ComboBox(1, "Ok", "#008000"));
            centralExtintores.Add(new ComboBox(2, "Não tem", "#FF0000"));
            centralExtintores.Add(new ComboBox(3, "Corrosão", "#FF0000"));

            centralLocal.Add(new ComboBox(1, "Ok", "#008000"));
            centralLocal.Add(new ComboBox(2, "Não tem", "#FF0000"));
            centralLocal.Add(new ComboBox(3, "Corrosão", "#FF0000"));



            PickerNomenclatura.ItemsSource = nomenclatura;
            PickerNomenclatura.SelectedIndexChanged += this.PickerSimpleChanged;

            //---------- Simples ---------

            PickerAuditado.ItemsSource = simples;
            PickerAuditado.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerPlanejado.ItemsSource = simples;
            PickerPlanejado.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerExecutado.ItemsSource = simples;
            PickerAuditado.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerApontamentos.ItemsSource = apontamentos;
            PickerApontamentos.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNivelRisco.ItemsSource = nivelRisco;
            PickerNivelRisco.SelectedIndexChanged += this.PickerSimpleChanged;

            //------------ Tubulação ------------ -
            PickerTubMaterial.ItemsSource = tubMaterial;
            PickerTubMaterial.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerTubAcabamento.ItemsSource = tubAcabamento;
            PickerTubAcabamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerTubVazamento.ItemsSource = tubVazamento;
            PickerTubVazamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerTubFixacao.ItemsSource = tubFixacao;
            PickerTubFixacao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNotaTub.ItemsSource = nota;
            PickerNotaTub.SelectedIndexChanged += this.PickerNotaChanged;
            //----------------  Registros --------

            PickerRegInstalacao.ItemsSource = regInstalacao;
            PickerRegInstalacao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerRegAcabamento.ItemsSource = regAcabamento;
            PickerRegAcabamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerRegFixacao.ItemsSource = regFixacao;
            PickerRegFixacao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNotaReg.ItemsSource = nota;
            PickerNotaReg.SelectedIndexChanged += this.PickerNotaChanged;

            //CentrAL

            PickerCentralSistema.ItemsSource = centralSistema;
            PickerCentralTanques.ItemsSource = centralTanques;
            PickerCentralDetectorGas.ItemsSource = centralDetectorGas;
            PickerCentralExtintores.ItemsSource = centralExtintores;
            PickerCentralLocal.ItemsSource = centralLocal;
            PickerNotaCentral.ItemsSource = nota;
            PickerNotaCentral.SelectedIndexChanged += this.PickerNotaChanged;


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
        public void AdicionarFotoCentral(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosCentral);
        }
        public void RemoverUltimaFotoCentral(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosCentral);
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
                this.editado = 'N';
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
            List<ClassePicker> listaPicker = new List<ClassePicker>();
            int soma = 0;
            int quantidade = 0;
            int valorFinal = 0;


            listaPicker.Add(new ClassePicker(PickerNotaTub, 1));
            listaPicker.Add(new ClassePicker(PickerNotaReg, 2));
            listaPicker.Add(new ClassePicker(PickerNotaCentral, 3));

            for (var i = 0; i < listaPicker.Count; i++)
            {
                //Picker pick = listaPicker[i].picker;
                //(List<ComboBox>)sender.GetType().GetProperty("ItemsSource").GetValue(sender, null);
                List<ComboBox> items = (List<ComboBox>)listaPicker[i].picker.GetType().GetProperty("ItemsSource").GetValue(listaPicker[i].picker, null);
                try
                {

                    switch (items[listaPicker[i].picker.SelectedIndex].Id)
                    {
                        case 1:
                            listaPicker[i].nota = 35;
                            break;
                        case 2:
                            listaPicker[i].nota = 75;
                            break;
                        case 3:
                            listaPicker[i].nota = 100;
                            break;
                    }

                }
                catch (ArgumentOutOfRangeException e)
                {
                    listaPicker[i].nota = 0;
                }
                soma = soma + listaPicker[i].nota;
                quantidade = quantidade + 1;
            }
            if (quantidade > 0)
            {
                valorFinal = soma / quantidade;
            }
            string stringfinal = valorFinal.ToString() + "%";
            var Color = new Color();

            if (valorFinal < 75)
            {
                Color = Color.FromHex("#FF0000");
                txtNotaFinal.TextColor = Color;
            }
            else
            {
                if (valorFinal == 100)
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