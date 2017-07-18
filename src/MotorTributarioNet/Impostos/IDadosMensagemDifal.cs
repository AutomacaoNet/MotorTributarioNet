namespace MotorTributarioNet.Impostos
{
    public interface IDadosMensagemDifal
    {
        decimal Fcp { get; }
        decimal ValorIcmsDestino { get; }
        decimal ValorIcmsOrigem { get; }
    }
}