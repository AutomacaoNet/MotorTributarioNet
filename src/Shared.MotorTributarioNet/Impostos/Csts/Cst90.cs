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
using MotorTributarioNet.Facade;
using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.Csts.Base;

namespace MotorTributarioNet.Impostos.Csts
{
    public class Cst90 : CstBase
    {
        public ModalidadeDeterminacaoBcIcms ModalidadeDeterminacaoBcIcms { get; set; }
        public ModalidadeDeterminacaoBcIcmsSt ModalidadeDeterminacaoBcIcmsSt { get; set; }
        public decimal ValorBcIcms { get; private set; }
        public decimal PercentualReducaoIcmsBc { get; private set; }
        public decimal PercentualIcms { get; set; }
        public decimal ValorIcms { get; set; }
        public decimal PercentualMva { get; private set; }
        public decimal PercentualReducaoSt { get; private set; }
        public decimal ValorBcIcmsSt { get; private set; }
        public decimal PercentualIcmsSt { get; private set; }
        public decimal ValorIcmsSt { get; private set; }
        public decimal PercentualCredito { get; private set; }
        public decimal ValorCredito { get; private set; }
		public decimal ValorBcFcp { get; private set; }
		public decimal PercentualFcp { get; private set; }
		public decimal ValorFcp { get; private set; }
		public decimal ValorBcFcpSt { get; private set; }
		public decimal PercentualFcpSt { get; private set; }
		public decimal ValorFcpSt { get; private set; }

		public Cst90(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional) : base(origemMercadoria, tipoDesconto)
        {
            Cst = Cst.Cst90;
            ModalidadeDeterminacaoBcIcmsSt = ModalidadeDeterminacaoBcIcmsSt.MargemValorAgregado;
            ModalidadeDeterminacaoBcIcms = ModalidadeDeterminacaoBcIcms.ValorOperacao;
        }

        public override void Calcula(ITributavel tributavel)
        {
            CalculaIcms(tributavel);

            CalculaIcmsSt(tributavel);

            CalculaCredito(tributavel);

			CalculaFcp(tributavel);

			CalculaFcpSt(tributavel);
		}


        private void CalculaCredito(ITributavel tributavel)
        {
            PercentualCredito = tributavel.PercentualCredito;

            switch (tributavel.Documento)
            {
                case Documento.MFe:
                case Documento.SAT:
                case Documento.MDFe:
                case Documento.NFCe:
                case Documento.CTeOs:
                case Documento.NFe:
                    var facade = new FacadeCalculadoraTributacao(tributavel, TipoDesconto);
                    var resultadoCalculaCredito = facade.CalculaIcmsCredito();
                    ValorCredito = resultadoCalculaCredito.Valor;
                break;

                case Documento.CTe:
                    var resultadoIcms = new FacadeCalculadoraTributacao(tributavel, TipoDesconto).CalculaIcms();
                    ValorCredito = resultadoIcms.Valor * tributavel.PercentualCredito / 100;
                break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void CalculaIcmsSt(ITributavel tributavel)
        {
            PercentualMva = tributavel.PercentualMva;
            PercentualReducaoSt = tributavel.PercentualReducaoSt;
            PercentualIcmsSt = tributavel.PercentualIcmsSt;

            var facade = new FacadeCalculadoraTributacao(tributavel, TipoDesconto);

            tributavel.ValorIpi = facade.CalculaIpi().Valor;

            var resultadoCalculoIcmsSt = facade.CalculaIcmsSt();

            ValorBcIcmsSt = resultadoCalculoIcmsSt.BaseCalculoIcmsSt;
            ValorIcmsSt = resultadoCalculoIcmsSt.ValorIcmsSt;
        }

        private void CalculaIcms(ITributavel tributavel)
        {
            PercentualReducaoIcmsBc = tributavel.PercentualReducao;
            PercentualIcms = tributavel.PercentualIcms;

            var facade = new FacadeCalculadoraTributacao(tributavel, TipoDesconto);

            tributavel.ValorIpi = facade.CalculaIpi().Valor;

            var resultadoCalculoIcms = facade.CalculaIcms();
            ValorBcIcms = resultadoCalculoIcms.BaseCalculo;
            ValorIcms = resultadoCalculoIcms.Valor;
        }

		private void CalculaFcp(ITributavel tributavel)
		{
			PercentualFcp = tributavel.PercentualFcp;

			var facade = new FacadeCalculadoraTributacao(tributavel, TipoDesconto);

			var resultadoCalculoFcp = facade.CalculaFcp();
			ValorBcFcp = resultadoCalculoFcp.BaseCalculo;
			ValorFcp = resultadoCalculoFcp.Valor;
		}

		private void CalculaFcpSt(ITributavel tributavel)
		{
			PercentualFcpSt = tributavel.PercentualFcpSt;

			var facade = new FacadeCalculadoraTributacao(tributavel, TipoDesconto);

			var resultadoCalculoFcpSt = facade.CalculaFcpSt();

			ValorBcFcpSt = resultadoCalculoFcpSt.BaseCalculoFcpSt;
			ValorFcpSt = resultadoCalculoFcpSt.ValorFcpSt;
		}

	}
}
