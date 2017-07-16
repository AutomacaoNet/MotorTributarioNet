using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.CalulosDeBC.Base;

namespace MotorTributarioNet.Impostos.CalulosDeBC
{
    public class CalculaBaseCalculoPis : CalculaBaseCalculoBase
    {
        private readonly ITributavel _tributavel;
        private readonly TipoDesconto _tipoDesconto;

        public CalculaBaseCalculoPis(ITributavel tributavel, TipoDesconto tipoDesconto) : base(tributavel)
        {
            _tributavel = tributavel;
            _tipoDesconto = tipoDesconto;
        }

        public decimal CalculaBaseCalculo()
        {
            var baseCalculo = CalculaBaseDeCalculo();

            return _tipoDesconto == TipoDesconto.Condincional ? CalculaIcmsComDescontoCondicional(baseCalculo) : CalculaIcmsComDescontoIncondicional(baseCalculo);
        }

        private decimal CalculaIcmsComDescontoIncondicional(decimal baseCalculoInicial)
        {
            var baseCalculo = baseCalculoInicial - _tributavel.Desconto;

            return baseCalculo;
        }

        private decimal CalculaIcmsComDescontoCondicional(decimal baseCalculoInicial)
        {
            var baseCalulo = baseCalculoInicial + _tributavel.Desconto;

            return baseCalulo;
        }
    }
}