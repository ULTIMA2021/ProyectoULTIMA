using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDeDatos;
using MySql.Data.MySqlClient;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestPersonaModelo
    {
        [TestMethod]
        public void TestAltaPersona()
        {
            try
            {
                PersonaModelo p = new PersonaModelo(2);
                p.Cedula = "11111122";
                p.Nombre = "Juan";
                p.Apellido = "Aguiar";
                p.Clave = "11111122";
                p.foto = null;
                p.GuardarPersona();


                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);

            }

        }

        [TestMethod]
        public void TestAltaAlumno()
        {

            try
            {
                PersonaModelo p = new PersonaModelo(2);
                p.Cedula = "11111222";
                p.Apodo = "Juancito";
                p.guardarAlumno();

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);

            }

        }

        [TestMethod]
        public void TestAltaAlumnoTemp(string Grupos)
        {

            try
            {
                PersonaModelo p = new PersonaModelo(2);
                p.Cedula = "11111122";
                p.Nombre = "Juan";
                p.Apellido = "Aguiar";
                p.Clave = "11111122";
                p.foto = null;
                p.Apodo = "Juancito";
                p.Grupos = null;
                p.GuardarPersona();

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);

            }

        }

        [TestMethod]
        public void TestAltaDocente()
        {

            try
            {
                PersonaModelo p = new PersonaModelo(2);
                p.Cedula = "11111113";
                //p.GuardarPersona();
                p.guardarDocente();

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);

            }

        }

        [TestMethod]
        public void TestAltaAdmin()
        {

            try
            {
                PersonaModelo p = new PersonaModelo(2);
                p.Cedula = "11111114";
                p.guardarAdmin();

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);

            }

        }










        [TestMethod]
        public void TestObtenerPersona(string cedula)
        {

            try
            {
                cedula = "11111111";
                PersonaModelo p = new PersonaModelo(2);
                p = p.obtenerPersona(cedula);

                Assert.IsNotNull(p.Cedula);
                Assert.IsNotNull(p.Nombre);
                Assert.IsNotNull(p.Apellido);
                
                
            }
            catch
            {
                Assert.IsTrue(false);

            }

        }

        [TestMethod]
        public void TestObtenerAlumnoTemp()
        {

            try
            {
                PersonaModelo p = new PersonaModelo(2);
                p.obtenerAlumnoTemp();

                Assert.IsNotNull(p.Cedula);
                Assert.IsNotNull(p.Nombre);
                Assert.IsNotNull(p.Apellido);
                Assert.IsNotNull(p.Apodo);
                Assert.IsNotNull(p.Grupos);


            }
            catch
            {
                Assert.IsTrue(false);

            }

        }

        //[TestMethod]
        //public void Test()
        //{

        //    try
        //    {
        //        PersonaModelo p = new PersonaModelo();
        //        p.obtenerAlumnoTemp();

        //        Assert.IsNotNull(p.Cedula);
        //        Assert.IsNotNull(p.Nombre);
        //        Assert.IsNotNull(p.Apellido);
        //        Assert.IsNotNull(p.Apodo);
        //        Assert.IsNotNull(p.Grupos);


        //    }
        //    catch
        //    {
        //        Assert.IsTrue(false);

        //    }

        //}
    }
}
