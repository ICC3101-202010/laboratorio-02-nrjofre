using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    class Playlist
    {
        public string nombre;
        private Cancion[] canciones;

        public Playlist(string nombre, Cancion[] canciones)
        {
            this.nombre = nombre;
            this.canciones = canciones;
        }

        public void VerPlaylist()
        {
            Console.WriteLine("\nPlaylist: " + nombre);
            Console.WriteLine("Esta Playlist tiene " + canciones.Length + " canciones:");
            foreach (Cancion cancion in canciones)
                Console.WriteLine(cancion.Informacion());
        }
    }
}
