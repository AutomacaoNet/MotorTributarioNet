namespace MotorTributarioNet.Impostos
{
    public interface IResultadoCalculoIcms
    {
        decimal BaseCalculo { get; }
        decimal Valor { get; }
    }
}