namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class ResultadoCalculoCredito : IResultadoCalculoCredito
    {
        public ResultadoCalculoCredito(decimal baseCalculo, decimal valor)
        {
            BaseCalculo = baseCalculo;
            Valor = valor;
        }

        public decimal BaseCalculo { get; }
        public decimal Valor { get; }
    }
}