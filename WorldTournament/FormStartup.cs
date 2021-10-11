using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldTournament
{
    public partial class FormStartup : Form
    {
        public FormStartup()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister NewRegister = new FormRegister();
            NewRegister.Show();
        }

        private void btnDeleteFighter_Click(object sender, EventArgs e)
        {
            FormDelete Deletion = new FormDelete();
            Deletion.Show();
        }

        private void btnCheckFighter_Click(object sender, EventArgs e)
        {
            FormCheckInfo Consult = new FormCheckInfo();
            Consult.Show();
        }

        private void btnEditFighter_Click(object sender, EventArgs e)
        {
            FormEdit Edit = new FormEdit();
            Edit.Show();
        }
    }
}
