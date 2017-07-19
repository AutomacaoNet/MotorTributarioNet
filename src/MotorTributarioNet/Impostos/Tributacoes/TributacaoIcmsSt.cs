using System;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.CalulosDeBC;
using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Tributacoes
{
    public class TributacaoIcmsSt
    {
        private readonly ITributavel _tributavel;
        private readonly CalculoBaseIcmsSemIpi _calculaBaseCalculoIcmsSemIpi;
        private readonly CalculoBaseIcmsSt _baseIcmsSt;

        public TributacaoIcmsSt(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _calculaBaseCalculoIcmsSemIpi = new CalculoBaseIcmsSemIpi(_tributavel, tipoDesconto);
            _baseIcmsSt = new CalculoBaseIcmsSt(_tributavel, tipoDesconto);
        }

        public IResultadoCalculoIcmsSt Calcula()
        {
            return CalculaIcmsSt();
        }

        private IResultadoCalculoIcmsSt CalculaIcmsSt()
        {
            var baseCalculoOperacaoPropria = _calculaBaseCalculoIcmsSemIpi.CalculaBaseCalculo();
            var valorIcmsProprio = CalculaIcmsSt(baseCalculoOperacaoPropria);

            var baseCalculoIcmsSt = _baseIcmsSt.CalculaBaseCalculo();

            var valorIcmsSt = (baseCalculoIcmsSt * (_tributavel.PercentualIcmsSt / 100)) - valorIcmsProprio;

            return new ResultadoCalculoIcmsSt(baseCalculoOperacaoPropria, valorIcmsProprio, baseCalculoIcmsSt, valorIcmsSt);
        }

        private decimal CalculaIcmsSt(decimal baseCalculo)
        {
            return baseCalculo * _tributavel.PercentualIcms / 100;
        }
    }
}