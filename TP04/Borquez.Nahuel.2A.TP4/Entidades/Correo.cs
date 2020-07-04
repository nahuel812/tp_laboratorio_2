using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
    
namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        
        /// <summary>
        /// Constructor por defecto de correo
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }
        

        /// <summary>
        /// Se encarga de cerrar todos los hilos 
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in mockPaquetes)
            {
                if (hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }
        
        /// <summary>
        /// Muestra todos los datos del correo 
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns> el string con los datos del correo</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete p in ((Correo)elementos).Paquetes)
            {
                sb.AppendFormat("{0} ({1})", p.ToString(), p.Estado.ToString());
                sb.AppendLine();
            }
            
            return sb.ToString();
        }
        

        /// <summary>
        /// Controla si el paquete ya esta en la lista
        /// </summary>
        /// <param name="c">Correo al que se le agregara el paquete</param>
        /// <param name="p">Paquete a ser agregad</param>
        /// <returns>El correo </returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (p == paquete)
                {
                    string message = String.Format("El trackingID {0} ya figura en la lista de envios.", p.TrackingID);
                    throw new TrackingIdRepetidoException(message);
                }
            }

            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }
        

    }
}
