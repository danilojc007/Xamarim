using Plugin.Media;
using Plugin.Media.Abstractions;
using Puma.Modelo;
using Puma.Paginas;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Puma.Service
{
    public class Manipulacao
    {

        public void ChangePicker(object sender, Picker picker, List<ComboBox> list)
        {
            //this.ChangeForSave();
            var selectedIndex = sender.GetType().GetProperty("SelectedIndex").GetValue(sender, null).ToString();
            int index = 0;
            index = Convert.ToInt32(selectedIndex);
            var Color = new Color();
            if (index >= 0)
            {
                Color = Color.FromHex(list[index].Color);
                picker.TextColor = Color;
            }
        }
        public void RemovePicture(Grid grid)
        {
            var index = grid.Children.Count;
            if (index > 0)
            {
                index = index - 1;
                grid.Children.RemoveAt(index);
            }
        }


    }
}
