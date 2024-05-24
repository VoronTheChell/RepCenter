using DataBase_App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RepetBase_App
{
    public partial class FormTeacher : Form
    {
        DataBase dataBase = new DataBase();

        LoginUp_Form lg = new LoginUp_Form();

        int selectdRow;

        int id_raspisanie;

        public FormTeacher()
        {
            InitializeComponent();
            label2.Text = lg.USER;
            MaximizeBox = false;
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = false;
            dataGridView3.ReadOnly = true;

            CreateColumns_Students();
            CreateColumns_DataTime();
            CreateColumns_Payment();
        }

        private void CreateColumns_Students()
        {
            dataBase.openConnection();
            SqlCommand com = new SqlCommand(@"SELECT student_id as 'ID', FIO as 'ФИО', Date_Birth as 'Дата рождения', 
					                          Number_Phone as 'Номер телефона', Predmet as 'Дата оплаты' from Student", dataBase.sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Student");
            dataGridView1.DataSource = ds.Tables[0];
            dataBase.closeConnection();

        }

        private void CreateColumns_DataTime()
        {
            // Реализовать вывод информации через ID (возможно понадобиться редактирование БД)

            dataBase.openConnection();
            SqlCommand com = new SqlCommand(@"SELECT schedule_id as 'ID', student_id as 'Студенты', tutor_id as 'Учетеля', 
					                          Time_Begin as 'Время', Time_of_Zaniyatia as 'Тип пользователя' from Raspisanie_Zaniyatiy", dataBase.sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Raspisanie_Zaniyatiy");
            dataGridView2.DataSource = ds.Tables[0];
            dataBase.closeConnection();

        }

        private void CreateColumns_Payment()
        {
            // Реализовать вывод информации через ID (возможно понадобиться редактирование БД)
            dataBase.openConnection();
            SqlCommand com = new SqlCommand(@"SELECT payment_id as 'Предмет', student_id as 'Студент', tutor_id as 'Репетитор', 
					                          Date_of_Payment as 'Дата оплаты', Summ_Payment as 'Сумма' from Payment", dataBase.sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Payment");
            dataGridView3.DataSource = ds.Tables[0];
            dataBase.closeConnection();

        }


        private void SearchUpStudents(DataGridView DGV)
        {
            string searchapString = $"select * from Student where FIO like '%" + textBox1.Text + "%'";
            SqlCommand com = new SqlCommand(searchapString, dataBase.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "applicant");
            DGV.DataSource = ds.Tables[0];
            dataBase.closeConnection();
        }

        private void SearchAppStudents_ChangeText(object sender, EventArgs e)
        {
            SearchUpStudents(dataGridView1);
        }

        private void SearchUpRZ(DataGridView DGV)
        {
            string searchapString = $"select schedule_id as 'ID', student_id as 'Студенты', tutor_id as 'Учетеля', Time_Begin as 'Время', Time_of_Zaniyatia as 'Тип пользователя' " +
                                    $"from Raspisanie_Zaniyatiy where concat (student_id, tutor_id) like '%" + textBox2.Text + "%'";
            SqlCommand com = new SqlCommand(searchapString, dataBase.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "applicant");
            DGV.DataSource = ds.Tables[0];
            dataBase.closeConnection();
        }

        private void SearchAppRZ_ChangeText(object sender, EventArgs e)
        {
            SearchUpRZ(dataGridView2);
        }

        private void SearchUpPay(DataGridView DGV)
        {
            string searchapString = $"select  payment_id as 'Предмет', student_id as 'Студент', tutor_id as 'Репетитор', " +
                                    $"Date_of_Payment as 'Дата оплаты', Summ_Payment as 'Сумма' from Payment where concat (student_id, tutor_id) like '%" + textBox3.Text + "%'";
            SqlCommand com = new SqlCommand(searchapString, dataBase.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "applicant");
            DGV.DataSource = ds.Tables[0];
            dataBase.closeConnection();
        }

        private void SearchApp6_ChangeText(object sender, EventArgs e)
        {
            SearchUpPay(dataGridView3);
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.closeConnection();
            this.Hide();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView2.Rows[selectdRow];

                    id_raspisanie = Convert.ToInt32(row.Cells[0].Value);
                    textBox4.Text = row.Cells[1].Value.ToString();
                    textBox5.Text = row.Cells[2].Value.ToString();
                    textBox6.Text = row.Cells[3].Value.ToString();
                    textBox7.Text = row.Cells[4].Value.ToString();
                }

                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Отсутсвует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                try
                {
                    string delcommandString = $"DELETE Raspisanie_Zaniyatiy where schedule_id = '{id_raspisanie}'";

                    dataBase.openConnection();

                    SqlCommand com = new SqlCommand(delcommandString, dataBase.GetConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "applicant");

                    CreateColumns_DataTime();

                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";

                    dataBase.closeConnection();

                    MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Ошибка при удаление выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            try
            {
                string addCommandString = $"INSERT INTO Raspisanie_Zaniyatiy (student_id, tutor_id, Time_Begin, Time_of_Zaniyatia) " +
                                          $"VALUES ('{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}', '{textBox7.Text}')";

                dataBase.openConnection();

                SqlCommand com = new SqlCommand(addCommandString, dataBase.GetConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "applicant");

                CreateColumns_DataTime();

                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

                dataBase.closeConnection();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                MessageBox.Show("Ошибка при создании записи!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            // Проверяем наличие значений в текстовых полях перед формированием запроса
            if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Формируем SQL запрос с использованием параметров
            string changeCommandString = "UPDATE Raspisanie_Zaniyatiy SET student_id = @Student, tutor_id = @Theacher, Time_Begin = @Time, Time_of_Zaniyatia = @TimePridmet WHERE schedule_id = @IDRaspis;";

            // Открываем соединение с базой данных
            dataBase.openConnection();

            // Создаем команду с параметрами
            SqlCommand com = new SqlCommand(changeCommandString, dataBase.GetConnection());
            com.Parameters.AddWithValue("@Student", textBox4.Text);
            com.Parameters.AddWithValue("@Theacher", textBox5.Text);
            com.Parameters.AddWithValue("@Time", textBox6.Text);
            com.Parameters.AddWithValue("@TimePridmet", textBox7.Text);
            com.Parameters.AddWithValue("@IDRaspis", id_raspisanie);


            // Выполняем команду
            com.ExecuteNonQuery();

            // Обновляем DataGridView
            CreateColumns_DataTime();

            // Очищаем текстовые поля
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

            // Закрываем соединение с базой данных
            dataBase.closeConnection();

            // Показываем сообщение об успешном изменении записи
            MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
