using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorTributarioNet.Util;

namespace TestCalculosTributarios.UtilsTestes
{
    [TestClass]
    public class DecimalUtilsTestes
    {
        [TestMethod]
        public void Arredondar_ValorNulo_DeveRetornarNull()
        {
            // arrange
            decimal? valor = null;

            // action
            var retorno = valor.Arredondar();

            // assert
            Assert.AreEqual(null, retorno);
        }

        [TestMethod]
        public void Arredondar_Valor_DeveRetornarValido()
        {
            // arrange
            decimal? valor = 10.0m;

            // action
            var retorno = valor.Arredondar();

            // assert
            Assert.AreEqual(10.00m, retorno);
        }

        [TestMethod]
        public void ArredondarUp_ValorNulo_DeveRetornarNull()
        {
            // arrange
            decimal? valor = null;

            // action
            var retorno = valor.ArredondarUP();

            // assert
            Assert.AreEqual(null, retorno);
        }

        [TestMethod]
        public void ArredondarUp_Valor_DeveRetornarValido()
        {
            // arrange
            decimal? valor = 10.0m;

            // action
            var retorno = valor.ArredondarUP();

            // assert
            Assert.AreEqual(10.00m, retorno);
        }
    }
}