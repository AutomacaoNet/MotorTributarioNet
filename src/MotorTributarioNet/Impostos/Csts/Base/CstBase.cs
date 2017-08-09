using MotorTributarioNet.Flags;
using System;

namespace MotorTributarioNet.Impostos.Csts.Base
{
    public abstract class CstBase
    {
        public OrigemMercadoria OrigemMercadoria { get; }
        public Cst Cst { get; protected set; }
        public TipoDesconto TipoDesconto { get; set; }

        public CstBase(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional)
        {
            OrigemMercadoria = origemMercadoria;
            TipoDesconto = tipoDesconto;
        }

        public virtual void Calcula(ITributavel tributavel)
        {
            throw new ArgumentException("Não existe calculo!");
        }
    }
}
