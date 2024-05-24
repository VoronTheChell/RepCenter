using DataBase_App;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RepetBase_App
{
    public partial class sign_up : Form
    {
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

        public sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;

            player.URL = "https://dl.vgmdownloads.com/soundtracks/wii-music-collection/novgcllnpa/12.%20Photo%20Channel.mp3";
            player.controls.play();
        }

        DataBase dataBase = new DataBase();
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (checkUser())

            {
                return;
            }

            var login = textBox_login.Text;
            var password = textBox_password2.Text;
            var subject = this.comboBoxSubject.GetItemText(this.comboBoxSubject.SelectedItem);

            string querystring = $"insert into register(login_user, password_user, subject_user, status_user) values('{login}', '{password}', '{subject}', 'учащийся')";

            SqlCommand comamnd = new SqlCommand(querystring, dataBase.GetConnection());

            dataBase.openConnection();

            if (comamnd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт был успешно создан!", $"Добро пожаловать, пользователь {login}!");
                LoginUp_Form frm_login = new LoginUp_Form();
                this.Hide();
                frm_login.Show();

            }

            else
            {
                MessageBox.Show("Аккаунт не был успешно создан!", "ОШИБКА РЕГЕСТРАЦИИ!");
            }

            dataBase.closeConnection();
        }

        private void Button_Clear(object sender, EventArgs e)
        {
            textBox_login.Text = "";
            textBox_password2.Text = "";
        }

        private Boolean checkUser()
        {
            var loginUser = textBox_login.Text;
            var passUser = textBox_password2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string quertystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(quertystring, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже зарегестрированн!", $"ОШИБКА!");
                return true;
            }

            else
            {
                return false;
            }
        }

        private void log_in_load(object sender, EventArgs e)
        {
            textBox_password2.PasswordChar = '●';
            textBox_password2.MaxLength = 50;
            ButtonHied.Visible = false;

            //textBox_password2.UseSystemPasswordChar = false;
            comboBoxSubject.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Show_Click(object sender, EventArgs e)
        {
            textBox_password2.PasswordChar = '●';
            textBox_password2.UseSystemPasswordChar = false;
            ButtonHied.Visible = false;
            ButtonShow.Visible = true;
            //textBox_password.UseSystemPasswordChar = false;
        }

        private void Hide_Click(object sender, EventArgs e)
        {
            textBox_password2.PasswordChar = '●';
            textBox_password2.UseSystemPasswordChar = false;
            ButtonHied.Visible = true;
            ButtonShow.Visible = false;
        }

        private void sign_up_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataBase.closeConnection();
            //this.Close();
            player.controls.stop();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox_login.Text != "" && textBox_password2.Text != "" && comboBoxSubject.Text != "" && checkBox1.Checked == true)
            {
                button1.Enabled = true;
            }

            else
                button1.Enabled = false;
        }

        private void sign_up_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginUp_Form frm_login = new LoginUp_Form();
            this.Hide();
            player.controls.stop();
            frm_login.Show();
        }

        private void comboBoxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBoxSubject.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
