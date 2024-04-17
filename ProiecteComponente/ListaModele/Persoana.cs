
using System;

namespace ListaModele
{
    public class Persoana
    {
        //protected const char SEPARATOR_PRINCIPAL_FISIER = ';';

        // nume
        private string nume;
        public string Nume
        {
            get { return nume; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nume = Capitalize(value);
                }
                else nume = "-";
            }
        }
        // prenume
        private string prenume;
        public string Prenume
        {
            get { return prenume; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    prenume = Capitalize(value);
                }
                else prenume = "-";
            }
        }
        // sex
        private string sex;
        public string Sex
        {
            get { return sex; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    string sexul = value.Trim().ToLower();
                    if (sexul == "m" || sexul == "f" || sexul == "altul")
                    {
                        sex = sexul;
                    }
                    else { sex = "necunoscut"; }
                }
                else sex = null;
            }
        }
        // data nasterii
        private DateTime dataNasterii;
        public string DataNasterii
        {
            get
            {
                return dataNasterii.ToShortDateString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (DateTime.TryParse(value, out DateTime extras))
                    {
                        if (extras > DateTime.Today)
                        {
                            dataNasterii = DateTime.MinValue;
                        }
                        else dataNasterii = extras;
                    }
                    else dataNasterii = DateTime.MinValue;
                }
                else dataNasterii = DateTime.MinValue;
            }
        }
        // varsta
        public string Varsta
        {
            get
            {
                if (dataNasterii == DateTime.MinValue || dataNasterii == DateTime.Today)
                {
                    return "0";
                }
                else
                {
                    int data_n = dataNasterii.Day;
                    int luna_n = dataNasterii.Month;
                    int anul_n = dataNasterii.Year;

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
                if (!string.IsNullOrEmpty(value))
                {
                    value = value.Trim();
                    if (value == "-")
                    {
                        cnp = "-";
                    }
                    else if (value.Length > 13 || value.Length < 13)
                    {
                        cnp = "incorect";
                    }
                    else { cnp = value; }
                }
                else cnp = "-";
            }
        }
        // ID
        private static int ID = 0;
        public int Id { get; protected set; }

        // constructoare

        public Persoana()
        {
            Id = ++ID;
            nume = "-";
            prenume = "-";
            sex = "-";
            dataNasterii = DateTime.Today;
            cnp = "-";
        }

        public Persoana(string nume, string prenume, string sex)
        {
            Id = ++ID;
            Nume = nume;
            Prenume = prenume;
            Sex = sex;
            dataNasterii = DateTime.Today;
            cnp = "-";
        }

        public Persoana(string nume, string prenume, string sex, string dataNasterii, string cnp)
        {
            Id = ++ID;
            Nume = nume;
            Prenume = prenume;
            Sex = sex;
            DataNasterii = dataNasterii;
            CNP = cnp;
        }

        public Persoana(Persoana persoana)
        {
            if (persoana != null && this != persoana)
            {
                Id = persoana.Id;
                nume = persoana.nume;
                prenume = persoana.prenume;
                sex = persoana.sex;
                dataNasterii = persoana.dataNasterii;
                cnp = persoana.cnp;
            }
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
                                 Nume, Prenume, Sex, DataNasterii, Varsta, CNP, Id);
        }

        static public string Capitalize(string str)
        {
            str = str.Trim();
            str = char.ToUpper(str[0]) + str.Substring(1).ToLower();
            return str;
        }

        //public virtual string ConversieLaSirPentruFisierText()
        //{
        //    return string.Format("{6}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}",
        //        SEPARATOR_PRINCIPAL_FISIER, nume, prenume, sex,
        //        dataNasterii.ToShortDateString(), cnp, Id.ToString());
        //}
    }
}
