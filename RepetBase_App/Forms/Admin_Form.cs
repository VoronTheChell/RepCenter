using DataBase_App;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace RepetBase_App
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Admin_Form : Form
    {
        DataBase dataBase = new DataBase();

        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

        int selectdRow;

        public int id_users;

        public int id_student, id_teacher, id_raspisanie, id_pridmet, id_payment;

        public Admin_Form()
        {
            InitializeComponent();

            MaximizeBox = false;

            CreateColumns_Users();
            CreateColumns_Students();
            CreateColumns_Rep();
            CreateColumns_DataTime();
            CreateColumns_ItemTeach();
            CreateColumns_Payment();

            PlayMusicFon();
        }

        private void PlayMusicFon()
        {
            DateTime dateTime = new DateTime();

            DateTime currentTime = DateTime.Now;
            DateTime MorningTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 8, 30, 00);
            DateTime NightTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 17, 30, 00);

            if (currentTime >= NightTime || dateTime < MorningTime)
            {
                player.controls.stop();
                player.URL = "https://vgmsite.com/soundtracks/wii-forecast-channel/uslofipyyl/11%20Global%20Forecast%20%28Nighttime%20-%20Layer%20Only%29.mp3";
                player.controls.play();
            }

            else if (currentTime >= MorningTime)
            {
                player.controls.stop();
                player.URL = "https://vgmsite.com/soundtracks/wii-forecast-channel/stywgflmqc/10%20Global%20Forecast%20%28Daytime%20-%20Layer%20Only%29.mp3";
                player.controls.play();
            }
        }

        private void CreateColumns_Users()
        {
            dataBase.openConnection();
            SqlCommand com = new SqlCommand(@"SELECT id_User as 'ID', login_user as 'Логин пользователей', password_user as 'Пароли', 
					                          subject_user as 'Предметы', status_user as 'Тип пользователя' from register", dataBase.sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "register");
            dataGridView1.DataSource = ds.Tables[0];
            dataBase.closeConnection();
            dataGridView1.AutoResizeColumns();
        }

        private void CreateColumns_Students()
        {
            dataBase.openConnection();
            SqlCommand com = new SqlCommand(@"SELECT student_id as 'ID', FIO as 'ФИО', Date_Birth as 'Дата рождения', 
					                          Number_Phone as 'Номер телефона', Predmet as 'Предмет' from Student", dataBase.sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Student");
            dataGridView2.DataSource = ds.Tables[0];
            dataBase.closeConnection();
            dataGridView2.AutoResizeColumns();
        }

        private void CreateColumns_Rep()
        {
            dataBase.openConnection();
            SqlCommand com = new SqlCommand(@"SELECT tutor_id as 'ID', FIO as 'ФИО', Phone_Number as 'Номер телефона', 
					                          Kvalification as 'Квалификация', Predmets as 'Предмет' from Repetitors", dataBase.sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Repetitors");
            dataGridView3.DataSource = ds.Tables[0];
            dataBase.closeConnection();
            dataGridView3.AutoResizeColumns();
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
            dataGridView4.DataSource = ds.Tables[0];
            dataBase.closeConnection();
            dataGridView4.AutoResizeColumns();
        }

        private void CreateColumns_ItemTeach()
        {
            dataBase.openConnection();
            SqlCommand com = new SqlCommand(@"SELECT subject_id as 'ID', Name_Pridment as 'Названия предмета' from Pridments", dataBase.sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Pridments");
            dataGridView5.DataSource = ds.Tables[0];
            dataBase.closeConnection();
            dataGridView5.AutoResizeColumns();
        }

        private void CreateColumns_Payment()
        {
            // Реализовать вывод информации через ID (возможно понадобиться редактирование БД)
            dataBase.openConnection();
            SqlCommand com = new SqlCommand(@"SELECT payment_id as 'ID', student_id as 'Студент', tutor_id as 'Репетитор', 
					                          Date_of_Payment as 'Дата оплаты', Summ_Payment as 'Сумма' from Payment", dataBase.sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Payment");
            dataGridView6.DataSource = ds.Tables[0];
            dataBase.closeConnection();
            dataGridView6.AutoResizeColumns();
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------

        // Реализация функции для пункта: Пользователи

        private void SearchUp(DataGridView dataGridView1)
        {
            string searchapString = $"select id_User as 'ID', login_user as 'Логин пользователей', password_user as 'Пароли', " +
                                    $"subject_user as 'Предметы', status_user as 'Тип пользователя' from register where login_user like '%" + textBox1.Text + "%'";

            SqlCommand com = new SqlCommand(searchapString, dataBase.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();

            adapter.Fill(ds, "applicant");
            dataGridView1.DataSource = ds.Tables[0];



            dataBase.closeConnection();
        }

        private void SearchApp_ChangeText(object sender, EventArgs e)
        {
            SearchUp(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[selectdRow];

                    id_users = Convert.ToInt32(row.Cells[0].Value);
                    textBox7.Text = row.Cells[1].Value.ToString();
                    textBox8.Text = row.Cells[2].Value.ToString();
                    textBox9.Text = row.Cells[3].Value.ToString();
                    textBox10.Text = row.Cells[4].Value.ToString();
                }

                catch 
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text) || string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Отсутсвует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                try
                {
                    string delcommandString = $"DELETE register where id_User = '{id_users}'";

                    dataBase.openConnection();

                    SqlCommand com = new SqlCommand(delcommandString, dataBase.GetConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "applicant");

                    CreateColumns_Users();

                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";

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
                string addCommandString = $"INSERT INTO register (login_user, password_user, subject_user, status_user) " +
                                          $"VALUES ('{textBox7.Text}', '{textBox8.Text}', '{textBox9.Text}', '{textBox10.Text}')";

                dataBase.openConnection();

                SqlCommand com = new SqlCommand(addCommandString, dataBase.GetConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "applicant");

                CreateColumns_Users();

                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";

                dataBase.closeConnection();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                MessageBox.Show("Ошибка при создании записи, такая запись существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            // Проверяем наличие значений в текстовых полях перед формированием запроса
            if (string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text) || string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Формируем SQL запрос с использованием параметров
            string changeCommandString = "UPDATE register SET login_user = @Login, password_user = @Password, subject_user = @Subject, status_user = @Status WHERE id_User = @UserID;";

            // Открываем соединение с базой данных
            dataBase.openConnection();

            // Создаем команду с параметрами
            SqlCommand com = new SqlCommand(changeCommandString, dataBase.GetConnection());
            com.Parameters.AddWithValue("@Login", textBox7.Text);
            com.Parameters.AddWithValue("@Password", textBox8.Text);
            com.Parameters.AddWithValue("@Subject", textBox9.Text);
            com.Parameters.AddWithValue("@Status", textBox10.Text);
            com.Parameters.AddWithValue("@UserID", id_users);

            // Выполняем команду
            com.ExecuteNonQuery();

            // Обновляем DataGridView
            CreateColumns_Users();

            // Очищаем текстовые поля
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";

            // Закрываем соединение с базой данных
            dataBase.closeConnection();

            // Показываем сообщение об успешном изменении записи
            MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearButton1_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";

            dataGridView1.Update();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------

        // Реализация функции для пункта: Студенты

        private void SearchUp2(DataGridView dataGridView2)
        {
            string searchapString = $"select student_id as 'ID', FIO as 'ФИО', Date_Birth as 'Дата рождения', " +
                                    $"Number_Phone as 'Номер телефона', Predmet as 'Предмет' from Student where FIO like '%" + textBox2.Text + "%'";

            SqlCommand com = new SqlCommand(searchapString, dataBase.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "applicant");
            dataGridView2.DataSource = ds.Tables[0];
            dataBase.closeConnection();
        }

        private void SearchApp2_ChangeText(object sender, EventArgs e)
        {
            SearchUp2(dataGridView2);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView2.Rows[selectdRow];

                    id_student = Convert.ToInt32(row.Cells[0].Value);
                    textBox14.Text = row.Cells[1].Value.ToString();
                    textBox13.Text = row.Cells[2].Value.ToString();
                    textBox12.Text = row.Cells[3].Value.ToString();
                    textBox11.Text = row.Cells[4].Value.ToString();
                }

                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonDel2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox14.Text) || string.IsNullOrEmpty(textBox13.Text) || string.IsNullOrEmpty(textBox12.Text) || string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Отсутсвует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                try
                {
                    string delcommandString = $"DELETE Student where student_id = '{id_student}'";

                    dataBase.openConnection();

                    SqlCommand com = new SqlCommand(delcommandString, dataBase.GetConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "applicant");

                    CreateColumns_Students();

                    textBox14.Text = "";
                    textBox13.Text = "";
                    textBox12.Text = "";
                    textBox11.Text = "";

                    dataBase.closeConnection();

                    MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Ошибка при удаление выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonNew2_Click(object sender, EventArgs e)
        {
            try
            {
                string addCommandString = $"INSERT INTO Student (FIO, Date_Birth, Number_Phone, Predmet) " +
                                          $"VALUES ('{textBox14.Text}', '{textBox13.Text}', '{textBox12.Text}', '{textBox11.Text}')";

                dataBase.openConnection();

                SqlCommand com = new SqlCommand(addCommandString, dataBase.GetConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "applicant");

                CreateColumns_Students();

                textBox14.Text = "";
                textBox13.Text = "";
                textBox12.Text = "";
                textBox11.Text = "";

                dataBase.closeConnection();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                MessageBox.Show("Ошибка при создании записи, такая запись существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChange2_Click(object sender, EventArgs e)
        {
            // Проверяем наличие значений в текстовых полях перед формированием запроса
            if (string.IsNullOrEmpty(textBox14.Text) || string.IsNullOrEmpty(textBox13.Text) || string.IsNullOrEmpty(textBox12.Text) || string.IsNullOrEmpty(textBox11.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Формируем SQL запрос с использованием параметров
            string changeCommandString = "UPDATE Student SET FIO = @FIO, Date_Birth = @DateBirth, Number_Phone = @NumberPhone, Predmet = @Predmet WHERE student_id = @IDStudent;";

            // Открываем соединение с базой данных
            dataBase.openConnection();

            // Создаем команду с параметрами
            SqlCommand com = new SqlCommand(changeCommandString, dataBase.GetConnection());
            com.Parameters.AddWithValue("@FIO", textBox14.Text);
            com.Parameters.AddWithValue("@DateBirth", textBox13.Text);
            com.Parameters.AddWithValue("@NumberPhone", textBox12.Text);
            com.Parameters.AddWithValue("@Predmet", textBox11.Text);
            com.Parameters.AddWithValue("@IDStudent", id_student);


            // Выполняем команду
            com.ExecuteNonQuery();

            // Обновляем DataGridView
            CreateColumns_Students();

            // Очищаем текстовые поля
            textBox14.Text = "";
            textBox13.Text = "";
            textBox12.Text = "";
            textBox11.Text = "";

            // Закрываем соединение с базой данных
            dataBase.closeConnection();

            // Показываем сообщение об успешном изменении записи
            MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void ClearButton2_Click(object sender, EventArgs e)
        {
            textBox14.Text = "";
            textBox13.Text = "";
            textBox12.Text = "";
            textBox11.Text = "";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------
        
        // Реализация функции для пункта: Репетиторы

        private void SearchUp3(DataGridView dataGridView3)
        {
            string searchapString = $"select tutor_id as 'ID', FIO as 'ФИО', Phone_Number as 'Номер телефона', " +
                                    $"Kvalification as 'Квалификация', Predmets as 'Предмет' from Repetitors where FIO like '%" + textBox3.Text + "%'";
            SqlCommand com = new SqlCommand(searchapString, dataBase.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "applicant");
            dataGridView3.DataSource = ds.Tables[0];
            dataBase.closeConnection();
        }

        private void SearchApp3_ChangeText(object sender, EventArgs e)
        {
            SearchUp3(dataGridView3);
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView3.Rows[selectdRow];

                    id_teacher = Convert.ToInt32(row.Cells[0].Value);
                    textBox18.Text = row.Cells[1].Value.ToString();
                    textBox17.Text = row.Cells[2].Value.ToString();
                    textBox16.Text = row.Cells[3].Value.ToString();
                    textBox15.Text = row.Cells[4].Value.ToString();
                }

                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonDel3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox18.Text) || string.IsNullOrEmpty(textBox17.Text) || string.IsNullOrEmpty(textBox16.Text) || string.IsNullOrEmpty(textBox15.Text))
            {
                MessageBox.Show("Отсутсвует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                try
                {
                    string delcommandString = $"DELETE Repetitors where tutor_id = '{id_teacher}'";

                    dataBase.openConnection();

                    SqlCommand com = new SqlCommand(delcommandString, dataBase.GetConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "applicant");

                    CreateColumns_Rep();

                    textBox18.Text = "";
                    textBox17.Text = "";
                    textBox16.Text = "";
                    textBox15.Text = "";

                    dataBase.closeConnection();

                    MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Ошибка при удаление выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonNew3_Click(object sender, EventArgs e)
        {
            try
            {
                string addCommandString = $"INSERT INTO Repetitors (FIO, Phone_Number, Kvalification, Predmets) " +
                                          $"VALUES ('{textBox18.Text}', '{textBox17.Text}', '{textBox16.Text}', '{textBox15.Text}')";

                dataBase.openConnection();

                SqlCommand com = new SqlCommand(addCommandString, dataBase.GetConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "applicant");

                CreateColumns_Rep();

                textBox18.Text = "";
                textBox17.Text = "";
                textBox16.Text = "";
                textBox15.Text = "";

                dataBase.closeConnection();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                MessageBox.Show("Ошибка при создании записи, такая запись существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChange3_Click(object sender, EventArgs e)
        {
            // Проверяем наличие значений в текстовых полях перед формированием запроса
            if (string.IsNullOrEmpty(textBox18.Text) || string.IsNullOrEmpty(textBox17.Text) || string.IsNullOrEmpty(textBox16.Text) || string.IsNullOrEmpty(textBox15.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Формируем SQL запрос с использованием параметров
            string changeCommandString = "UPDATE Repetitors SET FIO = @FIO, Phone_Number = @PhoneNumber, Kvalification = @Kvalification, Predmets = @Predmet WHERE tutor_id = @IDTeacher;";

            // Открываем соединение с базой данных
            dataBase.openConnection();

            // Создаем команду с параметрами
            SqlCommand com = new SqlCommand(changeCommandString, dataBase.GetConnection());
            com.Parameters.AddWithValue("@FIO", textBox18.Text);
            com.Parameters.AddWithValue("@PhoneNumber", textBox17.Text);
            com.Parameters.AddWithValue("@Kvalification", textBox16.Text);
            com.Parameters.AddWithValue("@Predmet", textBox15.Text);
            com.Parameters.AddWithValue("@IDTeacher", id_teacher);


            // Выполняем команду
            com.ExecuteNonQuery();

            // Обновляем DataGridView
            CreateColumns_Rep();

            // Очищаем текстовые поля
            textBox18.Text = "";
            textBox17.Text = "";
            textBox16.Text = "";
            textBox15.Text = "";

            // Закрываем соединение с базой данных
            dataBase.closeConnection();

            // Показываем сообщение об успешном изменении записи
            MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearButton3_Click(object sender, EventArgs e)
        {
            textBox18.Text = "";
            textBox17.Text = "";
            textBox16.Text = "";
            textBox15.Text = "";
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        // Реализация функции для пункта: Расписание

        private void SearchUp4(DataGridView dataGridView4)
        {
            string searchapString = $"select tutor_id as 'ID', FIO as 'ФИО', Phone_Number as 'Номер телефона', Kvalification as 'Квалификация', Predmets as 'Предмет' from Raspisanie_Zaniyatiy where concat (student_id, tutor_id) like '%" + textBox4.Text + "%'";
            SqlCommand com = new SqlCommand(searchapString, dataBase.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "applicant");
            dataGridView4.DataSource = ds.Tables[0];
            dataBase.closeConnection();
        }

        private void SearchApp4_ChangeText(object sender, EventArgs e)
        {
            SearchUp4(dataGridView4);
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView4.Rows[selectdRow];

                    id_raspisanie = Convert.ToInt32(row.Cells[0].Value);
                    textBox22.Text = row.Cells[1].Value.ToString();
                    textBox21.Text = row.Cells[2].Value.ToString();
                    textBox20.Text = row.Cells[3].Value.ToString();
                    textBox19.Text = row.Cells[4].Value.ToString();
                }

                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void buttonDel4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox19.Text) || string.IsNullOrEmpty(textBox20.Text) || string.IsNullOrEmpty(textBox21.Text) || string.IsNullOrEmpty(textBox22.Text))
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

                    textBox22.Text = "";
                    textBox21.Text = "";
                    textBox20.Text = "";
                    textBox19.Text = "";

                    dataBase.closeConnection();

                    MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Ошибка при удаление выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonNew4_Click(object sender, EventArgs e)
        {
            try
            {
                string addCommandString = $"INSERT INTO Raspisanie_Zaniyatiy (student_id, tutor_id, Time_Begin, Time_of_Zaniyatia) " +
                                          $"VALUES ('{textBox22.Text}', '{textBox21.Text}', '{textBox20.Text}', '{textBox19.Text}')";

                dataBase.openConnection();

                SqlCommand com = new SqlCommand(addCommandString, dataBase.GetConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "applicant");

                CreateColumns_DataTime();

                textBox22.Text = "";
                textBox21.Text = "";
                textBox20.Text = "";
                textBox19.Text = "";

                dataBase.closeConnection();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                MessageBox.Show("Ошибка при создании записи, такая запись существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChange4_Click(object sender, EventArgs e)
        {
            // Проверяем наличие значений в текстовых полях перед формированием запроса
            if (string.IsNullOrEmpty(textBox22.Text) || string.IsNullOrEmpty(textBox21.Text) || string.IsNullOrEmpty(textBox20.Text) || string.IsNullOrEmpty(textBox19.Text))
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
            com.Parameters.AddWithValue("@Student", textBox22.Text);
            com.Parameters.AddWithValue("@Theacher", textBox21.Text);
            com.Parameters.AddWithValue("@Time", textBox20.Text);
            com.Parameters.AddWithValue("@TimePridmet", textBox19.Text);
            com.Parameters.AddWithValue("@IDRaspis", id_raspisanie);


            // Выполняем команду
            com.ExecuteNonQuery();

            // Обновляем DataGridView
            CreateColumns_DataTime();

            // Очищаем текстовые поля
            textBox22.Text = "";
            textBox21.Text = "";
            textBox20.Text = "";
            textBox19.Text = "";

            // Закрываем соединение с базой данных
            dataBase.closeConnection();

            // Показываем сообщение об успешном изменении записи
            MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearButton4_Click(object sender, EventArgs e)
        {
            textBox22.Text = "";
            textBox21.Text = "";
            textBox20.Text = "";
            textBox19.Text = "";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------

        // Реализация функции для пункта: Предметы для учёбы

        private void SearchUp5(DataGridView dataGridView5)
        {
            string searchapString = $"select subject_id as 'ID', Name_Pridment as 'Названия предмета' from Pridments where Name_Pridment like '%" + textBox5.Text + "%'";
            SqlCommand com = new SqlCommand(searchapString, dataBase.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "applicant");
            dataGridView5.DataSource = ds.Tables[0];
            dataBase.closeConnection();
        }

        private void SearchApp5_ChangeText(object sender, EventArgs e)
        {
            SearchUp5(dataGridView5);
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView5.Rows[selectdRow];

                    id_pridmet = Convert.ToInt32(row.Cells[0].Value);
                    textBox26.Text = row.Cells[1].Value.ToString();
                }

                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonDel5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox26.Text))
            {
                MessageBox.Show("Отсутсвует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                try
                {
                    string delcommandString = $"DELETE Pridments where subject_id = '{id_pridmet}'";

                    dataBase.openConnection();

                    SqlCommand com = new SqlCommand(delcommandString, dataBase.GetConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "applicant");

                    CreateColumns_ItemTeach();

                    textBox26.Text = "";

                    dataBase.closeConnection();

                    MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Ошибка при удаление выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonNew5_Click(object sender, EventArgs e)
        {
            try
            {
                string addCommandString = $"INSERT INTO Pridments (Name_Pridment) " +
                                          $"VALUES ('{textBox26.Text}')";

                dataBase.openConnection();

                SqlCommand com = new SqlCommand(addCommandString, dataBase.GetConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "applicant");

                CreateColumns_ItemTeach();

                textBox26.Text = "";

                dataBase.closeConnection();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                MessageBox.Show("Ошибка при создании записи, такая запись существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton5_Click(object sender, EventArgs e)
        {
            textBox26.Text = "";
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        // Реализация функции для пункта: Статистика оплаты занятий

        private void SearchUp6(DataGridView dataGridView6)
        {
            string searchapString = $"select payment_id as 'ID', student_id as 'Студент', tutor_id as 'Репетитор', " +
                                    $"Date_of_Payment as 'Дата оплаты', Summ_Payment as 'Сумма' from Payment where concat (student_id, tutor_id) like '%" + textBox6.Text + "%'";
            SqlCommand com = new SqlCommand(searchapString, dataBase.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "applicant");
            dataGridView6.DataSource = ds.Tables[0];
            dataBase.closeConnection();
        }

        private void SearchApp6_ChangeText(object sender, EventArgs e)
        {
            SearchUp6(dataGridView6);
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView6.Rows[selectdRow];

                    id_payment = Convert.ToInt32(row.Cells[0].Value);
                    textBox30.Text = row.Cells[1].Value.ToString();
                    textBox29.Text = row.Cells[2].Value.ToString();
                    textBox28.Text = row.Cells[3].Value.ToString();
                    textBox27.Text = row.Cells[4].Value.ToString();
                }

                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonDel6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox30.Text) || string.IsNullOrEmpty(textBox29.Text) || string.IsNullOrEmpty(textBox28.Text) || string.IsNullOrEmpty(textBox27.Text))
            {
                MessageBox.Show("Отсутсвует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                try
                {
                    string delcommandString = $"DELETE Payment where payment_id = '{id_payment}'";

                    dataBase.openConnection();

                    SqlCommand com = new SqlCommand(delcommandString, dataBase.GetConnection());
                    SqlDataAdapter adapter = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "applicant");

                    CreateColumns_Payment();

                    textBox30.Text = "";
                    textBox29.Text = "";
                    textBox28.Text = "";
                    textBox27.Text = "";

                    dataBase.closeConnection();

                    MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    MessageBox.Show("Ошибка при удаление выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonNew6_Click(object sender, EventArgs e)
        {
            try
            {
                string addCommandString = $"INSERT INTO Payment (student_id, tutor_id, Date_of_Payment, Summ_Payment) " +
                                          $"VALUES ('{textBox30.Text}', '{textBox29.Text}', '{textBox28.Text}', '{textBox27.Text}')";

                dataBase.openConnection();

                SqlCommand com = new SqlCommand(addCommandString, dataBase.GetConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "applicant");

                CreateColumns_Payment();

                textBox30.Text = "";
                textBox29.Text = "";
                textBox28.Text = "";
                textBox27.Text = "";

                dataBase.closeConnection();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                MessageBox.Show("Ошибка при создании записи!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void сохранитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

            using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create))
            {
                Document doc = new Document(PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                Paragraph paragraph = new Paragraph("Expo: ");
                doc.Add(paragraph);

                PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText));
                }
                table.HeaderRows = 1;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int k = 0; k < dataGridView1.Columns.Count; k++)
                    {
                        if (dataGridView1[k, i].Value != null)
                        {
                            table.AddCell(new Phrase(dataGridView1[k, i].Value.ToString()));
                        }
                    }
                }
                doc.Add(table);
            }

            MessageBox.Show("Pdf-документ сохранен");
        }

        private void buttonChange6_Click(object sender, EventArgs e)
        {
            // Проверяем наличие значений в текстовых полях перед формированием запроса
            if (string.IsNullOrEmpty(textBox30.Text) || string.IsNullOrEmpty(textBox29.Text) || string.IsNullOrEmpty(textBox28.Text) || string.IsNullOrEmpty(textBox27.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Формируем SQL запрос с использованием параметров
            string changeCommandString = "UPDATE Payment SET student_id = @Student, tutor_id = @Theacher, Date_of_Payment = @DataPay, Summ_Payment = @SumPay WHERE payment_id = @IDPay;";

            // Открываем соединение с базой данных
            dataBase.openConnection();

            // Создаем команду с параметрами
            SqlCommand com = new SqlCommand(changeCommandString, dataBase.GetConnection());
            com.Parameters.AddWithValue("@Student", textBox30.Text);
            com.Parameters.AddWithValue("@Theacher", textBox29.Text);
            com.Parameters.AddWithValue("@DataPay", textBox28.Text);
            com.Parameters.AddWithValue("@SumPay", textBox27.Text);
            com.Parameters.AddWithValue("@IDPay", id_payment);


            // Выполняем команду
            com.ExecuteNonQuery();

            // Обновляем DataGridView
            CreateColumns_Payment();

            // Очищаем текстовые поля
            textBox30.Text = "";
            textBox29.Text = "";
            textBox28.Text = "";
            textBox27.Text = "";

            // Закрываем соединение с базой данных
            dataBase.closeConnection();

            // Показываем сообщение об успешном изменении записи
            MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearButton6_Click(object sender, EventArgs e)
        {
            textBox30.Text = "";
            textBox29.Text = "";
            textBox28.Text = "";
            textBox27.Text = "";
        }

        private void Admin_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            player.controls.stop();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            dataBase.closeConnection();

            this.Hide();
        }

    }


}