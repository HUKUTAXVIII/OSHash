using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserLib;

namespace RegisterForm
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            if (this.PassBox.Text.Length > 4 && this.PassBox.Text.Length < 16 && this.LoginBox.Text.Length > 4 && this.LoginBox.Text.Length < 16 && this.ConfPassBox.Text.Length > 4 && this.ConfPassBox.Text.Length < 16)
            {
                if (this.PassBox.Text == this.ConfPassBox.Text)
                {
                    string log = UserData.ComputeSha256Hash(this.LoginBox.Text);
                    string pass = UserData.ComputeSha256Hash(this.PassBox.Text);
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)+@"\Users";
                    if (!Directory.Exists(path)) {
                        Directory.CreateDirectory(path);
                    }

                    File.WriteAllText(path+@"\"+log+".txt",pass);
                    MessageBox.Show("Registered!");
                }
                else {
                    MessageBox.Show("Incorrect password!");
                    return;
                }

            }
            else {
                MessageBox.Show("Incorrect Login or Password!");
            }
        }
    }
}
