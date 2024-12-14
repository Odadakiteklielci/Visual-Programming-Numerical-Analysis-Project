using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Sayısal_Analiz_Visual_Proje_
{
    public partial class LoginRegister : Form
    {
        string dbName = "userTablo.db";
        SQLiteConnection connection = new SQLiteConnection("Data Source=userTablo.db;Version=3;");

        public LoginRegister()
        {
            InitializeComponent();
        }

        private void createDatabase()
        {
            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "CREATE TABLE user(id INTEGER PRIMARY KEY AUTOINCREMENT, username VARCHAR(255) NOT NULL, password VARCHAR(255) NOT NULL)";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private string HashPassword(string password)
        {
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            try
            {
                UserSQL userSQL;
                if (textBox3.Text == textBox5.Text && !string.IsNullOrEmpty(textBox3.Text))
                {
                    string hashedPassword = HashPassword(textBox3.Text);
                    userSQL = new UserSQL(textBox4.Text, hashedPassword);
                }
                else
                {
                    MessageBox.Show("Şifreler Eşleşmiyor", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (userSQL != null)
                {
                    SQLiteCommand cmd = new SQLiteCommand(connection);
                    cmd.CommandText = @"INSERT INTO user (username, password) VALUES (@username, @password)";
                    cmd.Parameters.AddWithValue("@username", userSQL.Username);
                    cmd.Parameters.AddWithValue("@password", userSQL.Password);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            connection.Open();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(connection);
                cmd.CommandText = @"SELECT COUNT(*) FROM user WHERE username = @username AND password = @password";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", HashPassword(password));

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {


                    // Kullanıcı adı ve şifre doğrulandıktan sonra ana menüye iletilir
                    UserSQL userSQL = new UserSQL(username, HashPassword(password));
                    anaMenu anaMenuForm = new anaMenu(userSQL);
                    anaMenuForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }


        private void LoginRegister_Load(object sender, EventArgs e)
        {
            createDatabase();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                this.AcceptButton = button1; // Tab 1 için atanacak buton
            }
            else
            {
                this.AcceptButton = button2; // Tab 2 için atanacak buton
            }

        }

        private void LoginRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Enter tuşuna basıldığında
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    button1.PerformClick(); // Tab 1 için atanmış butonu tetikle
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    button2.PerformClick(); // Tab 2 için atanmış butonu tetikle
                }
                
                }
            }
        }
    }

