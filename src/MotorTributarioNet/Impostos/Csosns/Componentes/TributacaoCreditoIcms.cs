using System;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Csosns.Componentes
{
    public class TributacaoCreditoIcms
    {
        private readonly ITributavel _tributavel;
        private readonly CalculaBaseCalculoIcms _calculaBaseCalculoIcms;

        public TributacaoCreditoIcms(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _calculaBaseCalculoIcms = new CalculaBaseCalculoIcms(_tributavel, tipoDesconto);
        }

        public IResultadoCalculoCredito Calcula()
        {
            return CalculaIcms();
        }

        private IResultadoCalculoCredito CalculaIcms()
        {
            var baseCalculo = _calculaBaseCalculoIcms.CalculaBaseCalculo();

            var valorCredito = CalculaCredito(baseCalculo);

            return new ResultadoCalculoCredito(baseCalculo, valorCredito);
        }

        private decimal CalculaCredito(decimal baseCalculo)
        {
            return baseCalculo * _tributavel.PercentualCredito / 100;
        }
    }
}