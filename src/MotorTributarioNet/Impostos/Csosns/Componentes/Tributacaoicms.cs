using System;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Csosns.Componentes
{
    public class TributacaoIcms
    {
        private readonly ITributavel _tributavel;
        private readonly CalculaBaseCalculoIcms _calculaBaseCalculoIcms;

        public TributacaoIcms(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _calculaBaseCalculoIcms = new CalculaBaseCalculoIcms(_tributavel, tipoDesconto);
        }

        public IResultadoCalculoIcms Calcula()
        {
            return CalculaIcms();
        }

        private IResultadoCalculoIcms CalculaIcms()
        {
            var baseCalculo = _calculaBaseCalculoIcms.CalculaBaseCalculo();

            var valorIcms = CalculaIcms(baseCalculo);

            return new ResultadoCalculoIcms(baseCalculo, valorIcms);
        }

        private decimal CalculaIcms(decimal baseCalculo)
        {
            return baseCalculo*_tributavel.PercentualIcms / 100;
        }
    }
}