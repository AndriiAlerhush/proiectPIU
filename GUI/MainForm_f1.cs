
using DataBase;
using LibrarieModele;
using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class MainForm : Form
    {
        //
        // Fields
        //
        private Database database;
        //
        private AdministrareLocuitoriMemorie adminMemorie;
        private ReturnCodes code;

        Timer timer;

        public MainForm()
        {
            InitializeComponent();

            //
            // MainForm Settings
            //
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Size = new Size(810, 475);
            //
            // MainForm Events
            //
            this.Click += MainForm_Click;

            //
            // Database initialization
            //
            string connectionString = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString;
            database = new Database(connectionString);

            //
            // afisorLocuitori Settings
            //
            afisorLocuitori.ReadOnly = true;
            afisorLocuitori.AllowUserToAddRows = false;
            afisorLocuitori.AllowUserToDeleteRows = false;
            afisorLocuitori.RowHeadersVisible = false;
            afisorLocuitori.AllowUserToResizeColumns = false;
            afisorLocuitori.AllowUserToResizeRows = false;
            //afisorLocuitori.TabStop = false;
            afisorLocuitori.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            afisorLocuitori.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            // afisorLocuitori Events
            //
            afisorLocuitori.MouseDown += AfisorLocuitori_MouseDown;
            afisorLocuitori.KeyDown += AfisorLocuitori_KeyDown;
            //afisorLocuitori.MouseLeave += AfisorLocuitori_MouseLeave;
            //afisorLocuitori.MouseEnter += AfisorLocuitori_MouseEnter;
            //
            // afisorLocuitori Context Menu
            //
            ToolStripMenuItem add = new ToolStripMenuItem("Adaugare");
            add.Click += Adaugare_Context_Menu_Click;
            contextMenuAfisorLocuitori.Items.Add(add);

            ToolStripMenuItem delete = new ToolStripMenuItem("Eliminare");
            delete.Click += Eliminare_Context_Menu_Click;
            contextMenuAfisorLocuitoriRecord.Items.Add(delete);
            ToolStripMenuItem update = new ToolStripMenuItem("Update");
            update.Click += Update_Context_Menu_Click;
            contextMenuAfisorLocuitoriRecord.Items.Add(update);
            ToolStripMenuItem add1 = new ToolStripMenuItem("Adaugare");
            add1.Click += Adaugare_Context_Menu_Click;
            contextMenuAfisorLocuitoriRecord.Items.Add(add1);

            //
            // Timer
            //
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            //
            // adminLocuitori initialization
            //
            database.GetAllLocuitori(out DataTable locuitori_);
            database.AnswerConverter(locuitori_, out List<Locuitor> locuitoriBd);
            adminMemorie = new AdministrareLocuitoriMemorie(locuitoriBd);

            toolTip1.SetToolTip(imaginePlus, "Adaugare");
            toolTip1.SetToolTip(imagineMinus, "Eliminare");
        }

        //
        // --------------------------------------------------------------------------------
        //

        //
        // MainForm
        //
        // Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            AfisareLocuitori();
            //afisorLocuitori.Focus();
            this.ActiveControl = afisorLocuitori;
            afisorLocuitori.ClearSelection();
            afisorLocuitori.CurrentCell = null;
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            afisorLocuitori.ClearSelection();
            afisorLocuitori.CurrentCell = null;
        }

        //
        // StripMenu Events
        //
        private void Exit_StripMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //
        // afisorLocuitori
        //
        // Afisare
        private void AfisareLocuitori()
        {
            afisorLocuitori.DataSource = null;

            code = adminMemorie.ListToDataTableConverter(out DataTable locuitori);

            //DataColumn newColumn = new DataColumn($"Nr. ({locuitori.Rows.Count})", typeof(string));
            //locuitori.Columns.Add(newColumn);
            //newColumn.SetOrdinal(0);

            //for (int i = 0; i < locuitori.Rows.Count; i++)
            //{
            //    locuitori.Rows[i][0] = i + 1;
            //}

            if (code == ReturnCodes.SUCCES)
            {
                afisorLocuitori.DataSource = locuitori;

                //afisorLocuitori.Columns[$"Nr. ({locuitori.Rows.Count})"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                //afisorLocuitori.Columns[$"Nr. ({locuitori.Rows.Count})"].Width = 75;
                afisorLocuitori.Columns["ID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                afisorLocuitori.Columns["Nume"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                afisorLocuitori.Columns["Prenume"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                afisorLocuitori.Columns["Sex"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                afisorLocuitori.Columns["Data nasterii"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                afisorLocuitori.Columns["CNP"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                afisorLocuitori.Columns["Camera"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            }

            labelNrInt.Text = locuitori.Rows.Count.ToString();
        }

        //
        // afisorLocuitori Events
        //
        private void AfisorLocuitori_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit;

            if (e.Button == MouseButtons.Left)
            {
                hit = afisorLocuitori.HitTest(e.X, e.Y);

                if (hit.Type == DataGridViewHitTestType.None)
                {
                    afisorLocuitori.ClearSelection();
                    afisorLocuitori.CurrentCell = null;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                hit = afisorLocuitori.HitTest(e.X, e.Y);

                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    afisorLocuitori.ClearSelection();
                    afisorLocuitori.Rows[hit.RowIndex].Selected = true;
                    contextMenuAfisorLocuitoriRecord.Show(afisorLocuitori, e.Location);
                }
                else if (afisorLocuitori.SelectedRows.Count > 0)
                {
                    contextMenuAfisorLocuitoriRecord.Show(afisorLocuitori, e.Location);
                }
                else
                {
                    contextMenuAfisorLocuitori.Show(afisorLocuitori, e.Location);
                }
            }
        }

        private void AfisorLocuitori_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;

                if (afisorLocuitori.Rows.Count > 0)
                {
                    if (afisorLocuitori.CurrentCell != null)
                    {
                        DataGridViewCell currentCell = afisorLocuitori.CurrentCell;

                        int nextRowIndex = (currentCell.RowIndex + 1) % afisorLocuitori.Rows.Count;
                        int columnIndex = currentCell.ColumnIndex;

                        afisorLocuitori.CurrentCell = afisorLocuitori.Rows[nextRowIndex].Cells[columnIndex];
                    }
                    else
                    {
                        afisorLocuitori.CurrentCell = afisorLocuitori.Rows[0].Cells[0];
                    }

                    afisorLocuitori.CurrentCell.Selected = true;
                }
            }
        }

        //
        // afisorLocuitori Context Menu
        //
        // Eliminare
        private void Eliminare_Context_Menu_Click(object sender, EventArgs e)
        {
            int n = afisorLocuitori.SelectedRows.Count;

            if (n > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Sigur doriti sa eliminati locuitorul?", "Confirmare Eliminare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in afisorLocuitori.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells[0].Value);
                        adminMemorie.DeleteLocuitor(id);
                        database.DeleteLocuitor(id);
                    }

                    AfisareLocuitori();
                    afisorLocuitori.ClearSelection();
                }
            }
        }

        private void Update_Context_Menu_Click(object sender, EventArgs e)
        {
            if (afisorLocuitori.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(afisorLocuitori.SelectedRows[0].Cells[0].Value);
                AddForm addForm = new AddForm(adminMemorie, database, true, id);

                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    AfisareLocuitori();

                    for (int i = 0; i < afisorLocuitori.Rows.Count; i++)
                    {
                        if ((int)afisorLocuitori.Rows[i].Cells["ID"].Value == addForm.CurentLocuitorId)
                        {
                            afisorLocuitori.ClearSelection();
                            afisorLocuitori.Rows[i].Selected = true;
                            afisorLocuitori.FirstDisplayedScrollingRowIndex = i;
                            break;
                        }
                    }

                    timer.Start();
                }
            }
            else MessageBox.Show("Nu sunt locuitori!", "Update");
        }

        // Adaugare
        private void Adaugare_Context_Menu_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(adminMemorie, database);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                AfisareLocuitori();

                for (int i = 0; i < afisorLocuitori.Rows.Count; i++)
                {
                    if ((int)afisorLocuitori.Rows[i].Cells["ID"].Value == addForm.CurentLocuitorId)
                    {
                        afisorLocuitori.ClearSelection();
                        afisorLocuitori.Rows[i].Selected = true;
                        afisorLocuitori.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }

                timer.Start();
            }
        }

        // Timer
        private void Timer_Tick(object sender, EventArgs e)
        {
            afisorLocuitori.ClearSelection();
            timer.Stop();
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(adminMemorie, database);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                AfisareLocuitori();

                for (int i = 0; i < afisorLocuitori.Rows.Count; i++)
                {
                    if ((int)afisorLocuitori.Rows[i].Cells["ID"].Value == addForm.CurentLocuitorId)
                    {
                        afisorLocuitori.ClearSelection();
                        afisorLocuitori.Rows[i].Selected = true;
                        afisorLocuitori.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }

                timer.Start();
            }
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            int n = afisorLocuitori.SelectedRows.Count;

            if (n > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Sigur doriti sa eliminati locuitorul?", "Confirmare Eliminare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in afisorLocuitori.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells[0].Value);
                        adminMemorie.DeleteLocuitor(id);
                        database.DeleteLocuitor(id);
                    }

                    AfisareLocuitori();
                    afisorLocuitori.ClearSelection();
                }
            }
            else MessageBox.Show("Alegeti locuitorul/locuitorii pe care doriti sa-l/sa-i eliminati.", "Eliminare");
        }
    }
}
