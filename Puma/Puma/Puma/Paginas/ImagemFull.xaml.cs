using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagemFull : ContentPage
    {
        public ImagemFull(string image)
        {
            InitializeComponent();
            Image.Source = image;
        }
    }
}