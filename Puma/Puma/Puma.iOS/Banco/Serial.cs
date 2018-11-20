using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Puma.Banco;
using System.IO;

[assembly: Dependency(typeof(Puma.iOS.Banco.Serial))]
namespace Puma.iOS.Banco
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