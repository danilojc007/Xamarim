using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puma.Banco;
using System.IO;
using Xamarin.Forms;
using Windows.Storage;

[assembly: Dependency(typeof(Puma.UWP.Banco.Caminho))]
namespace Puma.UWP.Banco
{
    public class Caminho : ICaminho
    {
        public string GetPath(string NomeDoArquivo)
        {
            string caminhoPasta = ApplicationData.Current.LocalFolder.Path;
            string caminhoBanco = Path.Combine(caminhoPasta, NomeDoArquivo);
            return caminhoBanco;
        }
    }
}
