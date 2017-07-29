using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos.Csosns
{
    public class Csosn201 : Csosn101
    {
        public Csosn201(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional) : base(origemMercadoria)
        {
            Csosn = Csosn.Csosn201;
            ModalidadeDeterminacaoBcIcmsSt = ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado;
        }

        public ModalidadeDeterminacaoBcIcmsSt ModalidadeDeterminacaoBcIcmsSt { get; set; }
        public decimal PercentualMva { get; private set; }
        public decimal PercentualReducaoSt { get; private set; }
        public decimal ValorBcIcmsSt { get; private set; }
        public decimal PercentualIcmsSt { get; private set; }
        public decimal ValorIcmsSt { get; private set; }


        public override void Calcula(ITributavel tributavel)
        {
            base.Calcula(tributavel);

            PercentualMva = tributavel.PercentualMva;
            PercentualReducaoSt = tributavel.PercentualReducaoSt;
            PercentualIcmsSt = tributavel.PercentualIcmsSt;

            var facade = new FacadeCalculadoraTributacao(tributavel);

            tributavel.ValorIpi = facade.CalculaIpi().Valor;

            var resultadoCalculoCofins = facade.CalculaIcmsSt();

            ValorBcIcmsSt = resultadoCalculoCofins.BaseCalculoIcmsSt;
            ValorIcmsSt = resultadoCalculoCofins.ValorIcmsSt;
        }
    }
}