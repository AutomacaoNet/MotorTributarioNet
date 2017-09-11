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