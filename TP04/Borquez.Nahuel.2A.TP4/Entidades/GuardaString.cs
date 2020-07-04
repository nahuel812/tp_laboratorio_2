using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {

        static StreamWriter sw;
        /// <summary>
        /// Guarda la informacion en un archivo de texto genereado en el escritorio
        /// </summary>
        /// <param name="texto">Texto a guardar</param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo;

                sw = new StreamWriter(path, true);
                sw.WriteLine(texto);
                
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al guardar el archivo.", ex);
                
            }
            finally
            {
                sw.Close();
            }
        }

    }
}
