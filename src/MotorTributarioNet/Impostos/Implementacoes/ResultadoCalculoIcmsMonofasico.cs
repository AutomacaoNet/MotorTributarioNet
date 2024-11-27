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
    public class ResultadoCalculoIcmsMonofasico : IResultadoCalculoIcmsMonofasico
    {
        public ResultadoCalculoIcmsMonofasico(decimal quantidadeBaseCalculoIcmsMonofasico,
            decimal valorIcmsMonofasicoProprio,
            decimal quantidadeBaseCalculoIcmsMonofasicoRetencao,
            decimal valorIcmsMonofasicoRetencao,
            decimal valorIcmsMonofasicoOperacao,
            decimal valorIcmsMonofasicoDiferido,
            decimal quantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente,
            decimal valorIcmsMonofasicoRetidoAnteriormente)
        {
            QuantidadeBaseCalculoIcmsMonofasico = quantidadeBaseCalculoIcmsMonofasico;
            ValorIcmsMonofasicoProprio = Math.Round(valorIcmsMonofasicoProprio, 2);
            QuantidadeBaseCalculoIcmsMonofasicoRetencao = quantidadeBaseCalculoIcmsMonofasicoRetencao;
            ValorIcmsMonofasicoRetencao = Math.Round(valorIcmsMonofasicoRetencao, 2);
            ValorIcmsMonofasicoOperacao = Math.Round(valorIcmsMonofasicoOperacao, 2);
            ValorIcmsMonofasicoDiferido = Math.Round(valorIcmsMonofasicoDiferido, 2);
            QuantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente = quantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente;
            ValorIcmsMonofasicoRetidoAnteriormente = Math.Round(valorIcmsMonofasicoRetidoAnteriormente, 2);

        }

        public decimal QuantidadeBaseCalculoIcmsMonofasico { get; }
        public decimal ValorIcmsMonofasicoProprio { get; }
        public decimal QuantidadeBaseCalculoIcmsMonofasicoRetencao { get; }
        public decimal ValorIcmsMonofasicoRetencao { get; }
        public decimal ValorIcmsMonofasicoOperacao { get; }
        public decimal ValorIcmsMonofasicoDiferido { get; }
        public decimal QuantidadeBaseCalculoIcmsMonofasicoRetidoAnteriormente { get; }
        public decimal ValorIcmsMonofasicoRetidoAnteriormente { get; }
    }
}