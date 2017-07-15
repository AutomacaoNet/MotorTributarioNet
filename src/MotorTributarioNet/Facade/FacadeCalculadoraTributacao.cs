using MotorTributarioNet.Impostos;
using MotorTributarioNet.Impostos.Csosns.Componentes;

namespace MotorTributarioNet.Facade
{
    public class FacadeCalculadoraTributacao
    {
        public static IResultadoCalculoIcms ProcessamentoDeIcms(TributacaoIcms tributacaoIcms)
        {
            return tributacaoIcms.Calcula();
        }
    }
}