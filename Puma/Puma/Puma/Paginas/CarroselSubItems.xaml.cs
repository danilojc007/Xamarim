using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Puma.Paginas;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarroselSubItems : CarouselPage
    {
        public CarroselSubItems()
        {
            //InitializeComponent();
            Children.Add(new Reservatorios());
            Children.Add(new Reservatorios());
            //this.ChildAdded(new Reservatorios());
            //this.ChildAdded(new Reservatorios());
        }
    }
}