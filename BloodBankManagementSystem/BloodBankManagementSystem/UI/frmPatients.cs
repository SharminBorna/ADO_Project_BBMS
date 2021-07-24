using BloodBankManagementSystem.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class frmPatients : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BloodBankManagementSystem;Integrated Security=True");

        public frmPatients()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAge.Text == "" || cmbGender.Text == "" || cmbBloodGroup.Text == "" || txtQuantity.Text == "" || txtContact.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblPatients(name,age,gender,bloodGroup,quantity,caseDate,contact,address) VALUES(@n,@age,@g,@bg,@q,@date,@c,@a)", con);
                    cmd.Parameters.AddWithValue("@n", txtName.Text);
                    cmd.Parameters.AddWithValue("@age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@g", cmbGender.SelectedItem);
                    cmd.Parameters.AddWithValue("@bg", cmbBloodGroup.SelectedItem);
                    cmd.Parameters.AddWithValue("@q", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@date", dateTimePickerDate.Value);
                    cmd.Parameters.AddWithValue("@c", txtContact.Text);
                    cmd.Parameters.AddWithValue("@a", txtAddress.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Added Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    LoadGrid();
                    ClearAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }              
            }           
        }
        private void LoadGrid()
        {
            txtPatientId.Enabled = false;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblPatients", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvPatients.DataSource = dt;
        }

        private void frmPatients_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void ClearAll()
        {
            txtPatientId.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            cmbGender.Text = "";
            cmbBloodGroup.Text = "";
            txtQuantity.Text = "";
            dateTimePickerDate.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tblPatients SET name=@n,age=@age,gender=@g,bloodGroup=@bg,quantity=@q,caseDate=@date,contact=@c,address=@a WHERE patientID=@patientID", con);
            cmd.Parameters.AddWithValue("@n", txtName.Text);
            cmd.Parameters.AddWithValue("@age", txtAge.Text);
            cmd.Parameters.AddWithValue("@g", cmbGender.SelectedItem);
            cmd.Parameters.AddWithValue("@bg", cmbBloodGroup.SelectedItem);
            cmd.Parameters.AddWithValue("@q", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePickerDate.Value);
            cmd.Parameters.AddWithValue("@c", txtContact.Text);
            cmd.Parameters.AddWithValue("@a", txtAddress.Text);
            cmd.Parameters.AddWithValue("@patientID", txtPatientId.Text);

            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Patient Updated Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
                ClearAll();
            }
            else
            {
                MessageBox.Show("Failed to Update Patient!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tblPatients WHERE patientID=@patientID", con);

            cmd.Parameters.AddWithValue("@patientID", txtPatientId.Text);

            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Patient Deleted Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
                ClearAll();
            }
            con.Close();
        }
        public DataTable Search(string keywords)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblPatients WHERE patientID LIKE '%" + keywords + "%' OR name LIKE '%" + keywords + "%' OR bloodGroup LIKE '%" + keywords + "%' OR address LIKE '%" + keywords + "%'", con);
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
                dgvPatients.DataSource = dt;
            }
        }

        private void dgvPatients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int RowIndex = e.RowIndex;
                txtPatientId.Text = dgvPatients.Rows[RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvPatients.Rows[RowIndex].Cells[1].Value.ToString();
                txtAge.Text = dgvPatients.Rows[RowIndex].Cells[2].Value.ToString();
                cmbGender.Text = dgvPatients.Rows[RowIndex].Cells[3].Value.ToString();
                cmbBloodGroup.Text = dgvPatients.Rows[RowIndex].Cells[4].Value.ToString();
                txtQuantity.Text = dgvPatients.Rows[RowIndex].Cells[5].Value.ToString();
                dateTimePickerDate.Text = dgvPatients.Rows[RowIndex].Cells[6].Value.ToString();
                txtContact.Text = dgvPatients.Rows[RowIndex].Cells[7].Value.ToString();
                txtAddress.Text = dgvPatients.Rows[RowIndex].Cells[8].Value.ToString();             
            }
            catch (Exception)
            { 
                MessageBox.Show("No Data Found..!!");
            }
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "*.pdf|(Pdf File)";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path + @"\Reports\Patients.rpt");
                Patients pt = new Patients();
                pt.ReportAppServer = cryRpt.ToString();

                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, saveFileDialog1.FileName + ".pdf");

                MessageBox.Show("Report Exported Succesfully..");

            }
            else
            {
                MessageBox.Show("Error occured!");
            }
        }
    }
}
