namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class ResultadoCalculoDifal : IResultadoCalculoDifal
    {
        public decimal BaseCalculo { get; }
        public decimal Fcp { get; }
        public decimal ValorIcmsDestino { get; }
        public decimal ValorIcmsOrigem { get; }
        public decimal Difal { get; }

        public ResultadoCalculoDifal(decimal baseCalculo, decimal difal, decimal fcp, decimal valorIcmsDestino, decimal valorIcmsOrigem)
        {
            BaseCalculo = baseCalculo;
            Difal = difal;
            Fcp = fcp;
            ValorIcmsDestino = valorIcmsDestino;
            ValorIcmsOrigem = valorIcmsOrigem;
        }

        public string GetObservacao(IDadosMensagemDifal dadosMensagemDifal)
        {
            return $"Valores totais do ICMS interstadual: DIFAL da UF destino {dadosMensagemDifal.ValorIcmsDestino} + FCP {dadosMensagemDifal.Fcp}; DIFAL da UF Origem {dadosMensagemDifal.ValorIcmsOrigem}";
        }
    }
}