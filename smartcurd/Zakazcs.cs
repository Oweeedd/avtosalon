using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smartcurd
{
    public partial class Zakaz : Form
    {
        public Zakaz()
        {
            InitializeComponent();
        }

        private void savezakaz_Click(object sender, EventArgs e)
        {
            if (avtozakazcomboBox.Text.Equals("") || clientzakazcomboBox.Text.Equals("") || dataopenmaskedTextBox.Text.Equals(""))
            {
                MessageBox.Show("Введённые данные не корpектны");
            }
            else
            {
                if (dataclosmaskedTextBox.Text.Trim() == ",  ,")
                {
                    CRUD.sql = "INSERT INTO zakazy (avto_id, client_id, data_start, data_end) VALUES " +
                        "(@avto_id, @client_id, @data_start::date, default)";

                    CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
                    CRUD.cmd.Parameters.Clear();

                    CRUD.cmd.Parameters.AddWithValue("avto_id", int.Parse(avtozakazcomboBox.Text.Trim()));
                    CRUD.cmd.Parameters.AddWithValue("client_id", int.Parse(clientzakazcomboBox.Text.Trim()));
                    if (Regex.IsMatch(dataopenmaskedTextBox.Text, "^(0[1-9]|1[012]),(0[1-9]|[12][0-9]|3[01]),(19|20)\\d\\d$")) { 
                        CRUD.cmd.Parameters.AddWithValue("data_start", dataopenmaskedTextBox.Text.Trim());
                        CRUD.PerformCRUD(CRUD.cmd);
                        
            MessageBox.Show("Save him!!!!", "Insert Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                    }
                    else MessageBox.Show("Введите дату формата: <ММ.ДД.ГГГГ>");
                }

                else
                {

                    CRUD.sql = "INSERT INTO zakazy (avto_id, client_id, data_start, data_end) VALUES " +
                            "(@avto_id, @client_id, @data_start::date, @data_end::date)";
                    CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
                    CRUD.cmd.Parameters.Clear();

                    CRUD.cmd.Parameters.AddWithValue("avto_id", int.Parse(avtozakazcomboBox.Text.Trim()));
                    CRUD.cmd.Parameters.AddWithValue("client_id", int.Parse(clientzakazcomboBox.Text.Trim()));
                    if (Regex.IsMatch(dataopenmaskedTextBox.Text, "^(0[1-9]|1[012]),(0[1-9]|[12][0-9]|3[01]),(19|20)\\d\\d$") &&
                        Regex.IsMatch(dataclosmaskedTextBox.Text, "^(0[1-9]|1[012]),(0[1-9]|[12][0-9]|3[01]),(19|20)\\d\\d$"))
                    {
                        CRUD.cmd.Parameters.AddWithValue("data_start", dataopenmaskedTextBox.Text.Trim());
                        CRUD.cmd.Parameters.AddWithValue("data_end", dataclosmaskedTextBox.Text.Trim());
                        CRUD.PerformCRUD(CRUD.cmd);
                        this.Close();
                    }
                    else MessageBox.Show("Введите дату формата: <ММ.ДД.ГГГГ>");
                }
                

                
            }
        }
        private void exitzakaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientEdit addClient = new ClientEdit();
            addClient.saveclient.Text = "Insert";
            addClient.ShowDialog();

            CRUD.sql = "SELECT id FROM client";

            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();

            DataTable client = CRUD.PerformCRUD(CRUD.cmd);

            List<Object> idClient = new List<Object>();
            foreach (DataRow row in client.Rows)
            {
                object id = row.ItemArray[0];
                idClient.Add(id);
            }

            this.clientzakazcomboBox.Items.Clear();
            this.clientzakazcomboBox.Items.AddRange(idClient.ToArray());
        }

        private void avtozakazcomboBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

    }
}
