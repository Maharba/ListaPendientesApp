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

        public PendientePage()
        {
            InitializeComponent();

            _datosAcceso = new AccesoDatosAdministrador();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (!string.IsNullOrEmpty(txtDescripcion.Text))
            {
                //TODO: Guardar información en una base de datos y archivarla.
                Pendiente pendiente1 = new Pendiente();
                pendiente1.Descripcion = txtDescripcion.Text;
                pendiente1.Fecha = dtFecha.Date;
                pendiente1.EstaHecho = swHecho.IsToggled;
                _datosAcceso.GuardarPendiente(pendiente1);
            }
        }
    }
}
