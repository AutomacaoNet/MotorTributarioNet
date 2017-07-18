namespace MotorTributarioNet.Impostos
{
    public interface ITributavel
    {
        decimal ValorProduto { get; set; }
        decimal Frete { get; set; }
        decimal Seguro { get; set; }
        decimal OutrasDespesas { get; set; }
        decimal Desconto { get; set; }
        decimal ValorIpi { get; }
        decimal PercentualReducao { get; set; }
        decimal QuantidadeProduto { get; set; }
        decimal PercentualIcms { get; set; }
        decimal PercentualCredito { get; set; }
        decimal PercentualInterna { get; set; }
        decimal PercentualInterestadual { get; set; }
        decimal PercentualFcp { get; set; }
    }
}