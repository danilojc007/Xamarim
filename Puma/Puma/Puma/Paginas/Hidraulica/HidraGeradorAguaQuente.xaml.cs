using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Puma.Modelo;
using Puma.Service;

namespace Puma.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HidraGeradorAguaQuente : ContentPage
    {
        // Paramentros Principais
        private char editado = 'N';
        private Manipulacao manipulacao = new Manipulacao();
        private CarroselSubItems carousel = null;
        //Listas Comum
        private List<ComboBox> simples = new List<ComboBox>();
        private List<ComboBox> nota = new List<ComboBox>();
        private List<ComboBox> apontamentos = new List<ComboBox>();
        private List<ComboBox> nivelRisco = new List<ComboBox>();
        // Lista Especifivo
        private List<ComboBox> nomenclatura = new List<ComboBox>();
        private List<ComboBox> sistema = new List<ComboBox>();
        private List<ComboBox> alimentacao = new List<ComboBox>();
        private List<ComboBox> boilerMaterial = new List<ComboBox>();
        private List<ComboBox> boilerIsolTermico = new List<ComboBox>();
        private List<ComboBox> boilerIsolMecanico = new List<ComboBox>();
        private List<ComboBox> boilerPortaInspecao = new List<ComboBox>();
        private List<ComboBox> boilerTermDigital = new List<ComboBox>();
        private List<ComboBox> boilerTerAnalogico = new List<ComboBox>();
        private List<ComboBox> boilerValvulaAlivio = new List<ComboBox>();
        private List<ComboBox> boilerStatusGeral = new List<ComboBox>();
        private List<ComboBox> aquePassInstalacao = new List<ComboBox>();
        private List<ComboBox> aquePassAcabamento = new List<ComboBox>();
        private List<ComboBox> aquePassDetectorGas = new List<ComboBox>();
        private List<ComboBox> aquePassFixacao = new List<ComboBox>();
        private List<ComboBox> bombaCalorInstalcao = new List<ComboBox>();
        private List<ComboBox> bombaCalorAcabamento = new List<ComboBox>();
        private List<ComboBox> bombaCalorVazamento = new List<ComboBox>();
        private List<ComboBox> placaSolarPlacas = new List<ComboBox>();
        private List<ComboBox> placaSolarTubulacao = new List<ComboBox>();
        private List<ComboBox> placaSolarFixacao = new List<ComboBox>();
        private List<ComboBox> bombaRolamentos = new List<ComboBox>();
        private List<ComboBox> bombaAcoplamento = new List<ComboBox>();
        private List<ComboBox> bombaSeloMecanico = new List<ComboBox>();
        private List<ComboBox> bombaAquecimento = new List<ComboBox>();
        private List<ComboBox> bombaPintura = new List<ComboBox>();
        private List<ComboBox> bombaStatusGeral = new List<ComboBox>();
        private List<ComboBox> bfeFixacao = new List<ComboBox>();
        private List<ComboBox> bfeVibStop = new List<ComboBox>();
        private List<ComboBox> bfeInstaEletrica = new List<ComboBox>();
        private List<ComboBox> bfeStatusGeral = new List<ComboBox>();
        private List<ComboBox> tubMaterial = new List<ComboBox>();
        private List<ComboBox> tubAcabamento = new List<ComboBox>();
        private List<ComboBox> tubVazamento = new List<ComboBox>();
        private List<ComboBox> tubFixacao = new List<ComboBox>();
        private List<ComboBox> regInstalacao = new List<ComboBox>();
        private List<ComboBox> regAcabamento = new List<ComboBox>();
        private List<ComboBox> regFixacao = new List<ComboBox>();

        //Parte das Fotos 
        List<Puma.ModelosBanco.FotosItem> FotosItem = new List<Puma.ModelosBanco.FotosItem>();
        List<Puma.ModelosBanco.FotosItem> DeleteFotosItem = new List<Puma.ModelosBanco.FotosItem>();
        // parte do Banco
        List<Puma.ModelosBanco.DetalhesItem> detalhesItem = null;
        Puma.ModelosBanco.ItemSubItem itemSubItem = null;
        Puma.Banco.AcessoBanco database = null;
        public HidraGeradorAguaQuente(CarroselSubItems carousel, Puma.ModelosBanco.ItemSubItem itemSubItem, Puma.Banco.AcessoBanco conexao)
        {
            InitializeComponent();
            this.database = conexao;
            this.itemSubItem = itemSubItem;
            this.carousel = carousel;

            //Lista Comum
            simples.Add(new ComboBox(1, "Sim", "#008000"));
            simples.Add(new ComboBox(2, "Não", "#FF0000"));
            simples.Add(new ComboBox(3, "N/A", "#000000"));

            apontamentos.Add(new ComboBox(1, "Sim", "#FF0000"));
            apontamentos.Add(new ComboBox(2, "Não", "#008000"));
            apontamentos.Add(new ComboBox(3, "N/A", "#000000"));

            nota.Add(new ComboBox(1, "35%", "#FF0000"));
            nota.Add(new ComboBox(2, "75%", "#FF9933"));
            nota.Add(new ComboBox(3, "100%", "#008000"));

            nivelRisco.Add(new ComboBox(1, "BAIXO", "#008000"));
            nivelRisco.Add(new ComboBox(2, "MÉDIO", "#FF9933"));
            nivelRisco.Add(new ComboBox(3, "ALTO", "#FF0000"));

            //Lista Especifica
            nomenclatura.Add(new ComboBox(1, "Queimada indireta", "#000000"));
            nomenclatura.Add(new ComboBox(2, "Queimada direta", "#000000"));

            sistema.Add(new ComboBox(1, "Boiler", "#000000"));
            sistema.Add(new ComboBox(2, "Aquecedor passagem", "#000000"));
            sistema.Add(new ComboBox(3, "Solar", "#000000"));
            sistema.Add(new ComboBox(4, "Bomba Calor", "#000000"));
            sistema.Add(new ComboBox(5, "Caldeira", "#000000"));

            alimentacao.Add(new ComboBox(1, "Solar", "#000000"));
            alimentacao.Add(new ComboBox(2, "Gás", "#000000"));
            alimentacao.Add(new ComboBox(3, "Elétrico", "#000000"));
            alimentacao.Add(new ComboBox(4, "Madeira", "#000000"));
            alimentacao.Add(new ComboBox(5, "Carvão", "#000000"));
            alimentacao.Add(new ComboBox(6, "Diesel", "#000000"));

            boilerMaterial.Add(new ComboBox(1, "Aço Inox", "#000000"));
            boilerMaterial.Add(new ComboBox(2, "Aço Carbono", "#000000"));
            boilerMaterial.Add(new ComboBox(3, "Cobre", "#000000"));

            boilerIsolTermico.Add(new ComboBox(1, "Danificado", "#FF0000"));
            boilerIsolTermico.Add(new ComboBox(2, "Irregular", "#FF0000"));
            boilerIsolTermico.Add(new ComboBox(3, "Soltando", "#FF0000"));
            boilerIsolTermico.Add(new ComboBox(4, "Não tem", "#FF0000"));
            boilerIsolTermico.Add(new ComboBox(5, "Ok", "#008000"));

            boilerIsolMecanico.Add(new ComboBox(1, "Danificado", "#FF0000"));
            boilerIsolMecanico.Add(new ComboBox(2, "Irregular", "#FF0000"));
            boilerIsolMecanico.Add(new ComboBox(3, "Soltando", "#FF0000"));
            boilerIsolMecanico.Add(new ComboBox(4, "Não tem", "#FF0000"));
            boilerIsolMecanico.Add(new ComboBox(5, "Ok", "#008000"));

            boilerPortaInspecao.Add(new ComboBox(1, "Corrosão", "#FF0000"));
            boilerPortaInspecao.Add(new ComboBox(2, "Irregular", "#FF0000"));
            boilerPortaInspecao.Add(new ComboBox(3, "Vazando", "#FF0000"));
            boilerPortaInspecao.Add(new ComboBox(4, "Não tem", "#FF0000"));
            boilerPortaInspecao.Add(new ComboBox(5, "Ok", "#008000"));


            boilerTermDigital.Add(new ComboBox(1, "Danificado", "#FF0000"));
            boilerTermDigital.Add(new ComboBox(2, "Irregular", "#FF0000"));
            boilerTermDigital.Add(new ComboBox(3, "Não tem", "#FF0000"));
            boilerTermDigital.Add(new ComboBox(4, "Ok", "#008000"));

            boilerTerAnalogico.Add(new ComboBox(1, "Danificado", "#FF0000"));
            boilerTerAnalogico.Add(new ComboBox(2, "Irregular", "#FF0000"));
            boilerTerAnalogico.Add(new ComboBox(3, "Não tem", "#FF0000"));
            boilerTerAnalogico.Add(new ComboBox(4, "Ok", "#008000"));

            boilerValvulaAlivio.Add(new ComboBox(1, "Danificado", "#FF0000"));
            boilerValvulaAlivio.Add(new ComboBox(2, "Irregular", "#FF0000"));
            boilerValvulaAlivio.Add(new ComboBox(3, "Não tem", "#FF0000"));
            boilerValvulaAlivio.Add(new ComboBox(4, "Ok", "#008000"));

            boilerStatusGeral.Add(new ComboBox(1, "Irregular", "#FF0000"));
            boilerStatusGeral.Add(new ComboBox(2, "Crítica", "#FF0000"));
            boilerStatusGeral.Add(new ComboBox(3, "Ok", "#008000"));

            aquePassInstalacao.Add(new ComboBox(1, "Ok", "#008000"));
            aquePassInstalacao.Add(new ComboBox(2, "Irregular", "#FF0000"));
            aquePassInstalacao.Add(new ComboBox(3, "Vazando", "#FF0000"));
            aquePassInstalacao.Add(new ComboBox(4, "Corrosão", "#FF0000"));
            aquePassInstalacao.Add(new ComboBox(5, "Sem Canopla", "#FF0000"));
            aquePassInstalacao.Add(new ComboBox(6, "Travado", "#FF0000"));
            aquePassInstalacao.Add(new ComboBox(7, "Em Manutenção", "#FF0000"));

            aquePassAcabamento.Add(new ComboBox(1, "Ok", "#008000"));
            aquePassAcabamento.Add(new ComboBox(2, "Irregular", "#FF0000"));
            aquePassAcabamento.Add(new ComboBox(3, "Sem identificação", "#FF0000"));
            aquePassAcabamento.Add(new ComboBox(4, "Sem tampa proteção", "#FF0000"));

            aquePassDetectorGas.Add(new ComboBox(1, "Ok", "#008000"));
            aquePassDetectorGas.Add(new ComboBox(2, "Irregular", "#FF0000"));
            aquePassDetectorGas.Add(new ComboBox(3, "Não tem", "#FF0000"));


            aquePassFixacao.Add(new ComboBox(1, "Ok", "#008000"));
            aquePassFixacao.Add(new ComboBox(2, "Irregular", "#FF0000"));
            aquePassFixacao.Add(new ComboBox(3, "Não tem", "#FF0000"));

            bombaCalorInstalcao.Add(new ComboBox(1, "Ok", "#008000"));
            bombaCalorInstalcao.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bombaCalorInstalcao.Add(new ComboBox(3, "Vazando", "#FF0000"));
            bombaCalorInstalcao.Add(new ComboBox(4, "Corrosão", "#FF0000"));
            bombaCalorInstalcao.Add(new ComboBox(5, "Sem Canopla", "#FF0000"));
            bombaCalorInstalcao.Add(new ComboBox(6, "Travado", "#FF0000"));
            bombaCalorInstalcao.Add(new ComboBox(7, "Em Manutenção", "#FF0000"));

            bombaCalorAcabamento.Add(new ComboBox(1, "Ok", "#008000"));
            bombaCalorAcabamento.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bombaCalorAcabamento.Add(new ComboBox(3, "Sem identificação", "#FF0000"));
            bombaCalorAcabamento.Add(new ComboBox(4, "Sem tampa proteção", "#FF0000"));

            bombaCalorVazamento.Add(new ComboBox(1, "Ok", "#008000"));
            bombaCalorVazamento.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bombaCalorVazamento.Add(new ComboBox(3, "Não tem", "#FF0000"));

            placaSolarPlacas.Add(new ComboBox(1, "Ok", "#008000"));
            placaSolarPlacas.Add(new ComboBox(2, "Irregular", "#FF0000"));
            placaSolarPlacas.Add(new ComboBox(3, "Vidro quebrado", "#FF0000"));
            placaSolarPlacas.Add(new ComboBox(4, "Suja", "#FF0000"));
            placaSolarPlacas.Add(new ComboBox(5, "Vazando", "#FF0000"));
            placaSolarPlacas.Add(new ComboBox(6, "Vidro quebrado", "#FF0000"));

            placaSolarTubulacao.Add(new ComboBox(1, "Ok", "#008000"));
            placaSolarTubulacao.Add(new ComboBox(2, "Irregular", "#FF0000"));
            placaSolarTubulacao.Add(new ComboBox(3, "Corrosão", "#FF0000"));
            placaSolarTubulacao.Add(new ComboBox(4, "Ressecada", "#FF0000"));
            placaSolarTubulacao.Add(new ComboBox(5, "Vazando", "#FF0000"));
            placaSolarTubulacao.Add(new ComboBox(6, "Sem fixação", "#FF0000"));

            placaSolarFixacao.Add(new ComboBox(1, "Ok", "#008000"));
            placaSolarFixacao.Add(new ComboBox(2, "Irregular", "#FF0000"));

            bombaRolamentos.Add(new ComboBox(1, "Com ruídos", "#FF0000"));
            bombaRolamentos.Add(new ComboBox(2, "Com vibrações", "#FF0000"));
            bombaRolamentos.Add(new ComboBox(3, "Ok", "#008000"));
            bombaRolamentos.Add(new ComboBox(4, "Irregular", "#FF0000"));

            bombaAcoplamento.Add(new ComboBox(1, "Ok", "#008000"));
            bombaAcoplamento.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bombaAcoplamento.Add(new ComboBox(3, "Alinhado", "#008000"));
            bombaAcoplamento.Add(new ComboBox(4, "Não Alinhado", "#FF0000"));
            bombaAcoplamento.Add(new ComboBox(5, "Gaxeta irregular", "#FF0000"));

            bombaSeloMecanico.Add(new ComboBox(1, "Ok", "#008000"));
            bombaSeloMecanico.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bombaSeloMecanico.Add(new ComboBox(3, "Vazando", "#FF0000"));

            bombaAquecimento.Add(new ComboBox(1, "Sim", "#FF0000"));
            bombaAquecimento.Add(new ComboBox(2, "Não", "#008000"));

            bombaPintura.Add(new ComboBox(1, "Ok", "#008000"));
            bombaPintura.Add(new ComboBox(2, "Oxidada", "#FF0000"));
            bombaPintura.Add(new ComboBox(3, "Irregular", "#FF0000"));

            bombaStatusGeral.Add(new ComboBox(1, "Ok", "#008000"));
            bombaStatusGeral.Add(new ComboBox(2, "irregular", "#FF0000"));
            bombaStatusGeral.Add(new ComboBox(3, "Crítica", "#FF0000"));

            bfeFixacao.Add(new ComboBox(1, "Ok", "#008000"));
            bfeFixacao.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bfeFixacao.Add(new ComboBox(3, "Não tem", "#FF0000"));

            bfeVibStop.Add(new ComboBox(1, "Ok", "#008000"));
            bfeVibStop.Add(new ComboBox(2, "Irregular", "#FF0000"));
            bfeVibStop.Add(new ComboBox(3, "Não tem", "#FF0000"));

            bfeInstaEletrica.Add(new ComboBox(1, "Ok", "#008000"));
            bfeInstaEletrica.Add(new ComboBox(2, "Irregular", "#FF0000"));

            bfeStatusGeral.Add(new ComboBox(1, "Ok", "#008000"));
            bfeStatusGeral.Add(new ComboBox(2, "Solto", "#FF0000"));
            bfeStatusGeral.Add(new ComboBox(3, "Com corrosão", "#FF0000"));
            bfeStatusGeral.Add(new ComboBox(4, "NA", "#008000"));
            bfeStatusGeral.Add(new ComboBox(5, "Irregular", "#FF0000"));

            tubMaterial.Add(new ComboBox(1, "Ferro", "#000000"));
            tubMaterial.Add(new ComboBox(2, "Aço Carbono", "#000000"));
            tubMaterial.Add(new ComboBox(3, "PVC marron", "#000000"));
            tubMaterial.Add(new ComboBox(4, "CPVC Branco", "#000000"));
            tubMaterial.Add(new ComboBox(5, "Ferro Fundido", "#000000"));
            tubMaterial.Add(new ComboBox(6, "Mangueira Pex", "#000000"));
            tubMaterial.Add(new ComboBox(7, "PVC Branco", "#000000"));
            tubMaterial.Add(new ComboBox(8, "Cobre", "#000000"));
            tubMaterial.Add(new ComboBox(9, "PPR", "#000000"));
            tubMaterial.Add(new ComboBox(10, "Aço fundido", "#000000"));
            tubMaterial.Add(new ComboBox(11, "Concreto", "#000000"));

            tubAcabamento.Add(new ComboBox(1, "Isolada", "#008000"));
            tubAcabamento.Add(new ComboBox(2, "Sem pintura", "#FF0000"));
            tubAcabamento.Add(new ComboBox(3, "Sem isolação", "#FF0000"));
            tubAcabamento.Add(new ComboBox(4, "Pintura Ok", "#008000"));
            tubAcabamento.Add(new ComboBox(5, "Ok", "#008000"));
            tubAcabamento.Add(new ComboBox(6, "Envelopada", "#008000"));

            tubVazamento.Add(new ComboBox(1, "Sim", "#FF0000"));
            tubVazamento.Add(new ComboBox(2, "Não", "008000"));
            tubVazamento.Add(new ComboBox(3, "Irregular", "#FF0000"));


            tubFixacao.Add(new ComboBox(1, "Ok", "#008000"));
            tubFixacao.Add(new ComboBox(2, "Irregular", "#FF0000"));
            tubFixacao.Add(new ComboBox(3, "Vazando", "#FF0000"));
            tubFixacao.Add(new ComboBox(4, "Corrosão", "#FF0000"));
            tubFixacao.Add(new ComboBox(5, "Sem Canopla", "#FF0000"));
            tubFixacao.Add(new ComboBox(6, "Travado", "#FF0000"));

            regInstalacao.Add(new ComboBox(1, "Ok", "#008000"));
            regInstalacao.Add(new ComboBox(2, "Irregular", "#FF0000"));
            regInstalacao.Add(new ComboBox(3, "Sem identificação", "#FF0000"));

            regAcabamento.Add(new ComboBox(1, "Ok", "#008000"));
            regAcabamento.Add(new ComboBox(2, "Irregular", "#FF0000"));
            regAcabamento.Add(new ComboBox(3, "Sem identificação", "#FF0000"));

            regFixacao.Add(new ComboBox(1, "Ok", "#008000"));
            regFixacao.Add(new ComboBox(2, "Irregular", "#FF0000"));

            PickerNomenclatura.ItemsSource = nomenclatura;
            PickerNomenclatura.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerSistema.ItemsSource = sistema;
            PickerSistema.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerAlimentacao.ItemsSource = alimentacao;
            PickerSistema.SelectedIndexChanged += this.PickerSimpleChanged;

            //---------- Simples ---------

            PickerAuditado.ItemsSource = simples;
            PickerAuditado.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerPlanejado.ItemsSource = simples;
            PickerPlanejado.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerExecutado.ItemsSource = simples;
            PickerAuditado.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerApontamentos.ItemsSource = apontamentos;
            PickerApontamentos.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNivelRisco.ItemsSource = nivelRisco;
            PickerNivelRisco.SelectedIndexChanged += this.PickerSimpleChanged;

            //----------Boiler ---------

            PickerBoilerMaterial.ItemsSource = boilerMaterial;
            PickerApontamentos.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBoilerIsolTermico.ItemsSource = boilerIsolTermico;
            PickerApontamentos.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBoilerIsolMecanico.ItemsSource = boilerIsolMecanico;
            PickerBoilerIsolMecanico.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBoilerPortaInspecao.ItemsSource = boilerPortaInspecao;
            PickerBoilerPortaInspecao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBoilerTermDigital.ItemsSource = boilerTermDigital;
            PickerBoilerTermDigital.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBoilerTerAnalogico.ItemsSource = boilerTerAnalogico;
            PickerBoilerTerAnalogico.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBoilerValvulaAlivio.ItemsSource = boilerValvulaAlivio;
            PickerBoilerValvulaAlivio.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBoilerStatusGeral.ItemsSource = boilerStatusGeral;
            PickerBoilerStatusGeral.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNotaBoiler.ItemsSource = nota;
            PickerNotaBoiler.SelectedIndexChanged += this.PickerNotaChanged;

            //-------- Aquecimento ------------------
            PickerAquePassInstalacao.ItemsSource = aquePassInstalacao;
            PickerAquePassInstalacao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerAquePassAcabamento.ItemsSource = aquePassAcabamento;
            PickerAquePassAcabamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerAquePassDetectorGas.ItemsSource = aquePassDetectorGas;
            PickerAquePassDetectorGas.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerAquePassFixacao.ItemsSource = aquePassFixacao;
            PickerAquePassFixacao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerFotoAqueNota.ItemsSource = nota;
            PickerFotoAqueNota.SelectedIndexChanged += this.PickerNotaChanged;
            //-------------Bomba Calor --------------
            PickerBombaCalorInstalcao.ItemsSource = bombaCalorInstalcao;
            PickerBombaCalorInstalcao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBombaCalorAcabamento.ItemsSource = bombaCalorAcabamento;
            PickerBombaCalorAcabamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBombaCalorVazamento.ItemsSource = bombaCalorVazamento;
            PickerBombaCalorVazamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBombaCalorNota.ItemsSource = nota;
            PickerBombaCalorNota.SelectedIndexChanged += this.PickerNotaChanged;
            //------------Placa Solar -------------- -

            PickerPlacaSolarPlacas.ItemsSource = placaSolarPlacas;
            PickerPlacaSolarPlacas.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerPlacaSolarTubulacao.ItemsSource = placaSolarTubulacao;
            PickerPlacaSolarTubulacao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerPlacaSolarFixacao.ItemsSource = placaSolarFixacao;
            PickerPlacaSolarFixacao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerPlacaSolarNota.ItemsSource = nota;
            PickerPlacaSolarNota.SelectedIndexChanged += this.PickerNotaChanged;
            //------------Bomba ---------------- -

            PickerBombaRolamentos.ItemsSource = bombaRolamentos;
            PickerBombaRolamentos.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBombaAcoplamento.ItemsSource = bombaAcoplamento;
            PickerBombaAcoplamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBombaSeloMecanico.ItemsSource = bombaSeloMecanico;
            PickerBombaSeloMecanico.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBombaAquecimento.ItemsSource = bombaAquecimento;
            PickerBombaAquecimento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBombaPintura.ItemsSource = bombaPintura;
            PickerBombaPintura.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBombaStatusGeral.ItemsSource = bombaStatusGeral;
            PickerBombaStatusGeral.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNotaBomba.ItemsSource = nota;
            PickerNotaBomba.SelectedIndexChanged += this.PickerNotaChanged;
            //---------------Bomba Fixação--------------

            PickerBfeFixacao.ItemsSource = bfeFixacao;
            PickerBfeFixacao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBfeVibStop.ItemsSource = bfeVibStop;
            PickerBfeVibStop.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBfeInstaEletrica.ItemsSource = bfeInstaEletrica;
            PickerBfeInstaEletrica.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerBfeStatusGeral.ItemsSource = bfeStatusGeral;
            PickerBfeStatusGeral.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNotaBfe.ItemsSource = nota;
            PickerNotaBfe.SelectedIndexChanged += this.PickerNotaChanged;
            //------------ Tubulação ------------ -
            PickerTubMaterial.ItemsSource = tubMaterial;
            PickerTubMaterial.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerTubAcabamento.ItemsSource = tubAcabamento;
            PickerTubAcabamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerTubVazamento.ItemsSource = tubVazamento;
            PickerTubVazamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerTubFixacao.ItemsSource = tubFixacao;
            PickerTubFixacao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNotaTub.ItemsSource = nota;
            PickerNotaTub.SelectedIndexChanged += this.PickerNotaChanged;
            //----------------  Registros --------

            PickerRegInstalacao.ItemsSource = regInstalacao;
            PickerRegInstalacao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerRegAcabamento.ItemsSource = regAcabamento;
            PickerRegAcabamento.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerRegFixacao.ItemsSource = regFixacao;
            PickerRegFixacao.SelectedIndexChanged += this.PickerSimpleChanged;

            PickerNotaReg.ItemsSource = nota;
            PickerNotaReg.SelectedIndexChanged += this.PickerNotaChanged;

            this.CarregaDoBanco();
        }
        public int GetContador()
        {
            return itemSubItem.Contador;
        }
        public Boolean GetEditado()
        {
            if (this.editado == 'S')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CarregaDoBanco()
        {
            detalhesItem = database.GetDetalhesItems(this.itemSubItem);
            //string teste = PickerNivelRisco.ToString();
            //PickerNivelRisco.SelectedIndex = 1;
            //var teste = this.FindByName<Picker>("PickerNivelRisco");
            if (detalhesItem.Count != 0)
            {
                for (var i = 0; i < detalhesItem.Count; i++)
                {
                    if (detalhesItem[i].Tipo == "Picker")
                    {
                        this.FindByName<Picker>(detalhesItem[i].Name).SelectedIndex = detalhesItem[i].Index;
                    }
                    else
                    {
                        if (detalhesItem[i].Tipo == "Entry")
                        {
                            this.FindByName<Entry>(detalhesItem[i].Name).Text = detalhesItem[i].Text;
                        }
                        else
                        {
                            if (detalhesItem[i].Tipo == "Editor")
                            {
                                this.FindByName<Editor>(detalhesItem[i].Name).Text = detalhesItem[i].Text;
                            }
                        }
                    }
                }
                this.CarregaPictures();

            }
            else
            {
                this.editado = 'S';
            }
        }
        public void PickerSimpleChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            Picker pick = (Picker)sender;
            List<ComboBox> items = (List<ComboBox>)sender.GetType().GetProperty("ItemsSource").GetValue(sender, null);
            manipulacao.ChangePicker(sender, pick, items);
        }
        public void PickerNotaChanged(object sender, EventArgs e)
        {
            this.ChangeForSave();
            Picker pick = (Picker)sender;
            List<ComboBox> items = (List<ComboBox>)sender.GetType().GetProperty("ItemsSource").GetValue(sender, null);
            manipulacao.ChangePicker(sender, pick, items);
            this.CalculaNotaFinal();
        }
        public void ChangeForSave()
        {
            this.editado = 'S';
            buttonAddSave.Text = "Salvar";
            buttonAddSave.Image = "arrow20.png";

        }


        public void OpaCliclouNaFoto(object sender, EventArgs e)
        {
            var imageSource = (StreamImageSource)sender.GetType().GetProperty("Source").GetValue(sender, null);
            Navigation.PushAsync(new ImagemFull(imageSource));
        }
        public void AdicionarFoto(Grid grid)
        {
            var index = grid.Children.Count;
            var colum = grid.ColumnDefinitions.Count;
            var row = grid.RowDefinitions.Count;
            var multiplicacao = colum * row;

            if (multiplicacao > index)
            {
                row = index / colum;
                colum = index % colum;

            }
            else
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = 150 });
                colum = 0;
            }

            var image = new Image { Source = "", HeightRequest = 100 };

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += this.OpaCliclouNaFoto;
            image.GestureRecognizers.Add(tap);
            this.CameraButton_Clicked(image, grid, colum, row);

        }
        public void AdicionarFotoBoiler(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosBoiler);
            this.ChangeForSave();
        }
        public void RemoverUltimaFotoBoiler(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosBoiler);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            }
        }
        public void AdicionarFotoAquePass(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosAquePass);
            this.ChangeForSave();
        }
        public void RemoverUltimaFotoAquePass(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosAquePass);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            }
        }
        public void AdicionarFotoBombaCalor(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosBombaCalor);
            this.ChangeForSave();
        }
        public void RemoverUltimaFotoBombaCalor(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosBombaCalor);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            }
        }
        public void AdicionarFotoPlacaSolar(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosPlacaSolar);
            this.ChangeForSave();
        }
        public void RemoverUltimaFotoPlacaSolar(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosPlacaSolar);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            }
        }
        public void AdicionarFotoBomba(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosBomba);
            this.ChangeForSave();
        }
        public void RemoverUltimaFotoBomba(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosBomba);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            }
        }
        public void AdicionarFotoBfe(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosBfe);
            this.ChangeForSave();
        }
        public void RemoverUltimaFotoBfe(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosBfe);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            }
        }
        public void AdicionarFotoTub(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosTub);
            this.ChangeForSave();
        }
        public void RemoverUltimaFotoTub(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosTub);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            }
        }
        public void AdicionarFotoReg(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosReg);
            this.ChangeForSave();
        }
        public void RemoverUltimaFotoReg(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosReg);
            if (this.FotosItem.Count > 0)
            {
                Puma.ModelosBanco.FotosItem foto = this.FotosItem[this.FotosItem.Count - 1];
                this.FotosItem.RemoveAt(this.FotosItem.Count - 1);
                this.DeleteFotosItem.Add(foto);
                this.ChangeForSave();
            }
        }
        public async void CameraButton_Clicked(Image image, Grid grid, int colum, int row)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported && !CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Alerta!", "Captura e seleção de foto não suportada", "ok");
            }
            else
            {
                StoreCameraMediaOptions store = new StoreCameraMediaOptions
                {
                    Directory = "Images",
                    Name = DateTime.Now + "_.jpg"
                };

                var file = await CrossMedia.Current.TakePhotoAsync(store);
                if (file == null)
                    return;
                //await DisplayAlert("File Path", file.Path, "Ok");
                image.Source = ImageSource.FromStream(() => { return file.GetStream(); });
                grid.Children.Add(image, colum, row);

                var stream = file.GetStream();
                var bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                string base64 = System.Convert.ToBase64String(bytes);
                Puma.ModelosBanco.FotosItem foto = new Puma.ModelosBanco.FotosItem();
                foto.Idrelatorio = this.itemSubItem.RelatoriosId;
                foto.Idsetor = this.itemSubItem.Idsetor;
                foto.Idsubitem = this.itemSubItem.Idsubitem;
                foto.Iditemsubitem = this.itemSubItem.Id;
                if (grid == GridFotosBoiler)
                {
                    foto.Name = "GridFotosBoiler";
                }
                if (grid == GridFotosAquePass)
                {
                    foto.Name = "GridFotosAquePass";
                }
                if (grid == GridFotosBombaCalor)
                {
                    foto.Name = "GridFotosBombaCalor";
                }
                if (grid == GridFotosPlacaSolar)
                {
                    foto.Name = "GridFotosPlacaSolar";
                }
                if (grid == GridFotosBomba)
                {
                    foto.Name = "GridFotosBomba";
                }
                if (grid == GridFotosBfe)
                {
                    foto.Name = "GridFotosBfe";
                }
                if (grid == GridFotosTub)
                {
                    foto.Name = "GridFotosTub";
                }
                if (grid == GridFotosReg)
                {
                    foto.Name = "GridFotosReg";
                }

                foto.Base64 = base64;
                this.FotosItem.Add(foto);
            }

        }
        public void PressSaveAdd(EventHandler press)
        {
            if (this.editado == 'S')
            {
                //Salvar

                this.Save();
                buttonAddSave.Text = "Adicionar";
                buttonAddSave.Image = "plusIcon30.png";
                this.editado = 'N';
            }
            else
            {
                Puma.ModelosBanco.ItemSubItem subItem = new Puma.ModelosBanco.ItemSubItem();
                subItem.RelatoriosId = this.itemSubItem.RelatoriosId;
                subItem.Idsetor = this.itemSubItem.Idsetor;
                subItem.Idsubitem = this.itemSubItem.Idsubitem;
                subItem.Contador = this.itemSubItem.Contador + 1;

                Puma.ModelosBanco.Subitemsetor subSetor = new Puma.ModelosBanco.Subitemsetor();
                subSetor = database.GetSubItemSetor(subItem.RelatoriosId, subItem.Idsetor, subItem.Idsubitem);
                if (subSetor != null)
                {
                    subSetor.Quantidade = subItem.Contador;
                    database.UpdateeSubItemSetor(subSetor);
                }

                ContentPage geradorAguaQuente = new HidraGeradorAguaQuente(this.carousel, subItem, database);
                this.database.CreateItemSubItem(subItem);
                this.carousel.Children.Add(geradorAguaQuente);
                this.carousel.CurrentPage = geradorAguaQuente;
            }

        }
        public void CarregaPictures()
        {
            this.FotosItem = database.GetFotosItems(this.itemSubItem);

            for (var i = 0; i < this.FotosItem.Count; i++)
            {
                Grid grid = (Grid)this.FindByName<Grid>(this.FotosItem[i].Name);
                this.AdicionarFotoCarregada(grid, FotosItem[i].Base64);
            }
        }
        public void AdicionarFotoCarregada(Grid grid, string base64)
        {
            var index = grid.Children.Count;
            var colum = grid.ColumnDefinitions.Count;
            var row = grid.RowDefinitions.Count;
            var multiplicacao = colum * row;

            if (multiplicacao > index)
            {
                row = index / colum;
                colum = index % colum;

            }
            else
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = 150 });
                colum = 0;
            }

            var image = new Image { Source = "", HeightRequest = 100 };

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += this.OpaCliclouNaFoto;
            image.GestureRecognizers.Add(tap);

            byte[] Base64Stream = Convert.FromBase64String(base64);
            image.Source = ImageSource.FromStream(() => new System.IO.MemoryStream(Base64Stream));

            grid.Children.Add(image, colum, row);

        }
        public void SavePictures()
        {
            for (var i = 0; i < FotosItem.Count; i++)
            {

                if (database.GetFotoItem(FotosItem[i]) == null)
                {
                    //create
                    database.CreateFotosItem(FotosItem[i]);
                }
            }
            for (var o = 0; o < DeleteFotosItem.Count; o++)
            {
                database.DeleteFotosItem(DeleteFotosItem[o]);
            }
        }
        public void Save()
        {
            this.SavePictures();
            if (detalhesItem.Count != 0)
            {
                for (var i = 0; i < detalhesItem.Count; i++)
                {
                    if (detalhesItem[i].Tipo == "Picker")
                    {
                        //this.FindByName<Picker>(detalhesItem[i].Name).SelectedIndex = detalhesItem[i].Index;
                        detalhesItem[i].Index = this.FindByName<Picker>(detalhesItem[i].Name).SelectedIndex;
                    }
                    else
                    {
                        if (detalhesItem[i].Tipo == "Entry")
                        {
                            detalhesItem[i].Text = this.FindByName<Entry>(detalhesItem[i].Name).Text;
                        }
                        else
                        {
                            if (detalhesItem[i].Tipo == "Editor")
                            {
                                detalhesItem[i].Text = this.FindByName<Editor>(detalhesItem[i].Name).Text;
                            }
                            else
                            {
                                if (detalhesItem[i].Tipo == "Label")
                                {
                                    detalhesItem[i].Text = this.FindByName<Label>(detalhesItem[i].Name).Text;
                                }

                            }
                        }
                    }

                    database.UpdateDetalheItem(detalhesItem[i]);
                }

            }
            else
            {
                //create
                Puma.ModelosBanco.DetalhesItem detalhe = null;

                //1
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNomenclatura, "PickerNomenclatura");
                database.CreateDetalheItem(detalhe);
                //2
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerSistema, "PickerSistema");
                database.CreateDetalheItem(detalhe);
                //3
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerAlimentacao, "PickerAlimentacao");
                database.CreateDetalheItem(detalhe);
                //4
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerAuditado, "PickerAuditado");
                database.CreateDetalheItem(detalhe);
                //5
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerPlanejado, "PickerPlanejado");
                database.CreateDetalheItem(detalhe);
                //6
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerExecutado, "PickerExecutado");
                database.CreateDetalheItem(detalhe);
                //7
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerApontamentos, "PickerApontamentos");
                database.CreateDetalheItem(detalhe);
                //--- 1 ° Nivel ---
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBoilerMaterial, "PickerBoilerMaterial");
                database.CreateDetalheItem(detalhe);
                //9
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBoilerIsolTermico, "PickerBoilerIsolTermico");
                database.CreateDetalheItem(detalhe);
                //10
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBoilerIsolMecanico, "PickerBoilerIsolMecanico");
                database.CreateDetalheItem(detalhe);
                //11
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBoilerPortaInspecao, "PickerBoilerPortaInspecao");
                database.CreateDetalheItem(detalhe);
                //12
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBoilerTermDigital, "PickerBoilerTermDigital");
                database.CreateDetalheItem(detalhe);
                //13
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBoilerTerAnalogico, "PickerBoilerTerAnalogico");
                database.CreateDetalheItem(detalhe);
                //14
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBoilerValvulaAlivio, "PickerBoilerValvulaAlivio");
                database.CreateDetalheItem(detalhe);
                //15
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBoilerStatusGeral, "PickerBoilerStatusGeral");
                database.CreateDetalheItem(detalhe);
                //16
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNotaBoiler, "PickerNotaBoiler");
                database.CreateDetalheItem(detalhe);
                //17--- 2° Nivel ----
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerAquePassInstalacao, "PickerAquePassInstalacao");
                database.CreateDetalheItem(detalhe);
                //18
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerAquePassAcabamento, "PickerAquePassAcabamento");
                database.CreateDetalheItem(detalhe);
                //19
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerAquePassDetectorGas, "PickerAquePassDetectorGas");
                database.CreateDetalheItem(detalhe);
                //20
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerAquePassFixacao, "PickerAquePassFixacao");
                database.CreateDetalheItem(detalhe);
                //21
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerFotoAqueNota, "PickerFotoAqueNota");
                database.CreateDetalheItem(detalhe);
                //22---- 3° Nivell------
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBombaCalorInstalcao, "PickerBombaCalorInstalcao");
                database.CreateDetalheItem(detalhe);
                //23
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBombaCalorAcabamento, "PickerBombaCalorAcabamento");
                database.CreateDetalheItem(detalhe);
                //24
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBombaCalorVazamento, "PickerBombaCalorVazamento");
                database.CreateDetalheItem(detalhe);
                //25
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBombaCalorNota, "PickerBombaCalorNota");
                database.CreateDetalheItem(detalhe);
                //26=== 4° Nivel -----
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerPlacaSolarPlacas, "PickerPlacaSolarPlacas");
                database.CreateDetalheItem(detalhe);
                //27
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerPlacaSolarTubulacao, "PickerPlacaSolarTubulacao");
                database.CreateDetalheItem(detalhe);

                //28
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerPlacaSolarFixacao, "PickerPlacaSolarFixacao");
                database.CreateDetalheItem(detalhe);

                //29
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerPlacaSolarNota, "PickerPlacaSolarNota");
                database.CreateDetalheItem(detalhe);

                //30--- 5° Nivel --
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBombaRolamentos, "PickerBombaRolamentos");
                database.CreateDetalheItem(detalhe);

                //31
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBombaAcoplamento, "PickerBombaAcoplamento");
                database.CreateDetalheItem(detalhe);

                //32
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBombaSeloMecanico, "PickerBombaSeloMecanico");
                database.CreateDetalheItem(detalhe);

                //33
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBombaAquecimento, "PickerBombaAquecimento");
                database.CreateDetalheItem(detalhe);

                //34
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBombaPintura, "PickerBombaPintura");
                database.CreateDetalheItem(detalhe);

                //35
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBombaStatusGeral, "PickerBombaStatusGeral");
                database.CreateDetalheItem(detalhe);

                //36
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerPlacaSolarTubulacao, "PickerNotaBomba");
                database.CreateDetalheItem(detalhe);

                //37-- 6° Nivel ---
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBfeFixacao, "PickerBfeFixacao");
                database.CreateDetalheItem(detalhe);

                //38
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBfeVibStop, "PickerBfeVibStop");
                database.CreateDetalheItem(detalhe);

                //39
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBfeInstaEletrica, "PickerBfeInstaEletrica");
                database.CreateDetalheItem(detalhe);

                //40
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerBfeStatusGeral, "PickerBfeStatusGeral");
                database.CreateDetalheItem(detalhe);

                //41
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNotaBfe, "PickerNotaBfe");
                database.CreateDetalheItem(detalhe);

                //42-- 7° Nivel ---
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerTubMaterial, "PickerTubMaterial");
                database.CreateDetalheItem(detalhe);

                //43
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerTubAcabamento, "PickerTubAcabamento");
                database.CreateDetalheItem(detalhe);

                //44
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerTubVazamento, "PickerTubVazamento");
                database.CreateDetalheItem(detalhe);

                //45
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerTubFixacao, "PickerTubFixacao");
                database.CreateDetalheItem(detalhe);

                //46
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNotaTub, "PickerNotaTub");
                database.CreateDetalheItem(detalhe);

                //47 -- 8° Nivel --
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerRegInstalacao, "PickerRegInstalacao");
                database.CreateDetalheItem(detalhe);

                //48
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerRegAcabamento, "PickerRegAcabamento");
                database.CreateDetalheItem(detalhe);
                //49
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerRegFixacao, "PickerRegFixacao");
                database.CreateDetalheItem(detalhe);

                //50
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNotaReg, "PickerNotaReg");
                database.CreateDetalheItem(detalhe);

                //51 -- Fim Nivel de Risco --
                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                detalhe = manipulacao.GeraModeloPicker(detalhe, PickerNivelRisco, "PickerNivelRisco");
                database.CreateDetalheItem(detalhe);

                /// Entry

                //detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                //manipulacao.GeraModeloEntry(detalhe, EntryLocalizacao, "EntryLocalizacao");
                //database.CreateDetalheItem(detalhe);


                //Editor

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioBoiler, "EditorComentarioBoiler");
                database.CreateDetalheItem(detalhe);

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioAquePass, "EditorComentarioAquePass");
                database.CreateDetalheItem(detalhe);

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioBombaCalor, "EditorComentarioBombaCalor");
                database.CreateDetalheItem(detalhe);

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioPlacaSolar, "EditorComentarioPlacaSolar");
                database.CreateDetalheItem(detalhe);

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioBomba, "EditorComentarioBomba");
                database.CreateDetalheItem(detalhe);

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioBfe, "EditorComentarioBfe");
                database.CreateDetalheItem(detalhe);

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioTub, "EditorComentarioTub");
                database.CreateDetalheItem(detalhe);

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloEditor(detalhe, EditorComentarioReg, "EditorComentarioReg");
                database.CreateDetalheItem(detalhe);

                //LabelNotaFiscal

                detalhe = this.manipulacao.CretaeBaseDetalhe(this.itemSubItem);
                manipulacao.GeraModeloLabel(detalhe, txtNotaFinal, "txtNotaFinal");
                database.CreateDetalheItem(detalhe);


            }
        }
        public void CalculaNotaFinal()
        {
            List<ClassePicker> listaPicker = new List<ClassePicker>();
            int soma = 0;
            int quantidade = 0;
            int valorFinal = 0;

            listaPicker.Add(new ClassePicker(PickerNotaBoiler, 1));
            listaPicker.Add(new ClassePicker(PickerFotoAqueNota, 2));
            listaPicker.Add(new ClassePicker(PickerBombaCalorNota, 3));
            listaPicker.Add(new ClassePicker(PickerPlacaSolarNota, 4));
            listaPicker.Add(new ClassePicker(PickerNotaBomba, 5));
            listaPicker.Add(new ClassePicker(PickerNotaBfe, 6));
            listaPicker.Add(new ClassePicker(PickerNotaTub, 7));
            listaPicker.Add(new ClassePicker(PickerNotaReg, 8));

            for (var i = 0; i < listaPicker.Count; i++)
            {
                //Picker pick = listaPicker[i].picker;
                //(List<ComboBox>)sender.GetType().GetProperty("ItemsSource").GetValue(sender, null);
                List<ComboBox> items = (List<ComboBox>)listaPicker[i].picker.GetType().GetProperty("ItemsSource").GetValue(listaPicker[i].picker, null);
                try
                {

                    switch (items[listaPicker[i].picker.SelectedIndex].Id)
                    {
                        case 1:
                            listaPicker[i].nota = 35;
                            break;
                        case 2:
                            listaPicker[i].nota = 75;
                            break;
                        case 3:
                            listaPicker[i].nota = 100;
                            break;
                    }

                }
                catch (ArgumentOutOfRangeException e)
                {
                    listaPicker[i].nota = 0;
                }
                soma = soma + listaPicker[i].nota;
                quantidade = quantidade + 1;
            }
            if (quantidade > 0)
            {
                valorFinal = soma / quantidade;
            }
            string stringfinal = valorFinal.ToString() + "%";
            var Color = new Color();

            if (valorFinal < 75)
            {
                Color = Color.FromHex("#FF0000");
                txtNotaFinal.TextColor = Color;
            }
            else
            {
                if (valorFinal == 100)
                {
                    Color = Color.FromHex("#008000");
                    txtNotaFinal.TextColor = Color;
                }
                else
                {
                    Color = Color.FromHex("#FF9933");
                    txtNotaFinal.TextColor = Color;
                }
            }
            txtNotaFinal.Text = stringfinal;

        }
    }

}