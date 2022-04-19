﻿//                      Projeto: Motor Tributario                                                  
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
    public class TributacaoFcpSt
    {
        private readonly ITributavel _tributavel;
        private readonly CalculoBaseIcmsSt _baseIcmsSt;

        public TributacaoFcpSt(ITributavel tributavel, TipoDesconto tipoDesconto)
        {
            _tributavel = tributavel ?? throw new ArgumentNullException(nameof(tributavel));
            _baseIcmsSt = new CalculoBaseIcmsSt(_tributavel, tipoDesconto);
        }

        public IResultadoCalculoFcpSt Calcula()
        {
            return CalculaFcpSt();
        }

        private IResultadoCalculoFcpSt CalculaFcpSt()
        {

            var baseCalculoIcmsSt = _baseIcmsSt.CalculaBaseCalculo();

            var valorIcmsSt = (baseCalculoIcmsSt * (_tributavel.PercentualFcpSt / 100));

            return new ResultadoCalculoFcpSt(baseCalculoIcmsSt, valorIcmsSt);
        }
    }
}
