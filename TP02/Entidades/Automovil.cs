using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        public enum ETipo { Monovolumen, Sedan }
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca">Marca del automovil</param>
        /// <param name="chasis">Nombre del chasis del automovil</param>
        /// <param name="color">Color del automovil</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {
            this.tipo = ETipo.Monovolumen;
        }
        /// <summary>
        /// Sobrecarga del constructor parametrizado de automovil
        /// </summary>
        /// <param name="marca">Marca del automovil</param>
        /// <param name="chasis">Nombre del chasis del automovil</param>
        /// <param name="color">Color del automovil</param>
        /// <param name="tipo">Tipo de automovil</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color,ETipo tipo) : this(marca, chasis, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Muestra los datos del automovil
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
