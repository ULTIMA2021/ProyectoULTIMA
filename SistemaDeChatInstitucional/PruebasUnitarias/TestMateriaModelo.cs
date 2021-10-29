using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaDeDatos;

namespace PruebasUnitarias
{
    [TestClass]
    public class TestMateriaModelo
    {
        [TestMethod]
        public void TestAltaMateria()
        {
            try
            {
                MateriaModelo materia = new MateriaModelo(2);

                materia.nombreMateria = "Biologia";
                materia.crearMateriaNueva();
                Assert.IsTrue(true);

            }
            catch 
            {

                Assert.IsTrue(false);
            }
            
        }

        [TestMethod]
        public void TestEstadoMateria()
        {
            try
            {
                MateriaModelo materia = new MateriaModelo(2);

                materia.actualizarEstadoDeMateria(true, "1");
                Assert.IsTrue(true);
                MateriaModelo mate = new MateriaModelo(2);
                mate.actualizarEstadoDeMateria(false, "1");


            }
            catch
            {

                Assert.IsTrue(false);
            }

            
        }

        [TestMethod]
        public void TestNombreMateria()
        {
            try
            {
                MateriaModelo materia = new MateriaModelo(2);

                materia.actualizarNombreDeMateria("test", "1");
                Assert.IsTrue(true);

                MateriaModelo mate = new MateriaModelo(2);
                mate.actualizarNombreDeMateria("mat1", "1");


            }
            catch
            {

                Assert.IsTrue(false);
            }


        }

        [TestMethod]
        public void TestGetMateria(string nombreMateria)
        {
            try
            {
                nombreMateria = "mat1";
                MateriaModelo materia = new MateriaModelo(2);
                materia.getMateria(nombreMateria);
                Assert.IsNotNull(materia.idMateria);

            }
            catch
            {

                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestCountSalaMateria()
        {
            try
            {

                MateriaModelo materia = new MateriaModelo(2);
                materia.idMateria = int.Parse("1");
                materia.countSalaPorMateria();

                Assert.IsTrue(true);

            }
            catch
            {

                Assert.IsTrue(false);
            }
        }

    }
}
