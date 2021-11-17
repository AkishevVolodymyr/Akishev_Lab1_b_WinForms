using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace Akishev_Lab1_b_WinForms
{

    public partial class Form1 : Form
    {
        public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Vlad Vlad/source/repos/Akishev_Lab1_b_WinForms/Users1.accdb;";
        public OleDbConnection myConnection1;

        public bool flag = false;

        TextBox LoginBox; // Поле введення логіну 
        TextBox PassBox; // Поле введення паролю
        TextBox PassConfBox; // Поле підтвердження паролю
        TextBox NamefBox; // Поле введення імені нового користувача в базу даних
        TextBox LastNameBox; // Поле введення прізвища нового користувача в базу даних
        TextBox AgeBox; // Поле введення віку нового користувача в базу даних
        Label label; // Надпис
        Button RegButton; // Кнопка реєстрації
        Button LoginButton; // Кнопка входу 
        Button SearchButton; // Кнопка пошуку за введеними параметрами
        DataGridView data; // Компонент для відображення та редагування таблиць
        TextBox SearchByLogin; // Пошук по логіну
        TextBox SearchByName; // Пошук по імені
        TextBox SearchByLastName; // Пошук по прізвищу
        TextBox SearchByAge; // Пошук по віку

        public Form1()
        {
            InitializeComponent();
            myConnection1 = new OleDbConnection(connectionString);
            myConnection1.Open();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection1.Close();
        }

        
        private void search_Click(object sender, EventArgs e)
        {
            (data.DataSource as DataTable).DefaultView.RowFilter = $"User_Login LIKE '%{SearchByLogin.Text}%' AND User_Name LIKE '%{SearchByName.Text}%' AND User_Last_name LIKE '%{SearchByLastName.Text}%' AND Age LIKE '%{SearchByAge.Text}%' ";
        }

        private void результатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                MessageBox.Show("Вы не авторизовались! Авторизуйтесь!");
            }
            else
            {
                panel1.Controls.Clear();
                data = new DataGridView();
                data.Visible = true;
                data.Location = new Point(10, 10);
                data.Width = 500;
                data.Height = 300;
                panel1.Controls.Add(data);

                generate_Filter();
                

                data.Rows.Clear();
                string query = "SELECT id, login, user_name, user_lastname, age FROM users";
                

                DataSet ds = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, myConnection1);
                adapter.Fill(ds);
                data.DataSource = ds.Tables[0];


            }


        }

        // Пункт меню "Вхід"

        private void вхідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            label = new Label();
            label.Text = "Login:";
            label.Visible = true;
            label.Location = new Point(100, 50);
            panel1.Controls.Add(label);
            //
            LoginBox = new TextBox();
            LoginBox.Visible = true;
            LoginBox.Location = new Point(100, 80);
            panel1.Controls.Add(LoginBox);
            //
            label = new Label();
            label.Text = "Pass:";
            label.Visible = true;
            label.Location = new Point(100, 120);
            panel1.Controls.Add(label);
            //
            PassBox = new TextBox();
            PassBox.Visible = true;
            PassBox.PasswordChar = '*';
            PassBox.Location = new Point(100, 160);
            panel1.Controls.Add(PassBox);
            //
            LoginButton = new Button();
            LoginButton.Text = "Enter!";
            LoginButton.Visible = true;
            LoginButton.Location = new Point(100, 200);
            panel1.Controls.Add(LoginButton);
            LoginButton.Click += new EventHandler(LoginButton_Click);


        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Перевірка введених користувачем даних - перевірка на заповнені поля

            string query = "SELECT User_Login, Password FROM Users_Table";
            OleDbCommand command = new OleDbCommand(query, myConnection1);
            OleDbDataReader dbReader = command.ExecuteReader();
            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Помилка, спробуйте пізніше!");
            }
            else
            {
                while (dbReader.Read())
                {
                    // Перевірка введених користувачем даних - перевірка на правильність заповнення полів

                    if (LoginBox.Text == dbReader["User_Login"].ToString() && PassBox.Text == dbReader["Password"].ToString())
                    {
                        flag = true;
                        результатToolStripMenuItem_Click(null, null);
                    }
                }
                if (!flag)
                {
                    MessageBox.Show("Ви ввели неправильний логін або пароль!");
                }
            }
        }

        // пункт меню "Вихід"
        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myConnection1.Close();
            Close();
        }

        // пункт меню "Реєстрація"
        private void реєстраціяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Створення нового логіну - створення підпису "Логін" 
            panel1.Controls.Clear();
            label = new Label();
            label.Text = "Логін:";
            label.Visible = true;
            label.Location = new Point(100, 50);
            panel1.Controls.Add(label);

            // Створення нового логіну - створення поля введення логіну
            LoginBox = new TextBox();
            LoginBox.Visible = true;
            LoginBox.Location = new Point(250, 50);
            LoginBox.Width = 250;
            panel1.Controls.Add(LoginBox);

            // Створення нового паролю - створення підпису "Пароль"
            label = new Label();
            label.Text = "Пароль:";
            label.Visible = true;
            label.Location = new Point(100, 100);
            panel1.Controls.Add(label);

            // Створення нового паролю - створення поля введення паролю
            PassBox = new TextBox();
            PassBox.Visible = true;
            PassBox.PasswordChar = '*'; // відображення введених символів паролю одним символом '*'
            PassBox.Location = new Point(250, 100);
            PassBox.Width = 250;
            panel1.Controls.Add(PassBox);

            // Підтвердження введеного паролю - створення підпису "Підтвердіть пароль:"
            label = new Label();
            label.Text = "Підтвердіть пароль:";
            label.Visible = true;
            label.Location = new Point(100, 150);
            panel1.Controls.Add(label);

            // Підтвердження введеного паролю - створення поля введення підтвердженого паролю
            PassConfBox = new TextBox();
            PassConfBox.Visible = true;
            PassConfBox.PasswordChar = '*'; // відображення введених символів паролю одним символом '*'
            PassConfBox.Location = new Point(250, 150);
            PassConfBox.Width = 250;
            panel1.Controls.Add(PassConfBox);

            // Введення імені користувача - створення підпису "Ваше ім'я:"
            label = new Label();
            label.Text = "Ваше ім'я:";
            label.Visible = true;
            label.Location = new Point(100, 200);
            panel1.Controls.Add(label);

            // Введення імені користувача - створення поля введення імені користувача
            NamefBox = new TextBox();
            NamefBox.Visible = true;
            NamefBox.Location = new Point(250, 200);
            NamefBox.Width = 250;
            panel1.Controls.Add(NamefBox);

            // Введення прізвища користувача - створення підпису "Ваше прізвище:"
            label = new Label();
            label.Text = "Ваше прізвище:";
            label.Visible = true;
            label.Location = new Point(100, 250);
            panel1.Controls.Add(label);

            // Введення прізвища користувача - створення поля введення прізвища користувача
            LastNameBox = new TextBox();
            LastNameBox.Visible = true;
            LastNameBox.Location = new Point(250, 250);
            LastNameBox.Width = 250;
            panel1.Controls.Add(LastNameBox);

            // Введення віку користувача - створення підпису "Ваш вік:"
            label = new Label();
            label.Text = "Ваш вік:";
            label.Visible = true;
            label.Location = new Point(100, 300);
            panel1.Controls.Add(label);

            // Введення віку користувача - створення поля введення віку користувача (кількість повних років)
            AgeBox = new TextBox();
            AgeBox.Visible = true;
            AgeBox.Location = new Point(250, 300);
            AgeBox.Width = 250;
            panel1.Controls.Add(AgeBox);

            // Кнопка "Зареєструватися"
            RegButton = new Button();
            RegButton.Text = "Зареєструватися";
            RegButton.Visible = true;
            RegButton.Location = new Point(210, 350);
            RegButton.Width = 175;
            panel1.Controls.Add(RegButton);
            RegButton.Click += new EventHandler(RegButton_Click);
        }

        // Процес реєстрації користувача
        private void RegButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LoginBox.Text) && !string.IsNullOrWhiteSpace(PassBox.Text) && PassBox.Text == PassConfBox.Text && !string.IsNullOrWhiteSpace(NamefBox.Text) && !string.IsNullOrWhiteSpace(LastNameBox.Text) && !string.IsNullOrWhiteSpace(AgeBox.Text))
            {
                string query = "SELECT User_Login FROM Users_Table"; 
                OleDbCommand command = new OleDbCommand(query, myConnection1);
                OleDbDataReader dbReader = command.ExecuteReader();
                bool login_isset = false;
                while (dbReader.Read())
                {
                    if (LoginBox.Text == dbReader["User_Login"].ToString())
                    {
                        login_isset = true;
                    }
                }

                if (login_isset)
                {
                    MessageBox.Show("Користувач із таким логіном вже існує!");
                    реєстраціяToolStripMenuItem_Click(null, null);
                }
                else
                {
                    // Внесення введених даних в базу даних 

                    string query_ins = $"INSERT INTO Users_Table (User_Login, Password, User_name, User_Last_name, Age) VALUES ('{LoginBox.Text}', '{PassBox.Text}', '{NamefBox.Text}', '{LastNameBox.Text}', '{AgeBox.Text}')";
                    OleDbCommand command_ins = new OleDbCommand(query_ins, myConnection1);
                    int result = command_ins.ExecuteNonQuery();
                    if (result != 0)
                    {
                        MessageBox.Show("Ви успішно зареєструвалися!");
                        вхідToolStripMenuItem_Click(null, null);

                    }
                    else
                    {
                        MessageBox.Show("Виникла помилка під час реєстрації, повторіть спробу!");
                    }
                }


            }
            else
            {
                // У випадку, коли не всі поля введені

                MessageBox.Show("Заповніть усі поля у формі!");
            }

        }

        // Функція створення фільтрування за логіном, ім'ям, прізвищем та віком
        private void generate_Filter()
        {
            // Фільтрування за логіном

            label = new Label();
            label.Text = "Фільтрувати за логіном:";
            label.Visible = true;
            label.Location = new Point(550, 10);
            panel1.Controls.Add(label);
            
            SearchByLogin = new TextBox();
            SearchByLogin.Visible = true;
            SearchByLogin.Location = new Point(550, 30);
            panel1.Controls.Add(SearchByLogin);

            // Фільтрування за іменем

            label = new Label();
            label.Text = "Фільтрувати за ім'ям:";
            label.Visible = true;
            label.Location = new Point(550, 50);
            panel1.Controls.Add(label);
            
            SearchByName = new TextBox();
            SearchByName.Visible = true;
            SearchByName.Location = new Point(550, 70);
            panel1.Controls.Add(SearchByName);

            // Фільтрування за прізвищем

            label = new Label();
            label.Text = "Фільтрувати за прізвищем:";
            label.Visible = true;
            label.Location = new Point(550, 90);
            panel1.Controls.Add(label);
            
            SearchByLastName = new TextBox();
            SearchByLastName.Visible = true;
            SearchByLastName.Location = new Point(550, 110);
            panel1.Controls.Add(SearchByLastName);

            // Фільтрування за віком
            label = new Label();
            label.Text = "Фільтрувати за віком:";
            label.Visible = true;
            label.Location = new Point(550, 130);
            panel1.Controls.Add(label);
            
            SearchByAge = new TextBox();
            SearchByAge.Visible = true;
            SearchByAge.Location = new Point(550, 150);
            panel1.Controls.Add(SearchByAge);

            // Кнопка "Фільтрувати"

            SearchButton = new Button();
            SearchButton.Text = "Фільтрувати";
            SearchButton.Visible = true;
            SearchButton.Location = new Point(600, 170);
            panel1.Controls.Add(SearchButton);
            SearchButton.Click += new EventHandler(search_Click);
        }
        private void проДодатокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label = new Label();
            label.Text = "Графічний інтерфейс 1(б). Акішев Володимир, ФІТ 1-3м. Київ 2021 ";
            label.Visible = true;
            label.Location = new Point(550, 50);
            panel1.Controls.Add(label);
        }

    }
}

