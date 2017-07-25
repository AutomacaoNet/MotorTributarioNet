using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Tributacoes
{
    public class TributacaoIbpt
    {
        private readonly ITributavel _tributavel;
        private readonly IIbpt _ibpt;

        public TributacaoIbpt(ITributavel tributavel, IIbpt ibpt)
        {
            _tributavel = tributavel;
            _ibpt = ibpt;
        }

        public IResultadoCalculoIbpt Calcula()
        {
            var baseCalculo = _tributavel.ValorProduto * _tributavel.QuantidadeProduto - _tributavel.Desconto;

            var impostoAproximadoFederal = baseCalculo * _ibpt.PercentualFederal / 100;
            var impostoAproximadoMunicipio = baseCalculo * _ibpt.PercentualMunicipal / 100;
            var impostoAproximadoEstadual = baseCalculo * _ibpt.PercentualEstadual / 100;
            var impostoAproximadoImportados = baseCalculo * _ibpt.PercentualFederalImportados / 100;


            return new ResultadoCalculoIbpt(impostoAproximadoFederal, impostoAproximadoMunicipio, impostoAproximadoEstadual, impostoAproximadoImportados, baseCalculo);
        }
    }
}