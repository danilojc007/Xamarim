using System;
using System.Collections.Generic;
using Puma.Modelo.ApiConnector.Model;
using Puma.Modelo;
using Puma.Modelo.ApiConnector.Model.Reservatorio;
using System.Collections.ObjectModel;

namespace Puma.Modelo.ApiConnector
{
    public class MontaString
    {
        // Instalações Hidraulicas
        public List<Reservatorio> reservatorios = new List<Reservatorio>();
        public List<Barrilete> barrilete = new List<Barrilete>();
        public List<Bombas> bombas = new List<Bombas>();
        public List<GeradoraAguaQuente> geradoraAguaQuente = new List<GeradoraAguaQuente>();
        public List<RedeGas> redeGas = new List<RedeGas>();
        public List<Tubulacoes> tubulacoes = new List<Tubulacoes>();
        public HeaderRequisicao header = new HeaderRequisicao();
        public ObservableCollection<Email> emails = new ObservableCollection<Email>();
        public Puma.Banco.AcessoBanco database = new Puma.Banco.AcessoBanco();
        Puma.ModelosBanco.Relatorios relatorio = null;



        public HeaderRequisicao MontaSaida(ObservableCollection<Email> emails, Puma.ModelosBanco.Relatorios relatorio)
        {
            //CAbeçalho
            var serial = Xamarin.Forms.DependencyService.Get<Puma.Banco.ISerial>();
            this.emails = emails;
            this.relatorio = relatorio;
            header.localRelatorio = relatorio.Ct;
            header.dataRelatorio = relatorio.Data;
            header.gerente = relatorio.Gerente;
            header.auditor = relatorio.Auditor;
            header.endereco = relatorio.Endereco;
            header.macAddress = serial.SerialNumber();
            header.modulos = new Modulos();

            //Instalações Hidraulicas
            header.modulos.instHidraulicas = new InstHidraulicas();
            header.modulos.instHidraulicas.reservatorio = this.MontaReservatorio();
            header.modulos.instHidraulicas.barrilete = this.MontaBarrilete();
            header.modulos.instHidraulicas.geradoraAguaQuente = this.MontaGerarAguaQuente();
            header.modulos.instHidraulicas.tubulacoes = this.MontaTubulacoes();
            header.modulos.instHidraulicas.bombas = this.MontaBomba();
            header.modulos.instHidraulicas.redeGas = this.MontaRedeGas();

            //Emails
            //header.emails = this.MontaEmails();
            header.emails = emails;

            return header;
        }
        public List<Email> MontaEmails()
        {
            List<Email> list = new List<Email>();
            //list.Add(new Email("danilojc007@gmail.com"));
            for (var i = 0; i < this.emails.Count; i++)
            {
                list.Add(new Email(this.emails[i].email));
            }
            return list;
        }
        public List<Barrilete> MontaBarrilete()
        {
            List<Barrilete> list = new List<Barrilete>();

            Puma.ModelosBanco.Subitemsetor subSetor = database.GetSubItemSetor(this.relatorio.Id, 3, 2);
            List<Puma.ModelosBanco.ItemSubItem> itemSubItems = database.GetListItemsSubItem(subSetor);
            for (var i = 0; i < itemSubItems.Count; i++)
            {
                // id = 1
                List<Puma.ModelosBanco.DetalhesItem> detalhes = database.GetDetalhesItems(itemSubItems[i]);
                List<Puma.ModelosBanco.FotosItem> fotos = database.GetFotosItems(itemSubItems[i]);
                list.Add(this.CriarBarrilete(detalhes, fotos));
            }
            return list;

        }
        public Barrilete CriarBarrilete(List<Puma.ModelosBanco.DetalhesItem> detalhes, List<Puma.ModelosBanco.FotosItem> fotos)
        {
            Barrilete barrilete = new Barrilete();

            for (var i = 0; i < detalhes.Count; i++)
            {
                switch (detalhes[i].Name)
                {
                    case "PickerNomenclatura":
                        barrilete.nomeclatura = detalhes[i].Text;
                        break;
                    case "PickerAuditado":
                        barrilete.itemAuditado = detalhes[i].Text;
                        break;
                    case "PickerPlanejado":
                        barrilete.planejado = detalhes[i].Text;
                        break;
                    case "PickerExecutado":
                        barrilete.executado = detalhes[i].Text;
                        break;
                    case "PickerApontamentos":
                        barrilete.apontamentos = detalhes[i].Text;
                        break;
                    case "PickerRolamentos":
                        barrilete.bombRolamento = detalhes[i].Text;
                        break;
                    case "PickerAcoplamento":
                        barrilete.bombAcoplamento = detalhes[i].Text;
                        break;
                    case "PickerSeloMecanico":
                        barrilete.bombSeloMecanico = detalhes[i].Text;
                        break;
                    case "PickerBombaAquecimento":
                        barrilete.bombAquecimento = detalhes[i].Text;
                        break;
                    case "PickerBombaPintura":
                        barrilete.bombPintura = detalhes[i].Text;
                        break;
                    case "PickerBombaStatusGeral":
                        barrilete.bombStatusGeral = detalhes[i].Text;
                        break;
                    case "PickerNotaBomba":
                        barrilete.bombNota = detalhes[i].Text;
                        break;
                    case "PickerBfeFixacao":
                        barrilete.bfelFixacao = detalhes[i].Text;
                        break;
                    case "PickerBfeVibStop":
                        barrilete.bfelVibraStop = detalhes[i].Text;
                        break;
                    case "PickerBfeInstaEletrica":
                        barrilete.bfelInstalacaoEletrica = detalhes[i].Text;
                        break;
                    case "PickerBfeStatusGeral":
                        barrilete.bfelStatusGeral = detalhes[i].Text;
                        break;
                    case "PickerNotaBfe":
                        barrilete.bfelNota = detalhes[i].Text;
                        break;
                    case "PickerTubMaterial":
                        barrilete.tubuMaterial = detalhes[i].Text;
                        break;
                    case "PickerTubAcabamento":
                        barrilete.tubuAcabamento = detalhes[i].Text;
                        break;
                    case "PickerTubVazamento":
                        barrilete.tubuVazamento = detalhes[i].Text;
                        break;
                    case "PickerTubFixacao":
                        barrilete.tubuFixacao = detalhes[i].Text;
                        break;
                    case "PickerNotaTub":
                        barrilete.tubuNota = detalhes[i].Text;
                        break;
                    case "PickerRegInstalacao":
                        barrilete.regiInstalacao = detalhes[i].Text;
                        break;
                    case "PickerRegAcabamento":
                        barrilete.regiAcabamento = detalhes[i].Text;
                        break;
                    case "PickerRegFixacao":
                        barrilete.regiFixacao = detalhes[i].Text;
                        break;
                    case "PickerNotaReg":
                        barrilete.regiNota = detalhes[i].Text;
                        break;
                    case "PickerNivelRisco":
                        barrilete.nivelRisco = detalhes[i].Text;
                        break;
                    case "EntryLocalizacao":
                        barrilete.localizacao = detalhes[i].Text;
                        break;
                    case "EditorComentarioBombaFixEle":
                        barrilete.bfelComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioBomba":
                        barrilete.bombComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioTubulacao":
                        barrilete.tubuComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioRegistros":
                        barrilete.regiComentario = detalhes[i].Text;
                        break;
                    case "txtNotaFinal":
                        barrilete.notaFinal = detalhes[i].Text;
                        break;

                }
            }

            for (var o = 0; o < fotos.Count; o++)
            {
                switch (fotos[o].Name)
                {
                    case "GridFotosBomba":
                        barrilete.bombFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosBfe":
                        barrilete.bfelFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosTub":
                        barrilete.tubuFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosReg":
                        barrilete.regiFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                }

            }
            return barrilete;
        }
        public List<Reservatorio> MontaReservatorio()
        {
            List<Reservatorio> list = new List<Reservatorio>();

            Puma.ModelosBanco.Subitemsetor subSetor = database.GetSubItemSetor(this.relatorio.Id, 3, 1);
            List<Puma.ModelosBanco.ItemSubItem> itemSubItems = database.GetListItemsSubItem(subSetor);
            for (var i = 0; i < itemSubItems.Count; i++)
            {
                // id = 1
                List<Puma.ModelosBanco.DetalhesItem> detalhes = database.GetDetalhesItems(itemSubItems[i]);
                List<Puma.ModelosBanco.FotosItem> fotos = database.GetFotosItems(itemSubItems[i]);
                list.Add(this.CriaReservatorio(detalhes, fotos));
            }
            return list;
        }
        public Reservatorio CriaReservatorio(List<Puma.ModelosBanco.DetalhesItem> detalhes, List<Puma.ModelosBanco.FotosItem> fotos)
        {
            Reservatorio reservatorio = new Reservatorio();

            for (var i = 0; i < detalhes.Count; i++)
            {
                switch (detalhes[i].Name)
                {
                    case "PickerNomenclatura":
                        reservatorio.nomeclatura = detalhes[i].Text;
                        break;
                    case "PickerTipo":
                        reservatorio.tipo = detalhes[i].Text;
                        break;
                    case "PickerAuditado":
                        reservatorio.itemAuditado = detalhes[i].Text;
                        break;
                    case "PickerPlanejado":
                        reservatorio.planejado = detalhes[i].Text;
                        break;
                    case "PickerExecutado":
                        reservatorio.executado = detalhes[i].Text;
                        break;
                    case "PickerApontamentos":
                        reservatorio.apontamentos = detalhes[i].Text;
                        break;
                    case "PickerFechamento":
                        reservatorio.portFechamento = detalhes[i].Text;
                        break;
                    case "PickerHermetico":
                        reservatorio.portHermetico = detalhes[i].Text;
                        break;
                    case "PickerStatusGeral":
                        reservatorio.portStatusGeral = detalhes[i].Text;
                        break;
                    case "PickerNotaPortinhola":
                        reservatorio.portNota = detalhes[i].Text;
                        break;
                    case "PickerTipoIper":
                        reservatorio.impTipo = detalhes[i].Text;
                        break;
                    case "PickerEstruturaIper":
                        reservatorio.impEstrutura = detalhes[i].Text;
                        break;
                    case "PickerStatusGeralIper":
                        reservatorio.impStatusGeral = detalhes[i].Text;
                        break;
                    case "PickerNotaIper":
                        reservatorio.impNota = detalhes[i].Text;
                        break;
                    case "PickerAguaLimp":
                        reservatorio.limpAgua = detalhes[i].Text;
                        break;
                    case "PickerBoiaLimp":
                        reservatorio.limpBoiaNivel = detalhes[i].Text;
                        break;
                    case "PickerStatusGeralLimp":
                        reservatorio.limpStatusGeral = detalhes[i].Text;
                        break;
                    case "PickerNotaLimp":
                        reservatorio.limpNota = detalhes[i].Text;
                        break;
                    case "PickerNivelRisco":
                        reservatorio.nivelRisco = detalhes[i].Text;
                        break;
                    case "EntryLocalizacao":
                        reservatorio.localizacao = detalhes[i].Text;
                        break;
                    case "EditorComentarioPort":
                        reservatorio.portComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioIper":
                        reservatorio.impComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioLimp":
                        reservatorio.limpComentario = detalhes[i].Text;
                        break;
                    case "txtNotaFinal":
                        reservatorio.notaFinal = detalhes[i].Text;
                        break;

                }

            }

            for (var o = 0; o < fotos.Count; o++)
            {
                switch (fotos[o].Name)
                {
                    case "GridFotosLimp":
                        reservatorio.limpFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosIper":
                        reservatorio.impFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosPort":
                        reservatorio.portFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                }

            }

            return reservatorio;
        }

