using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace template
{
    public partial class MainForm : Form
    {
        private string userRole;
        public MainForm(string role)
        {
            InitializeComponent();
            userRole = role;
            btnManageUsers.Visible = false;
            if (userRole == "А")
            {
                btnManageUsers.Visible = true;
            }
        }
        string ConnectionString = "server=localhost;database=zoo;uid=root;pwd=root;";
        private string connectionString;

        private void btnViewInfo_Click(object sender, EventArgs e)
        {
            string connString = "server=localhost;database=zoo;uid=root;pwd=root;";
            InformationForm informationForm = new InformationForm(connString, null); 
            informationForm.Show();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(); 
            userForm.Show();

        }

        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            Authorization authForm = new Authorization();
            authForm.Show();
        }

        private void btnFond_Click(object sender, EventArgs e)
        {
            FondForm form = new FondForm("server=localhost;user=root;database=zoo;password=root;");
            form.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Закрыть окно?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true; // Отменяем закрытие
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
