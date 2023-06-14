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

namespace smartcurd
{
    public partial class EmployeeEdit : Form
    {
        public int id;
        public EmployeeEdit()
        {
            InitializeComponent();
        }

        private void saveemplo_Click_1(object sender, EventArgs e)
        {
            if (lastnameEmploTextBox.Text.Equals("") || firstnameEmploTextBox.Text.Equals("") || patronymicEmloTextBox.Text.Equals("")
                || numpasEmploTextBox.Text.Equals("") || serpasEmploTextBox.Text.Equals("") || adpasEmploTextBox.Text.Equals("")
                || postEmplotextBox.Text.Equals(""))
            {
                MessageBox.Show("Введённые данные не подходят по формату");
            }
            else
            {
                if (this.saveemplo.Text == "Update")
                {
                    CRUD.sql = "UPDATE employee SET last_name = @last_name, first_name = @first_name, patronymic = @patronymic, num_pas = @num_pas, " +
                        "ser_pas = @ser_pas, address_pas = @address_pas, address_propiski = @address_propiski, post = @post, email = @email, " +
                        "salon_id = @salon_id WHERE id = @id::integer";
                    CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
                    CRUD.cmd.Parameters.Clear();
                    CRUD.cmd.Parameters.AddWithValue("last_name", lastnameEmploTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("first_name", firstnameEmploTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("patronymic", patronymicEmloTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("num_pas", int.Parse(numpasEmploTextBox.Text.Trim()));
                    CRUD.cmd.Parameters.AddWithValue("ser_pas", int.Parse(serpasEmploTextBox.Text.Trim()));
                    CRUD.cmd.Parameters.AddWithValue("address_pas", adpasEmploTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("address_propiski", adpropiskiEmploTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("post", postEmplotextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("email", mailEmploTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("salon_id", int.Parse(salonEmploTextBox.Text.Trim()));
                    CRUD.cmd.Parameters.AddWithValue("id", id);
                    CRUD.PerformCRUD(CRUD.cmd);


                    MessageBox.Show("List obnovlen!!!!", "Update Data",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (this.saveemplo.Text == "Insert")
                {
                    CRUD.sql = "INSERT INTO employee(last_name, first_name, patronymic, num_pas, ser_pas, address_pas, address_propiski, post, email, salon_id) VALUES " +
                        "(@last_name, @first_name, @patronymic, @num_pas, @ser_pas, @address_pas, @address_propiski, @post,  @email, @salon_id)";
                    CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
                    CRUD.cmd.Parameters.Clear();
                    CRUD.cmd.Parameters.AddWithValue("last_name", lastnameEmploTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("first_name", firstnameEmploTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("patronymic", patronymicEmloTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("num_pas", int.Parse(numpasEmploTextBox.Text.Trim()));
                    CRUD.cmd.Parameters.AddWithValue("ser_pas", int.Parse(serpasEmploTextBox.Text.Trim()));
                    CRUD.cmd.Parameters.AddWithValue("address_pas", adpasEmploTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("address_propiski", adpropiskiEmploTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("post", postEmplotextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("email", mailEmploTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("salon_id", int.Parse(salonEmploTextBox.Text.Trim()));
                    CRUD.PerformCRUD(CRUD.cmd);


                    MessageBox.Show("Save him!!!!", "Insert Data",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (this.saveemplo.Text == "Delete")
                {
                    CRUD.sql = "DELETE FROM employee WHERE id = @id";
                    CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
                    CRUD.cmd.Parameters.Clear();
                    CRUD.cmd.Parameters.AddWithValue("id", id);
                    CRUD.PerformCRUD(CRUD.cmd);


                    MessageBox.Show("Delete him!!!!", "Drop Data",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Close();
            }
        }

        private void mailEmploTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'A' || l > 'z') && l != '\b' && l != '.' && l != '@' && (l < '0' || l > '9'))
            {
                e.Handled = true;
                MessageBox.Show("Только английские буквы");
            }
        }

        private void lastnameEmploTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != '.' && l != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Только русские буквы");
            }
        }

        private void numpasEmploTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < '0' || l > '9') && l != '\b' && l != '.')
            {
                e.Handled = true;
                MessageBox.Show("Только цифры");
            }
        }

        private void adpasEmploTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != '.' && l != ' ' && l != ',' && (l < '0' || l > '9'))
            {
                e.Handled = true;
                MessageBox.Show("Только русские буквы");
            }
        }

        private void exitemplo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
