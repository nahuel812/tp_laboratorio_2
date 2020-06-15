using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;


        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura que valida que se haya ingresado un apellido.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }


        /// <summary>
        /// Propiedad de lectura y escritura que valida que se haya ingresado un nombe.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que valida que se haya ingresado un DNI.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para el enumerado Nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad de solo escritura para el atributo DNI
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de Persona, por defecto.
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Sobrecarga del constructor de Persona con 3 parametros
        /// </summary>
        /// <param name="nombre"> Nombre de la persona </param>
        /// <param name="apellido"> Apellido de la persona </param>
        /// <param name="nacionalidad"> Nacionalidad de persona </param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nacionalidad = nacionalidad;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        /// <summary>
        /// Sobrecarga del constructor de Persona con 4 parametros
        /// </summary>
        /// <param name="nombre"> Nombre de persona </param>
        /// <param name="apellido"> Apellido de persona </param>
        /// <param name="dni"> Dni de persona </param>
        /// <param name="nacionalidad"> Nacionalidad de persona </param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Sobrecarga del constructor de Persona con 4 parametros,utiliza StringToDNI.
        /// </summary>
        /// <param name="nombre"> Nombre de persona </param>
        /// <param name="apellido"> Apellido de persona </param>
        /// <param name="dni"> Dni de persona </param>
        /// <param name="nacionalidad"> Nacionalidad de persona </param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion


        #region Metodos

        /// <summary>
        /// Valida el formato del DNI dependiendo de la nacionalidad de la persona.
        /// </summary>
        /// <param name="nacionalidad"> Nacionalidad de la persona </param>
        /// <param name="dato"> Dni a validar </param>
        /// <returns> Retorna el dni  de la person a</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = -1;

            if (dato.Length <= 8 && Int32.TryParse(dato, out dni))
            {
                int dni = Int32.Parse(dato);

                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:

                        if (dni > 0 && dni < 90000000)
                        {
                            retorno = dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException();
                        }

                        break;

                    case ENacionalidad.Extranjero:

                        if (dni > 89999999 && dni <= 99999999)
                        {
                            retorno = dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException();
                        }

                        break;

                    default:
                        break;
                }
            }
            else
            {
                throw new DniInvalidoException("Error. DNI Incorrecto");
            }

            return retorno;
        }

        /// <summary>
        /// Valida el formato del DNI dependiendo de la nacionalidad de la ´persona. Pero validando el DNI como STRING.
        /// </summary>
        /// <param name="nacionalidad"> Nacionalidad de persona </param>
        /// <param name="dato"> Dni de persona </param>
        /// <returns> Retorna el dni de la persona </returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return this.ValidarDni(nacionalidad, dato.ToString());
        }


        /// <summary>
        /// Valida que los nombres tengan solamente caracteres qué sean validos.
        /// </summary>
        /// <param name="dato"> Nombre de persona </param>
        /// <returns> Retorna una cadena que pude ser el nombre o el apellido </returns>
        private string ValidarNombreApellido(string dato)
        {
            bool retorno = true;

            foreach (char item in dato)
            {
                if (!(char.IsLetter(item)))
                {
                    retorno = false;
                    break;
                }
            }

            if (retorno != true)
            {
                throw new Exception("Error. No se puede cargar el nombre/apellido.");
            }

            return dato;
        }
        #endregion


        #region SobrecargasMetodos

        /// <summary>
        /// Sobrecarga el metodo ToString().
        /// </summary>
        /// <returns> Retorna una cadena con los datos de la persona </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.apellido, this.nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.nacionalidad);

            return sb.ToString();
        }
        #endregion
        
    }
}
