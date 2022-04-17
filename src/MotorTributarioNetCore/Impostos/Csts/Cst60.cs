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

using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csts.Base;

namespace MotorTributarioNet.Impostos.Csts
{
    public class Cst60 : CstBase
    {
        public decimal PercentualBcStRetido { get; set; }
        public decimal ValorBcStRetido { get; set; }

        // Manual CT-e v3.00 - Pag. 165
        public decimal ValorCreditoOutorgadoOuPresumido { get; set; }

        // Manual CT-e v3.00 - Pag. 165
        public decimal ValorIcmsStRetido { get; set; }

		// Demais propriedades ainda devem ser implementadas para a NF-e 4.00
		public decimal PercentualSt { get; private set; }

        public Cst60(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional) : base(origemMercadoria, tipoDesconto)
        {
            Cst = Cst.Cst60;
        }

        public override void Calcula(ITributavel tributavel)
        {
            var facade = new FacadeCalculadoraTributacao(tributavel, TipoDesconto);
            var resultadoCalculoIcms = facade.CalculaIcmsSt();
            PercentualBcStRetido = tributavel.PercentualIcmsSt;
            ValorBcStRetido = resultadoCalculoIcms.BaseCalculoIcmsSt;
            ValorIcmsStRetido = resultadoCalculoIcms.ValorIcmsSt;

            ValorCreditoOutorgadoOuPresumido = facade.CalculaIcmsCredito().Valor;

			PercentualSt = tributavel.PercentualIcmsSt + tributavel.PercentualFcpSt;
        }
    }
}
