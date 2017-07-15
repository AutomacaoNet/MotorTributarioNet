using MotorTributarioNet.Impostos.Csosns.Componentes;

namespace MotorTributarioNet.Facade
{
    public class FacadeCalculadoraTributacao
    {
        public static void ProcessamentoDeIcms(TributacaoIcms tributacaoIcms)
        {
            tributacaoIcms.Calcula();
        }
    }
}