using System.ComponentModel;

namespace MotorTributarioNet.Flags
{
    public enum Csosn
    {
        [Description("101 - Tributada pelo Simples Nacional com permissão de crédito")]
        Csosn101 = 101,

        [Description("102 - Tributada pelo Simples Nacional sem permissão de crédito")]
        Csosn102 = 102,

        [Description("103 - Isenção do ICMS no Simples Nacional para faixa de receita bruta")]
        Csosn103 = 103,

        [Description("201 - Tributada pelo Simples Nacional com permissão de crédito e com cobrança do ICMS substituição tributária")]
        Csosn201 = 201,

        [Description("202 - Tributada pelo Simples Nacional sem permissão de crédito e com cobrança do ICMS substituição tributária")]
        Csosn202 = 202,

        [Description("203 - Isenção do ICMS no Simples Nacional para faixa de receita bruta e com cobrança do ICMS por substituição tributária")]
        Csosn203 = 203,

        [Description("300 - Imune")]
        Csosn300 = 300,

        [Description("400 - Não tributada pelo Simples Nacional")]
        Csosn400 = 400,

        [Description("500 - ICMS cobrado anteriormente por substituição tributária")]
        Csosn500 = 500,

        [Description("900 - Outros")]
        Csosn900 = 900
    }
}