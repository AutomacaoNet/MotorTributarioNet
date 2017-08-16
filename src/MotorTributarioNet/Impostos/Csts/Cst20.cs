using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos.Csts
{
    public class Cst20 : Cst00
    {
        public decimal PercentualReducao { get; private set; }

        public Cst20(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional) : base(origemMercadoria, tipoDesconto)
        {
            Cst = Cst.Cst20;
        }

        public override void Calcula(ITributavel tributavel)
        {
            base.Calcula(tributavel);
            PercentualReducao = tributavel.PercentualReducao;
        }
    }
}
