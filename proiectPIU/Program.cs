
using System;
using NivelStocareDate;
using ListaModele;

namespace proiectPIU
{
    internal class Program
    {
        static public Locuitor citireLocuitor()
        {
            Locuitor locuitor = new Locuitor();
            Console.Write("Nume:          ");
            locuitor.Nume = Console.ReadLine();
            Console.Write("Prenume:       ");
            locuitor.Prenume = Console.ReadLine();
            Console.Write("Sex:           ");
            locuitor.Sex = Console.ReadLine();
            Console.Write("Data nasterii: ");
            locuitor.DataNasterii = DateTime.Parse(Console.ReadLine());
            Console.Write("CNP:           ");
            locuitor.CNP = Console.ReadLine();
            Console.Write("Camera:        ");
            locuitor.Camera = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return locuitor;
        }

        static void Main(string[] args)
        {
            AdministrareLocuitori administrareLocuitori = new AdministrareLocuitori();
            AdministrarePersonal administrarePersonal = new AdministrarePersonal();

            Locuitor l1 = new Locuitor("Alergush", "Andrei", "m", new DateTime(2002, 09, 15), "1234567890123", 415);
            //Locuitor l1 = citireLocuitor();

            Locuitor l2 = new Locuitor("Chernov", "Iaroslav", "m", new DateTime(2006, 06, 10), "1234567890543", 415);
            Locuitor l3 = new Locuitor("Turcanu", "Vlad", "m", new DateTime(2003, 06, 10), "1234567894444", 315);
            administrareLocuitori.AddLocuitor(l1);
            administrareLocuitori.AddLocuitor(l2);
            administrareLocuitori.AddLocuitor(l3);
            Console.WriteLine("Afisare locuitori:\n" + administrareLocuitori.ToString());

            Console.WriteLine("//\n");

            Personal p1 = new Personal("Popescu", "Ion", "m", "portar");
            Personal p2 = new Personal("Calinescu", "Mihai", "m", "portar");
            Personal p3 = new Personal("Ana-Maria", "Babi", "f", "administrator");
            administrarePersonal.AddPersonal(p1);
            administrarePersonal.AddPersonal(p2);
            administrarePersonal.AddPersonal(p3);
            Console.WriteLine("Afisare personal:\n" + administrarePersonal.ToString());
            
            Console.WriteLine("// Cautare locuitori\n");

            // Locuitor cautare
            Locuitor locuitor;

            locuitor = administrareLocuitori.GetLocuitor("Alergush");
            if (locuitor != null)
            {
                Console.WriteLine(locuitor.ToString());
            }
            else { Console.WriteLine("Asa locuitor nu exista!"); }

            locuitor = administrareLocuitori.GetLocuitor("Chernov", "Iaroslav");
            if (locuitor != null)
            {
                Console.WriteLine(locuitor.ToString());
            }
            else { Console.WriteLine("Asa locuitor nu exista!"); }

            locuitor = administrareLocuitori.GetLocuitorCNP("1234567894444");
            if (locuitor != null)
            {
                Console.WriteLine(locuitor.ToString());
            }
            else { Console.WriteLine("Asa locuitor nu exista!"); }

            Console.WriteLine("// Cautare personal\n");

            // Personal cautare
            Personal personal;

            personal = administrarePersonal.GetResponsabil("Popescu");
            if (personal != null)
            {
                Console.WriteLine(personal.ToString());
            }
            else { Console.WriteLine("Asa responsabil nu exista!"); }

            personal = administrarePersonal.GetResponsabil("Calinescu", "Mihai");
            if (personal != null)
            {
                Console.WriteLine(personal.ToString());
            }
            else { Console.WriteLine("Asa responsabil nu exista!"); }
        }
    }
}
