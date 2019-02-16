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

using System.ComponentModel;

namespace MotorTributarioNet.Flags
{
    public enum CstIpi
    {
        
        [Description("00 - Entrada com Recuperação de Crédito")]
        Cst00 = 0,
        [Description("01 - Entrada Tributada com Alíquota Zero")]
        Cst01= 1,
        [Description("02 - Entrada Isenta")]
        Cst02 = 2,
        [Description("03 - Entrada Não Tributada")]
        Cst03 = 3,
        [Description("04 - Entrada Imune")]
        Cst04 = 4,
        [Description("05 - Entrada com Suspensão")]
        Cst05 = 5,
        [Description("49 - Outras Entradas")]
        Cst49 = 49,
        [Description("50 - Saída Tributada")]
        Cst50 = 50,
        [Description("51 - Saída Tributável com Alíquota Zero")]
        Cst51 = 51,
        [Description("52 - Saída Isenta")]
        Cst52 = 52 ,
        [Description("53 - Saída Não Tributada")]
        Cst53 = 53,
        [Description("54 - Saída Imune")]
        Cst54 = 54,
        [Description("55 - Saída com Suspensão")]
        Cst55 = 55,
        [Description("99 - Outras Saídas")]
        Cst99 = 99


    }
}
