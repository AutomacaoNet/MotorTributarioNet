namespace MotorTributarioNet.Impostos
{
    public interface IResultadoCalculoIbpt
    {
        decimal TributacaoFederal { get; set; }
        decimal TributacaoFederalImportados { get; set; }
        decimal BaseCalculo { get; set; }
        decimal TributacaoEstadual { get; set; }
        decimal TributacaoMunicipal { get; set; }
    }
}