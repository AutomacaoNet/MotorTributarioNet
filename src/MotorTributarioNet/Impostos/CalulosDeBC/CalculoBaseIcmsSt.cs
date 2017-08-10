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
            var baseCalculo = CalculaBaseDeCalculo() + _tributavel.ValorIpi;
            baseCalculo = baseCalculo - (baseCalculo * _tributavel.PercentualReducao / 100);
            var baseCalculoSt = CalculaBaseCalculoST(baseCalculo);
            return baseCalculoSt;
        }


        public decimal CalculaBaseCalculoST(decimal baseCalculoIcms)
        {
            var baseCalculoSt = _tipoDesconto == TipoDesconto.Condincional ? CalculaIcmsComDescontoCondicional(baseCalculoIcms) : CalculaIcmsComDescontoIncondicional(baseCalculoIcms);

            baseCalculoSt = baseCalculoSt * (1.00m + _tributavel.PercentualMva / 100.00m);

            return baseCalculoSt;
        }



        private decimal CalculaIcmsComDescontoIncondicional(decimal baseCalculoInicial)
        {
            var baseCalculo = baseCalculoInicial - _tributavel.Desconto;

            baseCalculo = baseCalculo - baseCalculo * _tributavel.PercentualReducaoSt / 100;

            return baseCalculo;
        }

        private decimal CalculaIcmsComDescontoCondicional(decimal baseCalculoInicial)
        {
            var baseCalulo = baseCalculoInicial + _tributavel.Desconto;

            baseCalulo = baseCalulo - baseCalulo * _tributavel.PercentualReducaoSt / 100;

            return baseCalulo;
        }
    }
}