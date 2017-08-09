using System.ComponentModel;

namespace MotorTributarioNet.Flags
{
    public enum Cst
    {
        [Description("00 - Tributada integralmente.")]
        Cst00 = 00,
        [Description("10 - Tributada e com cobrança do ICMS por substituição tributária.")]
        Cst10 = 10,
        [Description("20 - Com redução de Base de Cálculo")]
        Cst20 = 20,
        [Description("30 - Isenta ou não tributada e com cobrança do ICMS por substituição tributária")]
        Cst30 = 30,
        [Description("40 - Isenta")]
        Cst40 = 40,
        [Description("41 - Não tributada")]
        Cst41 = 41,
        [Description("50 - Com suspensão")]
        Cst50 = 50,
        [Description("51 - Com diferimento")]
        Cst51 = 51,
        [Description("60 - ICMS cobrado anteriormente por substituição tributária")]
        Cst60 = 60,
        [Description("70 - Com redução da Base de Cálculo e cobrança do ICMS por substituição tributária")]
        Cst70 = 70,
        [Description("90 - Outras")]
        Cst90 = 90
    }
}
