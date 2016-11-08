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
        public PendientesPage()
        {
            InitializeComponent();

            tbiAgregar.Clicked += TbiAgregarOnClicked;

            // Esto llena la lista con 3 tareas pendientes de ejemplo
            
            
        }

        private async void TbiAgregarOnClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new PendientePage());
        }
    }
}
