using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos
{
    public interface ITributavel
    {
        Cst Cst { get; set; }
        decimal ValorProduto { get; set; }
        decimal Frete { get; set; }
        decimal Seguro { get; set; }
        decimal OutrasDespesas { get; set; }
        decimal Desconto { get; set; }
        decimal ValorIpi { get; set; }
        decimal PercentualReducao { get; set; }
        decimal QuantidadeProduto { get; set; }
        decimal PercentualIcms { get; set; }
        decimal PercentualCredito { get; set; }
        decimal PercentualDiferimento { get; set; }
        decimal PercentualDifalInterna { get; set; }
        decimal PercentualDifalInterestadual { get; set; }
        decimal PercentualFcp { get; set; }
        decimal PercentualMva { get; set; }
        decimal PercentualIcmsSt { get; set; }
        decimal PercentualIpi { get; set; }
        decimal PercentualCofins { get; set; }
        decimal PercentualPis { get; set; }
        decimal PercentualReducaoSt { get; set; }
    }
}