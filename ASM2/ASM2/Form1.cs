using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void deleteee()
        {
            txtId.Text = "";
            txtName.Text = "";        
            Sx.Text = "";
            txtClass.Text = "";
            txtPhysics.Text = "";
            txtMath.Text = "";
            txtEnglish.Text = "";


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btFix.Enabled = false;
            btDelete.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btFix_Click(object sender, EventArgs e)
        {
            int index = dataGridViewSV.CurrentCell.RowIndex;
            dataGridViewSV[0, index].Value = txtId.Text;
            dataGridViewSV[1, index].Value = txtName.Text;
            dataGridViewSV[2, index].Value = dateTimePicker1.Text;
            dataGridViewSV[3, index].Value = Sx.Text;
            dataGridViewSV[4, index].Value = txtClass.Text;
            dataGridViewSV[5, index].Value = txtPhysics.Text;
            dataGridViewSV[6, index].Value = txtMath.Text;
            dataGridViewSV[7, index].Value = txtEnglish.Text;
            double medigrade = (Convert.ToDouble(txtEnglish.Text) + Convert.ToDouble(txtMath.Text) + Convert.ToDouble(txtPhysics.Text)) / 3;
            dataGridViewSV[8, index].Value = medigrade.ToString();
            deleteee();
        }

        

       

        private void btDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to delete", "Notification",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                int index = dataGridViewSV.CurrentCell.RowIndex;
                dataGridViewSV.Rows.RemoveAt(index);
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtName.Text != "" && Sx.Text != "" && txtClass.Text != "")
            {
                try
                {
                    double physics = Convert.ToDouble(txtPhysics.Text);
                    double math = Convert.ToDouble(txtMath.Text);
                    double english = Convert.ToDouble(txtEnglish.Text);
                    if (physics >= 0 && physics <= 10 && math >= 0 && math <= 10 && english >= 0 && english <= 10)
                    {
                        double medigrade = (english + math + physics) / 3;
                        dataGridViewSV.Rows.Add(txtId.Text, txtName.Text, dateTimePicker1.Text, Sx.Text, txtClass.Text, txtPhysics.Text, txtMath.Text, txtEnglish.Text, medigrade.ToString());
                        deleteee();
                        btDelete.Enabled = true;
                        btFix.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("The grade must be between 0 to 10");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Incorrect point data entry");
                }
            }
            else
            {
                MessageBox.Show("Student information has not been fully entered");
            } 
        }

        private void dataGridViewSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridViewSV.Rows[dataGridViewSV.CurrentCell.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            dateTimePicker1.Text = row.Cells[2].Value.ToString();
            Sx.Text = row.Cells[3].Value.ToString();
            txtClass.Text = row.Cells[4].Value.ToString();
            txtPhysics.Text = row.Cells[5].Value.ToString();
            txtMath.Text = row.Cells[6].Value.ToString();
            txtEnglish.Text = row.Cells[7].Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btStatistics_Click(object sender, EventArgs e)
        {
            if (rbMin.Checked)
            {
                 dataGridViewStatistical.Rows.Clear();
                 for(int i = 0; i < dataGridViewSV.Rows.Count - 1; i++)
                {
                    double medigrade = Convert.ToDouble(dataGridViewSV[8, i]);
                    if (medigrade >= 0 && medigrade < 4)
                    {
                        dataGridViewStatistical.Rows.Add(dataGridViewSV[0, i].Value, dataGridViewSV[1, i].Value, dataGridViewSV[2, i].Value, dataGridViewSV[3, i].Value,
                            dataGridViewSV[4, i].Value, dataGridViewSV[8, i].Value);
                    }
                }
            }
            else if (rbRelative.Checked)
            {
                dataGridViewStatistical.Rows.Clear();
                for (int i = 0; i < dataGridViewSV.Rows.Count - 1; i++)
                {
                    double medigrade = Convert.ToDouble(dataGridViewSV[8, i]);
                    if (medigrade >= 4 && medigrade < 6.5)
                    {
                        dataGridViewStatistical.Rows.Add(dataGridViewSV[0, i].Value, dataGridViewSV[1, i].Value, dataGridViewSV[2, i].Value, dataGridViewSV[3, i].Value,
                            dataGridViewSV[4, i].Value, dataGridViewSV[8, i].Value);
                    }
                }
            }
            else if(rbMax.Checked)
            {
                dataGridViewStatistical.Rows.Clear();
                for (int i = 0; i < dataGridViewSV.Rows.Count - 1; i++)
                {
                    double medigrade = Convert.ToDouble(dataGridViewSV[8, i]);
                    if (medigrade >= 6.5 && medigrade <= 10)
                    {
                        dataGridViewStatistical.Rows.Add(dataGridViewSV[0, i].Value, dataGridViewSV[1, i].Value, dataGridViewSV[2, i].Value, dataGridViewSV[3, i].Value,
                            dataGridViewSV[4, i].Value, dataGridViewSV[8, i].Value);
                    }
                }
            }
        }
    }
}
