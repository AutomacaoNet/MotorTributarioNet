using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos.Csosns
{
    public class Csosn203 : Csosn202
    {
        public Csosn203(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional) : base(origemMercadoria)
        {
            Csosn = Csosn.Csosn203;
        }
    }
}