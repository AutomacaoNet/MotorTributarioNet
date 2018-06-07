namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class ResultadoCalculoFcpSt : IResultadoCalculoFcpSt
    {
        public ResultadoCalculoFcpSt(decimal baseCalculoFcpSt, decimal valorFcpSt)
        {
            BaseCalculoFcpSt = baseCalculoFcpSt;
            ValorFcpSt = valorFcpSt;
        }

        public decimal BaseCalculoFcpSt { get; }
        public decimal ValorFcpSt { get; }
    }
}
