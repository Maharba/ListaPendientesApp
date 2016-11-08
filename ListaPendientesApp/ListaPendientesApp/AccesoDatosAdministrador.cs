﻿using System;
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

        }
    }
}