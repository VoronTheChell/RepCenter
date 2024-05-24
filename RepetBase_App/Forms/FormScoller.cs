using DataBase_App;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RepetBase_App
{
    public partial class FormScoller : Form
    {
        DataBase dataBase = new DataBase();

        LoginUp_Form lg = new LoginUp_Form();

        public FormScoller()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void FormScoller_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;

            CreateColumns_Rep();
            CreateColumns_DataTime();
            CreateColumns_Payment();

        }

        private void CreateColumns_Rep()
        {
            dataBase.openConnection();
            SqlCommand com = new SqlCommand(@"SELECT tutor_id as 'ID', FIO as 'ФИО', Phone_Number as 'Номер телефона', 
					                          Kvalification as 'Квалификация', Predmets as 'Предмет' from Repetitors", dataBase.sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Repetitors");
            dataGridView1.DataSource = ds.Tables[0];
            dataBase.closeConnection();

        }

        private void CreateColumns_DataTime()
        {
            // Реализовать вывод информации через ID (возможно понадобиться редактирование БД)

            dataBase.openConnection();
            SqlCommand com = new SqlCommand(@"SELECT schedule_id as 'ID', tutor_id as 'Учетеля', 
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
            SqlCommand com = new SqlCommand(@"SELECT tutor_id as 'Репетитор', payment_id as 'Предмет', 
					                          Date_of_Payment as 'Дата оплаты', Summ_Payment as 'Сумма' from Payment", dataBase.sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Payment");
            dataGridView3.DataSource = ds.Tables[0];
            dataBase.closeConnection();

        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.closeConnection();
            this.Hide();
        }
    }
}
