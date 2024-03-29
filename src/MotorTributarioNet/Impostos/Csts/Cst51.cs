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
    public class Cst51 : CstBase
    {
        public ModalidadeDeterminacaoBcIcms ModalidadeDeterminacaoBcIcms { get; set; }
        public decimal PercentualDiferimento { get;private set; }
        public decimal ValorIcmsDiferido { get; private set; }
        public decimal ValorIcmsOperacao { get; private set; }
        public decimal PercentualIcms { get; private set; }
        public decimal PercentualReducao { get; private set; }
        public decimal ValorBcIcms { get; private set; }
        public decimal ValorIcms { get; private set; }
		public decimal ValorBcFcp { get; private set; }
		public decimal PercentualFcp { get; private set; }
		public decimal ValorFcp { get; private set; }

		public Cst51(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional) : base(origemMercadoria, tipoDesconto)
        {
            Cst = Cst.Cst51;
            ModalidadeDeterminacaoBcIcms = ModalidadeDeterminacaoBcIcms.ValorOperacao;
        }

        public override void Calcula(ITributavel tributavel)
        {
			FacadeCalculadoraTributacao facadeCalculadoraTributacao = new FacadeCalculadoraTributacao(tributavel, TipoDesconto);

			IResultadoCalculoIcms resultadoCalculoIcms = facadeCalculadoraTributacao.CalculaIcms();

			PercentualReducao = tributavel.PercentualReducao;
            ValorBcIcms = resultadoCalculoIcms.BaseCalculo;
            PercentualIcms = tributavel.PercentualIcms;
            ValorIcmsOperacao = (ValorBcIcms * PercentualIcms) / 100;
            PercentualDiferimento = tributavel.PercentualDiferimento;
            ValorIcmsDiferido = (PercentualDiferimento * ValorIcmsOperacao) / 100;
            ValorIcms = ValorIcmsOperacao - ValorIcmsDiferido;

			IResultadoCalculoFcp resultadoCalculoFcp = facadeCalculadoraTributacao.CalculaFcp();

			PercentualFcp = tributavel.PercentualFcp;
			ValorBcFcp = resultadoCalculoFcp.BaseCalculo;
			ValorFcp = resultadoCalculoFcp.Valor;
        }
    }
}
