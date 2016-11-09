using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace ListaPendientesApp
{
    public class AccesoDatosAdministrador
    {
        private SQLiteConnection _conexionBaseDatos;
        private static object colisionLock = new object();

        public ObservableCollection<Pendiente> Pendientes { get; set; }

        public AccesoDatosAdministrador()
        {
            var dependencia = DependencyService.Get<ISQLite>();
            _conexionBaseDatos = dependencia.ObtenerConexion();
            Pendientes = new ObservableCollection<Pendiente>(_conexionBaseDatos.Table<Pendiente>());
        }

        public ObservableCollection<Pendiente> ObtenerListaPendientes()
        {
            return Pendientes;
        }

        public Pendiente ObtenerPendiente(string descripcion, DateTime fecha, bool estahecho)
        {
            var consulta =
                Pendientes.SingleOrDefault(
                    p => p.Descripcion == descripcion && p.Fecha == fecha && p.EstaHecho == estahecho);
            return consulta;
        }

        public void AgregarPendiente(string descripcion, DateTime fecha, bool estahecho)
        {
            Pendiente pendiente = new Pendiente()
            {
                Descripcion = descripcion,
                Fecha = fecha,
                EstaHecho = estahecho
            };
            Pendientes.Add(pendiente);
        }
    }
}
