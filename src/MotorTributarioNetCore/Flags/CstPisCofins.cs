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
    public enum CstPisCofins
    {
        [Description("01 - Operação Tributável com Alíquota Básica")]
        Cst01 = 01,
        [Description("02 - Operação Tributável com Alíquota Diferenciada")]
        Cst02 = 02,
        [Description("03 - Operação Tributável com Alíquota por Unidade de Medida de Produto")]
        Cst03 = 03,
        [Description("04 - Operação Tributável Monofásica - Revenda a Alíquota Zero")]
        Cst04 = 04,
        [Description("05 - Operação Tributável por Substituição Tributária")]
        Cst05 = 05,
        [Description("06 - Operação Tributável a Alíquota Zero")]
        Cst06 = 06,
        [Description("07 - Operação Isenta da Contribuição")]
        Cst07 = 07,
        [Description("08 - Operação sem Incidência da Contribuição")]
        Cst08 = 08,
        [Description("09 - Operação com Suspensão da Contribuição")]
        Cst09 = 09,
        [Description("49 - Outras Operações de Saída")]
        Cst49 = 49,
        [Description("50 - Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno")]
        Cst50 = 50,
        [Description("51 - Operação com Direito a Crédito – Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno")]
        Cst51 = 51,
        [Description("52 - Operação com Direito a Crédito - Vinculada Exclusivamente a Receita de Exportação")]
        Cst52 = 52,
        [Description("53 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno")]
        Cst53 = 53,
        [Description("54 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação")]
        Cst54 = 54,
        [Description("55 - Operação com Direito a Crédito - Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação")]
        Cst55 = 55,
        [Description("56 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação")]
        Cst56 = 56,
        [Description("60 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno")]
        Cst60 = 60,
        [Description("61 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno")]
        Cst61 = 61,
        [Description("62 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação")]
        Cst62 = 62,
        [Description("63 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno")]
        Cst63 = 63,
        [Description("64 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação")]
        Cst64 = 64,
        [Description("65 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação")]
        Cst65 = 65,
        [Description("66 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação")]
        Cst66 = 66,
        [Description("67 - Crédito Presumido - Outras Operações")]
        Cst67 = 67,
        [Description("70 - Operação de Aquisição sem Direito a Crédito")]
        Cst70 = 70,
        [Description("71 - Operação de Aquisição com Isenção")]
        Cst71 = 71,
        [Description("72 - Operação de Aquisição com Suspensão")]
        Cst72 = 72,
        [Description("73 - Operação de Aquisição a Alíquota Zero")]
        Cst73 = 73,
        [Description("74 - Operação de Aquisição sem Incidência da Contribuição")]
        Cst74 = 74,
        [Description("75 - Operação de Aquisição por Substituição Tributária")]
        Cst75 = 75,
        [Description("98 - Outras Operações de Entrada")]
        Cst98 = 98,
        [Description("99 - Outras Operações")]
        Cst99 = 99,
    }
}
