namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class ResultadoCalculoDifal : IResultadoCalculoDifal
    {
        public decimal BaseCalculo { get; }
        public decimal Fcp { get; }
        public decimal ValorIcmsDestino { get; }
        public decimal ValorIcmsOrigem { get; }
        public decimal Difal { get; }
        public string Observacao => GetObservacao();

        public ResultadoCalculoDifal(decimal baseCalculo, decimal difal, decimal fcp, decimal valorIcmsDestino, decimal valorIcmsOrigem)
        {
            BaseCalculo = baseCalculo;
            Difal = difal;
            Fcp = fcp;
            ValorIcmsDestino = valorIcmsDestino;
            ValorIcmsOrigem = valorIcmsOrigem;
        }

        private string GetObservacao()
        {
            return $"Valores totais do ICMS interstadual: DIFAL da UF destino {ValorIcmsDestino} + FCP {Fcp}; DIFAL da UF Origem {ValorIcmsOrigem}";
        }
    }
}