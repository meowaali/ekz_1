using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace _17
{
    public partial class commentForm : Form
    {
        public int applicationId;
        private string applicationStatus; 
        private string applicationText;
        // Свойство для получения введенного пользователем комментария
        public string Comment { get { return textBoxComment.Text; } }
        public commentForm(int id, string status, string documentText)
        {
            InitializeComponent();
            applicationId = id;
            applicationStatus = status;
            applicationText = documentText;
            // Отображаем информацию о заявке на форме
            textBoxApplicationInfo.Text = $"Заявка ID: {applicationId} - Статус: {applicationStatus}\n{applicationText}";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxComment.Text))
            {
                MessageBox.Show("Пожалуйста, введите комментарий.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Program.con.Open();
            try
            {
                    NpgsqlCommand commandComment = new NpgsqlCommand("UPDATE applications SET Comment =  @Comment WHERE id = @applicationid", Program.con);
                    commandComment.Parameters.AddWithValue("@applicationid", applicationId);
                    commandComment.Parameters.AddWithValue("@Comment", textBoxComment.Text);
                    commandComment.ExecuteNonQuery();

 
                DialogResult = DialogResult.OK; 
                Program.con.Close();
            }
            catch (Exception ex)
            {
                Program.con.Close();
                MessageBox.Show("Ошибка при добавлении комментария: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}