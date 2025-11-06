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
using MotorTributarioNet.Impostos.CalulosDeBC.Base;
using MotorTributarioNet.Impostos.Tributacoes;

namespace MotorTributarioNet.Impostos.CalulosDeBC
{
    /// <summary>
    /// Calcula a base de cálculo do IBS (Imposto sobre Bens e Serviços) e CBS (Contribuição sobre Bens e Serviços)
    /// Reforma Tributária - LC 214/2025 - Nota Técnica 2025.002
    /// Fórmula (NT 2025.002, página 19, regra UB16-10):
    /// vProd + vServ + vFrete + vSeg + vOutro + vII - vDesc - vPis - vCofins - vIcms - vIcmsUfDest - vFcp - vFcpUfDest - vIcmsMono - vIssqn + vIS
    /// </summary>
    public class CalculaBaseCalculoIbsCbs : CalculaBaseCalculoBase
    {
        private readonly ITributavel _tributavel;
        private readonly TipoDesconto _tipoDesconto;

        public CalculaBaseCalculoIbsCbs(ITributavel tributavel, TipoDesconto tipoDesconto) : base(tributavel)
        {
            _tributavel = tributavel;
            _tipoDesconto = tipoDesconto;
        }

        /// <summary>
        /// Calcula a base de cálculo conforme a fórmula da NT 2025.002
        /// </summary>
        public decimal CalculaBaseCalculo()
        {
            // vProd + vServ + vFrete + vSeg + vOutro
            var baseCalculo = CalculaBaseDeCalculo();

            // + vII (Imposto de Importação) - ainda não implementado, será 0 por enquanto
            baseCalculo += ObterValorImpostoImportacao();

            // - vDesc (Desconto)
            baseCalculo -= _tributavel.Desconto;

            // - vPis (Valor do PIS)
            baseCalculo -= CalcularValorPis();

            // - vCofins (Valor da COFINS)
            baseCalculo -= CalcularValorCofins();

            // - vIcms (Valor do ICMS)
            baseCalculo -= CalcularValorIcms();

            // - vIcmsUfDest (ICMS UF Destino) - ainda não implementado
            baseCalculo -= ObterValorIcmsUfDest();

            // - vFcp (Valor do FCP)
            baseCalculo -= ObterValorFcp();

            // - vFcpUfDest (FCP UF Destino) - ainda não implementado
            baseCalculo -= ObterValorFcpUfDest();

            // - vIcmsMono (ICMS Monofásico) - ainda não implementado
            baseCalculo -= ObterValorIcmsMonofasico();

            // - vIssqn (Valor do ISSQN)
            baseCalculo -= CalcularValorIssqn();

            // + vIS (Imposto Seletivo) - ainda não implementado, será 0 por enquanto
            baseCalculo += ObterValorImpostoSeletivo();

            return baseCalculo;
        }

        /// <summary>
        /// Calcula o valor do PIS para dedução da base
        /// </summary>
        private decimal CalcularValorPis()
        {
            var tributacaoPis = new TributacaoPis(_tributavel, _tipoDesconto);
            return tributacaoPis.Calcula().Valor;
        }

        /// <summary>
        /// Calcula o valor da COFINS para dedução da base
        /// </summary>
        private decimal CalcularValorCofins()
        {
            var tributacaoCofins = new TributacaoCofins(_tributavel, _tipoDesconto);
            return tributacaoCofins.Calcula().Valor;
        }

        /// <summary>
        /// Calcula o valor do ICMS para dedução da base
        /// </summary>
        private decimal CalcularValorIcms()
        {
            var tributacaoIcms = new TributacaoIcms(_tributavel, _tipoDesconto);
            return tributacaoIcms.Calcula().Valor;
        }

        /// <summary>
        /// Calcula o valor do ISSQN para dedução da base
        /// </summary>
        private decimal CalcularValorIssqn()
        {
            if (_tributavel.IsServico && _tributavel.PercentualIssqn > 0)
            {
                var tributacaoIssqn = new TributacaoIssqn(_tributavel, _tipoDesconto);
                return tributacaoIssqn.Calcula(false).Valor;
            }
            return 0m;
        }

        /// <summary>
        /// Obtém o valor do Imposto de Importação (vII)
        /// TODO: Implementar quando a propriedade for adicionada ao ITributavel
        /// </summary>
        private decimal ObterValorImpostoImportacao()
        {
            // Propriedade ainda não existe no ITributavel
            return 0m;
        }

        /// <summary>
        /// Obtém o valor do ICMS UF Destino (vIcmsUfDest)
        /// TODO: Implementar quando a propriedade for adicionada ao ITributavel
        /// </summary>
        private decimal ObterValorIcmsUfDest()
        {
            // Propriedade ainda não existe no ITributavel
            return 0m;
        }

        /// <summary>
        /// Obtém o valor do FCP (Fundo de Combate à Pobreza)
        /// TODO: Melhorar cálculo quando mais informações estiverem disponíveis
        /// </summary>
        private decimal ObterValorFcp()
        {
            // Cálculo simplificado - pode ser melhorado posteriormente
            if (_tributavel.PercentualFcp > 0)
            {
                var baseCalculoFcp = CalculaBaseDeCalculo() - _tributavel.Desconto;
                return baseCalculoFcp * _tributavel.PercentualFcp / 100;
            }
            return 0m;
        }

        /// <summary>
        /// Obtém o valor do FCP UF Destino (vFcpUfDest)
        /// TODO: Implementar quando a propriedade for adicionada ao ITributavel
        /// </summary>
        private decimal ObterValorFcpUfDest()
        {
            // Propriedade ainda não existe no ITributavel
            return 0m;
        }

        /// <summary>
        /// Obtém o valor do ICMS Monofásico (vIcmsMono)
        /// TODO: Implementar cálculo quando mais informações estiverem disponíveis
        /// </summary>
        private decimal ObterValorIcmsMonofasico()
        {
            // Cálculo do ICMS Monofásico ainda não implementado
            return 0m;
        }

        /// <summary>
        /// Obtém o valor do Imposto Seletivo (vIS)
        /// TODO: Implementar quando a propriedade for adicionada ao ITributavel
        /// O IS é um novo imposto da reforma tributária que incidirá sobre produtos específicos
        /// </summary>
        private decimal ObterValorImpostoSeletivo()
        {
            // Imposto Seletivo ainda não implementado
            return 0m;
        }
    }
}
