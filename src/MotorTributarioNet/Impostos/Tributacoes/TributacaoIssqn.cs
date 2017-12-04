using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.CalulosDeBC;
using MotorTributarioNet.Impostos.Implementacoes;
using System;

namespace MotorTributarioNet.Impostos.Tributacoes
{
    public class TributacaoIssqn
    {
        private readonly ITributavel _tributavel;
        private readonly CalculaBaseCalculoIssqn _calculaBaseCalculoIssqn;

        public TributacaoIssqn(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _calculaBaseCalculoIssqn = new CalculaBaseCalculoIssqn(_tributavel, tipoDesconto);
        }

        public IResultadoCalculoIssqn Calcula(bool calcularRetencoes)
        {
            return CalcularIssqn(calcularRetencoes);
        }

        private IResultadoCalculoIssqn CalcularIssqn(bool calcularRetencoes)
        {
            var baseCalculo = _calculaBaseCalculoIssqn.CalculaBaseCalculo();

            var valorIss = CalcularIssqn(baseCalculo);

            return !calcularRetencoes ? new ResultadoCalculoIssqn(baseCalculo, valorIss) : CalcularRetencoes(baseCalculo, valorIss);
        }

        private IResultadoCalculoIssqn CalcularRetencoes(decimal baseCalculo, decimal valorIss)
        {
            var baseCalculoInss = baseCalculo;
            var baseCalculoIrrf = baseCalculo;
            var valorRetPis = CalcularRetPis(baseCalculo);
            var valorRetCofins = CalcularRetCofins(baseCalculo);
            var valorRetCsll = CalcularRetCsll(baseCalculo);
            var valorRetIrrf = CalcularRetIrrf(baseCalculo);
            var valorRetInss = CalcularRetInss(baseCalculo);

            return new ResultadoCalculoIssqn(baseCalculo, valorIss, baseCalculoInss, baseCalculoIrrf, valorRetPis, valorRetCofins, valorRetCsll, valorRetIrrf, valorRetInss);

        }

        private decimal CalcularIssqn(decimal baseCalculo)
        {
            return baseCalculo * _tributavel.PercentualIssqn / 100;
        }
        private decimal CalcularRetPis(decimal baseCalculo)
        {
            var valor = baseCalculo * _tributavel.PercentualRetPis / 100;
            return valor > 10 ? valor : decimal.Zero;
        }

        private decimal CalcularRetCofins(decimal baseCalculo)
        {
            var valor = baseCalculo * _tributavel.PercentualRetCofins / 100;
            return valor > 10 ? valor : decimal.Zero;
        }

        private decimal CalcularRetCsll(decimal baseCalculo)
        {
            var valor = baseCalculo * _tributavel.PercentualRetCsll / 100;
            return valor > 10 ? valor : decimal.Zero;
        }

        private decimal CalcularRetIrrf(decimal baseCalculo)
        {
            var valor = baseCalculo * _tributavel.PercentualRetIrrf / 100;
            return valor > 10 ? valor : decimal.Zero;
        }

        private decimal CalcularRetInss(decimal baseCalculo)
        {
            var valor = baseCalculo * _tributavel.PercentualRetInss / 100;
            return valor > 29 ? valor : decimal.Zero;
        }
    }
}
