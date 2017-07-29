using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns.Base;

namespace MotorTributarioNet.Impostos.Csosns
{
    public class Csosn900 : CsosnBase
    {
        public Csosn900(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional) : base(origemMercadoria)
        {
            Csosn = Csosn.Csosn900;
            ModalidadeDeterminacaoBcIcmsSt = ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado;
            ModalidadeDeterminacaoBcIcms = ModalidadeDeterminacaoBcIcms.MargemValorAgregado;
        }

        public ModalidadeDeterminacaoBcIcms ModalidadeDeterminacaoBcIcms { get; set; }

        public decimal ValorBcIcms { get; private set; }

        public decimal PercentualReducaoIcmsBc { get; private set; }

        public decimal PercentualIcms { get; set; }

        public decimal ValorIcms { get; set; }

        public ModalidadeDeterminacaoBcIcmsSt ModalidadeDeterminacaoBcIcmsSt { get; set; }

        public decimal PercentualMva { get; private set; }

        public decimal PercentualReducaoSt { get; private set; }

        public decimal ValorBcIcmsSt { get; private set; }

        public decimal PercentualIcmsSt { get; private set; }

        public decimal ValorIcmsSt { get; private set; }

        public decimal PercentualCredito { get; private set; }

        public decimal ValorCredito { get; private set; }

        public override void Calcula(ITributavel tributavel)
        {
            CalculaIcms(tributavel);

            CalculaIcmsSt(tributavel);

            CalculaCredito(tributavel);
        }

        private void CalculaCredito(ITributavel tributavel)
        {
            PercentualCredito = tributavel.PercentualCredito;

            var facade = new FacadeCalculadoraTributacao(tributavel);
            var resultadoCalculaCredito = facade.CalculaIcmsCredito();
            ValorCredito = resultadoCalculaCredito.Valor;
        }

        private void CalculaIcmsSt(ITributavel tributavel)
        {
            PercentualMva = tributavel.PercentualMva;
            PercentualReducaoSt = tributavel.PercentualReducaoSt;
            PercentualIcmsSt = tributavel.PercentualIcmsSt;

            var facade = new FacadeCalculadoraTributacao(tributavel);

            tributavel.ValorIpi = facade.CalculaIpi().Valor;

            var resultadoCalculoIcmsSt = facade.CalculaIcmsSt();

            ValorBcIcmsSt = resultadoCalculoIcmsSt.BaseCalculoIcmsSt;
            ValorIcmsSt = resultadoCalculoIcmsSt.ValorIcmsSt;
        }

        private void CalculaIcms(ITributavel tributavel)
        {
            PercentualReducaoIcmsBc = tributavel.PercentualReducao;
            PercentualIcms = tributavel.PercentualIcms;

            var facade = new FacadeCalculadoraTributacao(tributavel);

            tributavel.ValorIpi = facade.CalculaIpi().Valor;

            var resultadoCalculoIcms = facade.CalculaIcms();
            ValorBcIcms = resultadoCalculoIcms.BaseCalculo;
            ValorIcms = resultadoCalculoIcms.Valor;
        }
    }
}