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
    public partial class FormEdit : Form
    {
        public FormEdit()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var Closure = MessageBox.Show("Close window and cancel edit?", "Close?", MessageBoxButtons.YesNo);
            if (Closure == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Verifying if the field isn't empty
            if (txtEnterID.Text == "")
            {
                MessageBox.Show("Please, enter the number of the Fighter's ID");
            }
            else
            {
                // Verifying Data type
                int number;
                bool result = Int32.TryParse(txtEnterID.Text, out number);
                if (!result)
                {
                    MessageBox.Show("The ID field only accepets numbers!");
                }
                else
                {
                    // Connects to the database to search for the informed ID
                    DBConnect Connect = new DBConnect();
                    Fighter SelectedFighter = new Fighter();
                    SelectedFighter = Connect.SelectByID(Convert.ToInt32(txtEnterID.Text));

                    // If this ID does not exist, then a error message will be shown
                    if (SelectedFighter.Name == null)
                    {
                        MessageBox.Show($"Fighter of ID {txtEnterID.Text} not found", "Error!");
                    }
                    // If the ID exists, a message showing the ID and name of the Fighter will be shown
                    else
                    {
                        var Confirm = MessageBox.Show("Confirm Fighter ID and name below." +
                            $"\nID: {SelectedFighter.ID}" +
                            $"\nName: {SelectedFighter.Name}", "Confirm Information", MessageBoxButtons.OKCancel);

                        // Clicking OK will enable the others text field and disable the EnterID textbox.
                        // Clicking Cancel will just close the message box.
                        if (Confirm == DialogResult.OK)
                        {
                            txtEnterID.Enabled = false;
                            btnSearch.Enabled = false;
                            btnCurrentCancel.Enabled = true;
                            txtName.Enabled = true;
                            txtHeight.Enabled = true;
                            txtWeight.Enabled = true;
                            txtPunchScore.Enabled = true;
                            btnEdit.Enabled = true;
                        }

                    }
                }
            }
        }

        private void btnCurrentCancel_Click(object sender, EventArgs e)
        {
            // This button will return the form window to it's original state, enableing some fields
            // and disableing others.
            var Cancel = MessageBox.Show("Cancel current edition?", "Cancel current?", MessageBoxButtons.YesNo);
            if (Cancel == DialogResult.Yes)
            {
                txtEnterID.Enabled = true;
                btnSearch.Enabled = true;
                btnCurrentCancel.Enabled = false;
                txtName.Enabled = false;
                txtHeight.Enabled = false;
                txtWeight.Enabled = false;
                txtPunchScore.Enabled = false;
                btnEdit.Enabled = false;
                txtEnterID.Text = "";
                txtName.Text = "";
                txtHeight.Text = "";
                txtWeight.Text = "";
                txtPunchScore.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // First, a checking is made to test if every field is empty
            if (txtName.Text == "" && txtHeight.Text == "" && txtWeight.Text == ""
                && txtPunchScore.Text == "")
            {
                MessageBox.Show("Please, inform at least one information");
            }
            // If at least one field is filled, then proceed
            else
            {
                List<string> Parameters = new List<string>();
                string ConfirmChanges = "Confirm the new information below:\n";

                // Creating a connection and selecting the fighter, so the changes can be confirmed
                DBConnect Connect = new DBConnect();
                Fighter SelectedFighter = new Fighter();
                SelectedFighter = Connect.SelectByID(Convert.ToInt32(txtEnterID.Text));

                // Checking which field is empty. If they're not, the field will be sent to the sql query
                if (txtName.Text != "")
                {
                    string Param = $"Name='{txtName.Text}'";
                    Parameters.Add(Param);
                    ConfirmChanges = ConfirmChanges + $"\nName: '{SelectedFighter.Name}' " +
                        $"will be changed to '{txtName.Text}'";
                }
                if (txtHeight.Text != "")
                {
                    string Param = $"Height={txtHeight.Text}";
                    Parameters.Add(Param);
                    ConfirmChanges = ConfirmChanges + $"\nHeight: {SelectedFighter.Height}cm " +
                        $"will be changed to {txtHeight.Text}cm";
                }
                if (txtWeight.Text != "")
                {
                    string Param = $"Weight={txtWeight.Text}";
                    Parameters.Add(Param);
                    ConfirmChanges = ConfirmChanges + $"\nWeight: {SelectedFighter.Weight}kg " +
                        $"will be changed to {txtWeight.Text}kg";
                }
                if (txtPunchScore.Text != "")
                {
                    string Param = $"PunchScore={txtPunchScore.Text}";
                    Parameters.Add(Param);
                    ConfirmChanges = ConfirmChanges + $"\nPunch Score: {SelectedFighter.PunchScore} " +
                        $"will be changed to {txtPunchScore.Text}";
                }

                // If everything is ok, a box of confirmation will be shown
                var Confirm = MessageBox.Show(ConfirmChanges, "Confirm", MessageBoxButtons.OKCancel);
                if (Confirm == DialogResult.OK)
                {
                    // If the user clicks 'OK', the query will be sent to the database
                    int FighterID = Convert.ToInt32(txtEnterID.Text);
                    Connect.Edit(Parameters, FighterID);
                    MessageBox.Show("Editing done successfully!");
                    this.Close();
                }
            }
        }
    }
}
