
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ListaModele;
using NivelStocareDate;
using System.Configuration;
using System.Data;
using DataBases;
using System.Drawing;

namespace GUI
{
    public partial class MainForm : Form
    {
        private List<Locuitor> locuitori;

        private string numeFisier;

        public MainForm()
        {
            InitializeComponent();

            this.Size = new System.Drawing.Size(1100, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            string caleSolutie = Directory.GetParent(Directory.GetParent(
                                 Directory.GetParent(Directory.GetParent(
                                 Directory.GetCurrentDirectory()).FullName).FullName).FullName).FullName;

            string caleFisier = "\\ProiecteComponente\\Consola\\bin\\Debug\\";
            //string numeFisier = caleFisier + ConfigurationManager.AppSettings["NumeFisier"];

            numeFisier = caleSolutie + caleFisier + ConfigurationManager.AppSettings["NumeFisier"];

            //string radacinaProiectului = AppDomain.CurrentDomain.BaseDirectory;
            //MessageBox.Show(numeFisier);

            AdministrareLocuitoriFisierText administrareLocuitoriFisierText = new AdministrareLocuitoriFisierText(numeFisier);

            locuitori = administrareLocuitoriFisierText.GetLocuitori();

            //

            string sqlConnection = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;

            //

            afisorLocuitori.Size = new System.Drawing.Size(1000, 150);

            afisorLocuitori.ReadOnly = true;
            afisorLocuitori.AllowUserToAddRows = false;
            afisorLocuitori.AllowUserToDeleteRows = false;
        }

        //
        //
        //

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRefreshLocuitori_Click(object sender, EventArgs e)
        {
            AfisareLocuitori();
        }

        private void AfisareLocuitori()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Nume", typeof(string));
            dataTable.Columns.Add("Prenume", typeof(string));
            dataTable.Columns.Add("Sex", typeof(string));
            dataTable.Columns.Add("Data nasterii", typeof(string));
            dataTable.Columns.Add("Varsta", typeof(string));
            dataTable.Columns.Add("CNP", typeof(string));
            dataTable.Columns.Add("Etaj", typeof(int));
            dataTable.Columns.Add("Camera", typeof(int));

            foreach (Locuitor locuitor in locuitori)
            {
                dataTable.Rows.Add(locuitor.Id, locuitor.Nume, locuitor.Prenume, locuitor.Sex, locuitor.DataNasterii, locuitor.Varsta, locuitor.Cnp, locuitor.Etaj, locuitor.Camera);
            }

            afisorLocuitori.DataSource = dataTable;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AfisareLocuitori();
        }

        private void buttonAdaugaLocuitor_Click(object sender, EventArgs e)
        {
            AddLocuitorForm addLocuitorForm = new AddLocuitorForm(ref locuitori, numeFisier);
            addLocuitorForm.ShowDialog();
        }
    }
}
