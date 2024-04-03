
using System;
using NivelStocareDate;
using ListaModele;
using System.Linq;
using System.Text;

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
            locuitor.DataNasterii = Console.ReadLine();
            Console.Write("CNP:           ");
            locuitor.CNP = Console.ReadLine();
            Console.Write("Camera:        ");
            locuitor.Camera = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return locuitor;
        }

        static public Responsabil citirePersonal(int zileDisponibile)
        {
            Responsabil responsabil = new Responsabil();
            Console.Write("Nume:          ");
            responsabil.Nume = Console.ReadLine();
            Console.Write("Prenume:       ");
            responsabil.Prenume = Console.ReadLine();
            Console.Write("Sex:           ");
            responsabil.Sex = Console.ReadLine();
            Console.Write("Data nasterii: ");
            responsabil.DataNasterii = Console.ReadLine();
            Console.Write("CNP:           ");
            responsabil.CNP = Console.ReadLine();

            // post
            Console.WriteLine("Posturi disponibile:");
            foreach (Posturi post in Enum.GetValues(typeof(Posturi)))
            {
                Console.WriteLine(" " + post + $" - {(int)post}");
            }
            Console.Write("Post: ");
            if (int.TryParse(Console.ReadLine(), out int postul))
            {
                responsabil.Post = postul;
            }
            else responsabil.Post = (int)Posturi.nesetat;

            // zile lucratoare
            Console.Write($"Zile lucratoare: ");

            responsabil.ZileLucratoare = Responsabil.CalculareZileLucratoare(Console.ReadLine());

            Console.WriteLine();
            return responsabil;
        }

        static void Main(string[] args)
        {
            AdministrareLocuitori administrareLocuitori = new AdministrareLocuitori();
            AdministrarePersonal administrarePersonal = new AdministrarePersonal();

            Locuitor l1 = new Locuitor("Alergush", "Andrei", "m", "15.09.2002", "1234567890123", 415);
            //Locuitor l1 = citireLocuitor();

            Locuitor l2 = new Locuitor("Chernov", "Iaroslav", "m", "10.06.2006", "1234567890543", 415);
            Locuitor l3 = new Locuitor("Turcanu", "Vlad", "m", "10.06.2003", "1234567894444", 315);
            administrareLocuitori.AddLocuitor(l1);
            administrareLocuitori.AddLocuitor(l2);
            administrareLocuitori.AddLocuitor(l3);
            Console.WriteLine("\n// Afisare locuitori\n\n" + administrareLocuitori.ToString());

            //Console.WriteLine("//\n");

            // nesetat - 0
            // portar  - 1
            // persoana de serviciu - 2
            // administrator - 3

            //Console.WriteLine("//Citire responsabil\n");
            //Responsabil p1 = citirePersonal();
            Responsabil p1 = new Responsabil("Popescu", "Ion", "m", 1, 96);
            Responsabil p2 = new Responsabil("Calinescu", "Mihai", "m", 1, "sambata duminica");
            Responsabil p3 = new Responsabil("Ana-Maria", "Babi", "f", 3);
            administrarePersonal.AddPersonal(p1);
            administrarePersonal.AddPersonal(p2);
            administrarePersonal.AddPersonal(p3);
            Console.WriteLine("// Afisare personal\n\n" + administrarePersonal.ToString());

            Console.WriteLine("// Cautare locuitori\n");

            // Locuitor cautare
            Locuitor locuitor;

            locuitor = administrareLocuitori.GetLocuitor("Alergush");
            if (locuitor != null)
            {
                Console.WriteLine(locuitor.ToString());
            }
            else Console.WriteLine("Asa locuitor nu exista!");

            locuitor = administrareLocuitori.GetLocuitor("Chernov", "Iaroslav");
            if (locuitor != null)
            {
                Console.WriteLine(locuitor.ToString());
            }
            else Console.WriteLine("Asa locuitor nu exista!");

            locuitor = administrareLocuitori.GetLocuitorCNP("1234567894444");
            if (locuitor != null)
            {
                Console.WriteLine(locuitor.ToString());
            }
            else Console.WriteLine("Asa locuitor nu exista!");

            Console.WriteLine("// Cautare personal\n");

            // Personal cautare
            Responsabil personal;

            personal = administrarePersonal.GetResponsabil("Popescu");
            if (personal != null)
            {
                Console.WriteLine(personal.ToString());
            }
            else Console.WriteLine("Asa responsabil nu exista!");

            personal = administrarePersonal.GetResponsabil("Calinescu", "Mihai");
            if (personal != null)
            {
                Console.WriteLine(personal.ToString());
            }
            else Console.WriteLine("Asa responsabil nu exista!");

            //
        }
    }
}
