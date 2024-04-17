
using System;

namespace ListaModele
{
    public class Locuitor : Persoana
    {
        protected const char SEPARATOR_PRINCIPAL_FISIER = ';';

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
            camera = 0;
        }

        public Locuitor(string nume, string prenume, string sex, int camera) : base(nume, prenume, sex)
        {
            Camera = camera;
        }

        public Locuitor(string nume, string prenume, string sex, string dataNasterii, string cnp, int camera)
            : base(nume, prenume, sex, dataNasterii, cnp)
        {
            Camera = camera;
        }

        public Locuitor(Locuitor locuitor) : base(locuitor)
        {
            if (locuitor != null && this != locuitor)
            {
                camera = locuitor.camera;
            }
        }

        public Locuitor(string linieFisier)
        {
            linieFisier = linieFisier.Trim();
            var dateLinieFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            Id = int.Parse(dateLinieFisier[0]);
            Nume = dateLinieFisier[1];
            Prenume = dateLinieFisier[2];
            Sex = dateLinieFisier[3];
            DataNasterii = dateLinieFisier[4];
            CNP = dateLinieFisier[5];
            Camera = int.Parse(dateLinieFisier[6]);
        }

        // metode

        public override string ToString()
        {
            return string.Format(
                                 "ID:            {6}\n" +
                                 "Nume:          {0}\n" +
                                 "Prenume:       {1}\n" +
                                 "Sex:           {2}\n" +
                                 "Data nasterii: {3}\n" +
                                 "Varsta:        {4}\n" +
                                 "CNP:           {5}\n" +
                                 "Camera:        {7}\n" +
                                 "Etaj:          {8}\n",
                                 Nume, Prenume, Sex, DataNasterii, Varsta, CNP, Id, camera, Etaj);
        }

        public string ConversieLaSirPentruFisierText()
        {
            return string.Format("{7}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}",
                SEPARATOR_PRINCIPAL_FISIER, Nume, Prenume, Sex,
                DataNasterii, CNP, camera.ToString(), Id.ToString());
        }
    }
}
