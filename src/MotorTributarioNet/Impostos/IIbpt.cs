namespace MotorTributarioNet.Impostos
{
    public interface IIbpt
    {
        decimal PercentualFederal { get; set; }
        decimal PercentualFederalImportados { get; set; }
        decimal PercentualEstadual { get; set; }
        decimal PercentualMunicipal { get; set; }
    }
}