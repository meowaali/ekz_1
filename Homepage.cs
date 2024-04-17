using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _17
{
    public partial class Homepage : Form
    {
        string _password = "";
        int _id_role = 0;
        string _username = "";
        string _direction = "";

        PrintDocument document = new PrintDocument();
        PrintDialog dialog = new PrintDialog();
        
        public Homepage(string password, int id_role)
        {
            InitializeComponent();
            _password = password;
            _id_role = id_role;
            _username = GetFullNameFromDatabase();
            _direction = GetDirectionFromDatabase();

            WriteText();

            // Подписываемся на событие PrintPage
            document.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            document.DefaultPageSettings.PrinterSettings.PrinterName = dialog.PrinterSettings.PrinterName;
            document.DefaultPageSettings.Landscape = false; // Портретная ориентация страницы
            document.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50); // Устанавливаем поля

            // Устанавливаем обработчик события для определения размеров печати
            document.PrinterSettings.PrinterName = dialog.PrinterSettings.PrinterName;
            document.PrinterSettings.PrinterName = dialog.PrinterSettings.PrinterName;
            document.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);

            if (_id_role == 2)
            {
                btnAccepting.Visible = false;
            }
            else
            {
                btnAccepting.Visible = true;
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            dialog.Document = document;

            // Если пользователь нажал "ОК" в диалоге печати, печатаем
            if (dialog.ShowDialog() == DialogResult.OK)
                document.Print();
        }

        // Метод для обработки события PrintPage
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Font font = new Font("Arial", 12))
            {
                SizeF textSize = e.Graphics.MeasureString(textBoxApplications.Text, font);
                float scale = Math.Min(e.MarginBounds.Width / textSize.Width, e.MarginBounds.Height / textSize.Height);
                e.Graphics.ScaleTransform(scale, scale);
                e.Graphics.DrawString(textBoxApplications.Text, font, Brushes.Black, e.MarginBounds.Location);
            }
        }

        public string GetFullNameFromDatabase()
        {
            Program.con.Open();
            string username = "";
            try
            {
                 NpgsqlCommand sqlfio = new NpgsqlCommand($"SELECT username FROM applicants WHERE password = '{_password}';", Program.con);
                 username = sqlfio.ExecuteScalar().ToString();

                 Program.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении ФИО из базы данных: " + ex.Message);
                Program.con.Close();
            }

            return username;
        }

        public string GetDirectionFromDatabase()
        {
            Program.con.Open();
            string direction = "";
            try
            {
                NpgsqlCommand sqldirection = new NpgsqlCommand($"SELECT direction FROM applicants WHERE password = '{_password}';", Program.con);
                direction = sqldirection.ExecuteScalar().ToString();

                Program.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении направления из базы данных: " + ex.Message);
                Program.con.Close();
            }

            return direction;
        }

        private void SaveToDatabase()
        {
            Program.con.Open();
            string id = "";

            try
            {
                NpgsqlCommand selectCommand = new NpgsqlCommand($@"SELECT id FROM applications WHERE ""FIOstudent"" = '{_username}'", Program.con);
                id = selectCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand($@"INSERT INTO public.applications(document_text, ""FIOstudent"") VALUES('{textBoxApplications.Text}', '{_username}') RETURNING id", Program.con);

                    int newId = (int)cmd.ExecuteScalar();

                    MessageBox.Show($"Документ успешно сохранен в базе данных. Новый ID: {newId}");
                    Program.con.Close();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Ошибка при сохранении документа: " + ex.Message);
                    Program.con.Close();
                }
            }

            NpgsqlCommand updateCommand = new NpgsqlCommand($"UPDATE applications SET document_text='{textBoxApplications.Text}' WHERE id = {id};", Program.con);
            updateCommand.ExecuteNonQuery();

            Program.con.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveToDatabase();
            textBoxApplications.Clear();
            textBoxApplications.Text = "Подано";
        }

        private void btnAccepting_Click(object sender, EventArgs e)
        {
            Accepting_applications applic = new Accepting_applications(_password, _id_role);
            applic.Show();
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string text = "";

            Program.con.Open();

            NpgsqlCommand selectCommand = new NpgsqlCommand($"SELECT document_text, status, comment FROM public.applications WHERE \"FIOstudent\" = '{_username}';", Program.con);
            NpgsqlDataReader reader = selectCommand.ExecuteReader();

            reader.Read();
            
            text = $"{reader.GetValue(0)} \n\r\n\rСтатус: {reader.GetValue(1)}\n\r\n\rКоментарий: {reader.GetValue(2)}";
            

            
            Program.con.Close();

            textBoxApplications.Text = text;

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            WriteText();
        }

        private void WriteText()
        {
            textBoxApplications.Text = $"                                       Заявление\r\nЯ, {_username} подал документы в ВУЗ\r\nНа направления подготовки: {_direction} \r\n\r\n\r\nДата:";
        }
    }
}
