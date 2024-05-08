
using DataBase;
using LibrarieModele;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class AddForm : Form
    {
        //
        private const bool VALID = false;
        //
        private const int NR_MAX_CAR_NUME_PRENUME = 15;
        private const int NR_MAX_CIFRE_CNP = 13;
        private const int NR_MAX_DE_ETAJE = 4;
        private const int NR_MAX_DE_CAMERE_PE_ETAJ = 25;
        //

        private Database database;
        //private DbReturnCodes dbCode;

        private AdministrareLocuitoriMemorie adminMemorie;
        private ReturnCodes code;

        public int CurentLocuitorId { get; private set; } = 0;

        private Locuitor locuitorCurent;

        public AddForm(AdministrareLocuitoriMemorie adminMemorie_, Database database_, bool updateMode = false, int id = 0)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            database = database_;
            adminMemorie = adminMemorie_;

            //
            // TextBox Events
            //
            // TextChanged
            //
            textNume.TextChanged += TextNume_TextChanged;
            textPrenume.TextChanged += TextPrenume_TextChanged;
            dataPicker.ValueChanged += DataPicker_ValueChanged;
            textCnp.TextChanged += TextCnp_TextChanged;
            textCamera.TextChanged += TextCamera_TextChanged;
            //
            // Leave
            //
            textNume.Leave += TextNume_Leave;
            textPrenume.Leave += TextPrenume_Leave;
            comboBoxSex.Leave += ComboBoxSex_Leave;
            dataPicker.Leave += DataPicker_Leave;
            textCnp.Leave += TextCnp_Leave;
            textCamera.Leave += TextCamera_Leave;
            //
            // KeyDown
            //
            textNume.KeyDown += TextNume_KeyDown;
            textPrenume.KeyDown += TextPrenume_KeyDown;
            textCnp.KeyDown += TextCnp_KeyDown;
            textCamera.KeyDown += TextCamera_KeyDown;

            // comboBoxSex Settings
            comboBoxSex.DataSource = Enum.GetValues(typeof(Sexe));

            // ToolStrip Settings
            //toolTip.InitialDelay = 500;
            //toolTip.AutoPopDelay = 3000;

            if (updateMode)
            {
                this.Text = "Update";
                labelAdaugareLocuitor.Text = "  Update Locuitor";
                buttonSalvare.Visible = false;
                buttonUpdate.Visible = true;

                adminMemorie.GetLocuitor(id, out Locuitor locuitor);
                locuitorCurent = locuitor;

                textNume.Text = locuitor.Nume;
                textPrenume.Text = locuitor.Prenume;
                comboBoxSex.Text = locuitor.Sex.ToString();
                dataPicker.Value = locuitor.DataNasterii;
                textCnp.Text = locuitor.Cnp;
                textCamera.Text = locuitor.Camera.ToString();

                textNume.TabIndex = 0;
                textPrenume.TabIndex = 1;
                comboBoxSex.TabIndex = 2;
                dataPicker.TabIndex = 3;
                textCnp.TabIndex = 4;
                textCamera.TabIndex = 5;
                buttonUpdate.TabIndex = 6;
                buttonCuratare.TabIndex = 7;
            }
        }

        // -----------------------------------------------------------------------------

        //
        // TextBox Events
        //
        // TextChanged
        //
        private void TextNume_TextChanged(object sender, EventArgs e)
        {
            ModificareControale(ValidareNume());
        }

        private void TextPrenume_TextChanged(object sender, EventArgs e)
        {
            ModificareControale(ValidarePrenume());
        }

        private void DataPicker_ValueChanged(object sender, EventArgs e)
        {
            ModificareControale(ValidareDataNasterii());
        }

        private void TextCnp_TextChanged(object sender, EventArgs e)
        {
            ModificareControale(ValidareCnp());
        }

        private void TextCamera_TextChanged(object sender, EventArgs e)
        {
            ModificareControale(ValidareCamera());
        }
        //
        // Leave
        //
        private void TextNume_Leave(object sender, EventArgs e)
        {
            ModificareControale(ValidareNume());
            textNume.Text = Persoana.Capitalize(textNume.Text.Trim());
        }

        private void TextPrenume_Leave(object sender, EventArgs e)
        {
            ModificareControale(ValidarePrenume());
            textPrenume.Text = Persoana.Capitalize(textPrenume.Text.Trim());
        }

        private void ComboBoxSex_Leave(object sender, EventArgs e)
        {
            ModificareControale(ValidareSex());
        }

        private void DataPicker_Leave(object sender, EventArgs e)
        {
            ModificareControale(ValidareDataNasterii());
        }

        private void TextCnp_Leave(object sender, EventArgs e)
        {
            ModificareControale(ValidareCnp());
            textCnp.Text = Persoana.Capitalize(textCnp.Text.Trim());
        }

        private void TextCamera_Leave(object sender, EventArgs e)
        {
            ModificareControale(ValidareCamera());
            textCamera.Text = Persoana.Capitalize(textCamera.Text.Trim());
        }
        //
        // KeyDown
        //
        private void TextNume_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textNume.Text = Persoana.Capitalize(textNume.Text.Trim());
                textNume.SelectionStart = textNume.Text.Length;
                textNume.SelectionLength = 0;
                e.SuppressKeyPress = true;
            }
        }

        private void TextPrenume_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textPrenume.Text = Persoana.Capitalize(textPrenume.Text.Trim());
                textPrenume.SelectionStart = textPrenume.Text.Length;
                textPrenume.SelectionLength = 0;
                e.SuppressKeyPress = true;
            }
        }

        private void TextCnp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textCnp.Text = textCnp.Text.Trim();
                textCnp.SelectionStart = textCnp.Text.Length;
                textCnp.SelectionLength = 0;
                e.SuppressKeyPress = true;
            }
        }

        private void TextCamera_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textCamera.Text = textCamera.Text.Trim();
                textCamera.SelectionStart = textCamera.Text.Length;
                textCamera.SelectionLength = 0;
                e.SuppressKeyPress = true;
            }
        }
        //
        // Button Events
        //
        private void ButtonSalvare_Click(object sender, EventArgs e)
        {
            if (ValidareToateDateleIntroduse() == VALID)
            {
                string cnp = textCnp.Text;

                code = adminMemorie.CheckLocuitor(cnp);

                if (code == ReturnCodes.RECORD_DONT_EXISTS)
                {
                    string nume = textNume.Text;
                    string prenume = textPrenume.Text;
                    Sexe sex = (Sexe)Enum.Parse(typeof(Sexe), comboBoxSex.Text);
                    DateTime dataNasterii = DateTime.Parse(dataPicker.Text);
                    int camera = int.Parse(textCamera.Text);

                    database.AddLocuitor(nume, prenume, sex, dataNasterii, cnp, camera, out int id);
                    code = adminMemorie.AddLocuitor(new Locuitor(id, nume, prenume, sex, dataNasterii, cnp, camera));
                    
                    TextBoxesCleaner();
                    //DefaultControlsStyle();

                    this.DialogResult = DialogResult.OK;
                    CurentLocuitorId = id;

                    this.Close();
                }
                else MessageBox.Show("Locuitorul deja exista.", "Salvare");
            }
            else MessageBox.Show("Date invalide!", "Salvare");
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (ValidareToateDateleIntroduse() == VALID)
            {
                string nume = textNume.Text;
                string prenume = textPrenume.Text;
                Sexe sex = (Sexe)Enum.Parse(typeof(Sexe), comboBoxSex.Text);
                DateTime dataNasterii = DateTime.Parse(dataPicker.Text);
                string cnp = textCnp.Text;
                int camera = int.Parse(textCamera.Text);

                if (cnp.Equals(locuitorCurent.Cnp))
                {
                    database.UpdateLocuitor(locuitorCurent.Id, nume, prenume, sex, dataNasterii, cnp, camera);
                    code = adminMemorie.UpdateLocuitor(locuitorCurent.Id, nume, prenume, sex, dataNasterii, cnp, camera);

                    //TextBoxesCleaner();
                    //DefaultControlsStyle();

                    CurentLocuitorId = locuitorCurent.Id;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    code = adminMemorie.CheckLocuitor(cnp);

                    if (code == ReturnCodes.RECORD_DONT_EXISTS)
                    {
                        database.UpdateLocuitor(locuitorCurent.Id, nume, prenume, sex, dataNasterii, cnp, camera);
                        code = adminMemorie.UpdateLocuitor(locuitorCurent.Id, nume, prenume, sex, dataNasterii, cnp, camera);

                        //TextBoxesCleaner();
                        //DefaultControlsStyle();

                        CurentLocuitorId = locuitorCurent.Id;

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else MessageBox.Show("Locuitor cu asa CNP deja exista.", "Salvare");
                }
            }
            else MessageBox.Show("Date invalide!", "Salvare");
        }

        private void ButtonCuratare_Click(object sender, EventArgs e)
        {
            TextBoxesCleaner();
            DefaultControlsStyle();
        }

        //
        // Validari
        //
        private CoduriEroare ValidareNume()
        {
            string nume = textNume.Text.Trim();

            if (string.IsNullOrEmpty(nume)) return CoduriEroare.NumeGol;
            if (nume.Length > NR_MAX_CAR_NUME_PRENUME) return CoduriEroare.NumePreaLung;
            if (Regex.IsMatch(nume, @"\s|\d")) return CoduriEroare.NumeInvalid;

            return CoduriEroare.NumeOk;
        }

        private CoduriEroare ValidarePrenume()
        {
            string prenume = textPrenume.Text.Trim();

            if (string.IsNullOrEmpty(prenume)) return CoduriEroare.PrenumeGol;
            if (prenume.Length > NR_MAX_CAR_NUME_PRENUME) return CoduriEroare.PrenumePreaLung;
            if (Regex.IsMatch(prenume, @"\s|\d")) return CoduriEroare.PrenumeInvalid;

            return CoduriEroare.PrenumeOk;
        }

        private CoduriEroare ValidareDataNasterii()
        {
            if (!DateTime.TryParse(dataPicker.Text.Trim(), out DateTime dataNasterii))
            {
                dataNasterii = new DateTime(1900, 01, 01);
            }

            if (dataNasterii < new DateTime(1900, 01, 01) ||
                dataNasterii > DateTime.Today)
            {
                return CoduriEroare.DataNasteriiInvalida;
            }
            if (dataNasterii == DateTime.Today) return CoduriEroare.DataNasteriiNesetata;

            return CoduriEroare.DataNasteriiOk;
        }

        private CoduriEroare ValidareSex()
        {
            if (comboBoxSex.Text == Sexe.nesetat.ToString()) return CoduriEroare.SexNesetat;
            return CoduriEroare.SexOk;
        }

        private CoduriEroare ValidareCnp()
        {
            string cnp = textCnp.Text.Trim();

            if (string.IsNullOrEmpty(cnp)) return CoduriEroare.CnpGol;
            if (Regex.IsMatch(cnp, @"[^\d]")) return CoduriEroare.CnpInvalid;

            if (cnp.Length > NR_MAX_CIFRE_CNP) return CoduriEroare.CnpPreaLung;
            if (cnp.Length < NR_MAX_CIFRE_CNP) return CoduriEroare.CnpPreaScurt;

            return CoduriEroare.CnpOk;
        }

        private CoduriEroare ValidareCamera()
        {
            string camera = textCamera.Text.Trim();

            if (string.IsNullOrEmpty(camera)) return CoduriEroare.CameraGol;
            if (Regex.IsMatch(camera, @"[^\d]")) return CoduriEroare.CameraInvalid;
            if (int.TryParse(camera, out int nrCamerei))
            {
                int adjustedNumber = nrCamerei - 1;
                int remainder = adjustedNumber % 100;

                if (remainder >= 0 && remainder < NR_MAX_DE_CAMERE_PE_ETAJ)
                {
                    if (adjustedNumber / 100 <= NR_MAX_DE_ETAJE)
                    {
                        return CoduriEroare.CameraOk;
                    }
                }

                return CoduriEroare.CameraIncorecta;
            }
            else return CoduriEroare.CameraInvalid;
        }

        private bool ValidareToateDateleIntroduse()
        {
            CoduriEroare cod;
            bool state = VALID;

            if ((cod = ValidareNume()) != CoduriEroare.NumeOk)
            {
                ModificareControale(cod);
                state = !VALID;
            }
            if ((cod = ValidarePrenume()) != CoduriEroare.PrenumeOk)
            {
                ModificareControale(cod);
                state = !VALID;
            }
            if ((cod = ValidareSex()) != CoduriEroare.SexOk)
            {
                ModificareControale(cod);
                state = !VALID;
            }
            if ((cod = ValidareDataNasterii()) != CoduriEroare.DataNasteriiOk)
            {
                ModificareControale(cod);
                state = !VALID;
            }
            if ((cod = ValidareCnp()) != CoduriEroare.CnpOk)
            {
                ModificareControale(cod);
                state = !VALID;
            }
            if ((cod = ValidareCamera()) != CoduriEroare.CameraOk)
            {
                ModificareControale(cod);
                state = !VALID;
            }

            return state;
        }

        //
        // Methods
        //
        private bool ModificareControale(CoduriEroare cod)
        {
            switch (cod)
            {
                // None
                case CoduriEroare.None:
                    return false;
                    //break;

                // Nume
                case CoduriEroare.NumeOk:
                    imagineNume.Visible = false;
                    labelNume.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
                    return false;
                    //break;

                case CoduriEroare.NumeGol:
                    imagineNume.Visible = true;
                    labelNume.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imagineNume, "*Obligatoriu!");
                    return true;
                    //break;

                case CoduriEroare.NumePreaLung:
                    imagineNume.Visible = true;
                    labelNume.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imagineNume, $"Nume prea lung!\n(max. {NR_MAX_CAR_NUME_PRENUME} litere)");
                    return true;

                case CoduriEroare.NumeInvalid:
                    imagineNume.Visible = true;
                    labelNume.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imagineNume, "Nume invalid!");
                    return true;
                    //break;

                // Prenume
                case CoduriEroare.PrenumeOk:
                    imaginePrenume.Visible = false;
                    labelPrenume.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
                    return false;
                    //break;

                case CoduriEroare.PrenumeGol:
                    imaginePrenume.Visible = true;
                    labelPrenume.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imaginePrenume, "*Obligatoriu!");
                    return true;
                    //break;

                case CoduriEroare.PrenumePreaLung:
                    imaginePrenume.Visible = true;
                    labelPrenume.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imaginePrenume, $"Prenume prea lung!\n(max. {NR_MAX_CAR_NUME_PRENUME} litere)");
                    return true;
                    //break;

                case CoduriEroare.PrenumeInvalid:
                    imaginePrenume.Visible = true;
                    labelPrenume.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imaginePrenume, "Prenume invalid!");
                    return true;
                    //break;

                // Sex
                case CoduriEroare.SexOk:
                    imagineSex.Visible = false;
                    labelSex.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
                    return false;
                    //break;

                case CoduriEroare.SexNesetat:
                    imagineSex.Visible = true;
                    labelSex.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imagineSex, "*Obligatoriu!");
                    return true;
                    //break;

                // Data nasterii
                case CoduriEroare.DataNasteriiOk:
                    imagineData.Visible = false;
                    labelData.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
                    return false;
                //break;

                case CoduriEroare.DataNasteriiNesetata:
                    imagineData.Visible = true;
                    labelData.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imagineData, "*Obligatoriu!");
                    return true;
                //break;

                case CoduriEroare.DataNasteriiInvalida:
                    imagineData.Visible = true;
                    labelData.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imagineData, "Data invalida!");
                    return true;
                    //break;

                // CNP
                case CoduriEroare.CnpOk:
                    imagineCnp.Visible = false;
                    labelCnp.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
                    return false;
                    //break;

                case CoduriEroare.CnpGol:
                    imagineCnp.Visible = true;
                    labelCnp.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imagineCnp, "*Obligatoriu!");
                    return true;
                    //break;

                case CoduriEroare.CnpPreaScurt:
                    imagineCnp.Visible = true;
                    labelCnp.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imagineCnp, $"CNP prea scurt!\n(Trebuie sa fie {NR_MAX_CIFRE_CNP} cifre)");
                    return true;
                    //break;

                case CoduriEroare.CnpPreaLung:
                    imagineCnp.Visible = true;
                    labelCnp.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imagineCnp, $"CNP prea lung!\n(Trebuie sa fie {NR_MAX_CIFRE_CNP} cifre)");
                    return true;
                    //break;

                case CoduriEroare.CnpInvalid:
                    imagineCnp.Visible = true;
                    labelCnp.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imagineCnp, "CNP invalid!");
                    return true;
                    //break;

                // Camera
                case CoduriEroare.CameraOk:
                    imagineCamera.Visible = false;
                    labelCamera.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
                    return false;
                    //break;

                case CoduriEroare.CameraGol:
                    imagineCamera.Visible = true;
                    labelCamera.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imagineCamera, "*Obligatoriu!");
                    return true;
                    //break;

                case CoduriEroare.CameraInvalid:
                    imagineCamera.Visible = true;
                    labelCamera.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imagineCamera, "Nr. de camera invalid!");
                    return true;
                    //break;

                case CoduriEroare.CameraIncorecta:
                    imagineCamera.Visible = true;
                    labelCamera.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
                    toolTip.SetToolTip(imagineCamera, "Nr. de camera incorect!\n(1-25, 101-125 ... 401-425)");
                    return true;
                    //break;
            }
            return false;
        }

        private void TextBoxesCleaner()
        {
            textNume.Text = "";
            textPrenume.Text = "";
            comboBoxSex.Text = Sexe.nesetat.ToString();
            dataPicker.Text = DateTime.Now.ToString();
            textCnp.Text = "";
            textCamera.Text = "";
        }

        private void DefaultControlsStyle()
        {
            labelNume.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
            imagineNume.Visible = false;

            labelPrenume.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
            imaginePrenume.Visible = false;

            labelSex.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
            imagineSex.Visible = false;

            labelData.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
            imagineData.Visible = false;

            labelCnp.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
            imagineCnp.Visible = false;

            labelCamera.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
            imagineCamera.Visible = false;
        }

        private void Exit_StripMenu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
