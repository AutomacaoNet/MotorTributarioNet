using System;
using System.Globalization;

namespace MotorTributarioNet.Util
{
    public static class DecimalExt
    {
        public static decimal Arredondar(this decimal valor)
        {
            
            var valorNovo = decimal.Round(valor, 2,System.MidpointRounding.AwayFromZero);
            var valorNovoStr = valorNovo.ToString("F" + 2, CultureInfo.CurrentCulture);
            return decimal.Parse(valorNovoStr);
        }

        public static decimal? Arredondar(this decimal? valor)
        {
            if (valor == null) return null;
            return Arredondar(valor.Value);
        }

        public static decimal ArredondarUP(this decimal valor)
        {
            var novoValor = Math.Round(valor, 2, MidpointRounding.AwayFromZero);
            var novoValorStr = novoValor.ToString("F" + 2, CultureInfo.CurrentCulture);
            return decimal.Parse(novoValorStr);
        }

        public static decimal? ArredondarUP(this decimal? valor)
        {
            if (valor == null) return null;
            return ArredondarUP(valor.Value);
        }
    }
}
