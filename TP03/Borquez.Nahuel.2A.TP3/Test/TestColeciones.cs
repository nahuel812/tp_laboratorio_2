using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
using EntidadesAbstractas;

namespace Test
{
    [TestClass]
    public class TestColeciones
    {
        [TestMethod]
        public void InstanciarProfesorTest()
        {
            //Jornada j = null;
            Jornada j = new Jornada(Universidad.EClases.Laboratorio,new Profesor(1,"Pablo","Ortiz","4234355",Persona.ENacionalidad.Argentino));

            Assert.IsNotNull(j.Alumnos);
        }


    }
}
