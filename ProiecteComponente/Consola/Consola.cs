
using System;
using NivelStocareDate;
using ListaModele;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using DataBases;

namespace Consola
{
    internal class Consola
    {
        static void Main(string[] args)
        {
            AdministrareLocuitoriMemorie administrareLocuitoriMemorie = new AdministrareLocuitoriMemorie();
            AdministrarePersonalMemorie administrarePersonalMemorie = new AdministrarePersonalMemorie();

            Locuitor l1 = new Locuitor("Alergush", "Andrei", "m", "15.09.2002", "1234567890123", 415);
            //Locuitor l1 = citireLocuitor();

            Locuitor l2 = new Locuitor("Chernov", "Iaroslav", "m", "10.06.2006", "1234567890543", 415);
            Locuitor l3 = new Locuitor("Turcanu", "Vlad", "m", "10.06.2003", "1234567894444", 315);
            administrareLocuitoriMemorie.AddLocuitor(l1);
            administrareLocuitoriMemorie.AddLocuitor(l2);
            administrareLocuitoriMemorie.AddLocuitor(l3);
            Console.WriteLine("\n// Afisare locuitori\n\n" + administrareLocuitoriMemorie.ToString());

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
            administrarePersonalMemorie.AddPersonal(p1);
            administrarePersonalMemorie.AddPersonal(p2);
            administrarePersonalMemorie.AddPersonal(p3);
            Console.WriteLine("// Afisare personal\n\n" + administrarePersonalMemorie.ToString());

            Console.WriteLine("// Cautare locuitori\n");

            // Locuitor cautare
            Locuitor locuitor;

            locuitor = administrareLocuitoriMemorie.GetLocuitor("Alergush");
            if (locuitor != null)
            {
                Console.WriteLine(locuitor.ToString());
            }
            else Console.WriteLine("Asa locuitor nu exista!");

            locuitor = administrareLocuitoriMemorie.GetLocuitor("Chernov", "Iaroslav");
            if (locuitor != null)
            {
                Console.WriteLine(locuitor.ToString());
            }
            else Console.WriteLine("Asa locuitor nu exista!");

            locuitor = administrareLocuitoriMemorie.GetLocuitorCNP("1234567894444");
            if (locuitor != null)
            {
                Console.WriteLine(locuitor.ToString());
            }
            else Console.WriteLine("Asa locuitor nu exista!");

            Console.WriteLine("// Cautare personal\n");

            // Personal cautare
            Responsabil personal;

            personal = administrarePersonalMemorie.GetResponsabil("popescu");
            if (personal != null)
            {
                Console.WriteLine(personal.ToString());
            }
            else Console.WriteLine("Asa responsabil nu exista!");

            personal = administrarePersonalMemorie.GetResponsabil("Calinescu", "Mihai");
            if (personal != null)
            {
                Console.WriteLine(personal.ToString());
            }
            else Console.WriteLine("Asa responsabil nu exista!");

            // scrierea locuitorilor in fisier
            Console.WriteLine("// Scrierea si citirea locuitorilor in fisier\n");

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];

            // stergerea continutului fisierului
            using (StreamWriter swFisierText = new StreamWriter(numeFisier, false)) { }

            AdministrareLocuitoriFisierText administrareLocuitoriFisierText = new AdministrareLocuitoriFisierText(numeFisier);

            administrareLocuitoriFisierText.AddLocuitor(l1);
            administrareLocuitoriFisierText.AddLocuitor(l2);
            administrareLocuitoriFisierText.AddLocuitor(l3);

            //List<Locuitor> locuitoriFisier = administrareLocuitoriFisierText.GetLocuitori();
            //Console.WriteLine(AdministrareLocuitoriFisierText.afisareLocuitori(locuitoriFisier));

            //DataBase dataBase = new DataBase("Server=192.168.2.197;Database=proiectPIU_demo;User ID=sa;Password=VeryStr0ngP@ssw0rd");

            //if (dataBase.IsAvailable)
            //{
            //    dataBase.AddLocuitor(l1.Nume, l1.Prenume, l1.Sex, l1.DataNasterii, l1.Cnp, l1.Camera);
            //    //dataBase.DeleteLocuitor(1);
            //}
            //else Console.WriteLine("Error DB");
        }

        //

        //static public Locuitor citireLocuitor()
        //{
        //    Locuitor locuitor = new Locuitor();
        //    Console.Write("Nume:          ");
        //    locuitor.Nume = Console.ReadLine();
        //    Console.Write("Prenume:       ");
        //    locuitor.Prenume = Console.ReadLine();
        //    Console.Write("Sex:           ");
        //    locuitor.Sex = Console.ReadLine();
        //    Console.Write("Data nasterii: ");
        //    locuitor.DataNasterii = Console.ReadLine();
        //    Console.Write("CNP:           ");
        //    locuitor.Cnp = Console.ReadLine();
        //    Console.Write("Camera:        ");
        //    locuitor.Camera = int.Parse(Console.ReadLine());
        //    Console.WriteLine();
        //    return locuitor;
        //}

        //static public Responsabil citirePersonal(int zileDisponibile)
        //{
        //    Responsabil responsabil = new Responsabil();
        //    Console.Write("Nume:          ");
        //    responsabil.Nume = Console.ReadLine();
        //    Console.Write("Prenume:       ");
        //    responsabil.Prenume = Console.ReadLine();
        //    Console.Write("Sex:           ");
        //    responsabil.Sex = Console.ReadLine();
        //    Console.Write("Data nasterii: ");
        //    responsabil.DataNasterii = Console.ReadLine();
        //    Console.Write("CNP:           ");
        //    responsabil.Cnp = Console.ReadLine();

        //    post
        //    Console.WriteLine("Posturi disponibile:");
        //    foreach (Posturi post in Enum.GetValues(typeof(Posturi)))
        //    {
        //        Console.WriteLine(" " + post + $" - {(int)post}");
        //    }
        //    Console.Write("Post: ");
        //    if (int.TryParse(Console.ReadLine(), out int postul))
        //    {
        //        responsabil.Post = postul;
        //    }
        //    else responsabil.Post = (int)Posturi.nesetat;

        //    zile lucratoare
        //    Console.Write($"Zile lucratoare: ");

        //    responsabil.ZileLucratoare = Responsabil.CalculareZileLucratoare(Console.ReadLine());

        //    Console.WriteLine();
        //    return responsabil;
        //}
    }
}
