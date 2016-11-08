using SQLite.Net;
using Xamarin.Forms;
using ListaPendientesApp.UWP;
using Windows.Storage;
using System.IO;
using System.Reflection;
using System;
using SQLite.Net.Platform.WinRT;

[assembly: Dependency(typeof(SQLiteServicioUWP))]
namespace ListaPendientesApp.UWP
{
    public class SQLiteServicioUWP : ISQLite
    {
        public SQLiteConnection ObtenerConexion()
        {
            var baseDatos = "pendientes.db3";
            var directorio = ApplicationData.Current.LocalFolder.Path;
            var rutaCompleta = Path.Combine(directorio, baseDatos);

            if (File.Exists(rutaCompleta))
            {
                var plataforma = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
                var conexion = new SQLiteConnection(plataforma, rutaCompleta);
                return conexion;
            }
            else
            {
                File.Create(rutaCompleta);
                var plataforma = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
                var conexion = new SQLiteConnection(plataforma, rutaCompleta);
                return conexion;
            }
        }
    }
}