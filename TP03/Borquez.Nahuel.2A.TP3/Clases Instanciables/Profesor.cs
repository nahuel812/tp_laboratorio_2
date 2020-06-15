using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        

        #region Constructores

        /// <summary>
        /// Constructor estatico, inicializa el atributo random.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// Sobrecargaa del constructor de profesor con 5 parametros
        /// </summary>
        /// <param name="id">id del profesor</param>
        /// <param name="nombre">Nombre del profesor</param>
        /// <param name="apellido">Apellido del profesor</param>
        /// <param name="dni">DNI del profesor</param>
        /// <param name="nacionalidad">Nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion


        #region Metodos    

        /// <summary>
        /// Metodo que asigna dos clases al atributo clasesDelDia del profesor
        /// </summary>
        private void _randomClases()
        {
            int i;

            for (i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 3));
            }

        }
        #endregion


        #region Sobrecargas

        /// <summary>
        /// Sobrecarga de metodo ParticiparEnClase
        /// </summary>
        /// <returns> Retorna el nombre de la clases que da el profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASES DEL DIA:\n");
            
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }


        /// <summary>
        /// Sobrecarga del metodo MostrarDatos
        /// </summary>
        /// <returns> Retorna en string todos los datos de profesor </returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }


        /// <summary>
        /// Sobrecara de metodo ToString que utiliza MostrarDatos
        /// </summary>
        /// <returns> Retorna los datos del profesor </returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        /// <summary>
        /// Sobrecarga operador == , el profesor es igual a la clase si da esa clase
        /// </summary>
        /// <param name="i"> Profesor a comparar </param>
        /// <param name="clase"> Clase a comparar </param>
        /// <returns>True si el profesor da la clase, false caso contrario</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (clase == item)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga operador == El profesor es distinto a la clase si NO da esa clase
        /// </summary>
        /// <param name="i"> Profesor a comparar </param>
        /// <param name="clase"> Clase a comparar </param>
        /// <returns>True si el profesor NO da la clase, false caso contrario </returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        
        #endregion
    }
}
