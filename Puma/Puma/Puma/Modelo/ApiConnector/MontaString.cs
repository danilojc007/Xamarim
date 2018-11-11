using System;
using System.Collections.Generic;
using System.Text;
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



        public HeaderRequisicao MontaSaida(ObservableCollection<Email> emails)
        {
            //CAbeçalho
            header.localRelatorio = "CT Paulista";
            header.dataRelatorio = "15/10/2018";
            header.gerente = "Ana Maria Rodrigues";
            header.auditor = "Gilmar Silva Santos";
            header.macAddress = "XXXXXXXXX";
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
            list.Add(new Email("danilojc007@gmail.com"));
            return list;
        }
        public List<Barrilete> MontaBarrilete()
        {
            List<Barrilete> list = new List<Barrilete>();

            list.Add(this.CriarBarrilete());

            return list;

        }
        public Barrilete CriarBarrilete()
        {
            Barrilete barrilete = new Barrilete();
            barrilete.nomeclatura = "Incêndio";
            barrilete.localizacao = "Pavimento Térreo";
            barrilete.itemAuditado = "Não";
            barrilete.planejado = "Sim";
            barrilete.executado = "Não";
            barrilete.apontamentos = "Não";
            barrilete.bombRolamento = "Com vibrações";
            barrilete.bombAcoplamento = "OK";
            barrilete.bombSeloMecanico = "Irregular";
            barrilete.bombAquecimento = "Sim";
            barrilete.bombPintura = "Oxidada";
            barrilete.bombStatusGeral = "OK";
            barrilete.bombFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));
            barrilete.bombComentario = "Bomba está totalmente danificada";
            barrilete.bombNota = "35%";
            barrilete.bfelFixacao = "OK";
            barrilete.bfelVibraStop = "Irregular";
            barrilete.bfelInstalacaoEletrica = "Irregular";
            barrilete.bfelStatusGeral = "Com Corrosão";
            barrilete.bfelFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));
            barrilete.bfelComentario = "Bomba com aquecimento e oxidada";
            barrilete.bfelNota = "35%";
            barrilete.tubuMaterial = "Aço Carbono";
            barrilete.tubuAcabamento = "Envelopada";
            barrilete.tubuVazamento = "Não";
            barrilete.tubuFixacao = "NA";
            barrilete.tubuFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            barrilete.tubuComentario = "Oxidação avançada nas tubulações";
            barrilete.tubuNota = "75%";
            barrilete.regiInstalacao = "OK";
            barrilete.regiAcabamento = "Irregular";
            barrilete.regiFixacao = "Irregular";
            barrilete.regiFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            barrilete.regiComentario = "As fixações precisam de uma pintura geral";
            barrilete.regiNota = "75%";
            barrilete.notaFinal = "47%";
            barrilete.nivelRisco = "MEDIO";
            return barrilete;
        }
        public List<Reservatorio> MontaReservatorio()
        {
            List<Reservatorio> list = new List<Reservatorio>();


            list.Add(this.CriaReservatorio());


            return list;
        }
        public Reservatorio CriaReservatorio()
        {
            Reservatorio reservatorio = new Reservatorio();

            reservatorio.nomeclatura = "Incêndio";
            reservatorio.tipo = "Polietileno";
            reservatorio.localizacao = "Pavimento Térreo";
            reservatorio.itemAuditado = "Não";
            reservatorio.planejado = "Sim";
            reservatorio.executado = "NA";
            reservatorio.apontamentos = "Não";
            reservatorio.portFechamento = "Cadeado";
            reservatorio.portHermetico = "Sim";
            reservatorio.portStatusGeral = "Danificada";
            reservatorio.portFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));
            reservatorio.portComentario = "A portinhola está completamente corroída e necessita ser trocada.";
            reservatorio.portNota = "75%";
            reservatorio.impTipo = "Asfáltica";
            reservatorio.impEstrutura = "Pontos aparente";
            reservatorio.impStatusGeral = "Soltando";
            reservatorio.impFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));
            reservatorio.impComentario = "A impermeabilização asfásltica está sem a proteção mecânica (fora das normas).";
            reservatorio.impNota = "35%";
            reservatorio.limpAgua = "LIMPA";
            reservatorio.limpBoiaNivel = "OK";
            reservatorio.limpStatusGeral = "OK";
            reservatorio.limpFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));
            reservatorio.limpComentario = "A água da está suja";
            reservatorio.limpNota = "100%";
            reservatorio.notaFinal = "47%";
            reservatorio.nivelRisco = "MEDIO";
            return reservatorio;
        }

        public List<Bombas> MontaBomba()
        {
            List<Bombas> list = new List<Bombas>();


            list.Add(this.CriarBomba());


            return list;
        }
        public Bombas CriarBomba()
        {
            Bombas boomba = new Bombas();

            boomba.nomeclatura = "Incêndio";
            boomba.localizacao = "Pavimento Térreo";
            boomba.itemAuditado = "Não";
            boomba.planejado = "Sim";
            boomba.executado = "NA";
            boomba.apontamentos = "Não";
            boomba.bombRolamento = "Com vibrações";
            boomba.bombAcoplamento = "OK";
            boomba.bombSeloMecanico = "Irregular";
            boomba.bombAquecimento = "Sim";
            boomba.bombPintura = "Oxidada";
            boomba.bombStatusGeral = "OK";
            boomba.bombFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            boomba.bombComentario = "Bomba está totalmente danificada";
            boomba.bombNota = "35%";
            boomba.bfelFixacao = "OK";
            boomba.bfelVibraStop = "Irregular";
            boomba.bfelInstalacaoEletrica = "Irregular";
            boomba.bfelStatusGeral = "Com Corrosão";
            boomba.bfelFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            boomba.bfelComentario = "Bomba com aquecimento e oxidada";
            boomba.bfelNota = "35%";
            boomba.notaFinal = "47%";
            boomba.nivelRisco = "MEDIO";



            return boomba;
        }
        public List<RedeGas> MontaRedeGas()
        {
            List<RedeGas> list = new List<RedeGas>();
            list.Add(this.CriaRedeGas());
            return list;
        }

        public RedeGas CriaRedeGas()
        {
            RedeGas rede = new RedeGas();

            rede.nomeclatura = "Incêndio";
            rede.alimentacao = "Pavimento Térreo";
            rede.itemAuditado = "Não";
            rede.planejado = "Sim";
            rede.executado = "NA";
            rede.apontamentos = "Não";
            rede.tubuMaterial = "Aço Carbono";
            rede.tubuAcabamento = "Envelopada";
            rede.tubuVazamento = "Não";
            rede.tubuFixacao = "NA";
            rede.tubuFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            rede.tubuComentario = "Oxidação avançada nas tubulações";
            rede.tubuNota = "75%";
            rede.regiInstalacao = "OK";
            rede.regiAcabamento = "Irregular";
            rede.regiFixacao = "Irregular";
            rede.regiFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            rede.regiComentario = "As fixações precisam de uma pintura geral";
            rede.regiNota = "75%";
            rede.gasSistema = "Gás Natural";
            rede.gasTanques = "Corrosão";
            rede.gasDetectorGas = "OK";
            rede.gasExtintores = "Não tem";
            rede.gasLocalInstalacao = "OK";
            rede.gasFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            rede.gasComentario = "As fixações precisam de uma pintura geral";
            rede.gasNota = "75%";
            rede.notaFinal = "47%";
            rede.nivelRisco = "MEDIO";


            return rede;
        }
        public List<Tubulacoes> MontaTubulacoes()
        {
            List<Tubulacoes> list = new List<Tubulacoes>();

            list.Add(this.CriarTubulacao());
            return list;
        }
        public Tubulacoes CriarTubulacao()
        {
            Tubulacoes tub = new Tubulacoes();

            tub.nomeclatura = "Incêndio";
            tub.alimentacao = "Pavimento Térreo";
            tub.itemAuditado = "Não";
            tub.planejado = "Sim";
            tub.executado = "NA";
            tub.apontamentos = "Não";
            tub.tubuMaterial = "Aço Carbono";
            tub.tubuAcabamento = "Envelopada";
            tub.tubuVazamento = "Não";
            tub.tubuFixacao = "NA";
            tub.tubuFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            tub.tubuComentario = "Oxidação avançada nas tubulações";
            tub.tubuNota = "75%";
            tub.regiInstalacao = "OK";
            tub.regiAcabamento = "Irregular";
            tub.regiFixacao = "Irregular";
            tub.regiFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            tub.regiComentario = "As fixações precisam de uma pintura geral";
            tub.regiNota = "75%";
            tub.notaFinal = "47%";
            tub.nivelRisco = "MEDIO";

            return tub;
        }

        public List<GeradoraAguaQuente> MontaGerarAguaQuente()
        {
            List<GeradoraAguaQuente> list = new List<GeradoraAguaQuente>();
            list.Add(this.CriaGeradorAguaQuente());
            return list;
        }
        public GeradoraAguaQuente CriaGeradorAguaQuente()
        {
            GeradoraAguaQuente gerador = new GeradoraAguaQuente();

            gerador.nomeclatura = "Incêndio";
            gerador.sistema = "Bomba Calor";
            gerador.alimentacao = "Elétrico";
            gerador.itemAuditado = "Não";
            gerador.planejado = "Sim";
            gerador.executado = "NA";
            gerador.apontamentos = "Não";
            gerador.boilMaterial = "Cobre";
            gerador.boilIsolamentoTermico = "Danificado";
            gerador.boilIsolamentoMecanico = "Soltando";
            gerador.boilPortaInspecao = "OK";
            gerador.boilTermDigital = "OK";
            gerador.boilTermAnalogico = "Irregular";
            gerador.boilValvulaAlivio = "Danificado";
            gerador.boilStatusGeral = "OK";
            gerador.boilFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            gerador.boilComentario = "Boiler com Vazamento";
            gerador.boilNota = "35%";
            gerador.aqueInstalacao = "Corrosão";
            gerador.aqueAcabamento = "OK";
            gerador.aqueDetectorGas = "Irregular";
            gerador.aqueFixacao = "OK";
            gerador.aqueFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            gerador.aqueComentario = "Dois aquecedores estão desligados";
            gerador.aqueNota = "35%";
            gerador.bombcInstalacao = "Vazando";
            gerador.bombcAcabamento = "OK";
            gerador.bombcFixacao = "OK";
            gerador.bombcFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            gerador.bombcComentario = "Comprerssor Queimado";
            gerador.bombcNota = "35%";
            gerador.placsPlacasSolares = "Suja";
            gerador.placsTubulacao = "Corrosão";
            gerador.placsFixacao = "OK";
            gerador.placsFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            gerador.placsComentario = "Sete Placas quebradas e sujas";
            gerador.placsNota = "35%";
            gerador.bombRolamento = "Com vibrações";
            gerador.bombAcoplamento = "OK";
            gerador.bombSeloMecanico = "Irregular";
            gerador.bombAquecimento = "Sim";
            gerador.bombPintura = "Oxidada";
            gerador.bombStatusGeral = "OK";
            gerador.bombFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            gerador.bombComentario = "Bomba está totalmente danificada";
            gerador.bombNota = "35%";
            gerador.bfelFixacao = "OK";
            gerador.bfelVibraStop = "Irregular";
            gerador.bfelInstalacaoEletrica = "Irregular";
            gerador.bfelStatusGeral = "Com Corrosão";
            gerador.bfelFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            gerador.bfelComentario = "Bomba com aquecimento e oxidada";
            gerador.bfelNota = "35%";
            gerador.tubuMaterial = "Aço Carbono";
            gerador.tubuAcabamento = "Envelopada";
            gerador.tubuVazamento = "Não";
            gerador.tubuFixacao = "NA";
            gerador.tubuFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            gerador.tubuComentario = "Oxidação avançada nas tubulações";
            gerador.tubuNota = "75%";
            gerador.regiInstalacao = "OK";
            gerador.regiAcabamento = "Irregular";
            gerador.regiFixacao = "Irregular";
            gerador.regiFotos.Add(new Imagem("data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAIAAAACUFjqAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QIJBywfp3IOswAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAkUlEQVQY052PMQqDQBREZ1f/d1kUm3SxkeAF/FdIjpOcw2vpKcRWCwsRPMFPsaIQSIoMr5pXDGNUFd9j8TOn7kRW71fvO5HTq6qqtnWtzh20IqE3YXtL0zyKwAROQLQ5l/c9gHjfKK6wMZjADE6s49Dver4/smEAc2CuqgwAYI5jU9NcxhHEy60sni986H9+vwG1yDHfK1jitgAAAABJRU5ErkJggg=="));

            gerador.regiComentario = "As fixações precisam de uma pintura geral";
            gerador.regiNota = "75%";
            gerador.notaFinal = "47%";
            gerador.nivelRisco = "MEDIO";


            return gerador;
        }


    }
}
