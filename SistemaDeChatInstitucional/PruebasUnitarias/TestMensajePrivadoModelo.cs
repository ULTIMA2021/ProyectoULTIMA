using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDeDatos;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestMensajePrivadoModelo
    {
        [TestMethod]
        public void TestEnviarMensaje(DateTime cp_mensajeFechaHora)
        {
            try
            {
                MensajePrivadoModelo mensaje = new MensajePrivadoModelo();

                mensaje.enviarMensaje(10, 10, 1, 1, "test", null, cp_mensajeFechaHora, "recibido",1);

                Assert.IsTrue(true);
            }
            catch 
            {

                Assert.IsTrue(false);
            }
        }
    }
}
