using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Puma.Paginas;
using Puma.Banco;
using Puma.ModelosBanco;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Puma
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //AcessoBanco database = new AcessoBanco();
            //database.

            var myNav = new NavigationPage(new PaginaInicialListaRelatorios());
            //myNav.Popped += (object sender, NavigationEventArgs e) =>
            //{
            //    var teste = myNav;
            //    string nameTela = sender.GetType().GetProperty("CurrentPage").GetValue(sender, null).ToString();
            //    if (nameTela == "Puma.Paginas.PaginaInicialListaRelatorios")
            //    {
            //        Puma.Paginas.PaginaInicialListaRelatorios pageListRela = (Puma.Paginas.PaginaInicialListaRelatorios)sender.GetType().GetProperty("CurrentPage").GetValue(sender, null);
            //    }
            //};

            MainPage = myNav;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
