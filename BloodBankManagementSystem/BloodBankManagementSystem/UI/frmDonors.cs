using BloodBankManagementSystem.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystem.UI
{
    public partial class frmDonors : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BloodBankManagementSystem;Integrated Security=True");

        string imageName = "no-image.jpg";
        string sourcePath = "";
        string destinationPath = "";

        string rowHeaderImage;
        public frmDonors()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //Add functionality to close this form
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAge.Text == "" || cmbGender.Text == "" || cmbBloodGroup.Text == "" || txtContact.Text == "" || txtAddress.Text == "" || imageName == "no-image.jpg")
            {
                MessageBox.Show("Missing Donors Information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblDonors(donorName,age,gender,bloodGroup,contactNo,address,lastDonationDate,imageName) VALUES(@dn,@age,@g,@bg,@c,@a,@date,@i)", con);
                    cmd.Parameters.AddWithValue("@dn", txtName.Text);
                    cmd.Parameters.AddWithValue("@age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@g", cmbGender.SelectedItem);
                    cmd.Parameters.AddWithValue("@bg", cmbBloodGroup.SelectedItem);
                    cmd.Parameters.AddWithValue("@c", txtContact.Text);
                    cmd.Parameters.AddWithValue("@a", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@date", dateTimePickerLDDate.Value);
                    cmd.Parameters.AddWithValue("@i", imageName);

                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("New Donor Added Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGrid();
                        ClearAll();
                    }
                    if (imageName != "no-image.jpg")
                    {
                        File.Copy(sourcePath, destinationPath);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to Add New Donor!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void LoadGrid()
        {
            txtDonorId.Enabled = false;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblDonors", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvDonors.DataSource = dt;
        }

        private void frmDonors_Load(object sender, EventArgs e)
        {
            LoadGrid();

            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string imagePath = paths + "\\Images\\no-image.jpg";
            pictureBoxProfilePic.Image = new Bitmap(imagePath);
        }
        private void ClearAll()
        {
            txtDonorId.Text = "";
            txtName.Text="";
            txtAge.Text = "";
            cmbGender.Text = "";
            cmbBloodGroup.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            dateTimePickerLDDate.Text = "";

            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string imagePath = paths + "\\Images\\no-image.jpg";
            pictureBoxProfilePic.Image = new Bitmap(imagePath);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblDonors SET donorName=@dn,age=@age,gender=@g,bloodGroup=@bg,contactNo=@c,address=@a,lastDonationDate=@date,imageName=@i WHERE donorId=@donorId", con);
                cmd.Parameters.AddWithValue("@dn", txtName.Text);
                cmd.Parameters.AddWithValue("@age", txtAge.Text);
                cmd.Parameters.AddWithValue("@g", cmbGender.SelectedItem);
                cmd.Parameters.AddWithValue("@bg", cmbBloodGroup.SelectedItem);
                cmd.Parameters.AddWithValue("@c", txtContact.Text);
                cmd.Parameters.AddWithValue("@a", txtAddress.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePickerLDDate.Value);
                cmd.Parameters.AddWithValue("@i", imageName);
                cmd.Parameters.AddWithValue("@donorId", txtDonorId.Text);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Donor Updated Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                    ClearAll();
                }
                if (imageName != "no-image.jpg" && imageName != lblOldImagePath.Text)
                {
                    File.Copy(sourcePath, destinationPath);
                }
                ClearAll();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tblDonors WHERE donorId=@donorId", con);

                cmd.Parameters.AddWithValue("@donorId", txtDonorId.Text);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Donor Deleted Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                    ClearAll();
                }
                if (rowHeaderImage != "no-image.jpg")
                {
                    string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    string imagePath = paths + "\\Images\\" + rowHeaderImage;

                    ClearAll();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(imagePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
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

        private void dgvDonors_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int RowIndex = e.RowIndex;
                txtDonorId.Text = dgvDonors.Rows[RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvDonors.Rows[RowIndex].Cells[1].Value.ToString();
                txtAge.Text = dgvDonors.Rows[RowIndex].Cells[2].Value.ToString();
                cmbGender.Text = dgvDonors.Rows[RowIndex].Cells[3].Value.ToString();
                cmbBloodGroup.Text = dgvDonors.Rows[RowIndex].Cells[4].Value.ToString();
                txtContact.Text = dgvDonors.Rows[RowIndex].Cells[5].Value.ToString();
                txtAddress.Text = dgvDonors.Rows[RowIndex].Cells[6].Value.ToString();
                dateTimePickerLDDate.Text = dgvDonors.Rows[RowIndex].Cells[7].Value.ToString();
                imageName = dgvDonors.Rows[RowIndex].Cells[8].Value.ToString();

                lblOldImagePath.Text= dgvDonors.Rows[RowIndex].Cells[8].Value.ToString();

                rowHeaderImage = imageName;

                string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                if (imageName != "no-image.jpg")
                {
                    string imagePath = paths + "\\Images\\" + imageName;
                    pictureBoxProfilePic.Image = new Bitmap(imagePath);
                }
                else
                {
                    string imagePath = paths + "\\Images\\no-image.jpg";
                    pictureBoxProfilePic.Image = new Bitmap(imagePath);
                }
            }
            catch (Exception)
            {
                string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                string imagePath = paths + "\\Images\\no-image.jpg";
                pictureBoxProfilePic.Image = new Bitmap(imagePath);
                MessageBox.Show("No Data Found..!!");
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.PNG; *.gif;)|*.jpg; *.jpeg; *.png; *.PNG; *.gif;";

            if (open.ShowDialog() == DialogResult.OK)
            {
                if (open.CheckFileExists)
                {
                    pictureBoxProfilePic.Image = new Bitmap(open.FileName);
                    //Rename  the image.
                    string ext = Path.GetExtension(open.FileName);
                    Random random = new Random();
                    int RandInt = random.Next(0, 1000);
                    imageName = "Blood_Bank_MS_Donor_" + RandInt + ext;

                    sourcePath = open.FileName;
                    string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
                    destinationPath = paths + "\\Images\\" + imageName;
                }
            }
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "*.pdf|(Pdf File)";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path + @"\Reports\Donors.rpt");
                Donors dn = new Donors();
                dn.ReportAppServer = cryRpt.ToString();

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
