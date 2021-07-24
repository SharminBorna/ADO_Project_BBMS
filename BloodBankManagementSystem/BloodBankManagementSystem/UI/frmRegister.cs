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
    public partial class frmRegister : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=BloodBankManagementSystem;Integrated Security=True");

        string Photo = "no-image.jpg";
        //string sourcePath = "";
        //string destinationPath = "";
        public frmRegister()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (txtUsername.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || txtFullName.Text == "" || txtContact.Text == "" || txtAddress.Text == "" || imageName == "no-image.jpg")
            //{
            //    MessageBox.Show("Missing Information");
            //}
            //else
            //{
            //    try
            //    {
            //        SqlCommand cmd = new SqlCommand("INSERT INTO tblUsers(username,email,password,fullName,contact,address,addedDate,imageName) VALUES(@un,@e,@p,@fn,@c,@a,@ad,@i)", con);
            //        cmd.Parameters.AddWithValue("@un", txtUsername.Text);
            //        cmd.Parameters.AddWithValue("@e", txtEmail.Text);
            //        cmd.Parameters.AddWithValue("@p", txtPassword.Text);
            //        cmd.Parameters.AddWithValue("@fn", txtFullName.Text);
            //        cmd.Parameters.AddWithValue("@c", txtContact.Text);
            //        cmd.Parameters.AddWithValue("@a", txtAddress.Text);
            //        cmd.Parameters.AddWithValue("@ad", DateTime.Now);
            //        cmd.Parameters.AddWithValue("@i", imageName);

            //        con.Open();
            //        if (cmd.ExecuteNonQuery() > 0)
            //        {
            //            MessageBox.Show("User Registration Successfull!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            ResetAll();
            //        }
            //        if (imageName != "no-image.jpg")
            //        {
            //            File.Copy(sourcePath, destinationPath);
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("User Registration Failed!! Try Again!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }
            //}

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
                MessageBox.Show("Missing Information");
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
                        MessageBox.Show("User Registration Successfull!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetAll();
                        this.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("User Registration Failed!! Try Again!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        private void ResetAll()
        {
            txtUserId.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string imagePath = paths + "\\Images\\no-image.jpg";
            pictureBoxProfilePic.Image = new Bitmap(imagePath);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            txtUserId.Enabled = false;

            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string imagePath = paths + "\\Images\\no-image.jpg";
            pictureBoxProfilePic.Image = new Bitmap(imagePath);
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            //OpenFileDialog open = new OpenFileDialog();
            //open.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.PNG; *.gif;)|*.jpg; *.jpeg; *.png; *.PNG; *.gif;";

            //if (open.ShowDialog() == DialogResult.OK)
            //{
            //    if (open.CheckFileExists)
            //    {
            //        pictureBoxProfilePic.Image = new Bitmap(open.FileName);
            //        //Rename  the image.
            //        string ext = Path.GetExtension(open.FileName);
            //        Random random = new Random();
            //        int RandInt = random.Next(0, 1000);
            //        imageName = "Blood_Bank_MS_User_" + RandInt + ext;

            //        sourcePath = open.FileName;
            //        string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
            //        destinationPath = paths + "\\Images\\" + imageName;

            //        //File.Copy(sourcePath, destinationPath);

            //        //MessageBox.Show("Image Successfully Uploaded.");
            //    }
            //}

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
    }
}
