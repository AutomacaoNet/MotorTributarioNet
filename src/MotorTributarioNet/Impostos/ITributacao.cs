namespace MotorTributarioNet.Impostos
{
    public interface ITributacao
    {
        decimal ValorProduto { get; set; }
        decimal Frete { get; set; }
        decimal Seguro { get; set; }
        decimal OutrasDespesas { get; set; }
        decimal Desconto { get; set; }
        decimal ValorIpi { get; }
        decimal PercentualReducao { get; set; }
        decimal QuantidadeProduto { get; set; }
        decimal BaseCalculoIcms { get; set; }
        decimal PercentualIcms { get; set; }
        decimal ValorIcms { get; set; }
    }
}