namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class ResultadoCalculoFcp : IResultadoCalculoFcp
    {
        public ResultadoCalculoFcp(decimal baseCalculo, decimal fcp)
        {
            BaseCalculo = baseCalculo;
            Valor = fcp;
        }

        public decimal BaseCalculo { get; }
        public decimal Valor { get; }
    }
}
