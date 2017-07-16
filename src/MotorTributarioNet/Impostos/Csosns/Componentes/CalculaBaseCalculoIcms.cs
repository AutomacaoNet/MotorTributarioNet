using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csosns.Base;

namespace MotorTributarioNet.Impostos.Csosns.Componentes
{
    public class CalculaBaseCalculoIcms : CalculaBaseCalculoBase
    {
        private readonly ITributavel _tributavel;
        private readonly TipoDesconto _tipoDesconto;

        public CalculaBaseCalculoIcms(ITributavel tributavel, TipoDesconto tipoDesconto) : base(tributavel)
        {
            _tributavel = tributavel;
            _tipoDesconto = tipoDesconto;
        }

        public decimal CalculaIcms()
        {
            var baseCalculo = CalculaBaseDeCalculo() + _tributavel.ValorIpi;

            return _tipoDesconto == TipoDesconto.Condincional ? CalculaIcmsComDescontoCondicional(baseCalculo) : CalculaIcmsComDescontoIncondicional(baseCalculo);
        }

        private decimal CalculaIcmsComDescontoIncondicional(decimal baseCalculoInicial)
        {
            var baseCalculo = baseCalculoInicial - _tributavel.Desconto;

            baseCalculo = baseCalculo - baseCalculo * _tributavel.PercentualReducao / 100;

            return baseCalculo;
        }

        private decimal CalculaIcmsComDescontoCondicional(decimal baseCalculoInicial)
        {
            var baseCalulo = baseCalculoInicial + _tributavel.Desconto;

            baseCalulo = baseCalulo - baseCalulo * _tributavel.PercentualReducao / 100;

            return baseCalulo;
        }
    }
}