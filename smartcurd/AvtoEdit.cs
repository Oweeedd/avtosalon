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

namespace smartcurd
{
    public partial class AvtoEdit : Form
    {
        public int id;
        public AvtoEdit()
        {
            InitializeComponent();
        }

        private void saveavto_Click(object sender, EventArgs e)
        {
            if (this.saveavto.Text == "Delete")
            {
                CRUD.sql = "DELETE FROM avto WHERE id = @id";
                CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
                CRUD.cmd.Parameters.Clear();
                CRUD.cmd.Parameters.AddWithValue("id", id);
                CRUD.PerformCRUD(CRUD.cmd);
                this.Close();
            }
            else if (idSalonTextBox.Text.Equals("") || !int.TryParse(nalichieTextBox.Text, out _) || markTextBox.Text.Equals("")
                || modelTextBox.Text.Equals("") || kppTextBox.Text.Equals("") || powerTextBox.Text.Equals("") || colorTextBox.Text.Equals("")
                || weightTextBox.Text.Equals("") || rzTextBox.Text.Equals("") || vTextBox.Text.Equals("") || rashTextBox.Text.Equals("")
                || yearTextBox.Text.Equals(""))
            {
                MessageBox.Show("Введённые данные не подходят по формату");
            }
            else
            {
                TextBox[] boxs = {markTextBox, modelTextBox, kppTextBox, powerTextBox, colorTextBox, weightTextBox, rzTextBox, vTextBox,
                rashTextBox, yearTextBox};
                if (this.saveavto.Text == "Update")
                {
                    CRUD.sql = "UPDATE avto SET price = @price, nalichie = @nalichie WHERE id = @id::integer";
                    CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
                    CRUD.cmd.Parameters.Clear();
                    CRUD.cmd.Parameters.AddWithValue("price", priceTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("nalichie", int.Parse(nalichieTextBox.Text.Trim()));
                    CRUD.cmd.Parameters.AddWithValue("id", id);
                    CRUD.PerformCRUD(CRUD.cmd);

                    for (int i = 0; i < boxs.Length; i++)
                    {
                        CRUD.sql = "UPDATE harackter SET znach_harackter = @znach_harackter WHERE id = @id::integer and avto = @idavto";
                        CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
                        CRUD.cmd.Parameters.Clear();
                        CRUD.cmd.Parameters.AddWithValue("znach_harackter", boxs[i].Text.Trim());
                        CRUD.cmd.Parameters.AddWithValue("id", i + 1);
                        CRUD.cmd.Parameters.AddWithValue("idavto", id);
                        CRUD.PerformCRUD(CRUD.cmd);
                    }
                }
                else if (this.saveavto.Text == "Insert")
                {
                    CRUD.sql = "INSERT INTO avto(price, nalichie, salon_id) VALUES (@price, @nalichie, @salon_id)";
                    CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
                    CRUD.cmd.Parameters.Clear();
                    CRUD.cmd.Parameters.AddWithValue("price", priceTextBox.Text.Trim());
                    CRUD.cmd.Parameters.AddWithValue("nalichie", int.Parse(nalichieTextBox.Text.Trim()));
                    CRUD.cmd.Parameters.AddWithValue("salon_id", int.Parse(idSalonTextBox.Text.Trim()));
                    CRUD.PerformCRUD(CRUD.cmd);

                    CRUD.sql = "select id FROM avto";

                    CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
                    CRUD.cmd.Parameters.Clear();

                    DataTable dt = CRUD.PerformCRUD(CRUD.cmd);

                    id = dt.AsEnumerable().Max(r => r.Field<int>("Id"));

                    for (int i = 0; i < boxs.Length; i++)
                    {
                        CRUD.sql = "INSERT INTO harackter(id, znach_harackter, avto) VALUES (@id, @znach_harackter, @idavto)";
                        CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
                        CRUD.cmd.Parameters.Clear();
                        CRUD.cmd.Parameters.AddWithValue("znach_harackter", boxs[i].Text.Trim());
                        CRUD.cmd.Parameters.AddWithValue("id", i + 1);
                        CRUD.cmd.Parameters.AddWithValue("idavto", id);
                        CRUD.PerformCRUD(CRUD.cmd);
                    }
                    
                }
                this.Close();
            }

        }

        private void exitavto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void powerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < '0' || l > '9') && l != '\b' && l != '.')
            {
                e.Handled = true;
                MessageBox.Show("Только цифры ");
            }
        }

        private void markTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && (l < 'A' || l > 'z') && l != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Только буковы русского алфавита");
            }
        }

        private void modelTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && (l < 'A' || l > 'z') && l != '\b' && (l < '0' || l > '9'))
            {
                e.Handled = true;
                MessageBox.Show("Только буковы");
            }
        }
    }
}