        public List<Bombas> MontaBomba()
        {
            List<Bombas> list = new List<Bombas>();
            Puma.ModelosBanco.Subitemsetor subSetor = database.GetSubItemSetor(this.relatorio.Id, 3, 5);
            List<Puma.ModelosBanco.ItemSubItem> itemSubItems = database.GetListItemsSubItem(subSetor);
            for (var i = 0; i < itemSubItems.Count; i++)
            {
                // id = 6
                List<Puma.ModelosBanco.DetalhesItem> detalhes = database.GetDetalhesItems(itemSubItems[i]);
                List<Puma.ModelosBanco.FotosItem> fotos = database.GetFotosItems(itemSubItems[i]);
                list.Add(this.CriarBomba(detalhes, fotos));
            }


            return list;
        }
        public Bombas CriarBomba(List<Puma.ModelosBanco.DetalhesItem> detalhes, List<Puma.ModelosBanco.FotosItem> fotos)
        {
            Bombas gerador = new Bombas();
            for (var i = 0; i < detalhes.Count; i++)
            {
                switch (detalhes[i].Name)
                {
                    case "PickerNomenclatura":
                        gerador.nomeclatura = detalhes[i].Text;
                        break;
                    case "PickerAuditado":
                        gerador.itemAuditado = detalhes[i].Text;
                        break;
                    case "PickerPlanejado":
                        gerador.planejado = detalhes[i].Text;
                        break;
                    case "PickerExecutado":
                        gerador.executado = detalhes[i].Text;
                        break;
                    case "PickerBombaRolamentos":
                        gerador.bombRolamento = detalhes[i].Text;
                        break;
                    case "PickerBombaAcoplamento":
                        gerador.bombAcoplamento = detalhes[i].Text;
                        break;
                    case "PickerBombaSeloMecanico":
                        gerador.bombSeloMecanico = detalhes[i].Text;
                        break;
                    case "PickerBombaAquecimento":
                        gerador.bombAquecimento = detalhes[i].Text;
                        break;
                    case "PickerBombaPintura":
                        gerador.bombPintura = detalhes[i].Text;
                        break;
                    case "PickerBombaStatusGeral":
                        gerador.bombStatusGeral = detalhes[i].Text;
                        break;
                    case "PickerNotaBomba":
                        gerador.bombNota = detalhes[i].Text;
                        break;
                    case "PickerBfeFixacao":
                        gerador.bfelFixacao = detalhes[i].Text;
                        break;
                    case "PickerBfeVibStop":
                        gerador.bfelVibraStop = detalhes[i].Text;
                        break;
                    case "PickerBfeInstaEletrica":
                        gerador.bfelInstalacaoEletrica = detalhes[i].Text;
                        break;
                    case "PickerBfeStatusGeral":
                        gerador.bfelStatusGeral = detalhes[i].Text;
                        break;
                    case "PickerNotaBfe":
                        gerador.bfelNota = detalhes[i].Text;
                        break;
                    case "PickerNivelRisco":
                        gerador.nivelRisco = detalhes[i].Text;
                        break;
                    case "EntryLocalizacao":
                        gerador.localizacao = detalhes[i].Text;
                        break;
                    case "EditorComentarioBfe":
                        gerador.bfelComentario = detalhes[i].Text;
                        break;
                    case "txtNotaFinal":
                        gerador.notaFinal = detalhes[i].Text;
                        break;

                }
            }

            for (var o = 0; o < fotos.Count; o++)
            {
                switch (fotos[o].Name)
                {
                    case "GridFotosBomba":
                        gerador.bombFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosBfe":
                        gerador.bfelFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                }

            }
            return gerador;
        }
        public List<RedeGas> MontaRedeGas()
        {
            List<RedeGas> list = new List<RedeGas>();
            Puma.ModelosBanco.Subitemsetor subSetor = database.GetSubItemSetor(this.relatorio.Id, 3, 6);
            List<Puma.ModelosBanco.ItemSubItem> itemSubItems = database.GetListItemsSubItem(subSetor);
            for (var i = 0; i < itemSubItems.Count; i++)
            {
                // id = 6
                List<Puma.ModelosBanco.DetalhesItem> detalhes = database.GetDetalhesItems(itemSubItems[i]);
                List<Puma.ModelosBanco.FotosItem> fotos = database.GetFotosItems(itemSubItems[i]);
                list.Add(this.CriaRedeGas(detalhes, fotos));
            }
            return list;
        }

