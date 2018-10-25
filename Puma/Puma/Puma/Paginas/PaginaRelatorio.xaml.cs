using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puma.Modelo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaRelatorio : ContentPage
    {
        public static ObservableCollection<TipoItem> items { get; set; }
        public PaginaRelatorio()
        {

            items = new ObservableCollection<TipoItem>() { };
            items.Add(new TipoItem("1", "Instalações Elétricas", "proibido.png", "Error"));
            items.Add(new TipoItem("2", "HAVAC - Ar Condicionado", "check.png", "Success"));
            items.Add(new TipoItem("3", "Instalações Hidráulicas", "proibido.png", "Error"));
            items.Add(new TipoItem("4", "Edificações", "check.png", "Success"));
            items.Add(new TipoItem("5", "Sistema de combate a incêndio", "proibido.png", "Error"));
            items.Add(new TipoItem("6", "Elevadores", "check.png", "Success"));
            items.Add(new TipoItem("7", "Relatórios de manutenção", "check.png", "Success"));
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
            var list = (ListView)sender;
            ////put your refreshing logic here
            //var itemList = items.Reverse().ToList();
            //items.Clear();
            //foreach (var s in itemList)
            //{
            //   items.Add(s);
            //}
            ////make sure to end the refresh state
            list.IsRefreshing = false;
        }
        void OnTap(object sender, ItemTappedEventArgs e)
        {
            var opa = e.Item.GetType().GetProperty("Codigo").GetValue(e.Item, null).ToString();
            //DisplayAlert("Item Tapped", e.Item.ToString(), "Ok") e.Item.Codigo.ToString();
            //var opa = e.Item.
            var page = new SubItemsPage(opa);
            //var context = new TipoItem("1", "Ola", "opa", "oi");
            //page.BindingContext = context;
            Navigation.PushAsync(page);
        }

        void OnMore(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            DisplayAlert("More Context Action", item.CommandParameter + " more context action", "OK");
        }

        void OnDelete(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            //items.Remove(item.CommandParameter.ToString());
            //items.Remove(item.CommandParameter);
        }

        public void PressBtnEviarRelatorio(object sender, EventArgs e)
        {
            var page = new EnviarEmail();
            Navigation.PushAsync(page);
        }
    }
}