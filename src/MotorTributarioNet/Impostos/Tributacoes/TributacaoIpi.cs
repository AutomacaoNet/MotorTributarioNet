using System;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.CalulosDeBC;
using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Tributacoes
{
    public class TributacaoIpi
    {
        private readonly ITributavel _tributavel;
        private readonly CalculaBaseCalculoIpi _calculaBaseCalculoIpi;

        public TributacaoIpi(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _calculaBaseCalculoIpi = new CalculaBaseCalculoIpi(_tributavel, tipoDesconto);
        }

        public IResultadoCalculoIpi Calcula()
        {
            return CalculaIpi();
        }

        private IResultadoCalculoIpi CalculaIpi()
        {
            var baseCalculo = _calculaBaseCalculoIpi.CalculaBaseCalculo();

            var valorIcms = CalculaIpi(baseCalculo);

            return new ResultadoCalculoIpi(baseCalculo, valorIcms);
        }

        private decimal CalculaIpi(decimal baseCalculo)
        {
            return baseCalculo * _tributavel.PercentualIcms / 100;
        }
    }
}