using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Puma.Banco;
using System.IO;

[assembly: Dependency(typeof(Puma.iOS.Banco.Caminho))]
namespace Puma.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public string GetPath(string NomeDoArquivo)
        {
            string caminhoDoPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string caminhoBiblioteca = Path.Combine(caminhoDoPasta, "..", "Library");
            string caminhoDoBanco = Path.Combine(caminhoBiblioteca, NomeDoArquivo);
            return caminhoDoBanco;
        }
    }
}