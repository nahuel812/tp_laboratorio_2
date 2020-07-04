using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        
        
        public delegate void DelegadoEstado(object sender, EventArgs e);

        public event DelegadoEstado InformaEstado;
        
        
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        /// <summary>
        /// Constructor con 2 param
        /// </summary>
        /// <param name="direccionEntrega">direccion de entrega del paquete</param>
        /// <param name="trackingID">id de trakeo del paquete</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }
        

        /// <summary>
        /// Gestiona los estados del paquete y luego inserta sus datos en la db           
        /// </summary>
        public void MockCicloDeVida()
        {
            while (Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                Estado += 1;
                InformaEstado(this, null);
            }

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar paquete en la base de datos", ex);
            }
        }
        

        /// <summary>
        /// Muestra todos los datos de paquete 
        /// </summary>
        /// <param name="elemento">Paquete que se mostrara</param>
        /// <returns>El string con los datos del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }
        
        /// <summary>
        /// Dos paquetes son iguales si coincide su TrackingId
        /// </summary>
        /// <param name="p1">Paquete 1</param>
        /// <param name="p2">Pauqete 2</param>
        /// <returns>True si son iguales, false caso contrario</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID.Equals(p2.TrackingID);
        }
        /// <summary>
        /// Dos  paquetes NO son iguales si coincide su TrackingId
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>True si NO son iguales, false caso contrario</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        

        /// <summary>
        /// Sobrecarga que retorna la informacion del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

    }
}
