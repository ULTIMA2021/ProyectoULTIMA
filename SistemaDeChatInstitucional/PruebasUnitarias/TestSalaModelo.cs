using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDeDatos;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestSalaModelo
    {
        [TestMethod]
        public void TestCrearSala()
        {
            try
            {


                SalaModelo sala = new SalaModelo();

                sala.idGrupo = int.Parse("1");
                sala.idMateria = int.Parse("1");
                sala.docenteCi = int.Parse("77777777");
                sala.anfitrion = int.Parse("1");
                sala.resumen = "resumen";
                sala.creacion = new DateTime();
                sala.isDone = false;
                sala.crearSala();

                Assert.IsTrue(true);
            }
            catch
            {

                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestUpdateResumen()
        {
            try
            {


                SalaModelo sala = new SalaModelo();

             
                sala.resumen = "resumen";
                sala.idSala = int.Parse("111");
                sala.salaResumenUpdate();
            }
            catch
            {

                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestUpdateEstado()
        {
            try
            {


                SalaModelo sala = new SalaModelo();
                sala.updateEstado("111", true);
            }
            catch
            {

                Assert.IsTrue(false);
            }
        }

        
        
    }

}

