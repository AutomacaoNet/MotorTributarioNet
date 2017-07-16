using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos;
using MotorTributarioNet.Impostos.Csosns.Componentes;

namespace MotorTributarioNet.Facade
{
    public static class FacadeCalculadoraTributacao
    {
        public static IResultadoCalculoIcms CalculaIcms(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            return new TributacaoIcms(tributavel, tipoDesconto).Calcula();
        }
    }
}