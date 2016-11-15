using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ListaPendientesApp
{
    public partial class PendientePage : ContentPage
    {
        private AccesoDatosAdministrador _datosAcceso;
        private Pendiente _pendienteAModificar;

        public PendientePage(Pendiente pendienteAModificar = null)
        {
            InitializeComponent();
            _datosAcceso = new AccesoDatosAdministrador();
            if (pendienteAModificar != null)
            {
                txtDescripcion.Text = pendienteAModificar.Descripcion;
                dtFecha.Date = pendienteAModificar.Fecha;
                swHecho.IsToggled = pendienteAModificar.EstaHecho;
                _pendienteAModificar = pendienteAModificar;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (!string.IsNullOrEmpty(txtDescripcion.Text))
            {
                
                //TODO: Guardar información en una base de datos y archivarla.
                if (_pendienteAModificar != null)
                {
                    if (swHecho.IsToggled)
                    {
                        _datosAcceso.EliminarPendiente(_pendienteAModificar);
                    }
                    else
                    {
                        _pendienteAModificar.Descripcion = txtDescripcion.Text;
                        _pendienteAModificar.Fecha = dtFecha.Date;
                        _pendienteAModificar.EstaHecho = swHecho.IsToggled;
                        _datosAcceso.GuardarPendiente(_pendienteAModificar);
                    }
                }
                else
                {
                    Pendiente pendiente1 = new Pendiente();
                    pendiente1.Descripcion = txtDescripcion.Text;
                    pendiente1.Fecha = dtFecha.Date;
                    pendiente1.EstaHecho = swHecho.IsToggled;
                    _datosAcceso.GuardarPendiente(pendiente1);
                }
                
            }
        }
    }
}
