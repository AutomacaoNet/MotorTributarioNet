namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class DadosMensagemDifal : IDadosMensagemDifal
    {
        public decimal Fcp { get; }
        public decimal ValorIcmsDestino { get; }
        public decimal ValorIcmsOrigem { get; }

        public DadosMensagemDifal(decimal fcp, decimal valorIcmsDestino, decimal valorIcmsOrigem)
        {
            Fcp = fcp;
            ValorIcmsDestino = valorIcmsDestino;
            ValorIcmsOrigem = valorIcmsOrigem;
        }
    }
}