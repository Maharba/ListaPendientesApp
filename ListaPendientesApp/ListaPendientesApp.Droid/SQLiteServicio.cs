using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net;
using Environment = System.Environment;
using Xamarin.Forms;
using ListaPendientesApp.Droid;

[assembly: Dependency(typeof(SQLiteServicio))]
namespace ListaPendientesApp.Droid
{
    public class SQLiteServicio : ISQLite
    {
        public SQLiteConnection ObtenerConexion()
        {
            var archivoSQLite = "pendientes.db3";
            string directorioDocumentosAndroid =
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var rutaCompleta = System.IO.Path.Combine(directorioDocumentosAndroid, archivoSQLite);
            if (System.IO.File.Exists(rutaCompleta))
            {
                var plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                var conexion = new SQLite.Net.SQLiteConnection(plataforma, rutaCompleta);
                return conexion;
            }
            else
            {
                System.IO.File.Create(rutaCompleta);
                var plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                var conexion = new SQLite.Net.SQLiteConnection(plataforma, rutaCompleta);
                return conexion;
            }
        }
    }
}