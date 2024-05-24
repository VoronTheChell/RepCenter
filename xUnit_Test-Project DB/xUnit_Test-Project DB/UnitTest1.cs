using System.Data.SqlClient;
using System.Data;

namespace xUnit_Test_Project_DB
{
    public class DbConnections_UnitTest
    {

        [Fact]
        public void Test1_Open_Connection()
        {
            // Arrange
            var db = new DataBase();

            // Act
            db.openConnection();

            // Assert
            Assert.Equal(ConnectionState.Open, db.sqlConnection.State);
        }

        [Fact]
        public void Test3_Close_Connection()
        {
            // Arrange
            var db = new DataBase();
            db.openConnection(); // Open connection first

            // Act
            db.closeConnection();

            // Assert
            Assert.Equal(ConnectionState.Closed, db.sqlConnection.State);
        }

        [Fact]
        public void Test2_Get_Connection()
        {
            // Arrange
            var db = new DataBase();

            // Act
            var connection = db.GetConnection();

            // Assert
            Assert.NotNull(connection);
            Assert.IsType<SqlConnection>(connection);
        }
    }

    public class reg_Db_UnitTest
    {
        [Fact]
        public void Test1_Insert_Data()
        {
            // Arrange
            var db = new DataBase();
            string sql = "INSERT INTO register (login_user, password_user, subject_user, status_user) " +
                         "VALUES ('TestUser', 'TestPassword', 'TestSubject', 'admin')";

            // Act
            int rowsAffected = db.ExecuteNonQuery(sql);

            // Assert
            Assert.Equal(1, rowsAffected); // ѕровер€ем, что одна строка была вставлена
        }

        [Fact]
        public void Test2_Delete_Data()
        {

            // Arrange
            var db = new DataBase();
            string sql = "DELETE register where login_user = 'TestUser'";

            // Act
            int rowsAffected = db.ExecuteNonQuery(sql);

            // Assert
            Assert.True(rowsAffected >= 1); // ѕровер€ем, что хот€ бы одна строка была удалена
        }
    }

    public class rep_Db_UnitTest
    {
        [Fact]
        public void Test1_Insert_Data()
        {
            // Arrange
            var db = new DataBase();
            string sql = "INSERT INTO Repetitors (FIO, Phone_Number, Kvalification, Predmets) " +
                         "VALUES ('TestFIO', 'TestPhone', 'TestSubject', 'Math')";

            // Act
            int rowsAffected = db.ExecuteNonQuery(sql);

            // Assert
            Assert.Equal(1, rowsAffected); // ѕровер€ем, что одна строка была вставлена
        }

        [Fact]
        public void Test2_Delete_Data()
        {

            // Arrange
            var db = new DataBase();
            string sql = "DELETE Repetitors where FIO = 'TestFIO'";

            // Act
            int rowsAffected = db.ExecuteNonQuery(sql);

            // Assert
            Assert.True(rowsAffected >= 1); // ѕровер€ем, что хот€ бы одна строка была удалена
        }
    }

    public class std_Db_UnitTest
    {
        [Fact]
        public void Test1_Insert_Data()
        {
            // Arrange
            var db = new DataBase();
            string sql = "INSERT INTO Student (FIO, Date_Birth, Number_Phone, Predmet) " +
                         "VALUES ('TestFIOstud', 'TestDate', 'TestNumberStud', 'Math')";

            // Act
            int rowsAffected = db.ExecuteNonQuery(sql);

            // Assert
            Assert.Equal(1, rowsAffected); // ѕровер€ем, что одна строка была вставлена
        }

        [Fact]
        public void Test2_Delete_Data()
        {

            // Arrange
            var db = new DataBase();
            string sql = "DELETE Student where Number_Phone = 'TestNumberStud'";

            // Act
            int rowsAffected = db.ExecuteNonQuery(sql);

            // Assert
            Assert.True(rowsAffected >= 1); // ѕровер€ем, что хот€ бы одна строка была удалена
        }
    }
}