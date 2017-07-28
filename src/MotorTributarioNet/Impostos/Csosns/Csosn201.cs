using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos.Csosns
{
    public class Csosn201 : Csosn101
    {
        public Csosn201(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional) : base(origemMercadoria)
        {
            Csosn = Csosn.Csosn201;
            ModalidadeDeterminacaoBcIcmsSt = ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado;
        }

        public ModalidadeDeterminacaoBcIcmsSt ModalidadeDeterminacaoBcIcmsSt { get; set; }
        public decimal ValorBcIcmsSt { get; set; }
        public decimal PercentualIcmsSt { get; set; }
        public decimal ValorIcmsSt { get; set; }
    }
}