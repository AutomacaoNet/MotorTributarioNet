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

            var valorIss = calcularIssqn(baseCalculo);

            return !calcularRetencoes ? new ResultadoCalculoIssqn(baseCalculo, valorIss) : CalcularRetencoes(baseCalculo, valorIss);
        }

        private IResultadoCalculoIssqn CalcularRetencoes(decimal baseCalculo, decimal valorIss)
        {
            decimal baseCalculoInss = baseCalculo;
            decimal baseCalculoIrrf = baseCalculo;
            decimal valorRetPis = calcularRetPis(baseCalculo);
            decimal valorRetCofins = calcularRetCofins(baseCalculo);
            decimal valorRetCsll = calcularRetCsll(baseCalculo);
            decimal valorRetIrrf = calcularRetIrrf(baseCalculo);
            decimal valorRetInss = calcularRetInss(baseCalculo);

            return new ResultadoCalculoIssqn(baseCalculo, valorIss, baseCalculoInss, baseCalculoIrrf, valorRetPis, valorRetCofins, valorRetCsll, valorRetIrrf, valorRetInss);

        }

        private decimal calcularIssqn(decimal baseCalculo)
        {
            return baseCalculo * _tributavel.PercentualIssqn / 100;
        }
        private decimal calcularRetPis(decimal baseCalculo)
        {
            decimal valor = baseCalculo * _tributavel.PercentualRetPis / 100;
            return valor >= 10 ? valor : decimal.Zero;
        }

        private decimal calcularRetCofins(decimal baseCalculo)
        {
            decimal valor = baseCalculo * _tributavel.PercentualRetCofins / 100;
            return valor >= 10 ? valor : decimal.Zero;
        }

        private decimal calcularRetCsll(decimal baseCalculo)
        {
            decimal valor = baseCalculo * _tributavel.PercentualRetCsll / 100;
            return valor >= 10 ? valor : decimal.Zero;
        }

        private decimal calcularRetIrrf(decimal baseCalculo)
        {
            decimal valor = baseCalculo * _tributavel.PercentualRetIrrf / 100;
            return valor >= 10 ? valor : decimal.Zero;
        }

        private decimal calcularRetInss(decimal baseCalculo)
        {
            decimal valor = baseCalculo * _tributavel.PercentualRetInss / 100;
            return valor >= 10 ? valor : decimal.Zero;
        }
    }
}
