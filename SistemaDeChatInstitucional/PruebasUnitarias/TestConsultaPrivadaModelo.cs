using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDeDatos;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestConsultaPrivadaModelo
    {
        [TestMethod]
        public void TestCrearConsultaPrivada()
        {
            try
            {
                ConsultaPrivadaModelo consulta = new ConsultaPrivadaModelo(2);
                consulta.cpFechaHora = new DateTime();
                
                consulta.crearConsultaPrivada(int.Parse("18"),"77777777","11111111","test","pendiente",consulta.cpFechaHora);


                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);

            }
        }

        //[TestMethod]
        //public void TestObtenerConsulta(string ciAlumno)
        //{

        // try
        // {
        //ciAlumno = "11111111";
        //ConsultaPrivadaModelo cons = new ConsultaPrivadaModelo();
        //cons = cons.getConsultas();


        //}
        //catch
        //{
        //Assert.IsTrue(false);

        //}

        //}
    }
}