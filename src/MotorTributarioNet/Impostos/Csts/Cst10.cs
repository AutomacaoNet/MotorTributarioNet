using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos.Csts
{
    public class Cst10 : Cst00
    {
        public ModalidadeDeterminacaoBcIcmsSt ModalidadeDeterminacaoBcIcmsSt { get; set; }

        public decimal PercentualMva { get; private set; }
        public decimal PercentualReducaoSt { get; private set; }
        public decimal ValorBcIcmsSt { get; private set; }
        public decimal PercentualIcmsSt { get; private set; }
        public decimal ValorIcmsSt { get; private set; }

        public Cst10(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional) : base(origemMercadoria, tipoDesconto)
        {
            Cst = Cst.Cst10;
            ModalidadeDeterminacaoBcIcmsSt = ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado;
        }

        public override void Calcula(ITributavel tributavel)
        {
            base.Calcula(tributavel);

            PercentualMva = tributavel.PercentualMva;
            PercentualReducaoSt = tributavel.PercentualReducaoSt;
            PercentualIcmsSt = tributavel.PercentualIcmsSt;

            var facade = new FacadeCalculadoraTributacao(tributavel, TipoDesconto);

            tributavel.ValorIpi = facade.CalculaIpi().Valor;

            var resultadoCalculoCofins = facade.CalculaIcmsSt();

            ValorBcIcmsSt = resultadoCalculoCofins.BaseCalculoIcmsSt;
            ValorIcmsSt = resultadoCalculoCofins.ValorIcmsSt;

        }
    }
}
