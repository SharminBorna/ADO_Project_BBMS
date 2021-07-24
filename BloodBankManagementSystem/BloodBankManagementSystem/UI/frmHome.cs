using BloodBankManagementSystem.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystem
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Users Form
            frmUsers users = new frmUsers();
            users.Show();
        }      

        private void patientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatients patients = new frmPatients();
            patients.Show();
        }

        private void donateBloodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonateBlood frmDonate = new frmDonateBlood();
            frmDonate.Show();
        }

        private void donorsDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDonors donors = new frmDonors();
            donors.Show();
        }

        private void bloodStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBloodStock stock = new frmBloodStock();
            stock.Show();
        }

        private void bloodTraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBloodTransfer bloodTransfer = new frmBloodTransfer();
            bloodTransfer.Show();
        }

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BloodBankManagementSystem;Integrated Security=True");

        private void GetData()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SUM(bloodStock) FROM tblBloodStock", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string BStock = dt.Rows[0][0].ToString();
            lblTotal.Text = "" + BStock;

            //O Positive
            SqlDataAdapter sda1 = new SqlDataAdapter("Select bloodStock from tblBloodStock WHERE bloodGroup='" + "O+" + "'", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            lblOPositiveCount.Text = dt1.Rows[0][0].ToString();
            //O Negative
            SqlDataAdapter sda2 = new SqlDataAdapter("Select bloodStock from tblBloodStock WHERE bloodGroup='" + "O-" + "'", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            lblONegativeCount.Text = dt2.Rows[0][0].ToString();
            //A Positive
            SqlDataAdapter sda3 = new SqlDataAdapter("Select bloodStock from tblBloodStock WHERE bloodGroup='" + "A+" + "'", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            lblAPositiveCount.Text = dt3.Rows[0][0].ToString();
            //A Negative
            SqlDataAdapter sda4 = new SqlDataAdapter("Select bloodStock from tblBloodStock WHERE bloodGroup='" + "A-" + "'", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            lblANegativeCount.Text = dt4.Rows[0][0].ToString();
            //B Positive
            SqlDataAdapter sda5 = new SqlDataAdapter("Select bloodStock from tblBloodStock WHERE bloodGroup='" + "B+" + "'", con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            lblBPositiveCount.Text = dt5.Rows[0][0].ToString();
            //B Negative
            SqlDataAdapter sda6 = new SqlDataAdapter("Select SUM(bloodStock) from tblBloodStock WHERE bloodGroup='" + "B-" + "'", con);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            lblBNegativeCount.Text = dt6.Rows[0][0].ToString();
            //AB Positive
            SqlDataAdapter sda7 = new SqlDataAdapter("Select SUM(bloodStock) from tblBloodStock WHERE bloodGroup='" + "AB+" + "'", con);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            lblABPositiveCount.Text = dt7.Rows[0][0].ToString();
            //AB Negative
            SqlDataAdapter sda8 = new SqlDataAdapter("Select SUM(bloodStock) from tblBloodStock WHERE bloodGroup='" + "AB-" + "'", con);
            DataTable dt8 = new DataTable();
            sda8.Fill(dt8);
            lblABNegativeCount.Text = dt8.Rows[0][0].ToString();
            //Donors Count
            SqlDataAdapter sda9 = new SqlDataAdapter("Select count(*) from tblDonors", con);
            DataTable dt9 = new DataTable();
            sda9.Fill(dt9);
            lblDonorCount.Text = dt9.Rows[0][0].ToString();
            //Transfer Count
            SqlDataAdapter sda10 = new SqlDataAdapter("Select count(*) from tblTransferBlood", con);
            DataTable dt10 = new DataTable();
            sda10.Fill(dt10);
            lblTransferCount.Text = dt10.Rows[0][0].ToString();
            //Users Count
            SqlDataAdapter sda11 = new SqlDataAdapter("Select count(*) from tblUsers", con);
            DataTable dt11 = new DataTable();
            sda11.Fill(dt11);
            lblUsersCount.Text = dt11.Rows[0][0].ToString();
            con.Close();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            GetData();
            LoadGrid();
        }
        private void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblDonors", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvDonors.DataSource = dt;
        }
        public DataTable Search(string keywords)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblDonors WHERE donorId LIKE '%" + keywords + "%' OR donorName LIKE '%" + keywords + "%' OR bloodGroup LIKE '%" + keywords + "%' OR address LIKE '%" + keywords + "%'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            String keywords = txtSearch.Text;
            if (keywords != null)
            {
                DataTable dt = Search(keywords);
                dgvDonors.DataSource = dt;
            }
        }

        private void frmHome_Activated(object sender, EventArgs e)
        {
            GetData();
            LoadGrid();
        }
    }
}
