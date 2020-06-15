using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
using EntidadesAbstractas;

namespace Test
{
    [TestClass]
    public class TestExcepciones
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalidoExceptionTest()
        {
            Alumno a = new Alumno(1, "Roberto", "Daga", "152JKSFDJ", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }
        
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetidoExceptionTest()
        {
            Universidad u = new Universidad();

            Alumno a = new Alumno(1, "Roberto", "Daga", "15255454", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            u += a;
            u += a;

        }


    }
}
