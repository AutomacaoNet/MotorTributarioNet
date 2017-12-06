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
            var calcularRetencoes = CalcularValorTotalTributacao(baseCalculo);

            var valorRetPis = calcularRetencoes ? CalcularRetPis(baseCalculo) : decimal.Zero;
            var valorRetCofins = calcularRetencoes ? CalcularRetCofins(baseCalculo) : decimal.Zero;
            var valorRetCsll = calcularRetencoes ? CalcularRetCsll(baseCalculo) : decimal.Zero;
            var valorRetIrrf = CalcularRetIrrf(baseCalculo);
            var valorRetInss = CalcularRetInss(baseCalculo);

            return new ResultadoCalculoIssqn(baseCalculo, valorIss, baseCalculoInss, baseCalculoIrrf, valorRetPis, valorRetCofins, valorRetCsll, valorRetIrrf, valorRetInss);
        }

        private decimal CalcularIssqn(decimal baseCalculo)
        {
            var valor = baseCalculo * _tributavel.PercentualIssqn / 100;
            return valor > 10 ? valor : decimal.Zero;
        }
        private decimal CalcularRetPis(decimal baseCalculo)
        {
            return baseCalculo * _tributavel.PercentualRetPis / 100;
        }

        private decimal CalcularRetCofins(decimal baseCalculo)
        {
            return baseCalculo * _tributavel.PercentualRetCofins / 100;
        }

        private decimal CalcularRetCsll(decimal baseCalculo)
        {
            return baseCalculo * _tributavel.PercentualRetCsll / 100;
        }

        private decimal CalcularRetIrrf(decimal baseCalculo)
        {
            var valor = baseCalculo * _tributavel.PercentualRetIrrf / 100;
            return valor > 10 ? valor : decimal.Zero;
        }

        private bool CalcularValorTotalTributacao(decimal baseCalculo)
        {
            var PercentualTotal = _tributavel.PercentualRetPis + _tributavel.PercentualRetCofins + _tributavel.PercentualRetCsll;
            var valor = baseCalculo * PercentualTotal / 100;
            return valor > 10;
        }

        private decimal CalcularRetInss(decimal baseCalculo)
        {
            var valor = baseCalculo * _tributavel.PercentualRetInss / 100;
            return valor > 29 ? valor : decimal.Zero;
        }
    }
}
