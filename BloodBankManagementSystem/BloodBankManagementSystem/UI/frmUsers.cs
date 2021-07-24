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
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using BloodBankManagementSystem.Reports;

namespace BloodBankManagementSystem.UI
{
    public partial class frmUsers : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BloodBankManagementSystem;Integrated Security=True");

        string Photo = "no-image.jpg";
        string rowHeaderImage;
        public frmUsers()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Add functionality to close this form
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //photo
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string fileExt = Path.GetExtension(openFileDialog1.FileName);
            Photo = path + "\\Images\\" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm") + fileExt;
            if (Photo == null)
            {
                MessageBox.Show("Please select a valid image.");
            }//end of photo process

            if (txtUsername.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || txtFullName.Text == "" || txtContact.Text == "" || txtAddress.Text == "" || fileExt == null)
            {
                MessageBox.Show("Missing Users Information");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblUsers(username,email,password,fullName,contact,address,addedDate,imageName) VALUES(@un,@e,@p,@fn,@c,@a,@ad,@i)", con);
                    cmd.Parameters.AddWithValue("@un", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@fn", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@c", txtContact.Text);
                    cmd.Parameters.AddWithValue("@a", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@ad", DateTime.Now);
                    cmd.Parameters.AddWithValue("@i", Photo);

                    //upload image to folder
                    File.Copy(openFileDialog1.FileName, Photo);

                    con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("New User Added Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGrid();
                        ClearAll();
                    }
                }
                catch (Exception m)
                {
                    MessageBox.Show(m.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        
        private void LoadGrid()
        {
            txtUserId.Enabled = false;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblUsers", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvUsers.DataSource = dt;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            LoadGrid();

            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string imagePath = paths + "\\Images\\no-image.jpg";
            pictureBoxProfilePic.Image = new Bitmap(imagePath);
        }
        private void ClearAll()
        {
            txtUserId.Text = "";
            txtFullName.Clear();
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string imagePath = paths + "\\Images\\no-image.jpg";
            pictureBoxProfilePic.Image = new Bitmap(imagePath);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        public DataTable Search(string keywords)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblUsers WHERE userId LIKE '%"+keywords+"%' OR fullName LIKE '%"+keywords+"%' OR address LIKE '%"+ keywords+ "%'", con);
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
            if (keywords!=null)
            {
                DataTable dt = Search(keywords);
                dgvUsers.DataSource = dt;
            }           
        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int RowIndex = e.RowIndex;
                txtUserId.Text = dgvUsers.Rows[RowIndex].Cells[0].Value.ToString();
                txtUsername.Text = dgvUsers.Rows[RowIndex].Cells[1].Value.ToString();
                txtEmail.Text = dgvUsers.Rows[RowIndex].Cells[2].Value.ToString();
                txtPassword.Text = dgvUsers.Rows[RowIndex].Cells[3].Value.ToString();
                txtFullName.Text = dgvUsers.Rows[RowIndex].Cells[4].Value.ToString();
                txtContact.Text = dgvUsers.Rows[RowIndex].Cells[5].Value.ToString();
                txtAddress.Text = dgvUsers.Rows[RowIndex].Cells[6].Value.ToString();
                Photo = dgvUsers.Rows[RowIndex].Cells[8].Value.ToString();

                lblOldImgLink.Text= dgvUsers.Rows[RowIndex].Cells[8].Value.ToString();

                rowHeaderImage = Photo;

                pictureBoxProfilePic.Image = new Bitmap(Photo);
                pictureBoxProfilePic.SizeMode = PictureBoxSizeMode.StretchImage;

                //string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                //if (Photo != "no-image.jpg")
                //{
                //    string imagePath = paths + "\\Images\\" + Photo;
                //    pictureBoxProfilePic.Image = new Bitmap(imagePath);
                //}
                //else
                //{
                //    string imagePath = paths + "\\Images\\no-image.jpg";
                //    pictureBoxProfilePic.Image = new Bitmap(imagePath);
                //}
            }
            catch (Exception)
            {
                
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //photo
            string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string fileExt = Path.GetExtension(openFileDialog1.FileName);
            string Photo2 = "";
            if (fileExt != "")
            {
                Photo2 = path + "\\Images\\" + DateTime.Now.ToString("MM-dd-yyyy-HH-mm") + fileExt;
            }
            else if (fileExt == "")
            {
                Photo2 = lblOldImgLink.Text;
            }//end of photo process


            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblUsers SET fullName=@fn,email=@e,username=@un,password=@p,contact=@c,address=@a,addedDate=@ad,imageName=@i WHERE userId=@userId", con);
                cmd.Parameters.AddWithValue("@fn", txtFullName.Text);
                cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                cmd.Parameters.AddWithValue("@un", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.Parameters.AddWithValue("@c", txtContact.Text);
                cmd.Parameters.AddWithValue("@a", txtAddress.Text);
                cmd.Parameters.AddWithValue("@ad", DateTime.Now);
                cmd.Parameters.AddWithValue("@i", Photo2);
                cmd.Parameters.AddWithValue("@userId", txtUserId.Text);

                con.Open();

                if (fileExt != "")
                {
                    File.Copy(openFileDialog1.FileName, Photo2);
                }

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("User Updated Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                    ClearAll();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tblUsers WHERE userId=@userId", con);

                cmd.Parameters.AddWithValue("@userId", txtUserId.Text);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("User Deleted Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                    ClearAll();
                }
                //if (rowHeaderImage != "no-image.jpg")
                //{
                //    string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                //    string imagePath = paths + "\\Images\\" + rowHeaderImage;

                //    ClearAll();
                //    GC.Collect();
                //    GC.WaitForPendingFinalizers();
                //    File.Delete(imagePath);
                //}
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

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Select image to be uploaded.";
            openFileDialog1.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        pictureBoxProfilePic.Image = new Bitmap(openFileDialog1.FileName);
                        pictureBoxProfilePic.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload image.");
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "*.pdf|(Pdf File)";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(path + @"\Reports\Users.rpt");
                Users us = new Users();
                us.ReportAppServer = cryRpt.ToString();

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
