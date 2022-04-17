using MotorTributarioNet.Util;
using Xunit;

namespace TestCalculosTributarios.UtilsTestes
{
    public class DecimalUtilsTestes
    {
        [Fact]
        public void Arredondar_ValorNulo_DeveRetornarNull()
        {
            // arrange
            decimal? valor = null;

            // action
            var retorno = valor.Arredondar();

            // assert
            Assert.Equal(null, retorno);
        }

        [Fact]
        public void Arredondar_Valor_DeveRetornarValido()
        {
            // arrange
            decimal? valor = 10.0m;

            // action
            var retorno = valor.Arredondar();

            // assert
            Assert.Equal(10.00m, retorno);
        }

        [Fact]
        public void ArredondarUp_ValorNulo_DeveRetornarNull()
        {
            // arrange
            decimal? valor = null;

            // action
            var retorno = valor.ArredondarUP();

            // assert
            Assert.Null(retorno);
        }

        [Fact]
        public void ArredondarUp_Valor_DeveRetornarValido()
        {
            // arrange
            decimal? valor = 10.0m;

            // action
            var retorno = valor.ArredondarUP();

            // assert
            Assert.Equal(10.00m, retorno);
        }
    }
}