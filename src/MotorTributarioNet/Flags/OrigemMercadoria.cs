using System.ComponentModel;

namespace MotorTributarioNet.Flags
{
    public enum OrigemMercadoria
    {
        [Description("Nacional")]
        Nacional = 0,

        [Description("Estrangeira Importação Direta")]
        EstrangeiraImportacaoDireta = 1,

        [Description("Estrangeira Interna")]
        EstrangeiraInterna = 2,

        [Description("Nacional Importação Inferior 40")]
        NacionalImportacaoSuperior40 = 3,

        [Description("Nacional Confirmidade Básicas")]
        NacionalConformidadeBasicas = 4,

        [Description("Nacional Importação Inferior 40")]
        NacionalImportacaoInferior40 = 5,

        [Description("Estrangeira Importação Direta Sem Similar")]
        EstrangeiraImportacaoDiretaSemSimilar = 6,

        [Description("Estrangeira Interna Sem Similar")]
        EstrangeiraInternaSemSimilar = 7,

        [Description("Nacional Importação Superior 70")]
        NacionalImportacaoSuperior70 = 8
    }
}