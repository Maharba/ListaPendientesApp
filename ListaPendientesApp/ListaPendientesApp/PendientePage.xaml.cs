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
        public PendientePage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (!string.IsNullOrEmpty(txtDescripcion.Text))
            {
                //TODO: Guardar información en una base de datos y archivarla.
            }
        }
    }
}
