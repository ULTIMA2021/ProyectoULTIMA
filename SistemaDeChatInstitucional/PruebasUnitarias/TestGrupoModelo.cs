using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDeDatos;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestGrupoModelo
    {
        [TestMethod]
        public void TestAltaGrupo()
        {
            try
            {
                GrupoModelo grupo = new GrupoModelo(2);
                grupo.nombreGrupo = "Test";
                grupo.crearGrupoNuevo();

                Assert.IsTrue(true);
            }
            catch 
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestBajaGrupo()
        {
            try
            {
                GrupoModelo grupo = new GrupoModelo(2);
                grupo.nombreGrupo = "BORRAME";
                grupo.crearGrupoNuevo();
                grupo.borrarGrupo(grupo.getGrupo("BORRAME"));

                if (string.IsNullOrEmpty(grupo.getGrupo("BORRAME")))
                    Assert.IsTrue(true);
                else
                    Assert.IsTrue(false);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }


        [TestMethod]
        public void TestAlumnoTieneGrupo()
        {
            try
            {
                GrupoModelo grupo = new GrupoModelo(2);
                if (grupo.countAlumnoTieneGrupo("11111111")!="0")
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestDocenteTieneGrupo()
        {
            try
            {
                GrupoModelo grupo = new GrupoModelo(2);
                grupo.countDocenteDictaGrupo("77777777");

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestIngresoAlumnoTieneGrupo()
        {
            try
            {
                GrupoModelo grupo = new GrupoModelo(2);
                grupo.nuevoIngresoAlumnoTieneGrupo("11111111", int.Parse("4"));

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestIngresoDocenteTieneGM()
        {
            try
            {
                GrupoModelo grupo = new GrupoModelo(2);
                grupo.actualizarDocenteTieneGM("77777777", "1", "1");
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }


    }
}
