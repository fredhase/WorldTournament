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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string MsgSuccess = "Are the fighter's informations correct?\n", MsgError = "Error!! \nMissing data or invalid data type!\n\n";
            string DataTypeError = "\n";
            bool Error = false;

            //Checking if any text box is empty

            // ID
            if (txtID.Text == "")
            {
                Error = true;
                MsgError = MsgError + "Missing " + lblID.Text + "!\n";
            }
            else
            {
                // Verifying Data type
                int number;
                bool result = Int32.TryParse(txtID.Text, out number);
                if (!result)
                {
                    Error = true;
                    DataTypeError = DataTypeError + lblID.Text + " only accepets numbers!\n";
                }
                else
                {
                    MsgSuccess = MsgSuccess + lblID.Text + ": " + txtID.Text + "\n";
                }
            }

            // Name
            if (txtName.Text == "")
            {
                Error = true;
                MsgError = MsgError + "Missing " + lblName.Text + "!\n";
            } 
            else
            {
                MsgSuccess = MsgSuccess + lblName.Text + ": " + txtName.Text + "\n";
            }

            // Height
            if (txtHeight.Text == "")
            {
                Error = true;
                MsgError = MsgError + "Missing " + lblHeight.Text + "!\n";
            }
            else
            {
                // Verifying data type
                int number;
                bool result = Int32.TryParse(txtHeight.Text, out number);
                if (!result)
                {
                    Error = true;
                    DataTypeError = DataTypeError + lblHeight.Text + " only accepets numbers (no decimal values)!\n";
                }
                else
                {
                    MsgSuccess = MsgSuccess + lblHeight.Text + ": " + txtHeight.Text + "\n";
                }
                
            }

            // Weight
            if (txtWeight.Text == "")
            {
                Error = true;
                MsgError = MsgError + "Missing " + lblWeight.Text + "!\n";
            }
            else
            {
                // Verifying data type
                double number;
                bool result = Double.TryParse(txtWeight.Text, out number);
                if (!result)
                {
                    Error = true;
                    DataTypeError = DataTypeError + lblWeight.Text + " only accepets numbers!\n";
                }
                else
                {
                    MsgSuccess = MsgSuccess + lblWeight.Text + ": " + txtWeight.Text + "\n";
                }
            }

            // Punch Score
            if (txtPunchScore.Text == "")
            {
                Error = true;
                MsgError = MsgError + "Missing " + lblPunchScore.Text + "!\n";
            }
            else
            {
                // Verifying data type
                int number;
                bool result = Int32.TryParse(txtPunchScore.Text, out number);
                if (!result)
                {
                    Error = true;
                    DataTypeError = DataTypeError + lblPunchScore.Text + " only accepets numbers!\n";
                }
                MsgSuccess = MsgSuccess + lblPunchScore.Text + ": " + txtPunchScore.Text + "\n";
            }

            // If any box is empty or any data type is wrong, an error message will be shown with missing parameters
            if (Error)
            {
                MessageBox.Show(MsgError + DataTypeError, "Missing or invalid information!", MessageBoxButtons.OK);
            }
            // If every box is filled, then a message to confirm the infos will be shown
            else
            {
                var Confirmation = MessageBox.Show(MsgSuccess, "Confirm information", MessageBoxButtons.YesNoCancel);

                // 'Yes' will register the fighter in the database
                if (Confirmation == DialogResult.Yes)
                {
                    Fighter NewFighter = new Fighter();
                    NewFighter.ID = Convert.ToInt32(txtID.Text);
                    NewFighter.Name = txtName.Text;
                    NewFighter.Height = Convert.ToInt32(txtHeight.Text);
                    NewFighter.Weight = Convert.ToDouble(txtWeight.Text);
                    NewFighter.PunchScore = Convert.ToInt32(txtPunchScore.Text);

                    DBConnect Connection = new DBConnect();
                    Connection.Insert(NewFighter);

                    MessageBox.Show("New fighter registration completed successfully!");
                    this.Close();
                }
                // 'No' will return to the form to correct infos 
                else if (Confirmation == DialogResult.No)
                {

                }
                // 'Cancel' will close the form and cancel this registration
                else if (Confirmation == DialogResult.Cancel)
                {
                    var Closure = MessageBox.Show("Close window and cancel registration?", "Close?", MessageBoxButtons.YesNo);
                    if (Closure == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var Closure = MessageBox.Show("Close window and cancel registration?", "Close?", MessageBoxButtons.YesNo);
            if (Closure == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
