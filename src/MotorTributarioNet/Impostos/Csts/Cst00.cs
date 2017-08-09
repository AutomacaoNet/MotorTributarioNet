using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csts.Base;

namespace MotorTributarioNet.Impostos.Csts
{
    public class Cst00 : CstBase
    {
        public ModalidadeDeterminacaoBcIcms ModalidadeDeterminacaoBcIcms { get; set; }
        public decimal ValorBCIcms { get; private set; }
        public decimal PercentualIcms { get; private set; }
        public decimal ValorIcms { get; set; }

        public Cst00(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional) : base(origemMercadoria)
        {
            Cst = Cst.Cst00;
            ModalidadeDeterminacaoBcIcms = ModalidadeDeterminacaoBcIcms.ValorOperacao;
        }

        public override void Calcula(ITributavel tributavel)
        {
            var result = new FacadeCalculadoraTributacao(tributavel).CalculaIcms();
            ValorBCIcms = result.BaseCalculo;
            PercentualIcms = tributavel.PercentualIcms;
            ValorIcms = result.Valor;
        }

    }
}