        public RedeGas CriaRedeGas(List<Puma.ModelosBanco.DetalhesItem> detalhes, List<Puma.ModelosBanco.FotosItem> fotos)
        {
            RedeGas gerador = new RedeGas();

            for (var i = 0; i < detalhes.Count; i++)
            {
                switch (detalhes[i].Name)
                {
                    case "PickerNomenclatura":
                        gerador.nomeclatura = detalhes[i].Text;
                        break;
                    case "PickerAlimentacao":
                        gerador.alimentacao = detalhes[i].Text;
                        break;
                    case "PickerAuditado":
                        gerador.itemAuditado = detalhes[i].Text;
                        break;
                    case "PickerPlanejado":
                        gerador.planejado = detalhes[i].Text;
                        break;
                    case "PickerExecutado":
                        gerador.executado = detalhes[i].Text;
                        break;
                    case "PickerTubMaterial":
                        gerador.tubuMaterial = detalhes[i].Text;
                        break;
                    case "PickerTubAcabamento":
                        gerador.tubuAcabamento = detalhes[i].Text;
                        break;
                    case "PickerTubVazamento":
                        gerador.tubuVazamento = detalhes[i].Text;
                        break;
                    case "PickerTubFixacao":
                        gerador.tubuFixacao = detalhes[i].Text;
                        break;
                    case "PickerNotaTub":
                        gerador.tubuNota = detalhes[i].Text;
                        break;
                    case "PickerRegInstalacao":
                        gerador.regiInstalacao = detalhes[i].Text;
                        break;
                    case "PickerRegAcabamento":
                        gerador.regiAcabamento = detalhes[i].Text;
                        break;
                    case "PickerRegFixacao":
                        gerador.regiFixacao = detalhes[i].Text;
                        break;
                    case "PickerNotaReg":
                        gerador.regiNota = detalhes[i].Text;
                        break;
                    case "PickerCentralSistema":
                        gerador.gasSistema = detalhes[i].Text;
                        break;
                    case "PickerCentralTanques":
                        gerador.gasTanques = detalhes[i].Text;
                        break;
                    case "PickerCentralDetectorGas":
                        gerador.gasDetectorGas = detalhes[i].Text;
                        break;
                    case "PickerCentralExtintores":
                        gerador.gasExtintores = detalhes[i].Text;
                        break;
                    case "PickerCentralLocal":
                        gerador.gasLocalInstalacao = detalhes[i].Text;
                        break;
                    case "PickerNotaCentral":
                        gerador.gasNota = detalhes[i].Text;
                        break;
                    case "PickerNivelRisco":
                        gerador.nivelRisco = detalhes[i].Text;
                        break;
                    case "EntryLocalizacao":
                        gerador.gasLocalInstalacao = detalhes[i].Text;
                        break;
                    case "EditorComentarioTub":
                        gerador.tubuComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioReg":
                        gerador.regiComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioCentral":
                        gerador.gasComentario = detalhes[i].Text;
                        break;
                    case "txtNotaFinal":
                        gerador.notaFinal = detalhes[i].Text;
                        break;

                }
            }

            for (var o = 0; o < fotos.Count; o++)
            {
                switch (fotos[o].Name)
                {
                    case "GridFotosTub":
                        gerador.tubuFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosReg":
                        gerador.regiFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosCentral":
                        gerador.gasFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                }

            }

            return gerador;
        }
        public List<Tubulacoes> MontaTubulacoes()
        {
            List<Tubulacoes> list = new List<Tubulacoes>();

            Puma.ModelosBanco.Subitemsetor subSetor = database.GetSubItemSetor(this.relatorio.Id, 3, 4);
            List<Puma.ModelosBanco.ItemSubItem> itemSubItems = database.GetListItemsSubItem(subSetor);
            for (var i = 0; i < itemSubItems.Count; i++)
            {
                // id = 3
                List<Puma.ModelosBanco.DetalhesItem> detalhes = database.GetDetalhesItems(itemSubItems[i]);
                List<Puma.ModelosBanco.FotosItem> fotos = database.GetFotosItems(itemSubItems[i]);
                list.Add(this.CriarTubulacao(detalhes, fotos));
            }
            return list;
        }
        public Tubulacoes CriarTubulacao(List<Puma.ModelosBanco.DetalhesItem> detalhes, List<Puma.ModelosBanco.FotosItem> fotos)
        {
            Tubulacoes gerador = new Tubulacoes();


            for (var i = 0; i < detalhes.Count; i++)
            {
                switch (detalhes[i].Name)
                {
                    case "PickerNomenclatura":
                        gerador.nomeclatura = detalhes[i].Text;
                        break;
                    case "PickerAuditado":
                        gerador.itemAuditado = detalhes[i].Text;
                        break;
                    case "PickerPlanejado":
                        gerador.planejado = detalhes[i].Text;
                        break;
                    case "PickerExecutado":
                        gerador.executado = detalhes[i].Text;
                        break;
                    case "PickerTubMaterial":
                        gerador.tubuMaterial = detalhes[i].Text;
                        break;
                    case "PickerTubAcabamento":
                        gerador.tubuAcabamento = detalhes[i].Text;
                        break;
                    case "PickerTubVazamento":
                        gerador.tubuVazamento = detalhes[i].Text;
                        break;
                    case "PickerTubFixacao":
                        gerador.tubuFixacao = detalhes[i].Text;
                        break;
                    case "PickerNotaTub":
                        gerador.tubuNota = detalhes[i].Text;
                        break;
                    case "PickerRegInstalacao":
                        gerador.regiInstalacao = detalhes[i].Text;
                        break;
                    case "PickerRegAcabamento":
                        gerador.regiAcabamento = detalhes[i].Text;
                        break;
                    case "PickerRegFixacao":
                        gerador.regiFixacao = detalhes[i].Text;
                        break;
                    case "PickerNotaReg":
                        gerador.regiNota = detalhes[i].Text;
                        break;
                    case "PickerNivelRisco":
                        gerador.nivelRisco = detalhes[i].Text;
                        break;
                    case "EntryLocalizacao":
                        gerador.localizacao = detalhes[i].Text;
                        break;
                    case "EditorComentarioTub":
                        gerador.tubuComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioReg":
                        gerador.regiComentario = detalhes[i].Text;
                        break;
                    case "txtNotaFinal":
                        gerador.notaFinal = detalhes[i].Text;
                        break;

                }
            }

            for (var o = 0; o < fotos.Count; o++)
            {
                switch (fotos[o].Name)
                {
                    case "GridFotosTub":
                        gerador.tubuFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosReg":
                        gerador.regiFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                }

            }

            return gerador;
        }

