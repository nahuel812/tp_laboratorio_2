using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado,
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;


        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Sobrecarga del constructor de alumno conn 6 parametros
        /// </summary>
        /// <param name="id">id del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Sobrecarga del constructor de alumno conn 7 parametros
        /// </summary>
        /// <param name="id">id del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion


        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del metodo MostrarDatos
        /// </summary>
        /// <returns> Retorna un string con los datos del alumno </returns>

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());

            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendLine("ESTADO DE CUENTA: Cuota al dia");
                    break;

                case EEstadoCuenta.Becado:
                    sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
                    break;

                case EEstadoCuenta.Deudor:
                    sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
                    break;

                default:
                    break;
            }
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de metodo  ParticiparEnClase
        /// </summary>
        /// <returns> La clase que toma </returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASE DE {0}", this.claseQueToma);
        }

        /// <summary>
        /// Sobrecarga de metodo ToString()
        /// </summary>
        /// <returns> Retorna los datos del alumno utilizando MostrarDatos </returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        /// <summary>
        /// Sobrecarga == del alumno y el de una clase.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si el alumno toma la clase y no es deudor, false caso contrario </returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }

            return retorno;
        }


        /// <summary>
        /// Sobrecarga != del alumno y el de una clase.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si el alumno NO toma la clase, false caso contrario </returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (a.claseQueToma != clase)
            {
                retorno = true;
            }

            return retorno;
        }
        #endregion
    }
}
