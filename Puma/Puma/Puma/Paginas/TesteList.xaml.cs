﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TesteList : ContentPage
    {
        public TesteList()
        {
            InitializeComponent();
            List<String> itens = new List<String>()
            {
                "Palmeiras", "Flamengo", "Atlético", "Santos", "Fluminense"
            };
            lv1.ItemsSource = itens;
        }
    }
}