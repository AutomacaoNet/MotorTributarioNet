using System;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Csosns.Componentes
{
    public class TributacaoCofins
    {
        private readonly ITributavel _tributavel;
        private readonly CalculaBaseCalculoCofins _calculaBaseCalculoCofins;

        public TributacaoCofins(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _calculaBaseCalculoCofins = new CalculaBaseCalculoCofins(_tributavel, tipoDesconto);
        }

        public IResultadoCalculoCofins Calcula()
        {
            return CalculaCofins();
        }

        private IResultadoCalculoCofins CalculaCofins()
        {
            var baseCalculo = _calculaBaseCalculoCofins.CalculaBaseCalculo();

            var valorIcms = CalculaCofins(baseCalculo);

            return new ResultadoCalculoCofins(baseCalculo, valorIcms);
        }

        private decimal CalculaCofins(decimal baseCalculo)
        {
            return baseCalculo * _tributavel.PercentualIcms / 100;
        }
    }
}