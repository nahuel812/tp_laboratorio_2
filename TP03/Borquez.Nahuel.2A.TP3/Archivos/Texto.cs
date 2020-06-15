using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter sw;
            bool escribio = false;

            try
            {
                using (sw = new StreamWriter(archivo))
                {
                    sw.WriteLine(datos);
                    escribio = true;
                }
                if (!escribio)
                {
                    throw new ArchivosException(new Exception("Ocurrido un error al guardar el archivo."));
                }
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }

            return escribio;
        }


        public bool Leer(string archivo, out string datos)
        {
            StreamReader sr;
            bool escribio = false;
            
            try
            {
                if (File.Exists(archivo))
                {
                    using (sr = new StreamReader(archivo))
                    {
                        datos = sr.ReadToEnd();
                        escribio = true;
                    }

                    if (!escribio)
                    {
                        throw new ArchivosException(new Exception("Ocurrido un error al guardar el archivo."));
                    }
                }
                else
                {
                    throw new ArchivosException(new Exception("Archivo inexistente."));
                }
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }
            
            return escribio;
        }
    }
}
