using System;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.CalulosDeBC;
using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Tributacoes
{
    public class TributacaoDifal
    {
        private readonly ITributavel _tributavel;
        private readonly CalculaBaseCalculoIcms _calculaBaseCalculoIcms;

        public TributacaoDifal(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _calculaBaseCalculoIcms = new CalculaBaseCalculoIcms(_tributavel, tipoDesconto);
        }

        public IResultadoCalculoDifal Calcula()
        {
            return CalculaIcms();
        }

        private IResultadoCalculoDifal CalculaIcms()
        {
            var baseCalculo = _calculaBaseCalculoIcms.CalculaBaseCalculo();


            var fcp = baseCalculo * (_tributavel.PercentualFcp / 100);
            var difal = CalcularDifal(baseCalculo);

            decimal percentualRateoOrigem = 40;
            decimal percentualReteoDestino = 60;

            if (DateTime.Now.Year == 2018)
            {
                percentualRateoOrigem = 20;
                percentualReteoDestino = 80;
            }

            if (DateTime.Now.Year >= 2019)
            {
                percentualRateoOrigem = 0;
                percentualReteoDestino = 100;
            }

            var aliquotaOrigem = difal * (percentualRateoOrigem/100);

            var aliquotaDestino = difal * (percentualReteoDestino/100);


            return new ResultadoCalculoDifal(baseCalculo, difal, fcp, aliquotaDestino, aliquotaOrigem);
        }

        private decimal CalcularDifal(decimal baseCalculo)
        {
            return baseCalculo * ((_tributavel.PercentualInterna - _tributavel.PercentualInterestadual) / 100);
        }
    }
}