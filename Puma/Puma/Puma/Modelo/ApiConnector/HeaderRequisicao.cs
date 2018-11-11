using Puma.Modelo.ApiConnector.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Puma.Modelo;
using System.Collections.ObjectModel;

namespace Puma.Modelo.ApiConnector
{
    public class HeaderRequisicao
    {
        public string localRelatorio { get; set; }
        public string dataRelatorio { get; set; }
        public string gerente { get; set; }
        public string auditor { get; set; }
        public string endereco { get; set; }
        public string macAddress { get; set; }
        public Modulos modulos { get; set; } = new Modulos();
        public ObservableCollection<Email> emails { get; set; } = new ObservableCollection<Email>();


    }
}
