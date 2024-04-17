
using ListaModele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NivelStocareDate
{
    public class AdministrareLocuitoriFisierText
    {
        private string numeFisier;

        public AdministrareLocuitoriFisierText(string numeFisier)
        {
            this.numeFisier = numeFisier.Trim();
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
            //using (StreamWriter swFisierText = new StreamWriter(numeFisier, false)) {}
        }

        public void AddLocuitor(Locuitor locuitor)
        {
            using (StreamWriter swFisierText = new StreamWriter(numeFisier, true))
            {
                swFisierText.WriteLine(locuitor.ConversieLaSirPentruFisierText());
            }
        }

        public List<Locuitor> GetLocuitori()
        {
            List<Locuitor> locuitori = new List<Locuitor>();

            using (StreamReader srFisierText = new StreamReader(numeFisier))
            {
                string linieFisier;

                while ((linieFisier = srFisierText.ReadLine()) != null)
                {
                    locuitori.Add(new Locuitor(linieFisier));
                }
            }

            return locuitori;
        }

        public static string afisareLocuitori(List<Locuitor> locuitori)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < locuitori.Count; i++)
            {
                sb.AppendFormat("Locuitor {0}\n", i + 1);
                sb.Append(locuitori[i].ToString());
                sb.Append("\n");
            }
            return sb.Remove(sb.Length - 1, 1).ToString();
        }
    }
}
