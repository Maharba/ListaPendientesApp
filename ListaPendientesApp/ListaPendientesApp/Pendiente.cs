using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace ListaPendientesApp
{
    [Table("Pendiente1")]
    public class Pendiente : INotifyPropertyChanged
    {
        private string _descripcion;
        private DateTime _fecha;
        private bool _estaHecho;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// El ID de cada registro de Pendiente
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int ID { get; set;  }

        /// <summary>
        /// Esta es la descripción de la tarea pendiente
        /// </summary>
        [NotNull, MaxLength(148)]
        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = value;
                PropiedadCambiada(nameof(Descripcion));
            }
        }

        /// <summary>
        /// Esta es la fecha de la tarea pendiente
        /// </summary>
        public DateTime Fecha
        {
            get {  return _fecha; }
            set
            {
                _fecha = value;
                PropiedadCambiada(nameof(Fecha));
            }
        }

        /// <summary>
        /// Determina si la tarea pendiente está terminada o no
        /// </summary>
        public bool EstaHecho
        {
            get { return _estaHecho; }
            set
            {
                _estaHecho = value;
                PropiedadCambiada(nameof(EstaHecho));
            }
        }

        private void PropiedadCambiada(string nombrePropiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
            }
        }
    }
}
