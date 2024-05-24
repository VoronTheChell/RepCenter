using DataBase_App;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RepetBase_App
{
    public partial class LoginUp_Form : Form
    {
        DataBase dataBase = new DataBase();

        public string USER;

        public LoginUp_Form()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
        }

        private void LoginUp_Form_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '●';
            pictureBox1.Visible = false;

            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;

        }

        private void Show_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = true;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            //textBox_password.UseSystemPasswordChar = false;
        }

        private void Hide_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_login.Text;
            USER = textBox_login.Text;
            var passUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());

            // Сommand Code
            adapter.SelectCommand = command;
            adapter.Fill(table);


            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Admin_Form adminForm = new Admin_Form();
                FormTeacher teacherForm = new FormTeacher();
                FormScoller scollerForm = new FormScoller();

                dataBase.openConnection();
                string checkStatus = $"SELECT status_user from register where login_user like '{loginUser}'";
                SqlCommand commandCheck = new SqlCommand(checkStatus, dataBase.GetConnection());
                string status = ((string)commandCheck.ExecuteScalar());

                Console.WriteLine(status);

                switch (status)
                {
                    case "admin":
                        {
                            this.Hide();
                            adminForm.ShowDialog();
                            this.Show();
                            break;
                        }

                    case "учащийся":
                        {
                            this.Hide();
                            scollerForm.ShowDialog();
                            this.Show();
                            break;
                        }

                    case "учитель":
                        {
                            this.Hide();
                            teacherForm.ShowDialog();
                            this.Show();
                            break;
                        }
                }
                    

                
            }

            else
            {
                MessageBox.Show("Ошибка входа!\nТого пользователя не существует или вы вели не верный пароль!", "Ошибка...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }

        private void Reg_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sign_up frm_sign = new sign_up();
            this.Hide();
            frm_sign.Show();
            
        }

        private void login_up_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataBase.closeConnection();
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
