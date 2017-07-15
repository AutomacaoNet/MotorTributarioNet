using System;
using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos.Csosns.Componentes
{
    public class TributacaoIcms
    {
        private readonly TipoDesconto _tipoDesconto;
        private readonly ITributacao _tributacao;

        public TributacaoIcms(ITributacao tributacao, TipoDesconto tipoDesconto)
        {
            _tributacao = tributacao ?? throw new ArgumentNullException(nameof(tributacao));
            _tipoDesconto = tipoDesconto;
        }

        public void Calcula()
        {
            var baseCalculo = _tributacao.ValorProduto * _tributacao.QuantidadeProduto + _tributacao.ValorIpi + _tributacao.Frete + _tributacao.Seguro + _tributacao.OutrasDespesas;

            if (_tipoDesconto == TipoDesconto.Condincional)
            {
                CalculaIcmsComDescontoCondicional(baseCalculo);
                return;
            }

            CalculaIcmsComDescontoIncondicional(baseCalculo);
        }

        private void CalculaIcmsComDescontoCondicional(decimal baseCalculo)
        {
            var baseCalculoDescontoCondicional = baseCalculo + _tributacao.Desconto;

            var baseCalculoFinalCondicional = baseCalculoDescontoCondicional -
                                              baseCalculoDescontoCondicional * _tributacao.PercentualReducao / 100;

            var valorIcmsCondicional = CalculaIcms(baseCalculoFinalCondicional);

            _tributacao.BaseCalculoIcms = baseCalculoFinalCondicional;
            _tributacao.ValorIcms = valorIcmsCondicional;
        }

        private void CalculaIcmsComDescontoIncondicional(decimal baseCalculo)
        {
            var baseCalculoDescontoIncondicional = baseCalculo - _tributacao.Desconto;

            var baseCalculoFinalIncondicional = baseCalculoDescontoIncondicional -
                                                baseCalculoDescontoIncondicional * _tributacao.PercentualReducao / 100;

            var valorIcmsIncondicional = CalculaIcms(baseCalculoFinalIncondicional);

            _tributacao.BaseCalculoIcms = baseCalculoFinalIncondicional;
            _tributacao.ValorIcms = valorIcmsIncondicional;
        }

        private decimal CalculaIcms(decimal baseCalculo)
        {
            return baseCalculo*_tributacao.PercentualIcms / 100;
        }
    }
}