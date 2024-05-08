
using DataBase;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class SignForm : Form
    {
        //
        // Fields
        //
        private readonly Database database;

        private bool darkMode = false;

        //
        // Constructor
        //
        public SignForm()
        {
            InitializeComponent();
            
            //
            // SignForm Settings
            //
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            //
            // SignForm Events
            //
            this.DoubleClick += SignForm_DoubleClick;
            this.KeyDown += new KeyEventHandler(SignForm_KeyDown);
            //
            // MenuStrip, Exit Events
            //
            exit_StripMenu.MouseEnter += Exit_StripMenu_MouseEnter;
            exit_StripMenu.MouseLeave += Exit_StripMenu_MouseLeave;
            //
            //
            // ToolTip
            //
            toolTip.SetToolTip(labelGuestMode, "Click");
            toolTip.SetToolTip(pictureLogin, "Login");
            toolTip.SetToolTip(picturePassword, "Password");
            //
            // Database
            //
            string connectionString = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;
            database = new Database(connectionString);
        }

        // ----------------------------------------------------------------------------

        //
        // SignForm Methods
        //
        #region
        private void SignForm_Load(object sender, EventArgs e)
        {
            menuStrip.BackColor = ColorTranslator.FromHtml(Culori.lightMode_MenuStrip_BackColor);

            textLogin.TabIndex = 0;
            textPassword.TabIndex = 1;
            buttonSignIn.TabIndex = 2;

            textLogin.MaxLength = 50;
            textPassword.MaxLength = 50;

            PasswordHide();

            if (!database.IsAvailable)
            {
                MessageBox.Show("Eroare conectare BD!", "Database");
                this.Close();
            }
        }

        private void ShowMainForm(bool adminMode = false)
        {
            this.Hide();
            MainForm mainForm = new MainForm(adminMode);
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }

        private void PasswordShow()
        {
            picturePassShow.Visible = false;
            picturePassHide.Visible = true;
            textPassword.UseSystemPasswordChar = false;
            toolTip.SetToolTip(picturePassHide, "Hide password");
        }

        private void PasswordHide()
        {
            picturePassShow.Visible = true;
            picturePassHide.Visible = false;
            textPassword.UseSystemPasswordChar = true;
            toolTip.SetToolTip(picturePassShow, "Show password");
        }

        private void SetDarkMode()
        {
            // Form
            this.BackColor = ColorTranslator.FromHtml(Culori.darkMode_FormsColor);
            // Labels
            labelSignIn.ForeColor = ColorTranslator.FromHtml(Culori.darkMode_Labels_ForeColor);
            // TextBoxes
            textLogin.BackColor = ColorTranslator.FromHtml(Culori.darkMode_TextBoxes_BackColor);
            textPassword.BackColor = ColorTranslator.FromHtml(Culori.darkMode_TextBoxes_BackColor);
            textLogin.ForeColor = ColorTranslator.FromHtml(Culori.darkMode_TextBoxes_ForeColor);
            textPassword.ForeColor = ColorTranslator.FromHtml(Culori.darkMode_TextBoxes_ForeColor);
            // Buttons
            buttonSignIn.BackColor = ColorTranslator.FromHtml(Culori.darkMode_Buttons_BackColor);
            buttonSignIn.ForeColor = ColorTranslator.FromHtml(Culori.darkMode_Buttons_ForeColor);
            //
            // MenuStrip
            //
            menuStrip.BackColor = ColorTranslator.FromHtml(Culori.darkMode_MenuStrip_BackColor);
        }

        private void SetLightMode()
        {
            // Form
            this.BackColor = ColorTranslator.FromHtml(Culori.lightMode_BackColor);
            // Labels
            labelSignIn.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
            // TextBoxes
            textLogin.BackColor = ColorTranslator.FromHtml(Culori.lightMode_BackColor);
            textPassword.BackColor = ColorTranslator.FromHtml(Culori.lightMode_BackColor);
            textLogin.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
            textPassword.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
            // Buttons
            buttonSignIn.BackColor = ColorTranslator.FromHtml(Culori.lightMode_BackColor);
            buttonSignIn.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
            //
            // MenuStrip
            //
            menuStrip.BackColor = ColorTranslator.FromHtml(Culori.lightMode_MenuStrip_BackColor);
        }
        #endregion

        //
        // SignForm Events
        //
        private void SignForm_DoubleClick(object sender, EventArgs e)
        {
            if (!darkMode)
            {
                SetDarkMode();
                darkMode = true;
            }
            else
            {
                SetLightMode();
                darkMode = false;
            }
        }

        private void SignForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.H)
            {
                if (textPassword.UseSystemPasswordChar)
                {
                    PasswordShow();
                }
                else PasswordHide();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.G)
            {
                ShowMainForm();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        //
        // Button Events
        //
        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            string login = textLogin.Text.Trim();
            string password = textPassword.Text.Trim();

            var returnCode = database.CheckAdmin(login, password, out _);

            if (returnCode == DbReturnCodes.RECORD_EXISTS)
            {
                ShowMainForm(true);
            }
            else MessageBox.Show("Date invalide!", "Admin");
        }

        //
        // Label Events
        //
        private void LabelGuestMode_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        //
        // Picture Events
        //
        private void PicturePassShow_Click(object sender, EventArgs e)
        {
            PasswordShow();
        }

        private void PicturePassHide_Click(object sender, EventArgs e)
        {
            PasswordHide();
        }

        //
        // MenuStrip Events
        //
        #region
        //
        // Exit
        //
        private void Exit_StripMenu_MouseEnter(object sender, EventArgs e)
        {
            exit_StripMenu.ForeColor = ColorTranslator.FromHtml(Culori.error_Labels_ForeColor);
        }

        private void Exit_StripMenu_MouseLeave(object sender, EventArgs e)
        {
            exit_StripMenu.ForeColor = ColorTranslator.FromHtml(Culori.lightMode_ForeColor);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
