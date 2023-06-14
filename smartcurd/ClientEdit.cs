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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace smartcurd
{ 
    public partial class ClientEdit : Form
    {
        public int id;
        public ClientEdit()
        {
            InitializeComponent();
        }

        private void saveclient_Click(object sender, EventArgs e)
        {
            if (lastnameTextBox.Text.Equals("") || firstnameTextBox.Text.Equals("") || patronymicTextBox.Text.Equals("")
                || adpasTextBox.Text.Equals("") || numpasTextBox.Text.Equals("") || serpasTextBox.Text.Equals("") || numberTextBox.Text.Equals(""))
            {
                MessageBox.Show("Введённые данные не подходят по формату");
            }
            else
            {
                if (this.saveclient.Text == "Update")
                {
                    CRUD.sql = "UPDATE client SET last_name = @last_name, first_name = @first_name, patronymic = @patronymic, number = @number," +
                        " num_pas = @num_pas, ser_pas = @ser_pas, address_pas = @address_pas, address_propiski = @address_propiski," +
                        " email = @email WHERE id = @id::integer";
                    CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
                    CRUD.cmd.Parameters.Clear();
                    CRUD.cmd.Parameters.AddWithValue("last_name", lastnameTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("first_name", firstnameTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("patronymic", patronymicTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("number", numberTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("num_pas", int.Parse(numpasTextBox.Text.Trim()));
                    CRUD.cmd.Parameters.AddWithValue("ser_pas", int.Parse(serpasTextBox.Text.Trim()));
                    CRUD.cmd.Parameters.AddWithValue("address_pas", adpasTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("address_propiski", adpropiskiTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("email", mailTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("id", id);
                    CRUD.PerformCRUD(CRUD.cmd);


                    MessageBox.Show("List obnovlen", "Update Data",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (this.saveclient.Text == "Insert")
                {
                    CRUD.sql = "INSERT INTO client(last_name, first_name, patronymic, number, num_pas, ser_pas, address_pas, address_propiski, email) VALUES " +
                        "(@last_name, @first_name, @patronymic, @number, @num_pas, @ser_pas, @address_pas, @address_propiski, @email)";
                    CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);



                    CRUD.cmd.Parameters.Clear();
                    CRUD.cmd.Parameters.AddWithValue("last_name", lastnameTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("first_name", firstnameTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("patronymic", patronymicTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("number", numberTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("num_pas", int.Parse(numpasTextBox.Text.Trim()));
                    CRUD.cmd.Parameters.AddWithValue("ser_pas", int.Parse(serpasTextBox.Text.Trim()));
                    CRUD.cmd.Parameters.AddWithValue("address_pas", adpasTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("address_propiski", adpropiskiTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("email", mailTextBox.Text.Trim());
                    CRUD.PerformCRUD(CRUD.cmd);


                    MessageBox.Show("Save him!!!!", "Insert Data",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (this.saveclient.Text == "Delete")
                {
                    CRUD.sql = "DELETE FROM client WHERE id = @id";
                    CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
                    CRUD.cmd.Parameters.Clear();
                    CRUD.cmd.Parameters.AddWithValue("id", id);
                    CRUD.PerformCRUD(CRUD.cmd);


                    MessageBox.Show("Delete him!!!!", "Insert Data",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Close();
            }
        }

        private void lastnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != '.' && l !=' ')
            {
                e.Handled = true;
                MessageBox.Show("Только русские буковы");
            }
            /*(System.Text.RegularExpressions.Regex.IsMatch(lastnameTextBox.Text, "[^а-яА-Я]"))
            {
                MessageBox.Show("Только русские буквы");
                lastnameTextBox.Text = lastnameTextBox.Text.Remove(lastnameTextBox.Text.Length - 1);
            }*/
        }

        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < '0' || l > '9') && l != '\b' && l != '.')
            {
                e.Handled = true;
                MessageBox.Show("Только сифры");
            }
               /* (System.Text.RegularExpressions.Regex.IsMatch(numberTextBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                numberTextBox.Text = numberTextBox.Text.Remove(numberTextBox.Text.Length - 1);
            }*/
        }

        private void adpasTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != '.' && l != ' ' && l != ',' && (l < '0' || l > '9'))
            {
                e.Handled = true;
                MessageBox.Show("Только символы русского алфавита");
            }
        }

        private void mailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'A' || l > 'z') && l != '\b' && l != '.' &&  l != '@' && (l < '0' || l > '9'))
            {
                e.Handled = true;
                MessageBox.Show("Только английские буквы");
            }
        }

        private void exitclient_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


