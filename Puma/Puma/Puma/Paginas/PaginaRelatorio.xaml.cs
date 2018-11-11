using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puma.Banco;
using Puma.Modelo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaRelatorio : ContentPage
    {
        public static ObservableCollection<TipoItem> items = new ObservableCollection<TipoItem>() { };
        public RelatorioInicial relatorio = null;

        Puma.ModelosBanco.Relatorios relatorioBanco = null;
        List<Puma.ModelosBanco.Setores> setoresBanco = null;
        public AcessoBanco database = null;
        public PaginaRelatorio(int IdRelatorio, AcessoBanco conexao)
        {
            database = conexao;

            DateTime dt = DateTime.Now;
            string diaFomated = String.Format("{0:dd/MM/yyyy}", dt);
            string horaFomated = String.Format("{0:hh:mm:ss}", dt);

            InitializeComponent();
            //LabelDataHora.Text = string.Concat(diaFomated, " - ", horaFomated);
            this.AtualizaHeader(IdRelatorio);
            if (relatorio.Data == null)
            {
                relatorio.Data = string.Concat(diaFomated, " - ", horaFomated);
                relatorioBanco.Data = relatorio.Data;
            }
            LabelDataHora.Text = relatorio.Data;
            database.UpdateRelatorio(relatorioBanco);

        }
        private void AtualizaRelatorio()
        {
            relatorioBanco.Data = LabelDataHora.Text;
            relatorioBanco.Ct = CtVistoriado.Text;
            relatorioBanco.Gerente = EntryGerente.Text;
            relatorioBanco.Auditor = EntryAuditor.Text;
            relatorioBanco.Endereco = EntryEndereco.Text;
            database.UpdateRelatorio(relatorioBanco);
        }

        private void AtualizaHeader(int IdRelatorio)
        {
            relatorioBanco = database.GetRelatorio(IdRelatorio);
            relatorio = new RelatorioInicial(relatorioBanco.Id);
            relatorio.Ct = relatorioBanco.Ct;
            relatorio.Data = relatorioBanco.Data;
            relatorio.Endereco = relatorioBanco.Endereco;
            relatorio.Auditor = relatorioBanco.Auditor;
            relatorio.Gerente = relatorioBanco.Gerente;

            if (relatorio.Ct != "Preencher Ct")
            {
                CtVistoriado.Text = relatorio.Ct;
            }
            EntryGerente.Text = relatorio.Gerente;
            EntryAuditor.Text = relatorio.Auditor;
            EntryEndereco.Text = relatorio.Endereco;

            this.AtualizaItems();

        }
        private void AtualizaItems()
        {
            Puma.ModelosBanco.Setores setor = new Puma.ModelosBanco.Setores();
            setoresBanco = database.GetSetoresRelatorio(relatorioBanco.Id);
            if (setoresBanco.Count == 0 && items.Count == 0)
            {
                //"check.png", "Success"
                items.Add(new TipoItem(1, "Instalações elétricas", "proibido.png", "Error"));
                items.Add(new TipoItem(2, "HAVAC - ar condicionado", "proibido.png", "Error"));
                items.Add(new TipoItem(3, "Instalações hidráulicas", "proibido.png", "Error"));
                items.Add(new TipoItem(4, "Edificações", "proibido.png", "Error"));
                items.Add(new TipoItem(5, "Sistema de combate a incêndio", "proibido.png", "Error"));
                items.Add(new TipoItem(6, "Elevadores", "proibido.png", "Error"));
                items.Add(new TipoItem(7, "Relatórios de manutenção", "proibido.png", "Error"));
                for (var i = 0; i < items.Count; i++)
                {
                    setor = new Puma.ModelosBanco.Setores();
                    setor.Idrelatorio = relatorioBanco.Id;
                    setor.Id = items[i].Id;
                    setor.Nome = items[i].Nome;
                    setor.Status = items[i].Status;
                    setor.Icone = items[i].Icone;
                    database.CriaSetor(setor);
                }

                this.AtualizaItems();
            }
            else
            {
                items.Clear();
                for (var o = 0; o < setoresBanco.Count; o++)
                {
                    items.Add(new TipoItem(setoresBanco[o].Id, setoresBanco[o].Nome, setoresBanco[o].Icone, setoresBanco[o].Status));
                }

            }

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
            this.AtualizaItems();
            list.IsRefreshing = false;
        }
        void OnTap(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = (TipoItem)sender.GetType().GetProperty("SelectedItem").GetValue(sender, null);
            this.AtualizaRelatorio();
            var page = new SubItemsPage(selectedItem.Id, relatorioBanco.Id, database);
            Navigation.PushAsync(page);
        }
        void OnDelete(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
        }

        public void PressBtnEviarRelatorio(object sender, EventArgs e)
        {
            this.AtualizaRelatorio();
            var page = new EnviarEmail();
            Navigation.PushAsync(page);
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    Navigation.PopAsync();
        //    return base.OnBackButtonPressed();
        //}

        protected override void OnDisappearing()
        {
            this.AtualizaRelatorio();
            base.OnDisappearing();
        }
        protected override void OnAppearing()
        {
            this.AtualizaItems();
            base.OnAppearing();
        }
    }
}