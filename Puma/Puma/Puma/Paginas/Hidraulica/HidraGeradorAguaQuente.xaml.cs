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
        private CarouselPage carousel = null;
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
        public HidraGeradorAguaQuente(CarouselPage carousel)
        {
            InitializeComponent();
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
        }
        public void RemoverUltimaFotoBoiler(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosBoiler);
        }
        public void AdicionarFotoAquePass(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosAquePass);
        }
        public void RemoverUltimaFotoAquePass(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosAquePass);
        }
        public void AdicionarFotoBombaCalor(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosBombaCalor);
        }
        public void RemoverUltimaFotoBombaCalor(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosBombaCalor);
        }
        public void AdicionarFotoPlacaSolar(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosPlacaSolar);
        }
        public void RemoverUltimaFotoPlacaSolar(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosPlacaSolar);
        }
        public void AdicionarFotoBomba(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosBomba);
        }
        public void RemoverUltimaFotoBomba(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosBomba);
        }
        public void AdicionarFotoBfe(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosBfe);
        }
        public void RemoverUltimaFotoBfe(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosBfe);
        }
        public void AdicionarFotoTub(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosTub);
        }
        public void RemoverUltimaFotoTub(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosTub);
        }
        public void AdicionarFotoReg(object sender, EventArgs e)
        {
            this.AdicionarFoto(GridFotosReg);
        }
        public void RemoverUltimaFotoReg(object sender, EventArgs e)
        {
            manipulacao.RemovePicture(GridFotosReg);
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
                ContentPage barrilete = new HidraBarrilhete(this.carousel);
                this.carousel.Children.Add(barrilete);
                this.carousel.CurrentPage = barrilete;
            }

        }
        public void Save() { }
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