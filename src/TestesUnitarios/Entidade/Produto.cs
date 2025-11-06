using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos;

namespace TestCalculosTributarios.Entidade
{
    public class Produto : ITributavelProduto
    {
        public Produto()
        {
            Documento = Documento.NFe;
        }

        public Documento Documento { get; set; }
        public CstIpi CstIpi { get; set; }
        public CstPisCofins CstPisCofins { get; set; }
        public bool IsServico { get; set; }
        public bool IsAtivoImobilizadoOuUsoeConsumo { get; set; }
        public MotorTributarioNet.Flags.Cst Cst { get; set; }
        public MotorTributarioNet.Flags.Csosn Csosn { get; set; }
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
        public decimal PercentualDiferimento { get; set; }
        public decimal PercentualIssqn { get; set; }
        public decimal PercentualRetPis { get; set; }
        public decimal PercentualRetCofins { get; set; }
        public decimal PercentualRetCsll { get; set; }
        public decimal PercentualRetIrrf { get; set; }
        public decimal PercentualRetInss { get; set; }
        public decimal PercentualFcpSt { get; set; }
        public decimal PercentualFcpStRetido { get; set; }
        public decimal ValorUltimaBaseCalculoIcmsStRetido { get; set; }
        public bool DeduzIcmsDaBaseDePisCofins { get; set; } = false;
        public decimal PercentualReducaoPis { get; set; }
        public decimal PercentualReducaoCofins { get; set; }
        public decimal PercentualBiodisel { get; set; }
        public decimal PercentualOriginarioUf { get; set; }
        public decimal QuantidadeBaseCalculoIcmsMonofasico { get; set; }
        public decimal AliquotaAdRemIcms { get; set; }
        public decimal QuantidadeBaseCalculoIcmsMonofasicoRetencao { get; set; }
        public decimal AliquotaAdRemIcmsretencao { get; set; }
        public decimal PercentualReducaoAliquotaAdRemIcms { get; set; }
        public decimal PercentualIcmsMonofasicoDiferido { get; set; }
        public decimal QuantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente { get; set; }
        public decimal AliquotaAdRemIcmsRetidoAnteriormente { get; set; }
        public bool CalcularIcmsEfetivoeRetencaoParaSt { get; set; }
        public decimal PercentualIcmsEfetivo { get; set; }
        public decimal PercentualReducaoIcmsEfetivo { get; set; }
        public decimal PercentualIbsUF { get; set; }
        public decimal PercentualIbsMunicipal { get; set; }
        public decimal PercentualCbs { get; set; }
    }
}