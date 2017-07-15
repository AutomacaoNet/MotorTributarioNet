using MotorTributarioNet.Impostos;

namespace TestCalculosTributarios.Entidade
{
    public class Produto :  ITributacao
    {
        public decimal ValorProduto { get; set; }
        public decimal Frete { get; set; }
        public decimal Seguro { get; set; }
        public decimal OutrasDespesas { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorIpi { get; set; }
        public decimal PercentualReducao { get; set; }
        public decimal QuantidadeProduto { get; set; }
        public decimal BaseCalculoIcms { get; set; }
        public decimal PercentualIcms { get; set; }
        public decimal ValorIcms { get; set; }
    }
}