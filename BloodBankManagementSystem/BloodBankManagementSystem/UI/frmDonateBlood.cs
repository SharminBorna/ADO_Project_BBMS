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
    public partial class frmDonateBlood : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BloodBankManagementSystem;Integrated Security=True");
        public frmDonateBlood()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDonateBlood_Load(object sender, EventArgs e)
        {
            txtName.Enabled = false;
            cmbBloodGroup.Enabled = false;
            LoadGrid();
            BloodStock();
        }
        private void LoadGrid()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblDonors", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvDonors.DataSource = dt;
            con.Close(); 
        }

        private void BloodStock()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblBloodStock", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvBloodStock.DataSource = dt;
            con.Close();
        }

        int oldStock;
        private void GetStock(string Bgroup)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblBloodStock WHERE bloodGroup=@bg", con);
            cmd.Parameters.AddWithValue("@bg", Bgroup);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                oldStock = Convert.ToInt32(dr["bloodStock"].ToString());
            }
            con.Close();
        }

        private void dgvDonors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;

            txtName.Text = dgvDonors.Rows[RowIndex].Cells[1].Value.ToString();
            cmbBloodGroup.Text = dgvDonors.Rows[RowIndex].Cells[4].Value.ToString();

            GetStock(cmbBloodGroup.Text);
        }

        private void ClearAll()
        {
            txtName.Text = "";
            cmbBloodGroup.Text = "";            
        }

        private void updateLastDonationDate()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblDonors SET lastDonationDate='" + DateTime.Now + "' WHERE donorName='" + txtName.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text=="")
            {
                MessageBox.Show("Select a donor.");
            }
            else
            {
                try
                {
                    int stock = oldStock + 1;
                    SqlCommand cmd = new SqlCommand("UPDATE tblBloodStock SET bloodStock=@bs WHERE bloodGroup=@bg", con);                   
                    cmd.Parameters.AddWithValue("@bg", cmbBloodGroup.SelectedItem);
                    cmd.Parameters.AddWithValue("@bs", stock);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donation Successfull!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    updateLastDonationDate();
                    LoadGrid();
                    ClearAll();
                    BloodStock();               
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
