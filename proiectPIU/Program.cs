
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NivelStocareDate;
using ListaModele;

namespace proiectPIU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persoana p0 = new Persoana();
            Console.WriteLine(p0.ToString());
            Persoana p = new Persoana("Alergush", "Andrei", "m", new DateTime(2002, 09, 15), "1234567890123");
            Console.WriteLine(p.ToString());
        }
    }
}
