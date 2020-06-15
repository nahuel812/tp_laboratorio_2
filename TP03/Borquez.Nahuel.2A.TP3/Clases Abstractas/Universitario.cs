using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;
        
        #region Constructores

        /// <summary>
        /// Constructor por defecto de Universitario.
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Soibrecarga del constructor de Universitario con 5 parametros.
        /// </summary>
        /// <param name="legajo"> Legajo de universitario </param>
        /// <param name="nombre"> Nombre de universitario </param>
        /// <param name="apellido"> Apellido de unviersitario </param>
        /// <param name="dni"> DNI del universitario </param>
        /// <param name="nacionalidad"> Nacionalidad de universitario </param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion


        #region Metodos

        /// <summary>
        /// Metodo que muestra los datos de Universitario.
        /// </summary>
        /// <returns> Datos del universitario </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendFormat("LEGAJO NUMERO: {0}", this.legajo);

            return sb.ToString();

        }

        /// <summary>
        /// Metodo abstracto ParticiparEnClase.
        /// </summary>
        protected abstract string ParticiparEnClase();
        #endregion


        #region Sobrecargas

        /// <summary>
        /// Sobrecarga Equals. Compara si son del mismo tipo.
        /// </summary> 
        /// <param name="obj"> Objeto que se va a comparar </param>
        /// <returns> True si son iguales, false caso contrario </returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj != null)
            {
                retorno = (obj.GetType() == this.GetType());
            }
            return retorno;
        }


        /// <summary>
        /// Sobrecarga del operador ==. Para saber si sus legajos y DNI son iguales.
        /// </summary>
        /// <param name="pg1"> Universitario 1 </param>
        /// <param name="pg2"> Universitario 2 </param>
        /// <returns> True si son iguales, false caso contrario </returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if ( pg1.Equals(pg2) && ((pg1.legajo == pg2.legajo) || (pg1.DNI == pg2.DNI)) )
            {
                retorno = true;
            }

            return retorno;
        }


        /// <summary>
        /// Sobrecarga del operador !=. Para saber si sus legajos y DNI son distintos.
        /// </summary>
        /// <param name="pg1"> Universitario 1 </param>
        /// <param name="pg2"> Universitario 2 </param>
        /// <returns> True si son distintos, false caso contrario </returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
