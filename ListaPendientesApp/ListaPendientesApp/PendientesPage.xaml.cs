using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ListaPendientesApp
{
    public partial class PendientesPage : ContentPage
    {
        private AccesoDatosAdministrador _accesoDatos;

        public PendientesPage()
        {
            InitializeComponent();

            tbiAgregar.Clicked += TbiAgregarOnClicked;
            tbiModificar.Clicked += TbiModificarOnClicked;
            tbiEliminar.Clicked += TbiEliminarOnClicked;

            _accesoDatos = new AccesoDatosAdministrador();
            lstPendientes.IsPullToRefreshEnabled = true;
            lstPendientes.Refreshing += LstPendientesOnRefreshing;

        }

        private void TbiEliminarOnClicked(object sender, EventArgs eventArgs)
        {
            Pendiente pendienteSeleccionado = lstPendientes.SelectedItem as Pendiente;
            if (pendienteSeleccionado != null)
            {
                _accesoDatos.EliminarPendiente(pendienteSeleccionado);
                lstPendientes.ItemsSource = _accesoDatos.ObtenerListaPendientes();
            }
        }

        private void TbiModificarOnClicked(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        private void LstPendientesOnRefreshing(object sender, EventArgs eventArgs)
        {
            lstPendientes.ItemsSource = _accesoDatos.ObtenerListaPendientes();
            lstPendientes.IsRefreshing = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lstPendientes.ItemsSource = _accesoDatos.ObtenerListaPendientes();
        }

        private async void TbiAgregarOnClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new PendientePage());
        }
    }
}
