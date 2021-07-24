using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BloodBankManagementSystem.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BloodBankManagementSystem;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("SELECT * FROM tblUsers WHERE username=@u and password=@p", con);

            cmd.Parameters.AddWithValue("@u", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p", txtPassword.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            con.Open();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Successfull...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmHome hm = new frmHome();
                hm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please enter a valid username and password.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister reg = new frmRegister();
            reg.Show();
        }
    }
}
