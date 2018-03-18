namespace MotorTributarioNet.Impostos
{
    public interface IResultadoCalculoFcp
    {
        decimal BaseCalculo { get; }
        decimal Valor { get; }
    }
}
