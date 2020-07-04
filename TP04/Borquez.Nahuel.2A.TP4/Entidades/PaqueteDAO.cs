using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
 

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;


        /// <summary>
        /// Establece la conexion con la base de datos
        /// </summary>
        static PaqueteDAO()
        {
            
            try
            {
                conexion = new SqlConnection(Properties.Settings.Default.conexion);
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la conexion con la base de datos", ex);
            }
        }

        /// <summary>
        /// Inserta en la base de datos un paquete 
        /// </summary>
        /// <param name="p">paquete que se va a guardar en la base</param>
        /// <returns>True si inserto con exito, false y una excepcion si ocurrio un error</returns>
        public static bool Insertar(Paquete p)
        {
            bool respuesta = false;

            try
            {
                string consulta = String.Format("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) " + "VALUES ('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Nahuel Borquez");
                comando.CommandText = consulta;

                conexion.Open();
                comando.ExecuteNonQuery();

                respuesta = true;
            }
            catch (Exception ex)
            {
                string message = String.Format("Error al guardar el paquete {0} en la base de datos", p.ToString());

                throw new Exception(message, ex);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return respuesta;
        }
        
    }
}
