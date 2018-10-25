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

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnviarEmail : ContentPage
    {
        public static ObservableCollection<Email> emails { get; set; }

        public EnviarEmail()
        {
            emails = new ObservableCollection<Email>() { };
            emails.Add(new Email("dj@hotmail.com"));
            InitializeComponent();

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

        public void PressEnviarEmail(object sender, EventArgs r)
        {
            HeaderRequisicao head = new HeaderRequisicao();
            MontaString montaString = new MontaString();
            head = montaString.MontaSaida();

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

    }
}