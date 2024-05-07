
using System;

namespace LibrarieModele
{
    public class Persoana
    {
        //
        // Campuri si Proprietati auto-implemented
        //
        private static int ID = 0;
        public int Id { get; protected set; }

        private string nume;
        public string Nume
        {
            get { return nume; }
            set
            {
                nume = Capitalize(value);
            }
        }

        private string prenume;
        public string Prenume
        {
            get { return prenume; }
            set
            {
                prenume = Capitalize(value);
            }
        }

        public Sexe Sex { get; set; }
        public DateTime DataNasterii { get; set; }
        public string Cnp { get; set; }
        public string Varsta
        {
            get
            {
                if (DataNasterii == DateTime.MinValue || DataNasterii == DateTime.Today || DataNasterii == DateTime.MaxValue)
                {
                    return "0";
                }

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
                    luni = 12 - luna_n + luna_c;
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

                return string.Format($"{ani} ani, {luni} luni, {zile} zile");
            }
        }

        //
        // Constructore
        //
        public Persoana()
        {
            Id = ++ID;
            Nume = "-";
            Prenume = "-";
            Sex = Sexe.nesetat;
            DataNasterii = DateTime.Today;
            Cnp = "-";
        }

        public Persoana(string nume, string prenume, Sexe sex, DateTime dataNasterii, string cnp)
        {
            Id = ++ID;
            Nume = nume;
            Prenume = prenume;
            Sex = sex;
            DataNasterii = dataNasterii;
            Cnp = cnp;
        }

        public Persoana(int id, string nume, string prenume, Sexe sex, DateTime dataNasterii, string cnp)
        {
            Id = id;
            Nume = nume;
            Prenume = prenume;
            Sex = sex;
            DataNasterii = dataNasterii;
            Cnp = cnp;
        }

        // Constructor de copiere
        public Persoana(Persoana persoana)
        {
            if (persoana != null && persoana.GetHashCode() != this.GetHashCode())
            {
                Id = persoana.Id;
                Nume = persoana.Nume;
                Prenume = persoana.Prenume;
                Sex = persoana.Sex;
                DataNasterii = persoana.DataNasterii;
                Cnp = persoana.Cnp;
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
                                 "CNP:           {6}\n",
                                 Id, Nume, Prenume, Sex, DataNasterii, Varsta, Cnp);
        }

        static public string Capitalize(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            s = s.Trim();
            s = char.ToUpper(s[0]) + s.Substring(1).ToLower();
            return s;
        }
    }
}
