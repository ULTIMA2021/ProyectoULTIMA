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
                MensajePrivadoModelo mensaje = new MensajePrivadoModelo(1);
                DateTime fecha = DateTime.Now;
                mensaje.cp_mensajeFechaHora = new DateTime();
               // new ConsultaPrivadaModelo(1)

                mensaje.enviarMensaje(10, 7, 77777777, 11111111, "test", null, fecha, "recibido",11111111);

                Assert.IsTrue(true);
            }
            catch 
            {

                Assert.IsTrue(false);
            }
        }
    }
}
