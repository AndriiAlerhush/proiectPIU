
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaModele;

namespace NivelStocareDate
{
    public class AdministrareCamin
    {
        private const int N_MAX_PERSOANE = 50;
        private Persoana[] persoane;
        public int N
        {
            get { return N; }
            private set { N = value; }
        }

        public AdministrareCamin()
        {
            persoane = new Persoana[N_MAX_PERSOANE];
            N = 0;
        }

        public void AddLocuitor(Locuitor locuitor)
        {
            persoane[N] = locuitor;
            N++;
        }
    }
}
