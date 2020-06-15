using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                if (archivo != null)
                {
                    using (XmlTextWriter xmlWriter = new XmlTextWriter(archivo, Encoding.UTF8))
                    {
                        if (xmlWriter != null)
                        {
                            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                            xmlSer.Serialize(xmlWriter, datos);
                            retorno = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }


        public bool Leer(string archivo, out T datos)
        {
            datos = default(T);
            bool retorno = false;

            try
            {
                if (!File.Exists(archivo))
                {
                    throw new ArchivosException(new Exception("Error archivo inexistente."));
                }

                using (XmlTextReader xmlReader = new XmlTextReader(archivo) )
                {
                    if (xmlReader != null)
                    {
                        XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                        datos = (T)xmlSer.Deserialize(xmlReader);
                        retorno = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}