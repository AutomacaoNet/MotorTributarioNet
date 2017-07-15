using System;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Csosns.Componentes
{
    public class TributacaoIcms
    {
        private readonly TipoDesconto _tipoDesconto;
        private readonly ITributavel _tributavel;

        public TributacaoIcms(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _tipoDesconto = tipoDesconto;
        }

        public IResultadoCalculoIcms Calcula()
        {
            var baseCalculo = _tributavel.ValorProduto * _tributavel.QuantidadeProduto + _tributavel.ValorIpi + _tributavel.Frete + _tributavel.Seguro + _tributavel.OutrasDespesas;

            return _tipoDesconto == TipoDesconto.Condincional ? CalculaIcmsComDescontoCondicional(baseCalculo) : CalculaIcmsComDescontoIncondicional(baseCalculo);
        }

        private IResultadoCalculoIcms CalculaIcmsComDescontoCondicional(decimal baseCalculoInicial)
        {
            var baseCalulo = baseCalculoInicial + _tributavel.Desconto;

            baseCalulo = baseCalulo - baseCalulo * _tributavel.PercentualReducao / 100;

            var valorIcms = CalculaIcms(baseCalulo);

            return new ResultadoCalculoIcms(baseCalulo, valorIcms);
        }

        private IResultadoCalculoIcms CalculaIcmsComDescontoIncondicional(decimal baseCalculoInicial)
        {
            var baseCalculo = baseCalculoInicial - _tributavel.Desconto;

            baseCalculo = baseCalculo - baseCalculo * _tributavel.PercentualReducao / 100;

            var valorIcms = CalculaIcms(baseCalculo);

            return new ResultadoCalculoIcms(baseCalculo, valorIcms);
        }

        private decimal CalculaIcms(decimal baseCalculo)
        {
            return baseCalculo*_tributavel.PercentualIcms / 100;
        }
    }
}