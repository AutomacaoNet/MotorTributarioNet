namespace MotorTributarioNet.Impostos
{
    public interface IResultadoCalculoDifal
    {
        decimal BaseCalculo { get; }
        decimal Fcp { get; }
        decimal ValorIcmsDestino { get; }
        decimal ValorIcmsOrigem { get; }
        decimal Difal { get; }
    }
}