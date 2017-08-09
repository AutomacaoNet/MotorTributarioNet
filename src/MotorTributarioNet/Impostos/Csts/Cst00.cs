using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csts.Base;

namespace MotorTributarioNet.Impostos.Csts
{
    public class Cst00 : CstBase
    {
        public ModalidadeDeterminacaoBcIcms ModalidadeDeterminacaoBcIcms { get; set; }
        public decimal ValorBcIcms { get; private set; }
        public decimal PercentualIcms { get; private set; }
        public decimal ValorIcms { get; private set; }

        public Cst00(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional) : base(origemMercadoria, tipoDesconto)
        {
            Cst = Cst.Cst00;
            ModalidadeDeterminacaoBcIcms = ModalidadeDeterminacaoBcIcms.ValorOperacao;
        }

        public override void Calcula(ITributavel tributavel)
        {
            var result = new FacadeCalculadoraTributacao(tributavel,TipoDesconto).CalculaIcms();
            ValorBcIcms = result.BaseCalculo;
            PercentualIcms = tributavel.PercentualIcms;
            ValorIcms = result.Valor;
        }

    }
}
