
using ListaModele;
using System;
using System.Text;

namespace NivelStocareDate
{
    public class AdministrarePersonalMemorie
    {
        // campuri & proprietati
        private const int N_MAX_PERSONAL = 10;
        private Responsabil[] personal;
        private int n;
        public int N
        {
            get { return n; }
            private set { n = value; }
        }

        // constructoare

        public AdministrarePersonalMemorie()
        {
            personal = new Responsabil[N_MAX_PERSONAL];
            N = 0;
        }

        // metode

        public bool AddPersonal(Responsabil persoana)
        {
            if (N <= N_MAX_PERSONAL)
            {
                personal[N] = persoana;
                N++;
                return true;
            }
            return false;
        }

        public string afisarePersonal()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                sb.AppendFormat("Responsabil {0}\n", i + 1);
                sb.Append(personal[i].ToString());
                sb.Append("\n");
            }
            return sb.Remove(sb.Length - 1, 1).ToString();
        }

        public override string ToString()
        {
            return this.afisarePersonal();
        }

        public Responsabil GetResponsabil(string nume)
        {
            nume = nume.Trim().ToLower();

            for (int i = 0; i < N; i++)
            {
                if (personal[i].Nume.ToLower().Equals(nume))
                {
                    return new Responsabil(personal[i]);
                }
            }
            return null;
        }

        public Responsabil GetResponsabil(string nume, string prenume)
        {
            nume = nume.Trim().ToLower();
            prenume = prenume.Trim().ToLower();

            for (int i = 0; i < N; i++)
            {
                if (personal[i].Nume.ToLower().Equals(nume) &&
                    personal[i].Prenume.ToLower().Equals(prenume))
                {
                    return new Responsabil(personal[i]);
                }
            }
            return null;
        }

        public Responsabil GetResponsabilCNP(string cnp)
        {
            cnp = cnp.Trim();

            for (int i = 0; i < N; i++)
            {
                if (personal[i].CNP.Equals(cnp))
                {
                    return new Responsabil(personal[i]);
                }
            }

            return null;
        }

        //public Responsabil[] GetResponsabili(Posturi post)
        //{
        //    byte n = 0;
        //    for (int i = 0; i < N; i++)
        //    {
        //        if (personal[i].Post == (int)post)
        //        {
        //            n++;
        //        }
        //    }

        //    Responsabil[] responsabili = new Responsabil[n];

        //    int j = 0;
        //    for (int i = 0; i < N; i++)
        //    {
        //        if (personal[i].Post == (int)post)
        //        {
        //            responsabili[j++] = new Responsabil(personal[i]);
        //        }
        //    }

        //    return responsabili;
        //}
    }
}
