using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    class Cancion
    {
        public string nombre;
        public string album;
        public string artista;
        public string genero;


    public Cancion(string nombre, string album, string artista, string genero)
        {
            this.nombre = nombre;
            this.album = album;
            this.artista = artista;
            this.genero = genero;
        }
    public string Informacion()
        {
            return $"género: {genero}, artista: {artista}, álbum: {album}, nombre: {nombre}";
        }

    }
}
