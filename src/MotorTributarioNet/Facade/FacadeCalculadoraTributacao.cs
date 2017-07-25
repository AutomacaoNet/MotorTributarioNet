using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos;
using MotorTributarioNet.Impostos.Tributacoes;

namespace MotorTributarioNet.Facade
{
    public class FacadeCalculadoraTributacao
    {
        private readonly ITributavel _tributavel;
        private readonly TipoDesconto _tipoDesconto;

        public FacadeCalculadoraTributacao(ITributavel tributavel, TipoDesconto tipoDesconto = TipoDesconto.Incondicional)
        {
            _tributavel = tributavel;
            _tipoDesconto = tipoDesconto;
        }

        public IResultadoCalculoIcms CalculaIcms()
        {
            return new TributacaoIcms(_tributavel, _tipoDesconto).Calcula();
        }

        public IResultadoCalculoIpi CalculaIpi()
        {
            return new TributacaoIpi(_tributavel, _tipoDesconto).Calcula();
        }

        public IResultadoCalculoCredito CalculaIcmsCredito()
        {
            return new TributacaoCreditoIcms(_tributavel, _tipoDesconto).Calcula();
        }

        public IResultadoCalculoCofins CalculaCofins()
        {
            return new TributacaoCofins(_tributavel, _tipoDesconto).Calcula();
        }

        public IResultadoCalculoPis CalculaPis()
        {
            return new TributacaoPis(_tributavel, _tipoDesconto).Calcula();
        }

        public IResultadoCalculoDifal CalculaDifalFcp()
        {
            return new TributacaoDifal(_tributavel, _tipoDesconto).Calcula();
        }

        public IResultadoCalculoIcmsSt CalculaIcmsSt()
        {
            return new TributacaoIcmsSt(_tributavel, _tipoDesconto).Calcula();
        }

        public IResultadoCalculoIbpt CalculaIbpt(IIbpt ibpt)
        {
            return new TributacaoIbpt(_tributavel, ibpt).Calcula();
        }
    }
}