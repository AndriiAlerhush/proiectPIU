
using System;

namespace LibrarieModele
{
    public class Locuitor : Persoana
    {
        //
        // Campuri si proprietati auto-implemented
        //
        //public const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private int camera;
        public int Camera
        {
            get { return camera; }
            set
            {
                if (value < 0 || value / 100 > 4 /*Camin.nrEtaje*/)
                {
                    camera = 0;
                }
                else camera = value;
            }
        }
        public int Etaj
        {
            get
            {
                return camera / 100;
            }
        }

        //
        // Constructoare
        //
        public Locuitor() : base()
        {
            camera = 0;
        }

        public Locuitor(string nume, string prenume, Sexe sex, DateTime dataNasterii, string cnp, int camera)
       : base(nume, prenume, sex, dataNasterii, cnp)
        {
            Camera = camera;
        }

        public Locuitor(int id, string nume, string prenume, Sexe sex, DateTime dataNasterii, string cnp, int camera)
               : base(id, nume, prenume, sex, dataNasterii, cnp)
        {
            Camera = camera;
        }

        public Locuitor(Locuitor locuitor) : base(locuitor)
        {
            if (locuitor != null && locuitor.GetHashCode() != this.GetHashCode())
            {
                Camera = locuitor.Camera;
            }
        }

        //
        // Metode
        //
        public override string ToString()
        {
            return string.Format(
                                 "ID:            {0}\n" +
                                 "Nume:          {1}\n" +
                                 "Prenume:       {2}\n" +
                                 "Sex:           {3}\n" +
                                 "Data nasterii: {4}\n" +
                                 "Varsta:        {5}\n" +
                                 "CNP:           {6}\n" +
                                 "Camera:        {7}\n" +
                                 "Etaj:          {8}\n",
                                 Id, Nume, Prenume, Sex, DataNasterii, Varsta, Cnp, Camera, Etaj);
        }
    }
}
