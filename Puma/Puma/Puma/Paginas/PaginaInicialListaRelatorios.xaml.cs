using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Puma.Modelo;
using Puma.Paginas;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;
using Puma.Banco;
using Puma.ModelosBanco;
using Android.Telephony;
using Android.OS;
using Puma.ModelosBanco;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicialListaRelatorios : ContentPage
    {
        public string SerialNumber { get; }
        //public static ObservableCollection<string> items { get; set; }
        public static ObservableCollection<RelatorioInicial> items = new ObservableCollection<RelatorioInicial>() { };

        public AcessoBanco database = new AcessoBanco();
        public PaginaInicialListaRelatorios()
        {
            InitializeComponent();
            this.AtualizaLista();
        }
        private void AtualizaLista()
        {
            //items = new ObservableCollection<RelatorioInicial>() { };
            items.Clear();
            List<Puma.ModelosBanco.Relatorios> list = database.GetRelatorios();
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i].Ct == null)
                {
                    list[i].Ct = "Preencher Ct";
                    database.UpdateRelatorio(list[i]);
                }
                items.Add(new RelatorioInicial(list[i].Id, list[i].Ct, list[i].Data, list[i].Gerente, list[i].Auditor, list[i].Endereco));
            }
            LabelTitulosRela.Text = "Relatórios(" + list.Count.ToString() + ")";

        }
        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
        }

        void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            this.AtualizaLista();
            ////make sure to end the refresh state
            list.IsRefreshing = false;
        }

        void OnTap(object sender, ItemTappedEventArgs e)
        {
            RelatorioInicial selectedItem = (RelatorioInicial)sender.GetType().GetProperty("SelectedItem").GetValue(sender, null);
            Navigation.PushAsync(new PaginaRelatorio(selectedItem.Id, database));
        }

        void OnMore(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            DisplayAlert("More Context Action", item.CommandParameter + " more context action", "OK");
        }

        void OnDelete(object sender, EventArgs e)
        {
            RelatorioInicial selectedItem = (RelatorioInicial)sender.GetType().GetProperty("CommandParameter").GetValue(sender, null);
            Puma.ModelosBanco.Relatorios relatorio = database.GetRelatorio(selectedItem.Id);
            database.DeleteRelatorio(relatorio);
            this.AtualizaLista();
        }
        public void PressCriarRelatorio(object sender, EventArgs r)
        {
            Puma.ModelosBanco.Relatorios relatorio = new Puma.ModelosBanco.Relatorios();
            database.CriarRelatorio(relatorio);
            Navigation.PushAsync(new PaginaRelatorio(relatorio.Id, database));
        }
        protected override void OnAppearing()
        {
            this.AtualizaLista();
            base.OnAppearing();
        }
    }
}