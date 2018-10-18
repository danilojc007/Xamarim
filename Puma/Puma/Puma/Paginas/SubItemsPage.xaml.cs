using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Puma.Modelo;
using System.Collections.ObjectModel;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubItemsPage : ContentPage
    {
        public static ObservableCollection<SubItem> items { get; set; }
        public SubItemsPage(string chave)
        {

            items = new ObservableCollection<SubItem>() { };

            switch (chave)
            {
                case "1":
                    items.Add(new SubItem("1", "Quadros elétricos", 1));
                    items.Add(new SubItem("2", "Gerador de energia", 0));
                    items.Add(new SubItem("1", "Cabine primária", 0));
                    items.Add(new SubItem("1", "Sistema de para raio", 2));
                    items.Add(new SubItem("1", "Cabeamento", 1));
                    items.Add(new SubItem("1", "Eletrodutos/Eltrocalhas", 3));
                    break;
                case "2":
                    items.Add(new SubItem("1", "Chiller", 1));
                    items.Add(new SubItem("1", "Torre de resfriamento", 1));
                    items.Add(new SubItem("1", "Bombas", 1));
                    items.Add(new SubItem("1", "Tubulação água gelada", 1));
                    items.Add(new SubItem("1", "Tubulação de gás refrigerante", 1));
                    items.Add(new SubItem("1", "Isolamento da tubulação", 1));
                    items.Add(new SubItem("1", "Condensadora", 1));
                    items.Add(new SubItem("1", "Evaporadora", 1));
                    items.Add(new SubItem("1", "Ventilação/Exaustão", 1));
                    break;
                case "3":
                    items.Add(new SubItem("1", "Reservatórios", 1));
                    items.Add(new SubItem("1", "Barrilhete", 1));
                    items.Add(new SubItem("1", "Gerador de água quente", 1));
                    items.Add(new SubItem("1", "Rede hidráulica - Tubulações", 1));
                    items.Add(new SubItem("1", "Bombas em geral", 1));
                    items.Add(new SubItem("1", "Rede de gás", 1));
                    items.Add(new SubItem("1", "ETA - Estação de tramento água reuso", 1));
                    items.Add(new SubItem("1", "ETA - Estação de tramento água esgoto", 1));
                    break;
                case "4":
                    items.Add(new SubItem("1", "Salas Administrativas", 1));
                    items.Add(new SubItem("1", "Salas técnicas", 1));
                    items.Add(new SubItem("1", "Fachada", 1));
                    items.Add(new SubItem("1", "Áreas externas", 1));
                    items.Add(new SubItem("1", "Cobertura", 1));
                    items.Add(new SubItem("1", "Estacionamentos", 1));
                    items.Add(new SubItem("1", "Áreas Operacionais", 1));
                    items.Add(new SubItem("1", "Sánitarios", 1));
                    items.Add(new SubItem("1", "Piscina", 1));
                    items.Add(new SubItem("1", "Cozinha", 1));
                    items.Add(new SubItem("1", "Apartamento hotel", 1));
                    items.Add(new SubItem("1", "Banheiros", 1));
                    break;
                case "5":
                    items.Add(new SubItem("1", "Rede de Sprinklers", 1));
                    items.Add(new SubItem("1", "Rede de hidrante", 1));
                    items.Add(new SubItem("1", "Central de alarme", 1));
                    items.Add(new SubItem("1", "Central de alarme", 1));
                    items.Add(new SubItem("1", "Iluminação de emergência", 1));
                    items.Add(new SubItem("1", "Sinalização de emergência", 1));
                    items.Add(new SubItem("1", "Escadas de emergência", 1));
                    items.Add(new SubItem("1", "Extintores", 1));
                    break;
                case "6":
                    items.Add(new SubItem("1", "Casa de máquinas", 1));
                    items.Add(new SubItem("1", "Cabine dos elevadores", 1));
                    break;
                case "7":
                    items.Add(new SubItem("1", "Ar condicionado - PMOC", 1));
                    items.Add(new SubItem("1", "Elevadores", 1));
                    items.Add(new SubItem("1", "Cabine primária", 1));
                    items.Add(new SubItem("1", "Limpeza de caixa de água", 1));
                    items.Add(new SubItem("1", "Sistema de combate a incêndio", 1));
                    items.Add(new SubItem("1", "Desistetização", 1));
                    items.Add(new SubItem("1", "Para raio", 1));
                    items.Add(new SubItem("1", "Gerador de água quente", 1));
                    items.Add(new SubItem("1", "Laudo da NR13", 1));
                    break;
            }

            InitializeComponent();
        }
        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            //DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
        }

        void OnRefresh(object sender, EventArgs e)
        {
        }

        void OnTap(object sender, ItemTappedEventArgs e)
        {
            //Navigation.PushAsync(new Reservatorios());
            Navigation.PushAsync(new CarroselSubItems());
        }

        void OnMore(object sender, EventArgs e)
        {

        }

        void OnDelete(object sender, EventArgs e)
        {

        }
    }
}