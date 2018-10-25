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
    public partial class HidraBombas : ContentPage
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
        private List<ComboBox> bombaRolamentos = new List<ComboBox>();
        private List<ComboBox> bombaAcoplamento = new List<ComboBox>();
        private List<ComboBox> bombaSeloMecanico = new List<ComboBox>();
        private List<ComboBox> bombaAquecimento = new List<ComboBox>();
        private List<ComboBox> bombaPintura = new List<ComboBox>();
        private List<ComboBox> bombaStatusGeral = new List<ComboBox>();
        private List<ComboBox> bfeFixacao = new List<ComboBox>();
        private List<ComboBox> bfeVibStop = new List<ComboBox>();
        private List<ComboBox> bfeInstaEletrica = new List<ComboBox>();
        private List<ComboBox> bfeStatusGeral = new List<ComboBox>();

        public HidraBombas(CarouselPage carousel)
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
            nomenclatura.Add(new ComboBox(1, "Rede de água fria", "#000000"));
            nomenclatura.Add(new ComboBox(2, "Rede de água quente", "#000000"));

            bombaAcoplamento.Add(new ComboBox(1, "Ok", "#008000"));
            bombaAcoplamento.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bombaAcoplamento.Add(new ComboBox(3, "Alinhado", "#008000"));
            bombaAcoplamento.Add(new ComboBox(4, "Não Alinhado", "#FF0000"));
            bombaAcoplamento.Add(new ComboBox(5, "Gaxeta irregular", "#FF0000"));

            bombaSeloMecanico.Add(new ComboBox(1, "Ok", "#008000"));
            bombaSeloMecanico.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bombaSeloMecanico.Add(new ComboBox(3, "Vazando", "#FF0000"));

            bombaAquecimento.Add(new ComboBox(1, "Sim", "#FF0000"));
            bombaAquecimento.Add(new ComboBox(2, "Não", "#008000"));

            bombaPintura.Add(new ComboBox(1, "Ok", "#008000"));
            bombaPintura.Add(new ComboBox(2, "Oxidada", "#FF0000"));
            bombaPintura.Add(new ComboBox(3, "Irregular", "#FF0000"));

            bombaStatusGeral.Add(new ComboBox(1, "Ok", "#008000"));
            bombaStatusGeral.Add(new ComboBox(2, "irregular", "#FF0000"));
            bombaStatusGeral.Add(new ComboBox(3, "Crítica", "#FF0000"));

            bfeFixacao.Add(new ComboBox(1, "Ok", "#008000"));
            bfeFixacao.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bfeFixacao.Add(new ComboBox(3, "Não tem", "#FF0000"));

            bfeVibStop.Add(new ComboBox(1, "Ok", "#008000"));
            bfeVibStop.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bfeVibStop.Add(new ComboBox(3, "Não tem", "#FF0000"));

            bfeInstaEletrica.Add(new ComboBox(1, "Ok", "#008000"));
            bfeInstaEletrica.Add(new ComboBox(2, "Irregular", "#FF0000"));

            bfeStatusGeral.Add(new ComboBox(1, "Ok", "#008000"));
            bfeStatusGeral.Add(new ComboBox(2, "Solto", "#FF0000"));
            bfeStatusGeral.Add(new ComboBox(3, "Com corrosão", "#FF0000"));
            bfeStatusGeral.Add(new ComboBox(4, "NA", "#008000"));
            bfeStatusGeral.Add(new ComboBox(5, "Irregular", "#FF0000"));


            PickerNomenclatura.ItemsSource = nomenclatura;
            //---------- Simples ---------

            PickerAuditado.ItemsSource = simples;
            PickerPlanejado.ItemsSource = simples;
            PickerExecutado.ItemsSource = simples;
            PickerApontamentos.ItemsSource = apontamentos;
            PickerNivelRisco.ItemsSource = nivelRisco;

            //------------Bomba ---------------- -

            PickerBombaRolamentos.ItemsSource = bombaRolamentos;
            PickerBombaAcoplamento.ItemsSource = bombaAcoplamento;
            PickerBombaSeloMecanico.ItemsSource = bombaSeloMecanico;
            PickerBombaAquecimento.ItemsSource = bombaAquecimento;
            PickerBombaPintura.ItemsSource = bombaPintura;
            PickerBombaStatusGeral.ItemsSource = bombaStatusGeral;
            PickerNotaBomba.ItemsSource = nota;
            //---------------Bomba Fixação--------------

            PickerBfeFixacao.ItemsSource = bfeFixacao;
            PickerBfeVibStop.ItemsSource = bfeVibStop;
            PickerBfeInstaEletrica.ItemsSource = bfeInstaEletrica;
            PickerBfeStatusGeral.ItemsSource = bfeStatusGeral;
            PickerNotaBfe.ItemsSource = nota;

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

            listaPicker.Add(new ClassePicker(PickerNotaBfe, 1));
            listaPicker.Add(new ClassePicker(PickerNotaBomba, 2));

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