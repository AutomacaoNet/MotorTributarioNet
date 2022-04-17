//                      Projeto: Motor Tributario                                                  
//          Biblioteca C# para Cálculos Tributários Do Brasil
//                    NF-e, NFC-e, CT-e, SAT-Fiscal     
//                                                                                                                                           
//  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la 
// sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  
// Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) 
// qualquer versão posterior.                                                   
//                                                                              
//  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   
// NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      
// ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor
// do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              
//                                                                              
//  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto
// com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  
// no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          
// Você também pode obter uma copia da licença em:                              
// https://github.com/AutomacaoNet/MotorTributarioNet/blob/master/LICENSE    

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
