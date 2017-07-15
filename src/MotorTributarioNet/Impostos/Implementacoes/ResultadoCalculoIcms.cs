namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class ResultadoCalculoIcms : IResultadoCalculoIcms
    {
        public ResultadoCalculoIcms(decimal baseCalculo, decimal valor)
        {
            BaseCalculo = baseCalculo;
            Valor = valor;
        }

        public decimal BaseCalculo { get; }
        public decimal Valor { get; }
    }
}