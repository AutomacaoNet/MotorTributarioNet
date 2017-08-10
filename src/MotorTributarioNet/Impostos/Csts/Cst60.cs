using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csts.Base;

namespace MotorTributarioNet.Impostos.Csts
{
    public class Cst60 : CstBase
    {
        public decimal PercentualBcStRetido { get; set; }
        public decimal ValorBcStRetido { get; set; }

        public Cst60(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional) : base(origemMercadoria, tipoDesconto)
        {
            Cst = Cst.Cst60;
        }

        
    }
}
