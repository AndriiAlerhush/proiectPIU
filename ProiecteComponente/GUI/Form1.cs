
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ListaModele;
using NivelStocareDate;
using System.Configuration;

namespace GUI
{
    public partial class Form1 : Form
    {
        private TextBox textNume;

        public Form1()
        {
            InitializeComponent();

            this.Size = new System.Drawing.Size(1025, 400);

            textNume = new TextBox();
            this.Controls.Add(this.textNume);

            string caleSolutie = Directory.GetParent(Directory.GetParent(
                                       Directory.GetParent(Directory.GetParent(
                                       Directory.GetCurrentDirectory()).FullName).FullName).FullName).FullName;

            string caleFisier = "\\ProiecteComponente\\Consola\\bin\\Debug\\";
            //string numeFisier = caleFisier + ConfigurationManager.AppSettings["NumeFisier"];

            string numeFisier = caleSolutie + caleFisier + ConfigurationManager.AppSettings["NumeFisier"];

            //string radacinaProiectului = AppDomain.CurrentDomain.BaseDirectory;
            MessageBox.Show(numeFisier);

            AdministrareLocuitoriFisierText administrareLocuitoriFisierText = new AdministrareLocuitoriFisierText(numeFisier);

            List<Locuitor> locuitoriFisier = administrareLocuitoriFisierText.GetLocuitori();

            string nume = locuitoriFisier[0].Nume;

            if (!string.IsNullOrEmpty(nume))
            {
                textNume.Text = locuitoriFisier[0].Nume;
            }

            dataGridView1.DataSource = locuitoriFisier;
        }
    }
}
