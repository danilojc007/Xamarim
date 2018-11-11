using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Puma.Modelo.ApiConnector;
using Puma.Paginas;
using Puma.Banco;
using Xamarin.Forms;

namespace Puma.Service
{
    public class apiConnector
    {
        public static EnviarEmail Email = null;

        public static string GetSerialNumber()
        {
            var serial = DependencyService.Get<ISerial>();
            var stringSerial = serial.SerialNumber();
            return stringSerial;
        }
        public static void GenerateWord(HeaderRequisicao requisicao, EnviarEmail email)
        {
            Email = email;
            Uri enderecoURL = new Uri("http://104.155.141.179:4321/generateWord");
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";

            string body = JsonConvert.SerializeObject(requisicao);
            //<HeaderRequisicao>(requisicao);
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(UploadCompleted);
            client.UploadStringAsync(enderecoURL, "POST", body);

        }
        public static void UploadCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            try
            {
                var o = e.Result;
                Email.ExibeMensagem("Sucesso", "E-mail enviado!");
            }
            catch (Exception exc)
            {
                //Email.ExibeMensagem("Erro", exc.ToString());
                Email.ExibeMensagem("Erro", "Erro na conexão por favor tente mais tarde");
            }
        }
    }
}
