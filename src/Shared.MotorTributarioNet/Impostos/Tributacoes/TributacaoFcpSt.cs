using System;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.CalulosDeBC;
using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Tributacoes
{
    public class TributacaoFcpSt
    {
        private readonly ITributavel _tributavel;
        private readonly CalculoBaseIcmsSt _baseIcmsSt;

        public TributacaoFcpSt(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _baseIcmsSt = new CalculoBaseIcmsSt(_tributavel, tipoDesconto);
        }

        public IResultadoCalculoFcpSt Calcula()
        {
            return CalculaFcpSt();
        }

        private IResultadoCalculoFcpSt CalculaFcpSt()
        {

            var baseCalculoIcmsSt = _baseIcmsSt.CalculaBaseCalculo();

            var valorIcmsSt = (baseCalculoIcmsSt * (_tributavel.PercentualFcpSt / 100));

            return new ResultadoCalculoFcpSt(baseCalculoIcmsSt, valorIcmsSt);
        }
    }
}
