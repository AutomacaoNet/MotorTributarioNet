namespace MotorTributarioNet.Impostos
{
    public interface IResultadoCalculoIcmsSt
    {
        decimal BaseCalculoOperacaoPropria { get; }
        decimal ValorIcmsProprio { get; }
        decimal BaseCalculoIcmsSt { get; }
        decimal ValorIcmsSt { get; }
    }
}