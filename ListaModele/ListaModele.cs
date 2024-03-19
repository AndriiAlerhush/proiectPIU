
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ListaModele
{
    public class Persoana
    {
        // nume
        public string Nume { get; set; }
        // prenume
        public string Prenume { get; set; }
        // sex
        private string sex;
        public string Sex
        {
            get { return sex; }
            set
            {
                if (value.ToUpper() == "M" || value.ToUpper() == "F" || value == "altul")
                {
                    sex = value.ToUpper();
                }
                else { sex = "necunoscut"; }
            }
        }
        // data nasterii
        private DateTime dataNasterii;
        public DateTime DataNasterii
        {
            get
            {
                return dataNasterii;
            }
            set
            {
                if (dataNasterii > DateTime.Today)
                {
                    dataNasterii = DateTime.Today;
                }
                else dataNasterii = value;
            }
        }
        // varsta
        public string Varsta
        {
            get
            {
                int data_n = DataNasterii.Day;
                int luna_n = DataNasterii.Month;
                int anul_n = DataNasterii.Year;

                int data_c = DateTime.Today.Day;
                int luna_c = DateTime.Today.Month;
                int anul_c = DateTime.Today.Year;

                int ani = anul_c - anul_n;
                int luni;
                int zile;
                if (luna_n <= luna_c)
                {
                    luni = luna_c - luna_n;
                }
                else
                {
                    ani--;
                    luni = luna_n - luna_c;
                    // 15.09.2002
                    // 19.03.2024
                }
                if (data_n <= data_c)
                {
                    zile = data_c - data_n;
                }
                else
                {
                    luni--;
                    zile = data_n - data_c;
                }

                return string.Format("{0} ani, {1} luni, {2} zile", ani, luni, zile);
            }
        }
        // CNP
        private string cnp;
        public string CNP
        {
            get
            {
                return cnp;
            }
            set
            {
                if (value.Length > 13 || value.Length < 13)
                {
                    cnp = "incorect";
                }
                else { cnp = value; }
            }
        }
        // ID
        private static int ID = 0;
        private int id;
        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        // constructoare

        public Persoana()
        {
            Nume = "-";
            Prenume = "-";
            sex = "-";
            dataNasterii = DateTime.MinValue;
            cnp = "-";
        }

        public Persoana(string nume, string prenume, string sex, DateTime dataNasterii, string cnp)
        {
            Id = ++ID;
            Nume = nume;
            Prenume = prenume;
            Sex = sex;
            DataNasterii = dataNasterii;
            CNP = cnp;
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
                                 "ID:            {6}\n",
                                 Nume, Prenume, Sex, dataNasterii.ToShortDateString(), Varsta, CNP, Id);
        }
    }

    public class Personal : Persoana
    {
        private string post;
        public string Post
        {
            get { return post; }
            set
            {
                if (value != "portar" && value != "persoana de serviciu" && value != "administrator")
                {
                    post = "inexistent";
                }
                else { post = value; }
            }
        }
    }

    public class Locuitor : Persoana
    {
        //public string Tip
        //{
        //    get { return Tip; }
        //    set
        //    {
        //        if (value != "student" && value != "profesor")
        //        {
        //            Tip = "incorect";
        //        }
        //        else { Tip = value; }
        //    }
        //}

        //public int Etaj
        //{
        //    get { return  Etaj; }
        //    set
        //    {
        //        if (value < 0 /* && value > Camin.nrEtaje */)
        //        {
        //            Etaj = -1;
        //        }
        //        else { Etaj = value; }
        //    }
        //}
        private int camera;
        public int Camera
        {
            get { return camera; }
            set
            {
                if (value / 100 > 4 /*Camin.nrEtaje*/ || value < 0)
                {
                    Camera = 0;
                }
                else { Camera = value; }
            }
        }
    }
}
