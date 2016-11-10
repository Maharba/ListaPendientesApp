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
            _conexionBaseDatos.CreateTable<Pendiente>();
            Pendientes = new ObservableCollection<Pendiente>(_conexionBaseDatos.Table<Pendiente>());
        }

        public List<Pendiente> ObtenerListaPendientes()
        {
            return _conexionBaseDatos.Table<Pendiente>().ToList();
        }

        public Pendiente ObtenerPendiente(int id)
        {
            var consulta =
                Pendientes.SingleOrDefault(p => p.ID == id);
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

        public void EliminarPendiente(Pendiente pendiente)
        {
            var id = pendiente.ID;
            var consulta =
                _conexionBaseDatos.Table<Pendiente>()
                    .FirstOrDefault(
                        p =>
                            p.Descripcion == pendiente.Descripcion && p.EstaHecho == pendiente.EstaHecho &&
                            p.Fecha == pendiente.Fecha);
            
            if (consulta.ID != 0)
            {
                _conexionBaseDatos.Delete<Pendiente>(consulta.ID);
                Pendientes.Remove(pendiente);
            }
        }

        public void GuardarPendiente(Pendiente pendiente)
        {
            if (pendiente.ID != 0)
            {
                var consulta = Pendientes.SingleOrDefault(p => p.ID == pendiente.ID);
                if (consulta != null)
                {
                    consulta.Descripcion = pendiente.Descripcion;
                    consulta.Fecha = pendiente.Fecha;
                    consulta.EstaHecho = pendiente.EstaHecho;
                    _conexionBaseDatos.Update(pendiente);
                }
                
            }
            else
            {
                AgregarPendiente(pendiente.Descripcion, pendiente.Fecha, pendiente.EstaHecho);
                _conexionBaseDatos.Insert(pendiente);
            }
        }
    }
}
