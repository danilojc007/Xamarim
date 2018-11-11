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
        public Puma.ModelosBanco.DetalhesItem GeraModeloPicker(Puma.ModelosBanco.DetalhesItem detalhe, Picker picker, string namePicker)
        {
            detalhe.Tipo = "Picker";
            detalhe.Index = picker.SelectedIndex;
            if (picker.SelectedItem != null)
            {
                detalhe.Text = picker.SelectedItem.ToString();
            }
            detalhe.Name = namePicker;
            return detalhe;
        }

        public Puma.ModelosBanco.DetalhesItem GeraModeloEditor(Puma.ModelosBanco.DetalhesItem detalhe, Editor editor, string nameEditor)
        {
            detalhe.Tipo = "Editor";
            detalhe.Index = 0;
            detalhe.Text = editor.Text;
            detalhe.Name = nameEditor;
            return detalhe;
        }
        public Puma.ModelosBanco.DetalhesItem GeraModeloEntry(Puma.ModelosBanco.DetalhesItem detalhe, Entry entry, string nameEntry)
        {
            detalhe.Tipo = "Entry";
            detalhe.Index = 0;
            detalhe.Text = entry.Text;
            detalhe.Name = nameEntry;
            return detalhe;
        }
        public Puma.ModelosBanco.DetalhesItem GeraModeloLabel(Puma.ModelosBanco.DetalhesItem detalhe, Label label, string nameLabel)
        {
            detalhe.Tipo = "Label";
            detalhe.Index = 0;
            detalhe.Text = label.Text;
            detalhe.Name = nameLabel;
            return detalhe;
        }

        public Puma.ModelosBanco.DetalhesItem CretaeBaseDetalhe(Puma.ModelosBanco.ItemSubItem itemSubItem)
        {
            Puma.ModelosBanco.DetalhesItem detalhe = new Puma.ModelosBanco.DetalhesItem();

            detalhe.Idrelatorio = itemSubItem.RelatoriosId;
            detalhe.Idsetor = itemSubItem.Idsetor;
            detalhe.Idsubitem = itemSubItem.Idsubitem;
            detalhe.Iditemsubitem = itemSubItem.Id;

            return detalhe;
        }


    }
}
