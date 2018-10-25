using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Puma.Modelo
{
    public class ClassePicker
    {
        public Picker picker { get; set; }
        public int id { get; set; }

        public int nota { get; set; }

        public ClassePicker(Picker picker, int id)
        {
            this.picker = picker;
            this.id = id;
            this.nota = 0;
        }
    }
}
