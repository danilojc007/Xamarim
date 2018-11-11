using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Puma.Banco;
using System.IO;

[assembly: Dependency(typeof(Puma.Droid.Banco.Caminho))]
namespace Puma.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string GetPath(string NomeDoArquivo)
        {
            string caminhoDoPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string caminhoDoBanco = Path.Combine(caminhoDoPasta, NomeDoArquivo);

            return caminhoDoBanco;
        }
    }
}