using System;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.CalulosDeBC;
using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Tributacoes
{
    public class TributacaoFcp
    {
        private readonly ITributavel _tributavel;
        private readonly CalculaBaseFcp _calculaBaseFcp;

        public TributacaoFcp(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _calculaBaseFcp = new CalculaBaseFcp(_tributavel, tipoDesconto);
        }

        public IResultadoCalculoFcp Calcula()
        {
            return CalculaFcp();
        }

        private IResultadoCalculoFcp CalculaFcp()
        {
            var baseCalculo = _calculaBaseFcp.CalculaBaseCalculo();

            var fcp = baseCalculo * (_tributavel.PercentualFcp / 100);

            return new ResultadoCalculoFcp(baseCalculo, fcp);
        }
    }
}
