using ListaModele;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class AddLocuitorForm : Form
    {
        private const int NR_MAX_CARACTERE = 15;
        private const int VALID = 1;

        private Color CuloareTextImplicit = Color.Black;
        private Color CuloareTextEroare = Color.Red;

        private List<Locuitor> locuitori;
        private AdministrareLocuitoriFisierText adminiLocFisierText;

        public AddLocuitorForm(ref List<Locuitor> locuitoriMain, string numeFisier)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            //Size = new Size(500, 500);

            locuitori = locuitoriMain;
            adminiLocFisierText = new AdministrareLocuitoriFisierText(numeFisier);

            textNume.TextChanged += textNume_TextChanged;
            textPrenume.TextChanged += textPrenume_TextChanged;
            textCnp.TextChanged += textCnp_TextChanged;
            buttonSalvareLocuitor.Click += ButtonSalvareLocuitor_Click;
        }

        private CoduriEroare ValidareNume()
        {
            // 1 - OK
            // 2 - Nume este gol
            // 3 - Nume > 15

            string nume = textNume.Text.Trim();

            if (string.IsNullOrEmpty(nume)) return CoduriEroare.NumeGol;
            if (nume.Length > NR_MAX_CARACTERE) return CoduriEroare.NumePreaLung;

            return CoduriEroare.NumeOk;
        }

        private CoduriEroare ValidarePrenume()
        {
            // 4 - OK
            // 5 - Prenume este gol
            // 6 - Prenume > 15

            string prenume = textPrenume.Text.Trim();

            if (string.IsNullOrEmpty(prenume)) return CoduriEroare.PrenumeGol;
            if (prenume.Length > NR_MAX_CARACTERE) return CoduriEroare.PrenumePreaLung;

            return CoduriEroare.PrenumeOk;
        }

        private CoduriEroare ValidareCnp()
        {
            // 7 - Note OK
            // 8 - Note este gol

            string cnp = textCnp.Text.Trim();

            if (string.IsNullOrEmpty(cnp)) return CoduriEroare.CnpGol;
            if (cnp.Length < 13) return CoduriEroare.CnpPreaScurt;
            if (cnp.Length > 13) return CoduriEroare.CnpPreaLung;

            foreach (char caracter in cnp)
            {
                if (!int.TryParse(caracter.ToString(), out int notaInt)) return CoduriEroare.CnpDateInvalide;
            }

            return CoduriEroare.CnpOk;
        }

        private int ValidareDate()
        {
            // 1 - Nume OK
            // 2 - Nume este gol
            // 3 - Nume > 15
            // 4 - Prenume OK
            // 5 - Prenume este gol
            // 6 - Prenume > 15
            // 7 - Note OK
            // 8 - Note este gol
            // 9 - Note Date invalide
            // 10 - studentul deja exista

            CoduriEroare cod;

            bool eroare = false;

            if ((cod = ValidareNume()) != CoduriEroare.NumeOk)
            {
                ModificareControale(cod);
                eroare = true;
            }
            if ((cod = ValidarePrenume()) != CoduriEroare.PrenumeOk)
            {
                ModificareControale(cod);
                eroare = true;
            }
            if ((cod = ValidareCnp()) != CoduriEroare.CnpOk)
            {
                ModificareControale(cod);
                eroare = true;
            }
            if (!eroare)
            {
                if (ExistaLocuitor(Persoana.Capitalize(textNume.Text.Trim()),
                                  Persoana.Capitalize(textPrenume.Text.Trim())))
                {
                    ModificareControale(CoduriEroare.LocuitorulDejaExista);
                    return 0;
                }
            }
            else return 0;

            return 1;
        }

        private void ModificareControale(CoduriEroare cod)
        {
            // 1 - Nume OK
            // 2 - Nume este gol
            // 3 - Nume > 15
            // 4 - Prenume OK
            // 5 - Prenume este gol
            // 6 - Prenume > 15
            // 7 - Note OK
            // 8 - Note este gol
            // 9 - Note Date invalide
            // 10 - studentul deja exista

            switch (cod)
            {
                case CoduriEroare.None:
                    break;

                case CoduriEroare.NumeOk:
                    labelNume.ForeColor = CuloareTextImplicit;
                    labelEroareNume.Text = "";
                    break;
                case CoduriEroare.NumeGol:
                    labelNume.ForeColor = CuloareTextEroare;
                    labelEroareNume.Text = "*obligatoriu";
                    break;

                case CoduriEroare.NumePreaLung:
                    labelNume.ForeColor = CuloareTextEroare;
                    labelEroareNume.Text = ">15!";
                    break;

                case CoduriEroare.PrenumeOk:
                    labelPrenume.ForeColor = CuloareTextImplicit;
                    labelEroarePrenume.Text = "";
                    break;

                case CoduriEroare.PrenumeGol:
                    labelPrenume.ForeColor = CuloareTextEroare;
                    labelEroarePrenume.Text = "*obligatoriu";
                    break;

                case CoduriEroare.PrenumePreaLung:
                    labelPrenume.ForeColor = CuloareTextEroare;
                    labelEroarePrenume.Text = ">15!";
                    break;

                case CoduriEroare.CnpOk:
                    labelCnp.ForeColor = CuloareTextImplicit;
                    labelEroareCnp.Text = "";
                    break;

                case CoduriEroare.CnpGol:
                    labelCnp.ForeColor = CuloareTextEroare;
                    labelEroareCnp.Text = "*obligatoriu";
                    break;

                case CoduriEroare.CnpDateInvalide:
                    labelCnp.ForeColor = CuloareTextEroare;
                    labelEroareCnp.Text = "date invalide!";
                    break;

                case CoduriEroare.CnpPreaScurt:
                    labelCnp.ForeColor = CuloareTextEroare;
                    labelEroareCnp.Text = "<13!";
                    break;


                case CoduriEroare.CnpPreaLung:
                    labelCnp.ForeColor = CuloareTextEroare;
                    labelEroareCnp.Text = ">13!";
                    break;

                case CoduriEroare.LocuitorulDejaExista:
                    MessageBox.Show("Asa student deja exista!");
                    break;
            }
        }

        private bool ExistaLocuitor(string nume, string prenume)
        {
            foreach (Locuitor locuitor in locuitori)
            {
                if (locuitor.Nume.Equals(nume) && locuitor.Prenume.Equals(prenume))
                {
                    return true;
                }
            }
            return false;
        }

        private void textCnp_TextChanged(object sender, EventArgs e)
        {
            ModificareControale(ValidareCnp());
        }

        private void textPrenume_TextChanged(object sender, EventArgs e)
        {
            ModificareControale(ValidarePrenume());
        }

        private void textNume_TextChanged(object sender, EventArgs e)
        {
            ModificareControale(ValidareNume());
        }

        private void ButtonSalvareLocuitor_Click(object sender, EventArgs e)
        {
            int cod = ValidareDate();
            if (cod == VALID)
            {
                string nume = textNume.Text.Trim();
                string prenume = textPrenume.Text.Trim();
                string sex = textSex.Text.Trim();
                string dataNasterii = textDataNasterii.Text.Trim();
                string cnp = textCnp.Text.Trim();
                int camera = int.Parse(textCamera.Text.Trim());

                Locuitor locuitor = new Locuitor(nume, prenume, sex, dataNasterii, cnp, camera);

                locuitori.Add(locuitor);
                adminiLocFisierText.AddLocuitor(locuitor);
            }
        }
    }
}
