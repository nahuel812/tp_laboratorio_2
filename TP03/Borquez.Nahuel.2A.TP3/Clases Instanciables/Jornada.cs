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
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Propiedades

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
        /// Propiedad de lectura y escritura de clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defector de jronada
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Sobrecarga del constructor de jornada con 2 parametros
        /// </summary>
        /// <param name="clase">clase de la jornada</param>
        /// <param name="instructor">instructor de la jornada </param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        
        #endregion


        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del operador ==, si el alumno participa en la jornada
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>true si participa de la jornada, false caso contrario</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return (a == j.Clase);
        }

        /// <summary>
        /// Sobrecarga del operador !=, si el alumno NO participa en la jornada
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>True si no participa, false caso contrario</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j==a);
        }

        /// <summary>
        /// Sobrecarga del operador +, agrega al alumno a al ajornada si no esta en ella
        /// </summary>
        /// <param name="j">jornada </param>
        /// <param name="a">alumno a agregar a la jornada</param>
        /// <returns>la jornada, independientemente si se pudo agregar el alumno a la jornada </returns>
        public static Jornada operator + (Jornada j, Alumno a)
        {

            foreach (Alumno item in j.alumnos)
            {
                if(item == a)
                {
                    return j;
                }

            }
            
            j.alumnos.Add(a);

            return j;
        }

        /// <summary>
        /// Sobrecarga del ToString
        /// </summary>
        /// <returns>string con los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\nJORNADA:");
            sb.AppendFormat("CLASE DE {0} POR {1}\n",this.Clase, this.Instructor.ToString() );
            sb.AppendLine("ALUMNOS:");

            foreach (Alumno item in this.Alumnos)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Archivos

        /// <summary>
        /// Metodo que guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="j">Jornada a guardar</param>
        /// <returns>bool, si pudo o no guardarse la misma.</returns>
        public static bool Guardar(Jornada j)
        {
            Texto txt = new Texto();

            return txt.Guardar("jornadas.txt", j.ToString());
        }

        /// <summary>
        /// Metodo que lee los datos de una jornada de un archivo de  texto texto.
        /// </summary>
        /// <returns>string con lo que leyo del archivo de texto</returns>
        public static string Leer()
        {

            Texto serializador = new Texto();
            string jornadaLeida = string.Empty;

            serializador.Leer("Jornadas.txt", out jornadaLeida);

            return jornadaLeida;
        }
        #endregion
    }
}
