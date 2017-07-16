using System;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Csosns.Componentes
{
    public class TributacaoPis
    {
        private readonly ITributavel _tributavel;
        private readonly CalculaBaseCalculoPis _calculaBaseCalculoPis;

        public TributacaoPis(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _calculaBaseCalculoPis = new CalculaBaseCalculoPis(_tributavel, tipoDesconto);
        }

        public IResultadoCalculoPis Calcula()
        {
            return CalculaPis();
        }

        private IResultadoCalculoPis CalculaPis()
        {
            var baseCalculo = _calculaBaseCalculoPis.CalculaBaseCalculo();

            var valorIcms = CalculaPis(baseCalculo);

            return new ResultadoCalculoPis(baseCalculo, valorIcms);
        }

        private decimal CalculaPis(decimal baseCalculo)
        {
            return baseCalculo * _tributavel.PercentualIcms / 100;
        }
    }
}