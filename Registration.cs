using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _17
{
    public partial class Registration : Form
    {
        private int maxSelectItems = 5;
        private int maxSelectSchoolItems = 4;
        public Registration()
        {
            InitializeComponent();
            level_education.Items.Add("СПО");
            level_education.Items.Add("Бакалавриат");
            level_education.Items.Add("Специалитет");
            level_education.Items.Add("Магистратура");

            use_scores.Items.Add("Русский язык");
            use_scores.Items.Add("Математика (базовый или профильный уровень)");
            use_scores.Items.Add("Обществознание");
            use_scores.Items.Add("История");
            use_scores.Items.Add("Иностранный язык");
            use_scores.Items.Add("Литература");
            use_scores.Items.Add("География");
            use_scores.Items.Add("Физика");
            use_scores.Items.Add("Химия");
            use_scores.Items.Add("Биология");
            use_scores.Items.Add("Информатика");
            use_scores.Items.Add("Профильная математика");

            textBox1.TextAlign = HorizontalAlignment.Center;
        }

        private void level_education_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < direction_training.Items.Count; i++)
            {
                direction_training.SetItemChecked(i, false);
            }

            // Получить выбранное значение в ComboBox
            string selectedValue = level_education.SelectedItem.ToString();

            // Очистить список элементов в CheckedListBox
            direction_training.Items.Clear();

            // В зависимости от выбранного значения в ComboBox
            // добавить соответствующие элементы в CheckedListBox
            switch (selectedValue)
            {
                case "СПО":
                    direction_training.Items.Add("11.01.01 Монтажник радиоэлектронной аппаратуры и приборов");
                    direction_training.Items.Add("08.02.01 Строительство и эксплуатация зданий и сооружений");
                    direction_training.Items.Add("08.02.05 Строительство и эксплуатация автомобильных дорог и аэродромов");
                    direction_training.Items.Add("08.02.08 Монтаж и эксплуатация оборудования и систем газоснабжения\t");
                    direction_training.Items.Add("08.02.13 Монтаж и эксплуатация внутренних сантехнических устройств, кондиционирования воздуха и вентиляции");
                    direction_training.Items.Add("09.02.01 Компьютерные системы и комплексы");
                    break;
                case "Бакалавриат":
                    direction_training.Items.Add("07.03.01 Архитектура Профиль: «Архитектура»");
                    direction_training.Items.Add("07.03.02  Реконструкция и реставрация архитектурного наследия Профиль: «Реконструкция и реставрация архитектурного наследия»");
                    direction_training.Items.Add("07.03.03 Дизайн архитектурной среды Профиль: «Дизайн архитектурной среды»");
                    direction_training.Items.Add("07.03.04 Градостроительство Профиль: «Градостроительное проектирование»");
                    break;
                case "Специалитет":
                    direction_training.Items.Add("10.05.02 Информационная безопасность телекоммуникационных систем");
                    direction_training.Items.Add("11.05.01 Радиоэлектронные системы и комплексы");
                    direction_training.Items.Add("24.05.02 Проектирование авиационных и ракетных двигателей");
                    direction_training.Items.Add("24.05.07 Самолето- и вертолетостроение");
                    break;
                case "Магистратура":
                    direction_training.Items.Add("07.04.01 Архитектура Программа «Актуальные направления теории и практики архитектуры»");
                    direction_training.Items.Add("07.04.02 Реконструкция и реставрация архитектурного наследия Программа «Реконструкция и реставрация архитектурного наследия»");
                    direction_training.Items.Add("07.04.03 Дизайн архитектурной среды Программа «Дизайн архитектурной среды»");
                    break;
            }
        }

        private void direction_training_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (direction_training.CheckedItems.Count >= maxSelectItems && e.NewValue == CheckState.Checked)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }

        private void use_scores_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (use_scores.CheckedItems.Count >= maxSelectSchoolItems && e.NewValue == CheckState.Checked)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (level_education.SelectedItem != null && use_scores.SelectedItem != null)
            {
                string educationLevel = level_education.SelectedItem.ToString();
                string selectedSubject = use_scores.SelectedItem.ToString();

                switch (educationLevel)
                {
                    case "СПО":
                        if (int.TryParse(textBoxScore.Text, out int spoScore1))
                        {
                            if (spoScore1 > 5 || spoScore1 < 0)
                            {
                                MessageBox.Show("Средний балл аттестата не может быть больше 5 и меньше 0!", "Ошибка");
                            }
                            else
                            {
                                selectedSubject = textBoxScore.Text;
                                MessageBox.Show("Всё верно");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректный средний балл аттестата!", "Ошибка");
                        }
                        break;
                    case "Бакалавриат":
                        if (int.TryParse(textBoxScore.Text, out int spoScore2))
                        {
                            if (spoScore2 > 100 || spoScore2 < 0)
                            {
                                MessageBox.Show("Баллы ЕГЭ не могут быть больше 300 и меньше 0!", "Ошибка");
                            }
                            else
                            {
                                selectedSubject = textBoxScore.Text;
                                MessageBox.Show("Всё верно");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректные баллы ЕГЭ!", "Ошибка");
                        }
                        break;
                    case "Специалитет":
                        if (int.TryParse(textBoxScore.Text, out int spoScore3))
                        {
                            if (spoScore3 > 100 || spoScore3 < 0)
                            {
                                MessageBox.Show("Баллы ЕГЭ не могут быть больше 300 и меньше 0!", "Ошибка");
                            }
                            else
                            {
                                selectedSubject = textBoxScore.Text;
                                MessageBox.Show("Всё верно");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректные баллы ЕГЭ!", "Ошибка");
                        }
                        break;
                    case "Магистратура":
                        if (int.TryParse(textBoxScore.Text, out int spoScore4))
                        {
                            if (spoScore4 > 100 || spoScore4 < 0)
                            {
                                MessageBox.Show("Средний балл диплома не может быть больше 100 и меньше 0!", "Ошибка");
                            }
                            else
                            {
                                selectedSubject = textBoxScore.Text;
                                MessageBox.Show("Всё верно");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректный средний балл диплома!", "Ошибка");
                        }
                        break;
                    default:
                        MessageBox.Show("Выберите уровень образования!", "Ошибка");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Выберите уровень образования и предмет!", "Ошибка");
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Получаем путь к выбранному файлу
                string selectedFilePath = openFileDialog1.FileName;

                // Отображаем путь к файлу в TextBox
                textBoxFilePath.Text = selectedFilePath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = textBoxUserName.Text;
            string usernamepar = textBoxUserNamePar.Text;
            string pasport = textBoxPasport.Text;
            string snils = textBoxSnils.Text;
            string mail = textBoxMail.Text;
            string school = textBoxSchool.Text;
            string phone = textBoxPhone.Text;
            string score = textBoxScore.Text;
            string file = textBoxFilePath.Text;
            string login = textBoxLog.Text;
            string password = textBoxPas.Text;

            string level = level_education.SelectedItem.ToString();

            List<string> direction = new List<string>();
            foreach (var item in direction_training.CheckedItems)
            {
                direction.Add(item.ToString());
            }
            string directionString = string.Join(",", direction);

            List<string> use = new List<string>();
            foreach (var item in use_scores.CheckedItems)
            {
                use.Add(item.ToString());
            }
            string useString = string.Join(",", use);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(usernamepar) || string.IsNullOrWhiteSpace(pasport) || string.IsNullOrWhiteSpace(snils) || string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(school) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(score) || string.IsNullOrWhiteSpace(file) || string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(level) || direction.Count == 0 || use.Count == 0)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            Program.con.Open();
            try
            {
                string query = "INSERT INTO applicants (username, usernamepar, pasport, snils, mail, school, phone, score, file, level, direction, use, login, password) VALUES (@username, @usernamepar, @pasport, @snils, @mail, @school, @phone, @score, @file, @level, @direction, @use, @login, @password)";
                NpgsqlCommand CommandRegistration = new NpgsqlCommand(query, Program.con);
                // Добавляем параметры
                CommandRegistration.Parameters.AddWithValue("@username", username);
                CommandRegistration.Parameters.AddWithValue("@usernamepar", usernamepar);
                CommandRegistration.Parameters.AddWithValue("@pasport", pasport);
                CommandRegistration.Parameters.AddWithValue("@snils", snils);
                CommandRegistration.Parameters.AddWithValue("@mail", mail);
                CommandRegistration.Parameters.AddWithValue("@school", school);
                CommandRegistration.Parameters.AddWithValue("@phone", phone);
                CommandRegistration.Parameters.AddWithValue("@score", score);
                CommandRegistration.Parameters.AddWithValue("@file", file);
                CommandRegistration.Parameters.AddWithValue("@login", login);
                CommandRegistration.Parameters.AddWithValue("@password", password);
                CommandRegistration.Parameters.AddWithValue("@level", level);
                CommandRegistration.Parameters.AddWithValue("@direction", directionString);
                CommandRegistration.Parameters.AddWithValue("@use", useString);
                // Выполняем запрос
                int rowsAffected = CommandRegistration.ExecuteNonQuery();
                Program.con.Close();

                // Проверяем успешность выполнения запроса
                if (rowsAffected > 0)
                {
                   MessageBox.Show("Пользователь зарегистрирован успешно! Вернитесь на главную страницу");
                }
                else
                {
                  MessageBox.Show("Ошибка при регистрации пользователя.");
                }
            }
            catch (Exception ex)
            {
                Program.con.Close();
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void label_Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label_Back_MouseEnter(object sender, EventArgs e)
        {
            label_Back.BackColor = System.Drawing.ColorTranslator.FromHtml("#a0a9b9");
        }

        private void label_Back_MouseLeave(object sender, EventArgs e)
        {
            label_Back.BackColor = Color.White;
        }
    }
}
