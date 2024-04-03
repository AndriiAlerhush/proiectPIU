
using System;
using System.Text;
using ListaModele;

namespace NivelStocareDate
{
    public class AdministrareLocuitori
    {
        // campuri & proprietati
        private const int N_MAX_LOCUITORI = 10;
        private Locuitor[] locuitori;
        private int n;
        public int N
        {
            get { return n; }
            private set { n = value; }
        }

        // constructoare

        public AdministrareLocuitori()
        {
            locuitori = new Locuitor[N_MAX_LOCUITORI];
            N = 0;
        }

        // metode

        public bool AddLocuitor(Locuitor locuitor)
        {
            if (N <= N_MAX_LOCUITORI)
            {
                locuitori[N] = locuitor;
                N++;
                return true;
            }
            return false;
        }

        public string afisareLocuitori()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                sb.AppendFormat("Locuitor {0}\n", i + 1);
                sb.Append(locuitori[i].ToString());
                sb.Append("\n");
            }
            return sb.Remove(sb.Length - 1, 1).ToString();
        }

        public override string ToString()
        {
            return this.afisareLocuitori();
        }

        public Locuitor GetLocuitor(string nume)
        {
            nume = Persoana.Capitalize(nume);

            for (int i = 0; i < N; i++)
            {
                if (locuitori[i].Nume.Equals(nume))
                {
                    return new Locuitor(locuitori[i]);
                }
            }
            return null;
        }

        public Locuitor GetLocuitor(string nume, string prenume)
        {
            nume = Persoana.Capitalize(nume);
            prenume = Persoana.Capitalize(prenume);

            for (int i = 0; i < N; i++)
            {
                if (locuitori[i].Nume.Equals(nume) && locuitori[i].Prenume.Equals(prenume))
                {
                    return new Locuitor(locuitori[i]);
                }
            }
            return null;
        }

        public Locuitor GetLocuitorCNP(string cnp)
        {
            for (int i = 0; i < N; i++)
            {
                if (locuitori[i].CNP.Equals(cnp.Trim()))
                {
                    return new Locuitor(locuitori[i]);
                }
            }
            return null;
        }
    }
}
