using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Cancion c = new Cancion("Lights", "Lights", "Ellie Goulding", "Pop");
            c.Informacion();
            Console.ReadLine();
        }
    }
}
