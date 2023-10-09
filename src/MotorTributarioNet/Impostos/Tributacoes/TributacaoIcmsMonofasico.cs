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

using System;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Tributacoes
{
    public class TributacaoIcmsMonofasico
    {
        private readonly ITributavel _tributavel;
        private decimal QuantidadeBaseCalculoIcmsMonofasico;
        private decimal ValorIcmsMonofasico;
        private decimal QuantidadeBaseCalculoIcmsMonofasicoRetencao;
        private decimal ValorIcmsMonofasicoRetencao;
        private decimal ValorIcmsMonofasicoOperacao;
        private decimal ValorIcmsMonofasicoDiferido;
        private decimal QuantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente;
        private decimal ValorIcmsMonofasicoRetidoAnteriormente;

        public TributacaoIcmsMonofasico(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
        }

        public IResultadoCalculoIcmsMonofasico Calcula()
        {
            switch (_tributavel.Cst)
            {
                case Cst.Cst02:
                    return CalculaIcmsMonofasicoCst02();
                case Cst.Cst15:
                    return CalculaIcmsMonofasicoCst15();
                case Cst.Cst53:
                    return CalculaIcmsMonofasicoCst53();
                case Cst.Cst61:
                    return CalculaIcmsMonofasicoCst61();
                default:
                    break;
            }
            return null;
        }

        private IResultadoCalculoIcmsMonofasico CalculaIcmsMonofasicoCst02()
        {
            QuantidadeBaseCalculoIcmsMonofasico = _tributavel.QuantidadeBaseCalculoIcmsMonofasico;
            ValorIcmsMonofasico = QuantidadeBaseCalculoIcmsMonofasico * _tributavel.AliquotaAdRemIcms;
            return new ResultadoCalculoIcmsMonofasico(QuantidadeBaseCalculoIcmsMonofasico, ValorIcmsMonofasico, QuantidadeBaseCalculoIcmsMonofasicoRetencao, ValorIcmsMonofasicoRetencao, ValorIcmsMonofasicoOperacao, ValorIcmsMonofasicoDiferido, QuantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente, ValorIcmsMonofasicoRetidoAnteriormente);
        }
        private IResultadoCalculoIcmsMonofasico CalculaIcmsMonofasicoCst15()
        {
            decimal aliquotaAdremReduzida = (_tributavel.AliquotaAdRemIcms - (_tributavel.AliquotaAdRemIcms * (_tributavel.PercentualReducaoAliquotaAdRemIcms / 100)));
            QuantidadeBaseCalculoIcmsMonofasico = _tributavel.QuantidadeBaseCalculoIcmsMonofasico - (_tributavel.QuantidadeBaseCalculoIcmsMonofasico * (_tributavel.PercentualBiodisel / 100));
            ValorIcmsMonofasico = QuantidadeBaseCalculoIcmsMonofasico * aliquotaAdremReduzida;

            QuantidadeBaseCalculoIcmsMonofasicoRetencao = _tributavel.QuantidadeBaseCalculoIcmsMonofasico * (_tributavel.PercentualBiodisel / 100);
            ValorIcmsMonofasicoRetencao = (QuantidadeBaseCalculoIcmsMonofasicoRetencao * _tributavel.AliquotaAdRemIcms) * (_tributavel.PercentualOriginarioUf / 100);

            return new ResultadoCalculoIcmsMonofasico(QuantidadeBaseCalculoIcmsMonofasico, ValorIcmsMonofasico, QuantidadeBaseCalculoIcmsMonofasicoRetencao, ValorIcmsMonofasicoRetencao, ValorIcmsMonofasicoOperacao, ValorIcmsMonofasicoDiferido, QuantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente, ValorIcmsMonofasicoRetidoAnteriormente);
        }
        private IResultadoCalculoIcmsMonofasico CalculaIcmsMonofasicoCst53()
        {
            QuantidadeBaseCalculoIcmsMonofasico = _tributavel.QuantidadeBaseCalculoIcmsMonofasico;
            ValorIcmsMonofasico = (QuantidadeBaseCalculoIcmsMonofasico * _tributavel.AliquotaAdRemIcms) - (QuantidadeBaseCalculoIcmsMonofasico * _tributavel.AliquotaAdRemIcms * (_tributavel.PercentualOriginarioUf / 100));
            ValorIcmsMonofasicoOperacao = QuantidadeBaseCalculoIcmsMonofasico * _tributavel.AliquotaAdRemIcms;
            ValorIcmsMonofasicoDiferido = QuantidadeBaseCalculoIcmsMonofasico * _tributavel.AliquotaAdRemIcms * (_tributavel.PercentualOriginarioUf / 100);
            return new ResultadoCalculoIcmsMonofasico(QuantidadeBaseCalculoIcmsMonofasico, ValorIcmsMonofasico, QuantidadeBaseCalculoIcmsMonofasicoRetencao, ValorIcmsMonofasicoRetencao, ValorIcmsMonofasicoOperacao, ValorIcmsMonofasicoDiferido, QuantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente, ValorIcmsMonofasicoRetidoAnteriormente);
        }
        private IResultadoCalculoIcmsMonofasico CalculaIcmsMonofasicoCst61()
        {
            QuantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente = _tributavel.QuantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente;
            ValorIcmsMonofasicoRetidoAnteriormente = QuantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente * _tributavel.AliquotaAdRemIcmsRetidoAnteriormente;

            return new ResultadoCalculoIcmsMonofasico(QuantidadeBaseCalculoIcmsMonofasico, ValorIcmsMonofasico, QuantidadeBaseCalculoIcmsMonofasicoRetencao, ValorIcmsMonofasicoRetencao, ValorIcmsMonofasicoOperacao, ValorIcmsMonofasicoDiferido, QuantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente, ValorIcmsMonofasicoRetidoAnteriormente);
        }
    }
}