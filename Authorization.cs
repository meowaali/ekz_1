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

namespace _17
{
    public partial class Authorization : Form
    {
        private string login = "";
        private string password = "";
        public Authorization()
        {
            InitializeComponent();
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_enter_MouseEnter(object sender, EventArgs e)
        {
            btn_enter.BackColor = System.Drawing.ColorTranslator.FromHtml("#4480eb");
        }

        private void btn_enter_MouseLeave(object sender, EventArgs e)
        {
            btn_enter.BackColor = Color.White;
        }

        private void label_registr_MouseEnter(object sender, EventArgs e)
        {
            label_registr.BackColor = System.Drawing.ColorTranslator.FromHtml("#4480eb");
        }

        private void label_registr_MouseLeave(object sender, EventArgs e)
        {
            label_registr.BackColor = Color.White;
        }

        private async void btn_enter_Click(object sender, EventArgs e)
        {
            login = textLog.Text;
            password = textPas.Text;

            if (login.Length == 0 || password.Length == 0)
            {
                return;
            }

            Program.con.Open();
            try
            {
                NpgsqlCommand commandCheckApplicants = new NpgsqlCommand($"SELECT id_role FROM applicants WHERE login = '{login}'", Program.con);
                int id_role = int.Parse(commandCheckApplicants.ExecuteScalar().ToString());

                Program.con.Close();

                if (!CheckPassword("applicants"))
                {
                    return;
                }
                
                Homepage page = new Homepage(password, id_role);
                page.Show();
                Hide();
            }
            catch (System.NullReferenceException ex)
            {
                
                NpgsqlCommand commandCheckKomission = new NpgsqlCommand($"SELECT id_role FROM komission WHERE login = '{login}'", Program.con);
                string id_role = commandCheckKomission.ExecuteScalar().ToString();

                Program.con.Close();

                if (!CheckPassword("komission"))
                {
                    return;
                }

                Accepting_applications app = new Accepting_applications(password, int.Parse(id_role));
                app.Show();
                Hide();
            }
            
        }
        private void label_registr_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.ShowDialog();
        }

        private bool CheckPassword(string table)
        {
            Program.con.Open();

            NpgsqlCommand commandSelect = new NpgsqlCommand($"SELECT password FROM {table} WHERE login = '{login}'", Program.con);
            string getedPassword = commandSelect.ExecuteScalar().ToString();

            Program.con.Close();

            if (password == getedPassword)
            {
                Program.con.Close();
                return true;
            }
            else
            {
                Program.con.Close();
                MessageBox.Show("Пароль не верный", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
