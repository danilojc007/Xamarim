using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Puma.Modelo;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Puma.Modelo.ApiConnector;
using Puma.Service;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnviarEmail : ContentPage
    {
        public static ObservableCollection<Email> emails { get; set; }
        public List<Puma.ModelosBanco.Emails> emailsBanco = new List<ModelosBanco.Emails>();
        public Banco.AcessoBanco database = new Banco.AcessoBanco();
        public Puma.ModelosBanco.Relatorios relatorio = null;

        public EnviarEmail(Puma.ModelosBanco.Relatorios relatorio)
        {
            this.relatorio = relatorio;
            emails = new ObservableCollection<Email>() { };
            InitializeComponent();
            this.AtualizaLista();

        }

        void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            this.AtualizaLista();
            list.IsRefreshing = false;
        }

        public void PressEnviarEmail(object sender, EventArgs r)
        {
            HeaderRequisicao head = new HeaderRequisicao();
            MontaString montaString = new MontaString();
            head = montaString.MontaSaida(emails, relatorio);
            apiConnector connector = new apiConnector();
            this.IsEnabled = false;
            BusyIndicator.IsRunning = true;
            apiConnector.GenerateWord(head, this);

            if (emails.Count > 0)
            {
                // cadastrar Emails
            }


        }

        public void ExibeMensagem(string header, string body)
        {
            this.IsEnabled = true;
            BusyIndicator.IsRunning = false;
            DisplayAlert(header, body, "ok");
        }
        void OnDelete(object sender, EventArgs e)
        {
            emails.Remove((Email)sender.GetType().GetProperty("CommandParameter").GetValue(sender, null));
        }
        public void AdicionarEmail(object sender, EventArgs e)
        {
            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}"
                                + "\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\"
                                + ".)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";
            Regex re = new Regex(strRegex);
            if (EntryEmail.Text != null)
            {
                if (re.IsMatch(EntryEmail.Text))
                {
                    int i = 0;
                    for (var o = 0; o < emails.Count; o++)
                    {
                        if (emails[o].email == EntryEmail.Text)
                        {
                            i = 1;
                        }
                    }
                    if (i == 0)
                    {
                        Puma.ModelosBanco.Emails email = new Puma.ModelosBanco.Emails();
                        email.Email = EntryEmail.Text;
                        database.CadastroEmail(email);
                        emails.Add(new Email(EntryEmail.Text));
                    }
                    else
                    {
                        DisplayAlert("E-mail já incluso", "", "ok");
                    }
                }
                else
                {
                    DisplayAlert("E-mail invalído", "", "ok");
                }
            }
            else
            {
                DisplayAlert("Insira um e-mail", "", "ok");
            }
        }
        private void AtualizaLista()
        {
            emailsBanco = database.GetEmails();
            emails.Clear();
            for (var i = 0; i < emailsBanco.Count; i++)
            {
                emails.Add(new Email(emailsBanco[i].Email));
            }
        }
        protected override void OnAppearing()
        {
            this.AtualizaLista();
            base.OnAppearing();
        }

    }
}