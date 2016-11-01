using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaPendientesApp
{
    public class Pendiente
    {
        /// <summary>
        /// Esta es la descripción de la tarea pendiente
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Esta es la fecha de la tarea pendiente
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Determina si la tarea pendiente está terminada o no
        /// </summary>
        public bool EstaHecho { get; set; }
    }
}
