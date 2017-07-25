using MotorTributarioNet.Impostos;

namespace TestCalculosTributarios.Entidade
{
    public class Produto : ITributavel, IIbpt
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
        public decimal PercentualDifalInterna { get; set; }
        public decimal PercentualDifalInterestadual { get; set; }
        public decimal PercentualFcp { get; set; }
        public decimal PercentualMva { get; set; }
        public decimal PercentualIcmsSt { get; set; }
        public decimal PercentualIpi { get; set; }
        public decimal PercentualCofins { get; set; }
        public decimal PercentualPis { get; set; }
        public decimal PercentualReducaoSt { get; set; }
        public decimal PercentualFederal { get; set; }
        public decimal PercentualFederalImportados { get; set; }
        public decimal PercentualEstadual { get; set; }
        public decimal PercentualMunicipal { get; set; }
    }
}