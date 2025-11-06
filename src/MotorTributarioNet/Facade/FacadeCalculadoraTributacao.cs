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
using MotorTributarioNet.Impostos;
using MotorTributarioNet.Impostos.Tributacoes;

namespace MotorTributarioNet.Facade
{
    public class FacadeCalculadoraTributacao
    {
        private readonly ITributavel _tributavel;
        private readonly TipoDesconto _tipoDesconto;
        private readonly TipoCalculoIcmsDesonerado? _tipoCalculoIcmsDesonerado;

        public FacadeCalculadoraTributacao(ITributavel tributavel, TipoDesconto tipoDesconto = TipoDesconto.Incondicional, TipoCalculoIcmsDesonerado? tipoCalculoIcmsDesonerado = null)
        {
            _tributavel = tributavel;
            _tipoDesconto = tipoDesconto;
            _tipoCalculoIcmsDesonerado = tipoCalculoIcmsDesonerado;
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

        public IResultadoCalculoFcp CalculaFcp()
        {
            return new TributacaoFcp(_tributavel, _tipoDesconto).Calcula();
        }

        public IResultadoCalculoFcpSt CalculaFcpSt()
        {
            return new TributacaoFcpSt(_tributavel, _tipoDesconto).Calcula();
        }

        public IResultadoCalculoIssqn CalculaIssqn(bool calcularRetencao)
        {
            return new TributacaoIssqn(_tributavel, _tipoDesconto).Calcula(calcularRetencao);
        }
        public IResultadoCalculoIcmsDesonerado CalculaIcmsDesonerado()
        {
            return new TributacaoIcmsDesonerado(_tributavel, _tipoDesconto, _tipoCalculoIcmsDesonerado).Calcula();
        }
        public IResultadoCalculoIcmsMonofasico CalculaIcmsMonofasico()
        {
            return new TributacaoIcmsMonofasico(_tributavel, _tipoDesconto).Calcula();
        }
        public IResultadoCalculoIcmsEfetivo CalculaIcmsEfetivo()
        {
            return new TributacaoIcmsEfetivo(_tributavel, _tipoDesconto).Calcula();
        }

        /// <summary>
        /// Calcula o IBS UF (Imposto sobre Bens e Serviços - componente estadual) - Reforma Tributária LC 214/2025
        /// </summary>
        public IResultadoCalculoIbs CalculaIbs()
        {
            return new TributacaoIbs(_tributavel, _tipoDesconto).Calcula();
        }

        /// <summary>
        /// Calcula o IBS Municipal (Imposto sobre Bens e Serviços - componente municipal) - Reforma Tributária LC 214/2025
        /// </summary>
        public IResultadoCalculoIbsMunicipal CalculaIbsMunicipal()
        {
            return new TributacaoIbsMunicipal(_tributavel, _tipoDesconto).Calcula();
        }

        /// <summary>
        /// Calcula a CBS (Contribuição sobre Bens e Serviços) - Reforma Tributária LC 214/2025
        /// </summary>
        public IResultadoCalculoCbs CalculaCbs()
        {
            return new TributacaoCbs(_tributavel, _tipoDesconto).Calcula();
        }
    }
}