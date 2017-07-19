namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class ResultadoCalculoIcmsSt : IResultadoCalculoIcmsSt
    {
        public decimal BaseCalculoOperacaoPropria { get; }
        public decimal ValorIcmsProprio { get; }
        public decimal BaseCalculoIcmsSt { get; }
        public decimal ValorIcmsSt { get; }

        public ResultadoCalculoIcmsSt(decimal baseCalculoOperacaoPropria, decimal valorIcmsProprio, decimal baseCalculoIcmsSt, decimal valorIcmsSt)
        {
            BaseCalculoOperacaoPropria = baseCalculoOperacaoPropria;
            ValorIcmsProprio = valorIcmsProprio;
            BaseCalculoIcmsSt = baseCalculoIcmsSt;
            ValorIcmsSt = valorIcmsSt;
        }
    }
}