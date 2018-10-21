using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Puma.Paginas;
using Puma.Paginas.Hidraulica;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarroselSubItems : CarouselPage
    {
        public CarroselSubItems(string id)
        {
            //InitializeComponent();
            switch (id)
            {
                case "1":
                    this.Title = "Reservatórios";
                    Children.Add(new Reservatorios(this));
                    Children.Add(new Reservatorios(this));
                    break;
                case "2":
                    this.Title = "Barrilhete";
                    Children.Add(new HidraBarrilhete(this));
                    Children.Add(new HidraBarrilhete(this));
                    break;
                case "3":
                    this.Title = "Gerador de água quente";
                    Children.Add(new HidraGeradorAguaQuente());
                    Children.Add(new HidraGeradorAguaQuente());
                    break;
                case "4":
                    this.Title = "Rede hidráulica - Tubulações";
                    Children.Add(new HidraRede());
                    Children.Add(new HidraRede());
                    break;
                case "5":
                    this.Title = "Bombas em geral";
                    Children.Add(new HidraBombas());
                    Children.Add(new HidraBombas());
                    break;
                case "6":
                    this.Title = "Rede de gás";
                    Children.Add(new HidraRedeGas());
                    Children.Add(new HidraRedeGas());
                    break;
                case "7":
                    this.Title = "ETA - Reuso";
                    Children.Add(new HidraEtaReuso());
                    Children.Add(new HidraEtaReuso());
                    break;
                case "8":
                    this.Title = "ETA - Esgoto";
                    Children.Add(new HidraEtaEsgoto());
                    Children.Add(new HidraEtaEsgoto());
                    break;
            }

        }
    }
}