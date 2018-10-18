using System;
using System.Collections.Generic;
using System.Text;

namespace Puma.Modelo
{
    public class ComboBox
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Color { get; set; }

        public ComboBox(int id, string texto, string color)
        {

            this.Id = id;
            this.Color = color;
            this.Texto = texto;
        }

        public override string ToString()
        {
            return this.Texto;
        }
    }
}
