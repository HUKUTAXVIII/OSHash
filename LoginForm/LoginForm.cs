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

namespace LoginForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Users";
            if (this.PassBox.Text.Length > 4 && this.PassBox.Text.Length < 16 && this.LoginBox.Text.Length > 4 && this.LoginBox.Text.Length < 16) {
                if (Directory.Exists(path)) {
                    var users = Directory.GetFiles(path).ToList();
                    string log = UserData.ComputeSha256Hash(this.LoginBox.Text);
                    string pass = UserData.ComputeSha256Hash(this.PassBox.Text);
                    foreach (var item in users)
                    {
                        if (new FileInfo(item).Name == log + ".txt")
                        {
                            if (File.ReadAllText(new FileInfo(item).FullName) == pass)
                            {
                                MessageBox.Show("You entered!");
                                return;
                            }
                            else {
                                MessageBox.Show("Incorrect password!");
                            }
                        }

                    }
                    MessageBox.Show("Unknown User!");

                }
            }
        }
    }
}
