using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.CalulosDeBC.Base;

namespace MotorTributarioNet.Impostos.CalulosDeBC
{
    public class CalculoBaseIcmsSt : CalculaBaseCalculoBase
    {
        private readonly ITributavel _tributavel;
        private readonly TipoDesconto _tipoDesconto;

        public CalculoBaseIcmsSt(ITributavel tributavel, TipoDesconto tipoDesconto) : base(tributavel)
        {
            _tributavel = tributavel;
            _tipoDesconto = tipoDesconto;
        }

        public decimal CalculaBaseCalculo()
        {
            var baseCalculoSt = CalculaBaseDeCalculo() + _tributavel.ValorIpi;

            baseCalculoSt = _tipoDesconto == TipoDesconto.Condincional ? CalculaIcmsComDescontoCondicional(baseCalculoSt) : CalculaIcmsComDescontoIncondicional(baseCalculoSt);

            baseCalculoSt = baseCalculoSt * (1.00m + _tributavel.PercentualMva / 100.00m);

            return baseCalculoSt;
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