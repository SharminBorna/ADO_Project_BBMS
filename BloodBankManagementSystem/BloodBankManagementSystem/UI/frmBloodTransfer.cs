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
    public partial class frmBloodTransfer : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BloodBankManagementSystem;Integrated Security=True");
        public frmBloodTransfer()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void fillPatientID()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT patientID FROM tblPatients", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("patientID",typeof(int));
            dt.Load(rdr);
            cmbPatientID.ValueMember = "patientID";
            cmbPatientID.DataSource = dt;
            con.Close();
        }
        private void GetData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblPatients WHERE patientID="+cmbPatientID.SelectedValue.ToString()+"", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtPatientName.Text = dr["name"].ToString();
                cmbBloodGroup.Text = dr["bloodGroup"].ToString();
                txtQuantity.Text = dr["quantity"].ToString();
            }
            con.Close();
        }

        int Stock;
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
                Stock = Convert.ToInt32(dr["bloodStock"].ToString());
            }
            con.Close();
        }

        private void frmBloodTransfer_Load(object sender, EventArgs e)
        {
            txtPatientName.Enabled = false;
            cmbBloodGroup.Enabled = false;
            txtQuantity.Enabled = false;
            lblStatusOfBlood.Visible = false;
            btnTransfer.Visible = false;
            fillPatientID();
        }
       
        private void cmbPatientID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetData();
            GetStock(cmbBloodGroup.Text);
            if (Stock>= Convert.ToInt32(txtQuantity.Text))
            {
                btnTransfer.Visible = true;
                lblStatusOfBlood.Text = "Available Stock";
                lblStatusOfBlood.Visible = true;
            }
            else
            {
                lblStatusOfBlood.Text = "Stock not Available";
                lblStatusOfBlood.Visible = true;
                btnTransfer.Visible = false;
            }
        }

        private void lblPatient_Click(object sender, EventArgs e)
        {
            frmPatients patients = new frmPatients();
            patients.Show();
            this.Hide();
        }
        private void ClearAll()
        {
            txtPatientName.Text = "";
            cmbBloodGroup.Text = "";
            txtQuantity.Text = "";
            lblStatusOfBlood.Visible = false;
            btnTransfer.Visible = false;
        }
        private void updateStock()
        {
            int newStock = Stock - Convert.ToInt32(txtQuantity.Text);
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblBloodStock SET bloodStock='"+newStock+ "' WHERE bloodGroup='"+cmbBloodGroup.SelectedItem+"'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (txtPatientName.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {              
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblTransferBlood(patientName,bloodGroup,quantity) VALUES(@pn,@bg,@q)", con);
                    cmd.Parameters.AddWithValue("@pn", txtPatientName.Text);
                    cmd.Parameters.AddWithValue("@bg", cmbBloodGroup.SelectedItem);
                    cmd.Parameters.AddWithValue("@q", txtQuantity.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Transfer Successfull!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    GetStock(cmbBloodGroup.Text);
                    updateStock();
                    ClearAll();
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to Transfer!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
        }
    }
}
