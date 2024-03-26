
using ListaModele;
using System;
using System.Text;

namespace NivelStocareDate
{
    public class AdministrarePersonal
    {
        // campuri & proprietati
        private const int N_MAX_PERSONAL = 10;
        private Personal[] personal;
        private int n;
        public int N
        {
            get { return n; }
            private set { n = value; }
        }

        // constructoare

        public AdministrarePersonal()
        {
            personal = new Personal[N_MAX_PERSONAL];
            N = 0;
        }

        // metode

        public bool AddPersonal(Personal persoana)
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

        public Personal GetResponsabil(string nume)
        {
            for (int i = 0; i < N; i++)
            {
                if (personal[i].Nume.Equals(nume))
                {
                    return new Personal(personal[i]);
                }
            }
            return null;
        }

        public Personal GetResponsabil(string nume, string prenume)
        {
            for (int i = 0; i < N; i++)
            {
                if (personal[i].Nume.Equals(nume) && personal[i].Prenume.Equals(prenume))
                {
                    return new Personal(personal[i]);
                }
            }
            return null;
        }

        public Personal GetResponsabilCNP(string cnp)
        {
            for (int i = 0; i < N; i++)
            {
                if (personal[i].CNP.Equals(cnp))
                {
                    return new Personal(personal[i]);
                }
            }
            return null;
        }
    }
}
