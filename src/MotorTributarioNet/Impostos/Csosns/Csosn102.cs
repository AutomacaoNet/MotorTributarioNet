using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns.Base;

namespace MotorTributarioNet.Impostos.Csosns
{
    public class Csosn102 : CsosnBase
    {
        public Csosn102(OrigemMercadoria origemMercadoria) : base(origemMercadoria)
        {
            Csosn = Csosn.Csosn102;
        }
    }
}