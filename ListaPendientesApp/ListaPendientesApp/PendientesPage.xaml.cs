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
            Pendiente pendiente1 = new Pendiente();
            pendiente1.Descripcion = "Terminar el ejemplo";
            pendiente1.Fecha = DateTime.Now;

            Pendiente pendiente2 = new Pendiente();
            pendiente2.Descripcion = "Ir por la leche";
            pendiente2.Fecha = new DateTime(2024, 12, 25);

            Pendiente pendiente3 = new Pendiente();
            pendiente3.Descripcion = "Entregar la tarea al profe";
            pendiente3.Fecha = DateTime.MaxValue;

            List<Pendiente> listaPendientes = new List<Pendiente>();
            listaPendientes.Add(pendiente1);
            listaPendientes.Add(pendiente2);
            listaPendientes.Add(pendiente3);

            lstPendientes.ItemsSource = listaPendientes;
        }

        private async void TbiAgregarOnClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new PendientePage());
        }
    }
}
