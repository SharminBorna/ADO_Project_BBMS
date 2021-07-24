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

namespace BloodBankManagementSystem.UI
{
    public partial class frmBloodStock : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BloodBankManagementSystem;Integrated Security=True");
        public frmBloodStock()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBloodStock_Load(object sender, EventArgs e)
        {
            BloodStock();
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
        public DataTable Search(string keywords)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblBloodStock WHERE bloodGroup LIKE '%" + keywords + "%'", con);
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

        private void cmbBloodGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            String keywords = cmbBloodGroup.Text;
            if (keywords != null)
            {
                DataTable dt = Search(keywords);
                dgvBloodStock.DataSource = dt;
            }
        }
    }
}
