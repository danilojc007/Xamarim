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
using Puma.Banco;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Puma.Droid.Banco.Serial))]
namespace Puma.Droid.Banco
{
    public class Serial : ISerial
    {
        public string SerialNumber()
        {
            var serial = Build.Serial;
            return serial.ToString();
        }
    }
}