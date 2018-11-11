using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Puma.Modelo;
using System.Collections.ObjectModel;
using Puma.Banco;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubItemsPage : ContentPage
    {
        public static ObservableCollection<SubItem> items = new ObservableCollection<SubItem>() { };
        public string pageSelected = "1";
        Puma.ModelosBanco.Relatorios relatorioBanco = null;
        List<Puma.ModelosBanco.Subitemsetor> listSubItemSetor = null;
        public int setorId = 0;
        public AcessoBanco database = null;
        public SubItemsPage(int setorID, int relatorioId, AcessoBanco conexao)
        {
            this.setorId = setorID;
            database = conexao;

            this.BuscarRelatorio(relatorioId);
            InitializeComponent();
        }
        private void BuscarRelatorio(int IdRelatorio)
        {
            relatorioBanco = database.GetRelatorio(IdRelatorio);
            this.BuscaListaSubItemSetores();
        }
        private void BuscaListaSubItemSetores()
        {
            listSubItemSetor = database.GetListSubitemSetor(relatorioBanco.Id, setorId);
            this.PreencheLista(setorId);
        }
        private void PreencheLista(int setorId)
        {
            if (listSubItemSetor.Count == 0 && items.Count == 0)
            {
                switch (setorId)
                {
                    case 1:
                        this.Title = "Instalações Elétricas";
                        this.pageSelected = "1";
                        items.Add(new SubItem(1, "Quadros elétricos", 1));
                        items.Add(new SubItem(2, "Gerador de energia", 0));
                        items.Add(new SubItem(3, "Cabine primária", 0));
                        items.Add(new SubItem(4, "Sistema de para raio", 2));
                        items.Add(new SubItem(5, "Cabeamento", 1));
                        items.Add(new SubItem(6, "Eletrodutos/Eltrocalhas", 3));
                        break;
                    case 2:
                        this.pageSelected = "2";
                        this.Title = "HAVAC - Ar Condicionado";
                        items.Add(new SubItem(1, "Chiller", 1));
                        items.Add(new SubItem(2, "Torre de resfriamento", 1));
                        items.Add(new SubItem(3, "Bombas", 1));
                        items.Add(new SubItem(4, "Tubulação água gelada", 1));
                        items.Add(new SubItem(5, "Tubulação de gás refrigerante", 1));
                        items.Add(new SubItem(6, "Isolamento da tubulação", 1));
                        items.Add(new SubItem(7, "Condensadora", 1));
                        items.Add(new SubItem(8, "Evaporadora", 1));
                        items.Add(new SubItem(9, "Ventilação/Exaustão", 1));
                        break;
                    case 3:
                        this.pageSelected = "3";
                        this.Title = "Instalações Hidráulicas";
                        items.Add(new SubItem(1, "Reservatórios", 1));
                        items.Add(new SubItem(2, "Barrilete", 1));
                        items.Add(new SubItem(3, "Gerador de água quente", 1));
                        items.Add(new SubItem(4, "Rede hidráulica - Tubulações", 1));
                        items.Add(new SubItem(5, "Bombas em geral", 1));
                        items.Add(new SubItem(6, "Rede de gás", 1));
                        items.Add(new SubItem(7, "ETA - Estação de tramento água reuso", 1));
                        items.Add(new SubItem(8, "ETE - Estação de tramento água esgoto", 1));
                        break;
                    case 4:
                        this.pageSelected = "4";
                        this.Title = "Edificações";
                        items.Add(new SubItem(1, "Salas Administrativas", 1));
                        items.Add(new SubItem(2, "Salas técnicas", 1));
                        items.Add(new SubItem(3, "Fachada", 1));
                        items.Add(new SubItem(4, "Áreas externas", 1));
                        items.Add(new SubItem(5, "Cobertura", 1));
                        items.Add(new SubItem(6, "Estacionamentos", 1));
                        items.Add(new SubItem(7, "Áreas Operacionais", 1));
                        items.Add(new SubItem(8, "Sánitarios", 1));
                        items.Add(new SubItem(9, "Piscina", 1));
                        items.Add(new SubItem(10, "Cozinha", 1));
                        items.Add(new SubItem(11, "Apartamento hotel", 1));
                        items.Add(new SubItem(12, "Banheiros", 1));
                        break;
                    case 5:
                        this.pageSelected = "5";
                        this.Title = "Sistema de combate a incêndio";
                        items.Add(new SubItem(1, "Rede de Sprinklers", 1));
                        items.Add(new SubItem(2, "Rede de hidrante", 1));
                        items.Add(new SubItem(3, "Central de alarme", 1));
                        items.Add(new SubItem(4, "Iluminação de emergência", 1));
                        items.Add(new SubItem(5, "Sinalização de emergência", 1));
                        items.Add(new SubItem(6, "Escadas de emergência", 1));
                        items.Add(new SubItem(7, "Extintores", 1));
                        break;
                    case 6:
                        this.pageSelected = "6";
                        this.Title = "Elevadores";
                        items.Add(new SubItem(1, "Casa de máquinas", 1));
                        items.Add(new SubItem(2, "Cabine dos elevadores", 1));
                        break;
                    case 7:
                        this.pageSelected = "7";
                        this.Title = "Relatórios de manutenção";
                        items.Add(new SubItem(1, "Ar condicionado - PMOC", 1));
                        items.Add(new SubItem(2, "Elevadores", 1));
                        items.Add(new SubItem(3, "Cabine primária", 1));
                        items.Add(new SubItem(4, "Limpeza de caixa de água", 1));
                        items.Add(new SubItem(5, "Sistema de combate a incêndio", 1));
                        items.Add(new SubItem(6, "Desistetização", 1));
                        items.Add(new SubItem(7, "Para raio", 1));
                        items.Add(new SubItem(8, "Gerador de água quente", 1));
                        items.Add(new SubItem(9, "Laudo da NR13", 1));
                        break;
                }

                Puma.ModelosBanco.Subitemsetor subItemSetor = new Puma.ModelosBanco.Subitemsetor();
                for (var i = 0; i < items.Count; i++)
                {
                    subItemSetor = new Puma.ModelosBanco.Subitemsetor();
                    subItemSetor.Idrelatorio = relatorioBanco.Id;
                    subItemSetor.Idsetor = setorId;
                    subItemSetor.Id = items[i].Id;
                    subItemSetor.Nome = items[i].Nome;
                    subItemSetor.Quantidade = items[i].Quantidade;
                    database.CreateSubItemSetor(subItemSetor);
                }
                this.BuscaListaSubItemSetores();
            }
            else
            {
                items.Clear();
                for (var o = 0; o < listSubItemSetor.Count; o++)
                {
                    items.Add(new SubItem(listSubItemSetor[o].Id, listSubItemSetor[o].Nome, listSubItemSetor[o].Quantidade));
                }

            }
        }
        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
        }
        protected override void OnAppearing()
        {
            this.BuscaListaSubItemSetores();
            base.OnAppearing();
        }

        void OnRefresh(object sender, EventArgs e)
        {
            this.BuscaListaSubItemSetores();
        }

        void OnTap(object sender, ItemTappedEventArgs e)
        {
            var id = (int)e.Item.GetType().GetProperty("Id").GetValue(e.Item, null);
            Puma.ModelosBanco.Subitemsetor subSelected = database.GetSubItemSetor(relatorioBanco.Id, setorId, id);
            Navigation.PushAsync(new CarroselSubItems(subSelected, database));
        }

        void OnMore(object sender, EventArgs e)
        {

        }

        void OnDelete(object sender, EventArgs e)
        {

        }
    }
}