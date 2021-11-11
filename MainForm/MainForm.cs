using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            new RegisterForm.RegisterForm().Show();
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            new LoginForm.LoginForm().Show();
            

        }
    }
}
