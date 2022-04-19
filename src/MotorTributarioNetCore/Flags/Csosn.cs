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
    public enum Csosn
    {
        [Description("101 - Tributada pelo Simples Nacional com permissão de crédito")]
        Csosn101 = 101,

        [Description("102 - Tributada pelo Simples Nacional sem permissão de crédito")]
        Csosn102 = 102,

        [Description("103 - Isenção do ICMS no Simples Nacional para faixa de receita bruta")]
        Csosn103 = 103,

        [Description("201 - Tributada pelo Simples Nacional com permissão de crédito e com cobrança do ICMS substituição tributária")]
        Csosn201 = 201,

        [Description("202 - Tributada pelo Simples Nacional sem permissão de crédito e com cobrança do ICMS substituição tributária")]
        Csosn202 = 202,

        [Description("203 - Isenção do ICMS no Simples Nacional para faixa de receita bruta e com cobrança do ICMS por substituição tributária")]
        Csosn203 = 203,

        [Description("300 - Imune")]
        Csosn300 = 300,

        [Description("400 - Não tributada pelo Simples Nacional")]
        Csosn400 = 400,

        [Description("500 - ICMS cobrado anteriormente por substituição tributária")]
        Csosn500 = 500,

        [Description("900 - Outros")]
        Csosn900 = 900
    }
}