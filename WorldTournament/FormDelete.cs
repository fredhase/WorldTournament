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
    public partial class FormDelete : Form
    {
        public FormDelete()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Verifying if the field isn't empty
            if (txtID.Text == "")
            {
                MessageBox.Show("Please, enter the number of the Fighter's ID");
            }
            else
            {
                // Verifying Data type
                int number;
                bool result = Int32.TryParse(txtID.Text, out number);
                if (!result)
                {
                    MessageBox.Show("The ID field only accepets numbers!");
                }
                else
                {
                    // Connects to the database to search for the informed ID
                    DBConnect Connect = new DBConnect();
                    Fighter SelectedFighter = new Fighter();
                    SelectedFighter = Connect.SelectByID(Convert.ToInt32(txtID.Text));

                    // If this ID does not exist, then a error message will be shown
                    if (SelectedFighter.Name == null)
                    {
                        MessageBox.Show($"Fighter of ID {txtID.Text} not found", "Error!");
                    }
                    // If the ID exists, a message showing the ID and name of the Fighter will be shown
                    else
                    {
                        var Confirm = MessageBox.Show("Confirm Fighter ID and name below." +
                            $"\nID: {SelectedFighter.ID}" +
                            $"\nName: {SelectedFighter.Name}", "Confirm Information", MessageBoxButtons.OKCancel);
                        // Clicking OK will delete de the fighter from the database. Clicking Cancel will just close
                        // the message box.
                        if (Confirm == DialogResult.OK)
                        {
                            Connect.Delete(SelectedFighter.ID);
                            MessageBox.Show("Fighter deleted!");
                            this.Close();
                        }

                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var Closure = MessageBox.Show("Close window and cancel deletion?", "Close?", MessageBoxButtons.YesNo);
            if (Closure == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
