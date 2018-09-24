using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Puma.Modelo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;


namespace Puma.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaInicialListaRelatorios : ContentPage
	{
        //public static ObservableCollection<string> items { get; set; }
        public static ObservableCollection<RelatorioInicial> items { get; set; }
        public PaginaInicialListaRelatorios ()
		{
            //items = new ObservableCollection<string>() { "Speaker", "Pen", "Lamp", "Monitor", "Bag", "Book", "Cap", "Tote", "Floss", "Phone" };

            items = new ObservableCollection<RelatorioInicial>() {  };

            items.Add(new RelatorioInicial("Ct Jaraguá", "21/02/2018"));
            items.Add(new RelatorioInicial("Ct Faria Lima", "19/06/2018"));
            items.Add(new RelatorioInicial("Ct Jabaquara", "03/08/2018"));
            items.Add(new RelatorioInicial("Ct Santo André", "10/09/2018"));
            items.Add(new RelatorioInicial("Ct Santo André", "10/09/2018"));
            items.Add(new RelatorioInicial("Ct Santo André", "10/09/2018"));
            items.Add(new RelatorioInicial("Ct Santo André", "10/09/2018"));
            items.Add(new RelatorioInicial("Ct Santo André", "10/09/2018"));
            items.Add(new RelatorioInicial("Ct Santo André", "10/09/2018"));
            items.Add(new RelatorioInicial("Ct Santo André", "10/09/2018"));
            items.Add(new RelatorioInicial("Ct Santo André", "10/09/2018"));
            items.Add(new RelatorioInicial("Ct Santo André", "10/09/2018"));
            items.Add(new RelatorioInicial("Ct Santo André", "10/09/2018"));
            items.Add(new RelatorioInicial("Ct Santo André", "10/09/2018"));


            InitializeComponent();
            //this.Resources.Add(StyleSheet.FromAssemblyResource(
            //IntrospectionExtensions.GetTypeInfo(typeof(PaginaInicialListaRelatorios)).Assembly,
            //V));
        }
        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
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
            //RelatorioInicial rel = new RelatorioInicial( e.Item.ToString());
            //DisplayAlert("Item Tapped", e.Item.ToString(), "Ok");
            DisplayAlert("Item Tapped", e.Item.ToString(), "Ok");
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
      	}
	}