using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns.Base;

namespace MotorTributarioNet.Impostos.Csosns
{
    public class Csosn900 : CsosnBase
    {
        public Csosn900(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional) : base(origemMercadoria)
        {
            Csosn = Csosn.Csosn900;
            ModalidadeDeterminacaoBcIcmsSt = ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado;
            ModalidadeDeterminacaoBcIcms = ModalidadeDeterminacaoBcIcms.MargemValorAgregado;
        }

        public ModalidadeDeterminacaoBcIcms ModalidadeDeterminacaoBcIcms { get; set; }

        public decimal ValorBcIcms { get; set; }

        public decimal PercentualIcms { get; set; }

        public decimal ValorIcms { get; set; }

        public ModalidadeDeterminacaoBcIcmsSt ModalidadeDeterminacaoBcIcmsSt { get; set; }

        public decimal ValorBcIcmsSt { get; set; }

        public decimal PercentualIcmsSt { get; set; }

        public decimal ValorIcmsSt { get; set; }

        public decimal PercentualCredito { get; set; }

        public decimal ValorCredito { get; set; }
    }
}