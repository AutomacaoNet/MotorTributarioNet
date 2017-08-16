using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csts.Base;
using MotorTributarioNet.Util;

namespace MotorTributarioNet.Impostos.Csts
{
    public class Cst51 : CstBase
    {
        public ModalidadeDeterminacaoBcIcms ModalidadeDeterminacaoBcIcms { get; set; }
        public decimal PercentualDiferimento { get;private set; }
        public decimal ValorIcmsDiferido { get; private set; }
        public decimal ValorIcmsOperacao { get; private set; }
        public decimal PercentualIcms { get; private set; }
        public decimal PercentualReducao { get; private set; }
        public decimal ValorBcIcms { get; private set; }
        public decimal ValorIcms { get; private set; }



        public Cst51(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional) : base(origemMercadoria, tipoDesconto)
        {
            Cst = Cst.Cst51;
            ModalidadeDeterminacaoBcIcms = ModalidadeDeterminacaoBcIcms.ValorOperacao;
        }

        public override void Calcula(ITributavel tributavel)
        {
            var result = new FacadeCalculadoraTributacao(tributavel, TipoDesconto).CalculaIcms();
            PercentualReducao = tributavel.PercentualReducao;
            ValorBcIcms = result.BaseCalculo;
            PercentualIcms = tributavel.PercentualIcms;
            ValorIcmsOperacao = (ValorBcIcms * PercentualIcms) / 100;
            PercentualDiferimento = tributavel.PercentualDiferimento;
            ValorIcmsDiferido = (PercentualDiferimento * ValorIcmsOperacao) / 100;
            ValorIcms = ValorIcmsOperacao - ValorIcmsDiferido;
        }
    }
}
