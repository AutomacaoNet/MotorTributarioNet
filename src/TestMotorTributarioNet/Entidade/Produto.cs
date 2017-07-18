using MotorTributarioNet.Impostos;

namespace TestCalculosTributarios.Entidade
{
    public class Produto : ITributavel
    {
        public decimal ValorProduto { get; set; }
        public decimal Frete { get; set; }
        public decimal Seguro { get; set; }
        public decimal OutrasDespesas { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorIpi { get; set; }
        public decimal PercentualReducao { get; set; }
        public decimal QuantidadeProduto { get; set; }
        public decimal PercentualIcms { get; set; }
        public decimal PercentualCredito { get; set; }
        public decimal PercentualInterna { get; set; }
        public decimal PercentualInterestadual { get; set; }
        public decimal PercentualFcp { get; set; }
    }
}