        public List<GeradoraAguaQuente> MontaGerarAguaQuente()
        {
            List<GeradoraAguaQuente> list = new List<GeradoraAguaQuente>();

            Puma.ModelosBanco.Subitemsetor subSetor = database.GetSubItemSetor(this.relatorio.Id, 3, 3);
            List<Puma.ModelosBanco.ItemSubItem> itemSubItems = database.GetListItemsSubItem(subSetor);
            for (var i = 0; i < itemSubItems.Count; i++)
            {
                // id = 3
                List<Puma.ModelosBanco.DetalhesItem> detalhes = database.GetDetalhesItems(itemSubItems[i]);
                List<Puma.ModelosBanco.FotosItem> fotos = database.GetFotosItems(itemSubItems[i]);
                list.Add(this.CriaGeradorAguaQuente(detalhes, fotos));
            }
            return list;
        }
        public GeradoraAguaQuente CriaGeradorAguaQuente(List<Puma.ModelosBanco.DetalhesItem> detalhes, List<Puma.ModelosBanco.FotosItem> fotos)
        {
            GeradoraAguaQuente gerador = new GeradoraAguaQuente();

            for (var i = 0; i < detalhes.Count; i++)
            {
                switch (detalhes[i].Name)
                {
                    case "PickerNomenclatura":
                        gerador.nomeclatura = detalhes[i].Text;
                        break;
                    case "PickerSistema":
                        gerador.sistema = detalhes[i].Text;
                        break;
                    case "PickerAlimentacao":
                        gerador.alimentacao = detalhes[i].Text;
                        break;
                    case "PickerAuditado":
                        gerador.itemAuditado = detalhes[i].Text;
                        break;
                    case "PickerPlanejado":
                        gerador.planejado = detalhes[i].Text;
                        break;
                    case "PickerExecutado":
                        gerador.executado = detalhes[i].Text;
                        break;

                    case "PickerBoilerMaterial":
                        gerador.boilMaterial = detalhes[i].Text;
                        break;
                    case "PickerBoilerIsolTermico":
                        gerador.boilIsolamentoTermico = detalhes[i].Text;
                        break;
                    case "PickerBoilerIsolMecanico":
                        gerador.boilIsolamentoMecanico = detalhes[i].Text;
                        break;
                    case "PickerBoilerPortaInspecao":
                        gerador.boilPortaInspecao = detalhes[i].Text;
                        break;
                    case "PickerBoilerTermDigital":
                        gerador.boilTermDigital = detalhes[i].Text;
                        break;
                    case "PickerBoilerTerAnalogico":
                        gerador.boilTermAnalogico = detalhes[i].Text;
                        break;
                    case "PickerBoilerValvulaAlivio":
                        gerador.boilValvulaAlivio = detalhes[i].Text;
                        break;
                    case "PickerBoilerStatusGeral":
                        gerador.boilStatusGeral = detalhes[i].Text;
                        break;
                    case "PickerNotaBoiler":
                        gerador.boilNota = detalhes[i].Text;
                        break;
                    case "PickerAquePassInstalacao":
                        gerador.aqueInstalacao = detalhes[i].Text;
                        break;
                    case "PickerAquePassAcabamento":
                        gerador.aqueAcabamento = detalhes[i].Text;
                        break;
                    case "PickerAquePassDetectorGas":
                        gerador.aqueDetectorGas = detalhes[i].Text;
                        break;
                    case "PickerAquePassFixacao":
                        gerador.aqueFixacao = detalhes[i].Text;
                        break;
                    case "PickerFotoAqueNota":
                        gerador.aqueNota = detalhes[i].Text;
                        break;
                    case "PickerBombaCalorInstalcao":
                        gerador.bombcInstalacao = detalhes[i].Text;
                        break;
                    case "PickerBombaCalorAcabamento":
                        gerador.bombcAcabamento = detalhes[i].Text;
                        break;
                    case "PickerBombaCalorVazamento":
                        gerador.bombcFixacao = detalhes[i].Text;
                        break;
                    case "PickerBombaCalorNota":
                        gerador.bombcNota = detalhes[i].Text;
                        break;
                    case "PickerPlacaSolarPlacas":
                        gerador.placsPlacasSolares = detalhes[i].Text;
                        break;
                    case "PickerPlacaSolarTubulacao":
                        gerador.placsTubulacao = detalhes[i].Text;
                        break;
                    case "PickerPlacaSolarFixacao":
                        gerador.placsFixacao = detalhes[i].Text;
                        break;
                    case "PickerPlacaSolarNota":
                        gerador.placsNota = detalhes[i].Text;
                        break;
                    case "PickerBombaRolamentos":
                        gerador.bombRolamento = detalhes[i].Text;
                        break;
                    case "PickerBombaAcoplamento":
                        gerador.bombAcoplamento = detalhes[i].Text;
                        break;
                    case "PickerBombaSeloMecanico":
                        gerador.bombSeloMecanico = detalhes[i].Text;
                        break;
                    case "PickerBombaAquecimento":
                        gerador.bombAquecimento = detalhes[i].Text;
                        break;
                    case "PickerBombaPintura":
                        gerador.bombPintura = detalhes[i].Text;
                        break;
                    case "PickerBombaStatusGeral":
                        gerador.bombStatusGeral = detalhes[i].Text;
                        break;
                    case "PickerNotaBomba":
                        gerador.bombNota = detalhes[i].Text;
                        break;
                    case "PickerBfeFixacao":
                        gerador.bfelFixacao = detalhes[i].Text;
                        break;
                    case "PickerBfeVibStop":
                        gerador.bfelVibraStop = detalhes[i].Text;
                        break;
                    case "PickerBfeInstaEletrica":
                        gerador.bfelInstalacaoEletrica = detalhes[i].Text;
                        break;
                    case "PickerBfeStatusGeral":
                        gerador.bfelStatusGeral = detalhes[i].Text;
                        break;
                    case "PickerNotaBfe":
                        gerador.bfelNota = detalhes[i].Text;
                        break;
                    case "PickerTubMaterial":
                        gerador.tubuMaterial = detalhes[i].Text;
                        break;
                    case "PickerTubAcabamento":
                        gerador.tubuAcabamento = detalhes[i].Text;
                        break;
                    case "PickerTubVazamento":
                        gerador.tubuVazamento = detalhes[i].Text;
                        break;
                    case "PickerTubFixacao":
                        gerador.tubuFixacao = detalhes[i].Text;
                        break;
                    case "PickerNotaTub":
                        gerador.tubuNota = detalhes[i].Text;
                        break;
                    case "PickerRegInstalacao":
                        gerador.regiInstalacao = detalhes[i].Text;
                        break;
                    case "PickerRegAcabamento":
                        gerador.regiAcabamento = detalhes[i].Text;
                        break;
                    case "PickerRegFixacao":
                        gerador.regiFixacao = detalhes[i].Text;
                        break;
                    case "PickerNotaReg":
                        gerador.regiNota = detalhes[i].Text;
                        break;
                    case "PickerNivelRisco":
                        gerador.nivelRisco = detalhes[i].Text;
                        break;
                    //case "EntryLocalizacao":
                    //    gerador.localizacao = detalhes[i].Text;
                    //    break;
                    case "EditorComentarioBoiler":
                        gerador.boilComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioAquePass":
                        gerador.aqueComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioBombaCalor":
                        gerador.bombcComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioPlacaSolar":
                        gerador.placsComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioBomba":
                        gerador.bombcComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioBfe":
                        gerador.bfelComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioTub":
                        gerador.tubuComentario = detalhes[i].Text;
                        break;
                    case "EditorComentarioReg":
                        gerador.regiComentario = detalhes[i].Text;
                        break;
                    case "txtNotaFinal":
                        gerador.notaFinal = detalhes[i].Text;
                        break;

                }
            }

            for (var o = 0; o < fotos.Count; o++)
            {
                switch (fotos[o].Name)
                {
                    case "GridFotosBoiler":
                        gerador.boilFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosAquePass":
                        gerador.aqueFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosBombaCalor":
                        gerador.bombcFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosPlacaSolar":
                        gerador.placsFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosBomba":
                        gerador.bombFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosBfe":
                        gerador.bfelFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosTub":
                        gerador.tubuFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                    case "GridFotosReg":
                        gerador.regiFotos.Add(new Imagem("data:image/png;base64," + fotos[o].Base64));
                        break;
                }

            }
            return gerador;
        }


    }
}
