using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos.CalulosDeBC
{
    public class CalculaBaseFcp : CalculaBaseCalculoIcms
    {
        public CalculaBaseFcp(ITributavel tributavel, TipoDesconto tipoDesconto) : base(tributavel, tipoDesconto)
        {
        }
    }
}
