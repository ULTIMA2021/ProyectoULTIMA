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
                GrupoModelo grupo = new GrupoModelo();
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
        public void TestAlumnoTieneGrupo(string ci)
        {
            try
            {
                GrupoModelo grupo = new GrupoModelo();
                grupo.countAlumnoTieneGrupo("11111111");

                Assert.IsTrue(true);
            }
            catch
            {

                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestDocenteTieneGrupo(string ci)
        {
            try
            {
                GrupoModelo grupo = new GrupoModelo();
                grupo.countDocenteDictaGrupo("77777777");

                Assert.IsTrue(true);
            }
            catch
            {

                Assert.IsTrue(false);
            }
        }


        [TestMethod]
        public void TestIngresoAlumnoTieneGrupo(string alumnoCi, int idGrupo)
        {
            try
            {
                GrupoModelo grupo = new GrupoModelo();
                grupo.nuevoIngresoAlumnoTieneGrupo("11111111", int.Parse("1"));

                Assert.IsTrue(true);
            }
            catch
            {

                Assert.IsTrue(false);
            }
        }


        [TestMethod]
        public void TestIngresoDocenteTieneGM(string docenteCi, int idGrupo, int idMateria)
        {
            try
            {
                GrupoModelo grupo = new GrupoModelo();
                grupo.nuevoIngresoDocenteTieneGM("77777777", int.Parse("1"), int.Parse("1"));

                Assert.IsTrue(true);
            }
            catch
            {

                Assert.IsTrue(false);
            }
        }


    }
}
