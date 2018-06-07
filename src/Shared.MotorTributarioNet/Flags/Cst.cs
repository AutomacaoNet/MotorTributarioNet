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
    public enum Cst
    {
        [Description("00 - Tributada integralmente.")]
        Cst00 = 00,
        [Description("10 - Tributada e com cobrança do ICMS por substituição tributária.")]
        Cst10 = 10,
        [Description("20 - Com redução de Base de Cálculo")]
        Cst20 = 20,
        [Description("30 - Isenta ou não tributada e com cobrança do ICMS por substituição tributária")]
        Cst30 = 30,
        [Description("40 - Isenta")]
        Cst40 = 40,
        [Description("41 - Não tributada")]
        Cst41 = 41,
        [Description("50 - Com suspensão")]
        Cst50 = 50,
        [Description("51 - Com diferimento")]
        Cst51 = 51,
        [Description("60 - ICMS cobrado anteriormente por substituição tributária")]
        Cst60 = 60,
        [Description("70 - Com redução da Base de Cálculo e cobrança do ICMS por substituição tributária")]
        Cst70 = 70,
        [Description("90 - Outras")]
        Cst90 = 90
    }
}
