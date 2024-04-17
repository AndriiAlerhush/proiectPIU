
using System;
using System.Linq;
using System.Text;

namespace ListaModele
{
    public class Responsabil : Persoana
    {
        // post
        private Posturi post;
        public int Post
        {
            get { return (int)post; }
            set
            {
                if (Enum.IsDefined(typeof(Posturi), value))
                {
                    post = (Posturi)value;
                }
                else post = Posturi.nesetat;
            }
        }
        // zile lucratoare
        private Zile zileLucratoare;
        public int ZileLucratoare
        {
            get { return (int)zileLucratoare; }
            set
            {
                if (Enum.IsDefined(typeof(Zile), value))
                {
                    zileLucratoare = (Zile)value;
                }
                else zileLucratoare = Zile.Nu;
            }
        }

        // constructoare

        public Responsabil() : base()
        {
            post = Posturi.nesetat;
            zileLucratoare = Zile.Nu;
        }

        public Responsabil(string nume, string prenume, string sex, int post)
            : base(nume, prenume, sex)
        {
            Post = post;
            zileLucratoare = Zile.Nu;
        }

        public Responsabil(string nume, string prenume, string sex, int post, int zileLucratoare)
            : base(nume, prenume, sex)
        {
            Post = post;
            ZileLucratoare = zileLucratoare;
        }

        public Responsabil(string nume, string prenume, string sex, int post, string zileLucratoare)
            : base(nume, prenume, sex)
        {
            Post = post;
            ZileLucratoare = CalculareZileLucratoare(zileLucratoare);
        }

        public Responsabil(string nume, string prenume, string sex, string dataNasterii, string cnp, int post, int zileLucratoare)
            : base(nume, prenume, sex, dataNasterii, cnp)
        {
            Post = post;
            ZileLucratoare = zileLucratoare;
        }

        public Responsabil(string nume, string prenume, string sex, string dataNasterii, string cnp, int post, string zileLucratoare)
            : base(nume, prenume, sex, dataNasterii, cnp)
        {
            Post = post;
            //ZileLucratoare = zileLucratoare;
            ZileLucratoare = CalculareZileLucratoare(zileLucratoare);
        }

        public Responsabil(Responsabil responsabil) : base(responsabil)
        {
            if (responsabil != null && this != responsabil)
            {
                post = responsabil.post;
                zileLucratoare = responsabil.zileLucratoare;
            }
        }

        // metode

        public override string ToString()
        {
            return string.Format(
                                 "ID:              {6}\n" +
                                 "Nume:            {0}\n" +
                                 "Prenume:         {1}\n" +
                                 "Sex:             {2}\n" +
                                 "Data nasterii:   {3}\n" +
                                 "Varsta:          {4}\n" +
                                 "CNP:             {5}\n" +
                                 "Post:            {7}\n" +
                                 "Zile lucratoare: {8}\n",
                                 Nume, Prenume, Sex, DataNasterii,
                                 Varsta, CNP, Id,
                                 post.ToString().Replace("_", " "),
                                 zileLucratoare);
        }

        static public int CalculareZileLucratoare(string zile)
        {
            if (!string.IsNullOrEmpty(zile))
            {
                string[] zileCitite = zile.Trim().Split(' ', ',');
                for (byte i = 0; i < zileCitite.Length; i++)
                {
                    zileCitite[i] = Capitalize(zileCitite[i]);
                }

                int zileLucratoare = 0;
                foreach (string ziCitita in zileCitite)
                {
                    foreach (Zile zi in Enum.GetValues(typeof(Zile)))
                    {
                        if (ziCitita.Equals(zi.ToString()))
                        {
                            zileLucratoare |= (int)zi;
                            break;
                        }
                    }
                }

                return zileLucratoare;
            }
            else return 0;
        }
    }
}
