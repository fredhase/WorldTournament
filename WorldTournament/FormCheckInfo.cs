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
    public partial class FormCheckInfo : Form
    {
        public FormCheckInfo()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var Closure = MessageBox.Show("Close window?", "Close?", MessageBoxButtons.YesNo);
            if (Closure == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // A message box will ask the conformation to clear the list
            var Confirm = MessageBox.Show("Clear the list?", "Clear?", MessageBoxButtons.YesNo);
            // By clicking Yes, an empty list will be the new data source, clearing the list
            if (Confirm == DialogResult.Yes)
            {
                List<Fighter> ClearList = new List<Fighter>();
                gridFightersInfo.DataSource = ClearList;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // First, a checking is made to test if every field is empty
            if (txtID.Text == "" && txtName.Text == "" && txtHeight.Text == "" && txtWeight.Text == "" 
                && txtPunchScore.Text == "" )
            {
                MessageBox.Show("Please, inform at least one information");
            }
            // If at least one field is filled, then proceed
            else
            {
                List<string> Parameters = new List<string>();

                // Checking which field is empty. If they're not, the field will be sent to the sql query
                if (txtID.Text != "")
                {
                    string Param = $"ID={txtID.Text}";
                    Parameters.Add(Param);
                }
                if (txtName.Text != "")
                {
                    string Param = $"Name='{txtName.Text}'";
                    Parameters.Add(Param);
                }
                if (txtHeight.Text != "")
                {
                    string Param = $"Height={txtHeight.Text}";
                    Parameters.Add(Param);
                }
                if (txtWeight.Text != "")
                {
                    string Param = $"Weight={txtWeight.Text}";
                    Parameters.Add(Param);
                }
                if (txtPunchScore.Text != "")
                {
                    string Param = $"PunchScore={txtPunchScore.Text}";
                    Parameters.Add(Param);
                }

                // A list is created to be used as data source for the data grid.
                // The list will b the returning result of the function SelectBtMultiple, which will contain
                // the selected data base values.
                List<Fighter> SelectedFighters = new List<Fighter>();
                DBConnect Connect = new DBConnect();
                SelectedFighters = Connect.SelectByMultiple(Parameters);

                if (SelectedFighters.Count == 0)
                {
                    MessageBox.Show("No fighter was found with these information.");
                    List<Fighter> ClearList = new List<Fighter>();
                    gridFightersInfo.DataSource = ClearList;
                }
                else
                {
                    gridFightersInfo.DataSource = SelectedFighters;
                }
            }

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            List<Fighter> SelectedFighters = new List<Fighter>();
            DBConnect Connect = new DBConnect();
            SelectedFighters = Connect.SelectAll();

            if (SelectedFighters.Count == 0)
            {
                MessageBox.Show("No fighter registered!");
                List<Fighter> ClearList = new List<Fighter>();
                gridFightersInfo.DataSource = ClearList;
            }
            else
            {
                gridFightersInfo.DataSource = SelectedFighters;
            }
        }
    }
}
