namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class ResultadoCalculoIpi : IResultadoCalculoIpi
    {
        public ResultadoCalculoIpi(decimal baseCalculo, decimal valor)
        {
            BaseCalculo = baseCalculo;
            Valor = valor;
        }

        public decimal BaseCalculo { get; }
        public decimal Valor { get; }
    }
}