using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NivelStocareDate;
using LibrarieModele;

namespace ProiectPIU
{
    public partial class Form1 : Form
    {
        private AdministrareLocuitoriMemorie locuitoriMemorie;

        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
