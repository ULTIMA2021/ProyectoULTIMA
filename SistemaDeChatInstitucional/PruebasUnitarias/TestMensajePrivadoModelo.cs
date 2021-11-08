using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDeDatos;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestMensajePrivadoModelo
    {
        [TestMethod]
        public void TestEnviarMensaje()
        {
            try
            {
                new MensajePrivadoModelo(2).enviarMensaje(7, 1, 77777777, 11111111, "test", null, DateTime.Now, "recibido",11111111);
                Assert.IsTrue(true);
            }
            catch 
            {
                Assert.IsTrue(false);
            }
        }
    }
}
