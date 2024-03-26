
using System;

namespace ListaModele
{
    public class Locuitor : Persoana
    {
        // camera
        private int camera;
        public int Camera
        {
            get { return camera; }
            set
            {
                if (value / 100 > 4 /*Camin.nrEtaje*/ || value < 0)
                {
                    camera = 0;
                }
                else { camera = value; }
            }
        }
        // etaj
        public int Etaj
        {
            get
            {
                return camera / 100;
            }
        }

        // constructoare

        public Locuitor() : base()
        {
            Camera = 0;
        }

        public Locuitor(string nume, string prenume, string sex, int camera) : base(nume, prenume, sex)
        {
            Camera = camera;
        }

        public Locuitor(string nume, string prenume, string sex, DateTime dataNasterii, string cnp, int camera) : base(nume, prenume, sex, dataNasterii, cnp)
        {
            Camera = camera;
        }

        public Locuitor(Locuitor locuitor) : base(locuitor)
        {
            if (locuitor != null && this != locuitor)
            {
                camera = locuitor.Camera;
            }
        }

        // metode

        public override string ToString()
        {
            return string.Format("Nume:          {0}\n" +
                                 "Prenume:       {1}\n" +
                                 "Sex:           {2}\n" +
                                 "Data nasterii: {3}\n" +
                                 "Varsta:        {4}\n" +
                                 "CNP:           {5}\n" +
                                 "ID:            {6}\n" +
                                 "Camera:        {7}\n" +
                                 "Etaj:          {8}\n",
                                 Nume, Prenume, Sex, DataNasterii.ToShortDateString(), Varsta, CNP, Id, camera, Etaj);
        }
    }
}
