using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Metodo de interfaz guardar
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>True si logro guardar, false caso contrario</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Metodo de interfaz leer
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">donde se guardaran los datos leidos del archivo</param>
        /// <returns>True si pudo leer, false caso contrario</returns>
        bool Leer(string archivo, out T datos);
    }
}
