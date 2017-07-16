using System;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Csosns.Componentes
{
    public class TributacaoIpi
    {
        private readonly ITributavel _tributavel;
        private readonly CalculaBaseCalculoIcms _calculaBaseCalculoIcms;

        public TributacaoIpi(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _calculaBaseCalculoIcms = new CalculaBaseCalculoIcms(_tributavel, tipoDesconto);
        }

        public IResultadoCalculoIpi Calcula()
        {
            return CalculaIcms();
        }

        private IResultadoCalculoIpi CalculaIcms()
        {
            var baseCalculo = _calculaBaseCalculoIcms.CalculaIcms();

            var valorIcms = CalculaIcms(baseCalculo);

            return new ResultadoCalculoIpi(baseCalculo, valorIcms);
        }

        private decimal CalculaIcms(decimal baseCalculo)
        {
            return baseCalculo * _tributavel.PercentualIcms / 100;
        }
    }
}