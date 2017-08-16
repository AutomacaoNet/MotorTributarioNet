using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csts.Base;

namespace MotorTributarioNet.Impostos.Csts
{
    public class Cst40 : CstBase
    {
        public MotivoDesoneracao MotivoDesoneracao { get; set; }
        public decimal ValorIcmsDesonerado { get; set; }

        public Cst40(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional) : base(origemMercadoria, tipoDesconto)
        {
            Cst = Cst.Cst40;
        }

    }
}
