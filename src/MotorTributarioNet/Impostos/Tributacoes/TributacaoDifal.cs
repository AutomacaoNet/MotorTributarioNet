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
using MotorTributarioNet.Impostos.CalulosDeBC;
using MotorTributarioNet.Impostos.Implementacoes;

namespace MotorTributarioNet.Impostos.Tributacoes
{
    public class TributacaoDifal
    {
        private readonly ITributavel _tributavel;
        private readonly CalculaBaseCalculoIcms _calculaBaseCalculoIcms;

        public TributacaoDifal(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _calculaBaseCalculoIcms = new CalculaBaseCalculoIcms(_tributavel, tipoDesconto);
        }

        public IResultadoCalculoDifal Calcula()
        {
            return CalculaIcms();
        }

        private IResultadoCalculoDifal CalculaIcms()
        {
            var baseCalculo = _calculaBaseCalculoIcms.CalculaBaseCalculo();


            var fcp = baseCalculo * (_tributavel.PercentualFcp / 100);
            var difal = CalcularDifal(baseCalculo);

            decimal percentualRateoOrigem = 40;
            decimal percentualReteoDestino = 60;

            if (DateTime.Now.Year == 2018)
            {
                percentualRateoOrigem = 20;
                percentualReteoDestino = 80;
            }

            if (DateTime.Now.Year >= 2019)
            {
                percentualRateoOrigem = 0;
                percentualReteoDestino = 100;
            }

            var aliquotaOrigem = difal * (percentualRateoOrigem/100);

            var aliquotaDestino = difal * (percentualReteoDestino/100);


            return new ResultadoCalculoDifal(baseCalculo, difal, fcp, aliquotaDestino, aliquotaOrigem);
        }

        private decimal CalcularDifal(decimal baseCalculo)
        {
            return baseCalculo * ((_tributavel.PercentualDifalInterna - _tributavel.PercentualDifalInterestadual) / 100);
        }
    }
}