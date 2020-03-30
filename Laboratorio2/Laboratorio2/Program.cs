using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    class Program
    {
        //cree un metodo para comprobar si el valor entregado por el usuario es un string
        public static string PedirString(string explicacion)
        {
            string valor = "";
            bool valido = false;
            while (!valido)
            {
                Console.WriteLine(explicacion);
                valor = Console.ReadLine();
                if (valor.Trim() != "")
                    valido = true;
                else
                    Console.WriteLine("Debes ingresar un valor valido");
            }
            return valor;
        }

        public static void ComandosDisponibles()
        {
            Console.WriteLine("\nLos comandos disponibles son:\n");
            Console.WriteLine("1: Agregar cancion");
            Console.WriteLine("2: Ver canciones");
            Console.WriteLine("3: Ver canciones por criterio");
            Console.WriteLine("4: Crear playlist");
            Console.WriteLine("5: Ver mis playlists");
            Console.WriteLine("0: Salir del programa\n");
        }

        public static void Main(string[] args)
        {
            // Partimos con 3 canciones en el programa por default
            Espotifai espotifai = new Espotifai();
            espotifai.AgregarCancion(new Cancion("Memories", "Memories", "Maroon 5", "Pop"));
            espotifai.AgregarCancion(new Cancion("Lovely", "Lovely", "Billie Eilish", "Pop"));
            espotifai.AgregarCancion(new Cancion("Tusa", "Tusa", "Karol G", "Reggaeton"));
            
            bool cerrarPrograma = false;
            Console.WriteLine("Bienvenido a Espotifai");
            
            while (!cerrarPrograma)
            {
                ComandosDisponibles();
                string comando = Console.ReadLine();
                
                if (comando == "1")
                {
                    string nombre = PedirString("Ingresa el nombre de la cancion");
                    string album = PedirString("Ingresa el album de la cancion:");
                    string artista = PedirString("Ingresa el artista de la cancion:");
                    string genero = PedirString("Ingresa el género de la cancion:");
                    
                    Cancion cancion = new Cancion(nombre, album, artista, genero);
                    
                    if (espotifai.AgregarCancion(cancion))
                    {
                        Console.WriteLine("Se agrego la cancion.");
                    }
                }
                
                else if (comando == "2")
                {
                    espotifai.VerCanciones();
                }
                
                else if (comando == "3")
                {
                    string criterio = PedirString("Ingresa un criterio (nombre, album, artista, genero)");
                    string valor = PedirString("Ingresa un valor para el criterio");
                    Cancion[] canciones = espotifai.CancionesPorCriterio(criterio, valor);
                    
                    if (canciones.Length == 0)
                        Console.WriteLine("No se encontraron canciones");
                    foreach (Cancion cancion in canciones)
                        Console.WriteLine(cancion.Informacion());
                }
                
                else if (comando == "4")
                {
                    string nombre = PedirString("Ingresa un nombre para la playlist:");
                    string criterio = PedirString("Ingresa un criterio (nombre, album, artista, genero)");
                    string valor = PedirString("Ingresa un valor para el criterio");
                    
                    if (espotifai.GenerarPlaylist(criterio, valor, nombre))
                        Console.WriteLine("Lista generada exitosamente.");
                }
                
                else if (comando == "5")
                {
                    espotifai.VerMisPlaylists();
                }
                
                else if (comando == "0")
                {
                    cerrarPrograma = true;
                }
                
                else
                {
                    Console.WriteLine("Comando desconocido.");
                    ComandosDisponibles();
                }
            }
        }
    }
}