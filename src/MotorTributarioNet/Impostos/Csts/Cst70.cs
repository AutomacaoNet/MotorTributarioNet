using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos.Csts
{
    public class Cst70 : Cst10
    {
        
        public decimal PercentualReducao { get; private set; }

        public Cst70(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional) : base(origemMercadoria, tipoDesconto)
        {
            Cst = Cst.Cst70;
            ModalidadeDeterminacaoBcIcms = ModalidadeDeterminacaoBcIcms.ValorOperacao;
        }

        public override void Calcula(ITributavel tributavel)
        {
            base.Calcula(tributavel);
            PercentualReducao = tributavel.PercentualReducao;
        }

    }
}
