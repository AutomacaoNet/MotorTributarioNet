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

namespace MotorTributarioNet.Impostos.Csosns
{
    public class Csosn202 : Csosn102
    {
        public Csosn202(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional) : base(origemMercadoria, tipoDesconto)
        {
            Csosn = Csosn.Csosn202;
            ModalidadeDeterminacaoBcIcmsSt = ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado;
        }

        public ModalidadeDeterminacaoBcIcmsSt ModalidadeDeterminacaoBcIcmsSt { get; set; }

        public decimal PercentualMvaSt { get; private set; }
        public decimal PercentualReducaoSt { get; private set; }
        public decimal ValorBcIcmsSt { get; private set; }
        public decimal PercentualIcmsSt { get; private set; }
        public decimal ValorIcmsSt { get; private set; }

        public override void Calcula(ITributavel tributavel)
        {
            PercentualMvaSt = tributavel.PercentualMva;
            PercentualReducaoSt = tributavel.PercentualReducaoSt;
            PercentualIcmsSt = tributavel.PercentualIcmsSt;

            var facade = new FacadeCalculadoraTributacao(tributavel, TipoDesconto);

            tributavel.ValorIpi = facade.CalculaIpi().Valor;

            var resultadoCalculoCofins = facade.CalculaIcmsSt();

            ValorBcIcmsSt = resultadoCalculoCofins.BaseCalculoIcmsSt;
            ValorIcmsSt = resultadoCalculoCofins.ValorIcmsSt;
        }
    }
}