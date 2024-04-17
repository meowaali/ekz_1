using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace _17
{
    public partial class Accepting_applications : Form
    {
        string _password = "";
        int id_role = 0;

        public Accepting_applications(string password, int id_role)
        {
            InitializeComponent();


            //listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            comboBoxStatus.Items.Add("Готово");
            comboBoxStatus.Items.Add("В доработку");
            _password = password;
            this.id_role = id_role;
        }

        private void Accepting_applications_Load(object sender, EventArgs e)
        {
            DisplayApplications();
        }

        private void DisplayApplications(string searchQuery = "")
        {
            Program.con.Open(); 
            try
            {
                string sqlQuery = "SELECT id, document_text, status FROM applications";
                // Если есть поисковой запрос, добавляем условие WHERE для фильтрации
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    sqlQuery += $" WHERE document_text ILIKE '%{searchQuery}%' OR status ILIKE '%{searchQuery}%'";
                }
                NpgsqlCommand cmd = new NpgsqlCommand(sqlQuery, Program.con);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd); DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                listBox1.Items.Clear();
                // Добавление каждой заявки в ListBox
                foreach (DataRow row in dataTable.Rows)
                {
                    string documentText = row["document_text"].ToString();
                    string status = row["status"].ToString(); listBox1.Items.Add($"Заявка ID: {row["id"]} - Статус: {status}\n{documentText}\n");
                }
                Program.con.Close();
            }
            catch (Exception ex)
            {
                Program.con.Close();
                MessageBox.Show("Ошибка при отображении заявок: " + ex.Message);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedApplication = listBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedApplication))
            {
                string[] parts = selectedApplication.Split(new string[] { " - " }, StringSplitOptions.None);
                if (parts.Length >= 2)
                {
                    string idPart = parts[0].Replace("Заявка ID: ", "").Trim();
                    int id;
                    if (int.TryParse(idPart, out id))
                    {
                        string status = parts[1];
                        string documentText = string.Join(" - ", parts.Skip(2));

                        commentForm commentForm = new commentForm(id, status, documentText);
                        //// Открываем форму
                        DialogResult result = commentForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            // Здесь вы можете получить комментарий из CommentForm
                            string comment = commentForm.Comment;

                        }
                    }
                }
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите заявку для установки статуса.");
                    return;
                }
                Program.con.Open(); 
                string selectedItemId = listBox1.SelectedItem.ToString().Split(':')[1].Trim().Split(' ')[0];
                int id = Convert.ToInt32(selectedItemId); 
                string status = comboBoxStatus.Text;
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE applications SET status = @status WHERE id = @id", Program.con);
                cmd.Parameters.AddWithValue("@status", status); 
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Program.con.Close();
                MessageBox.Show("Статус успешно сохранен.");
                DisplayApplications();
            }
            catch (Exception ex)
            {
                Program.con.Close();
                MessageBox.Show("Ошибка при сохранении статуса: " + ex.Message);
            }
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = textBoxSearch.Text.ToLower();
            DisplayApplications(searchQuery);
        }
    }
}
