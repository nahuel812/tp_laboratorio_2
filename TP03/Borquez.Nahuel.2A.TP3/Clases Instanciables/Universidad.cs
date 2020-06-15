using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;


        #region Propiedades e indexdaores

        /// <summary>
        /// Propiedad de lectura y escritura de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de isntructores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// indexador de jornada
        /// </summary>
        /// <param name="i">indice de la jornada solicitada</param>
        /// <returns>la jornada en el indice indicado</returns>
        public Jornada this[int i]
        {
            get
            {
                return this.Jornadas[i];
            }
            set
            {
                this.jornada.Insert(i, value);
            }
        }

        #endregion


        #region Constructor

        /// <summary>
        /// Constructor por defecto que inicializa los atributos de la universidad
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion
        

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del operador ==, entre universidad y alumno para saber si el alumno esta en la universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>True si esta en la uniersidad, false caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador !=,entre universidad y alumno para ver si no esta el alumno en la universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>True si no esta en la universidad,  false caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga del operador ==, entre universidad y profesor para ver si el profesor da clase en la universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>True si esta en la universidad,  false caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador !=, entre universidad y profesor para ver si el profesor NO da clase en la universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>True si NO esta en la universidad,  false caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga del operador == entre universidad y clase que retorna un profesor, busca un profesor que de esa clase
        /// </summary>
        /// <param name="u">Universidada a  comparar</param>
        /// <param name="clase">Clase a comparar </param>
        /// <returns>Un profesor nulo si no encuenntra profesor que de esa clase, caso contrario retorna un profesor que de esa clase </returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profAux = null;
            bool disponible = false;

            foreach (Profesor item in u.profesores)
            {
                if(item == clase)
                {
                    disponible = true;
                    profAux = item;
                    break;
                }
            }

            if(!disponible)
            {
                throw new SinProfesorException();
            }

            return profAux;
        }

        /// <summary>
        /// Sobrecarga del operador != entre universidad y clase que retorna un profesor, busca un profesor que NO de esa clase
        /// </summary>
        /// <param name="u">Universidad a comparar</param>
        /// <param name="clase"> Clase a comparar</param>
        /// <returns>Un profesor que de una clase distinta a la recivida como parametro, caso contrario un profesor en null</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profAux = null;
            bool disponible = false;

            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    disponible = true;
                    profAux = item;
                    break;
                }
            }

            if (!disponible)
            {
                throw new SinProfesorException();
            }

            return profAux;
        }

        /// <summary>
        /// Sobrecarga del operador + entre universidad y clase, crea una nueva joranda, le asigna un profesor y alumnos, agrega la jornada a la universidad.
        /// </summary>
        /// <param name="g">Universidad donde se agrega la clase</param>
        /// <param name="clase">clase a agregar</param>
        /// <returns>Universidad con la nueva clase</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesorAux = null;
            Jornada jornadaAux = null;

            try
            {
                profesorAux = (g == clase);
                if (profesorAux != null)
                {
                    jornadaAux = new Jornada(clase, profesorAux);

                    foreach (Alumno item in g.alumnos)
                    {
                        if (item == clase)
                        {
                            jornadaAux = jornadaAux + item;
                        }
                    }

                    g.jornada.Add(jornadaAux);
                }
            }
            catch (SinProfesorException e)
            {
                throw e;
            }
            return g;
        }

        /// <summary>
        /// Sobrecarga del operador + entre universidad y alumno, agrega el alumno a la lista de alumnos de la universidad  
        /// </summary>
        /// <param name="u">Universidad donde se agregara el alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>la universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            try
            {
                if (u != a)
                {
                    u.alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            catch (AlumnoRepetidoException e)
            {
                throw e;
            }

            return u;
        }

        /// <summary>
        /// Sobrecarga del operador + entre universidad y profesor, agrega el profesor a la universidad 
        /// </summary>
        /// <param name="u">Universidad donde se agregara</param>
        /// <param name="i"> Profesor a agregar</param>
        /// <returns>la universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Sobrecarga ToString muestra los datos de la universidad utilizando MostrarDatos
        /// </summary>
        /// <returns>string con los datos de la universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion


        #region Metodos
        /// <summary>
        /// Metodo MostrarDatos expone los datos de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada j in uni.Jornadas)
            {
                sb.Append(j.ToString());
                sb.AppendLine("<----------------------------------------------------->");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Metodo guardar, guarda los datos de la universidad en un archivo de tipo xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> universidadXml = new Xml<Universidad>();

            return universidadXml.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Metodo leer, lee los datos de un archivo xml 
        /// </summary>
        /// <returns>retorna la universidad leida</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> universidadXml = new Xml<Universidad>();

            Universidad universidad = null;

            if (universidadXml.Leer("Universidad.xml", out universidad) == false)
            {
                universidad = null;
            }

            return universidad;
        }

        #endregion

    }
}
