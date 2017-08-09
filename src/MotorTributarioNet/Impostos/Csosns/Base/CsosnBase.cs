using System;
using MotorTributarioNet.Flags;

namespace MotorTributarioNet.Impostos.Csosns.Base
{
    public abstract class CsosnBase
    {
        public OrigemMercadoria OrigemMercadoria { get; }
        public Csosn Csosn { get; protected set; }
        public TipoDesconto TipoDesconto { get; set; }

        public CsosnBase(OrigemMercadoria origemMercadoria = OrigemMercadoria.Nacional, TipoDesconto tipoDesconto = TipoDesconto.Incondicional)
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