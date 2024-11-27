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

namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class ResultadoCalculoIbpt : IResultadoCalculoIbpt
    {
        public ResultadoCalculoIbpt(decimal impostoAproximadoFederal, decimal impostoAproximadoMunicipio,
            decimal impostoAproximadoEstadual, decimal impostoAproximadoImportados, decimal baseCalculo)
        {
            TributacaoFederal = Math.Round(impostoAproximadoFederal, 2);
            TributacaoEstadual = Math.Round(impostoAproximadoEstadual, 2);
            TributacaoMunicipal = Math.Round(impostoAproximadoMunicipio, 2);
            TributacaoFederalImportados = Math.Round(impostoAproximadoImportados, 2);
            BaseCalculo = Math.Round(baseCalculo, 2);
            ValorTotalTributos = TributacaoFederal + TributacaoFederalImportados + TributacaoEstadual + TributacaoMunicipal;
        }

        public decimal TributacaoFederal { get; set; }
        public decimal TributacaoFederalImportados { get; set; }
        public decimal BaseCalculo { get; set; }
        public decimal TributacaoEstadual { get; set; }
        public decimal TributacaoMunicipal { get; set; }
        public decimal ValorTotalTributos { get; set; }
    }
}
