using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puma.Banco;
using System.IO;
using Xamarin.Forms;
using Windows.Storage;

[assembly: Dependency(typeof(Puma.UWP.Banco.Serial))]
namespace Puma.UWP.Banco
{
    public class Serial : ISerial
    {
        public string SerialNumber()
        {
            var serial = "";//Build.Serial;
            return serial.ToString();
        }
    }
}
