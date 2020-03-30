using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    class Espotifai
    {
        Cancion[] canciones;
        Playlist[] playlists;


        public Espotifai()
        {
            canciones = new Cancion[0];
            playlists = new Playlist[0];
        }
        public bool AgregarCancion(Cancion cancion)
        {   // Comprueba si la cancion ya esta
            foreach(Cancion cancionGuardada in canciones)
            { if (cancionGuardada.nombre == cancion.nombre && cancionGuardada.artista == cancion.artista && cancionGuardada.album == cancion.album)
                {
                    return false;
                }
            }

            Array.Resize(ref canciones, canciones.Length + 1);

            canciones[canciones.Length - 1] = cancion;
            return true;
        }

        public void VerCanciones()
        {
            foreach(Cancion cancion in canciones)
            {
                Console.WriteLine(cancion.Informacion());
            }
        }

        public Cancion[] CancionesPorCriterio(string criterio, string valor)
        {
            Cancion[] filtrocancion = new Cancion[0];

            if (criterio != "nombre" && criterio != "genero" && criterio != "album" && criterio != "artista")
            {
                Console.WriteLine("Criterio no valido. Ingrese nombre, genero, album o artista");
                return filtrocancion;
            }

            foreach (Cancion cancion in canciones)
            {
                bool agregarCancion = false;

                if (criterio == "nombre" && cancion.nombre == valor)
                    agregarCancion = true;
                else if (criterio == "genero" && cancion.genero == valor)
                    agregarCancion = true;
                else if (criterio == "album" && cancion.album == valor)
                    agregarCancion = true;
                else if (criterio == "artista" && cancion.artista == valor)
                    agregarCancion = true;

                if (agregarCancion)
                {
                    Array.Resize(ref filtrocancion, filtrocancion.Length + 1);
                    filtrocancion[filtrocancion.Length - 1] = cancion;
                }
            }

            return filtrocancion;
        }

        public bool GenerarPlaylist(string criterio, string valorCriterio, string nombrePlaylist)
        {
            foreach (Playlist playlist in playlists)
                if (playlist.nombre == nombrePlaylist)
                {
                    Console.WriteLine("El nombre de esa Playlist ya existe");
                    return false;
                }
            
            Cancion[] filtrocancion = CancionesPorCriterio(criterio, valorCriterio);

            if (filtrocancion.Length == 0)
            {
                Console.WriteLine("No hay canciones con ese criterio");
                return false;
            }

            Array.Resize(ref playlists, playlists.Length + 1);
            playlists[playlists.Length - 1] = new Playlist(nombrePlaylist, filtrocancion);
            return true;
        }

        public void VerMisPlaylists()
        {
            foreach (Playlist playlist in playlists)
                playlist.VerPlaylist(); 
        }

    }   
}
