namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class ResultadoCalculoCofins : IResultadoCalculoCofins
    {
        public ResultadoCalculoCofins(decimal baseCalculo, decimal valor)
        {
            BaseCalculo = baseCalculo;
            Valor = valor;
        }

        public decimal BaseCalculo { get; }
        public decimal Valor { get; }
    }
}