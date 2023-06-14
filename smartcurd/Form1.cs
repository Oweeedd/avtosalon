using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Npgsql;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace smartcurd
{
    public partial class Form1 : Form
    {

        private string id = "";
        private int intRow = 0;
        public Form1()
        {
            InitializeComponent();
            resetMe();
        }

        private void resetMe()
        {
            this.id = string.Empty;

            firstnametextBox.Text = string.Empty;
            lastnametextBox.Text = string.Empty;

            if (gendercomboBox.Items.Count > 0)
            {
                gendercomboBox.SelectedIndex = 0;
            }

            keywordtextBox.Clear();

            if (keywordtextBox.CanSelect)
            {
                keywordtextBox.Select();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData("");

        }

        private void loadData(string keyword)
        {
            CRUD.sql = "SELECT autoid, firstname, lastname, CONCAT(firstname, ' ', lastname) AS fullname, gender FROM tb_smart_crud " +
                "WHERE CONCAT(CAST(autoid as varchar), ' ', firstname, ' ', lastname) LIKE @keyword::varchar " +
                "OR TRIM(gender) LIKE @keyword::varchar ORDER BY autoid ASC" ;

            string strKeyword = String.Format("%{0}%", keyword);

            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("keyword", strKeyword);

            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);

            if (dt.Rows.Count > 0)
            {
                intRow = Convert.ToInt32(dt.Rows.Count.ToString());
            }
            else
            {
                intRow = 0;
            }

            toolStripStatusLabel1.Text = "Number of rows" + intRow.ToString();

            DataGridView dgv1 = dataGridView1;

            dgv1.MultiSelect = false;
            dgv1.AutoGenerateColumns = true;
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv1.DataSource = dt;

            dgv1.Columns[0].HeaderText = "ID";
            dgv1.Columns[1].HeaderText = "First name";
            dgv1.Columns[2].HeaderText = "Last name";
            dgv1.Columns[3].HeaderText = "Full name";
            dgv1.Columns[4].HeaderText = "Gender";

            dgv1.Columns[0].Width = 85;
            dgv1.Columns[1].Width = 180;
            dgv1.Columns[2].Width = 180;
            dgv1.Columns[3].Width = 280;
            dgv1.Columns[4].Width = 60;

        }

        private void execute(string mySQL, String param)
        {
            CRUD.cmd = new NpgsqlCommand(mySQL, CRUD.con);
            addParameters(param);
            CRUD.PerformCRUD(CRUD.cmd);
        }

        private void addParameters(string str)
        {
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("firstName", firstnametextBox.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("lastName", lastnametextBox.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("gender", gendercomboBox.SelectedItem.ToString());

            if(str == "Update" || str == "Delete" && !string.IsNullOrEmpty(this.id))
            {
                CRUD.cmd.Parameters.AddWithValue("id", this.id);
            }
        }

        private void insertbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstnametextBox.Text.Trim()) || string.IsNullOrEmpty(lastnametextBox.Text.Trim()))
            {

                MessageBox.Show("Wwedite name and familiyou", "Insert Data", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CRUD.sql = "INSERT INTO tb_smart_crud(firstname, lastname, gender) VALUES(@firstName, @lastName, @gender)";

            execute(CRUD.sql, "Insert");

            MessageBox.Show("Save him!!!!", "Insert Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            loadData("");

            resetMe();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridView dgv1 = dataGridView1;

                this.id = Convert.ToString(dgv1.CurrentRow.Cells[0].Value);
                updatebutton.Text = "Update (" + this.id + ")";
                deletebutton.Text = "Delete (" + this.id + ")";

                firstnametextBox.Text = Convert.ToString(dgv1.CurrentRow.Cells[1].Value);
                lastnametextBox.Text = Convert.ToString(dgv1.CurrentRow.Cells[2].Value);

                gendercomboBox.SelectedItem = Convert.ToString(dgv1.CurrentRow.Cells[4].Value);
            }

        }

        private void updatebutton_Click(object sender, EventArgs e) //update
        {
            if (dataGridView1.Rows.Count == 0)
            {
                Console.WriteLine('1');
                return;
            }

            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("List obnovlen", "Update Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Console.WriteLine('2');

                return;
            }

            if (string.IsNullOrEmpty(firstnametextBox.Text.Trim()) || string.IsNullOrEmpty(lastnametextBox.Text.Trim()))
            {
                Console.WriteLine('3');

                MessageBox.Show("Wwedite name and familiyou", "Insert Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CRUD.sql = "UPDATE tb_smart_crud SET firstname = @firstName, lastname = @lastName, gender = @gender WHERE autoid = @id::integer";

            execute(CRUD.sql, "Update");

            MessageBox.Show("UPDATE him!!!!", "Update Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            loadData("");
            Console.WriteLine('4');

            resetMe();
        }

        private void deletebutton_Click(object sender, EventArgs e) //delete
        {
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.id))
            {
                MessageBox.Show("List clear", "Delete Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Uveren?", "Delete Data",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                CRUD.sql = "DELETE FROM tb_smart_crud WHERE autoid = @id::integer";

                execute(CRUD.sql, "Update");

                MessageBox.Show("Delete him!!!!", "Delete Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                loadData("");

                resetMe();

            }

            
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(keywordtextBox.Text.Trim()))
            {
                loadData("");
            }
            else
            {
                loadData(keywordtextBox.Text.Trim());
            }
            
            resetMe();
            //int rowIndex = dataGridView1.CurrentRow.Index;
            //this.firstnametextBox.Text = rowIndex.ToString();
        }


        private void loadavto()
        {
            CRUD.sql = "select avto.id, harackter.znach_harackter, avto.price, avto.nalichie, avto.salon_id FROM avto LEFT JOIN harackter ON avto.id = harackter.avto;";

            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();

            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);
            DataTable auto = new DataTable("auto");
            auto.Columns.Add(new DataColumn("Id", Type.GetType("System.Int32")));
            auto.Columns.Add(new DataColumn("Марка", Type.GetType("System.String")));
            auto.Columns.Add(new DataColumn("Модель", Type.GetType("System.String")));
            auto.Columns.Add(new DataColumn("Кпп", Type.GetType("System.String")));
            auto.Columns.Add(new DataColumn("Мощность", Type.GetType("System.String")));
            auto.Columns.Add(new DataColumn("Цвет", Type.GetType("System.String")));
            auto.Columns.Add(new DataColumn("Вес", Type.GetType("System.String")));
            auto.Columns.Add(new DataColumn("Разгон", Type.GetType("System.String")));
            auto.Columns.Add(new DataColumn("Объём бака", Type.GetType("System.String")));
            auto.Columns.Add(new DataColumn("Расход", Type.GetType("System.String")));
            auto.Columns.Add(new DataColumn("Год", Type.GetType("System.String")));
            auto.Columns.Add(new DataColumn("Стоимость", Type.GetType("System.String")));
            auto.Columns.Add(new DataColumn("Наличие", Type.GetType("System.String")));
            auto.Columns.Add(new DataColumn("Номер салона", Type.GetType("System.String")));

            int index = 1;
            List<Object> lst = new List<Object>();
            foreach (DataRow row in dt.Rows)
            {
                var cells = row.ItemArray;
                
                if (index == 11)
                {
                    DataRow newrow = auto.NewRow();
                    newrow.ItemArray = lst.ToArray();
                    auto.Rows.Add(newrow);
                    lst = new List<Object>();
                    index = 1;
                    
                }
                
                if (index == 1)
                {
                    lst.Add(cells[0]);
                }
                lst.Add(cells[1]);
                if (index == 10)
                {
                    lst.Add(cells[2]);
                    lst.Add(cells[3]);
                    lst.Add(cells[4]);
                }
                index++;
            }

            DataRow roww = auto.NewRow();
            roww.ItemArray = lst.ToArray();
            auto.Rows.Add(roww);

            if (dt.Rows.Count > 0)
            {
                intRow = Convert.ToInt32(dt.Rows.Count.ToString());
            }
            else
            {
                intRow = 0;
            }



            //toolStripStatusLabel1.Text = "Number of rows" + intRow.ToString();

            DataGridView dgv2 = dataGridViewAvto;

            dgv2.MultiSelect = false;
            dgv2.AutoGenerateColumns = true;
            dgv2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv2.DataSource = auto;

            dgv2.Columns[0].HeaderText = "ID";
            dgv2.Columns[1].HeaderText = "Марка";
            dgv2.Columns[2].HeaderText = "Модель";
            dgv2.Columns[3].HeaderText = "Кпп";
            dgv2.Columns[4].HeaderText = "Мощность";
            dgv2.Columns[5].HeaderText = "Цвет";
            dgv2.Columns[6].HeaderText = "Вес";
            dgv2.Columns[7].HeaderText = "Разгон";
            dgv2.Columns[8].HeaderText = "Объём бака";
            dgv2.Columns[9].HeaderText = "Расход";
            dgv2.Columns[10].HeaderText = "Год";
            dgv2.Columns[11].HeaderText = "Стоимость";
            dgv2.Columns[12].HeaderText = "Наличие";
            dgv2.Columns[13].HeaderText = "Номер салона";



            dgv2.Columns[0].Width = 20;
            dgv2.Columns[1].Width = 100;
            dgv2.Columns[2].Width = 50;
            dgv2.Columns[3].Width = 50;
            dgv2.Columns[4].Width = 50;
            dgv2.Columns[5].Width = 70;
            dgv2.Columns[6].Width = 50;
            dgv2.Columns[7].Width = 50;
            dgv2.Columns[8].Width = 50;
            dgv2.Columns[9].Width = 50;
            dgv2.Columns[10].Width = 50;
            dgv2.Columns[11].Width = 80;
            dgv2.Columns[12].Width = 55;
            dgv2.Columns[13].Width = 100;

        }


        public void addParametersAvto(string str)
        {
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("Марка", firstnametextBox.Text);
            CRUD.cmd.Parameters.AddWithValue("Модель", lastnametextBox.Text);
            CRUD.cmd.Parameters.AddWithValue("Кпп", lastnametextBox.Text);
            CRUD.cmd.Parameters.AddWithValue("Мощность", lastnametextBox.Text);
            CRUD.cmd.Parameters.AddWithValue("Цвет", lastnametextBox.Text);
            CRUD.cmd.Parameters.AddWithValue("Вес", lastnametextBox.Text);
            CRUD.cmd.Parameters.AddWithValue("Разгон", lastnametextBox.Text);
            CRUD.cmd.Parameters.AddWithValue("Объём_бака", lastnametextBox.Text);
            CRUD.cmd.Parameters.AddWithValue("Расход", lastnametextBox.Text);
            CRUD.cmd.Parameters.AddWithValue("Год", lastnametextBox.Text);

            if (str == "Update" || str == "Delete" && !string.IsNullOrEmpty(this.id))
            {
                CRUD.cmd.Parameters.AddWithValue("id", this.id);
            }
        }

        private void serchavto_Click(object sender, EventArgs e)
        {
            loadavto();
        }

        private void insertavto_Click(object sender, EventArgs e)
        {
           AvtoEdit editavto = new AvtoEdit();
           editavto.saveavto.Text = "Insert";
            editavto.Show();
        }

        private void updateavto_Click(object sender, EventArgs e)
        {
            AvtoEdit editavto = new AvtoEdit();
            editavto.saveavto.Text = "Update";
            editavto.id = (int)dataGridViewAvto.CurrentRow.Cells[0].Value;
            editavto.markTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[1].Value);
            editavto.modelTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[2].Value);
            editavto.kppTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[3].Value);
            editavto.powerTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[4].Value);
            editavto.colorTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[5].Value);
            editavto.weightTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[6].Value);
            editavto.rzTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[7].Value);
            editavto.vTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[8].Value);
            editavto.rashTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[9].Value);
            editavto.yearTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[10].Value);
            editavto.priceTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[11].Value);
            editavto.nalichieTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[12].Value);
            editavto.idSalonTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[13].Value);
            editavto.Show();
        }

        private void deleteavto_Click(object sender, EventArgs e)
        {
            AvtoEdit editavto = new AvtoEdit();
            editavto.saveavto.Text = "Delete";
            editavto.id = (int)dataGridViewAvto.CurrentRow.Cells[0].Value;
            editavto.markTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[1].Value);
            editavto.modelTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[2].Value);
            editavto.kppTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[3].Value);
            editavto.powerTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[4].Value);
            editavto.colorTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[5].Value);
            editavto.weightTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[6].Value);
            editavto.rzTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[7].Value);
            editavto.vTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[8].Value);
            editavto.rashTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[9].Value);
            editavto.yearTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[10].Value);
            editavto.priceTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[11].Value);
            editavto.nalichieTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[12].Value);
            editavto.idSalonTextBox.Text = Convert.ToString(dataGridViewAvto.CurrentRow.Cells[13].Value);
            editavto.Show();
        }

        private void serchbuttonclient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxserchclient.Text.Trim()))
            {
                loadClient("");
            }
            else
            {
                loadClient(textBoxserchclient.Text.Trim());
            }
        }

        private void loadClient(string keyword)
        {
            CRUD.sql = "SELECT * FROM client " +
                "WHERE CONCAT(CAST(id as varchar), ' ', first_name, ' ', last_name, ' ', patronymic, ' ', number, ' ', CAST(num_pas AS varchar)," +
                " ' ', CAST(ser_pas AS varchar), ' ', address_pas, ' ', address_propiski, ' ', email) LIKE @keyword::varchar " +
                "ORDER BY id ASC";

            string strKeyword = String.Format("%{0}%", keyword);

            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("keyword", strKeyword);

            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);
            
            if (dt.Rows.Count > 0)
            {
                intRow = Convert.ToInt32(dt.Rows.Count.ToString());
            }
            else
            {
                intRow = 0;
            }

            //toolStripStatusLabel1.Text = "Number of rows" + intRow.ToString();

            DataGridView dgv3 = dataGridViewClient;

            dgv3.MultiSelect = false;
            dgv3.AutoGenerateColumns = true;
            dgv3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            dgv3.DataSource = dt;

            dgv3.Columns[0].HeaderText = "ID";
            dgv3.Columns[1].HeaderText = "Фамилия";
            dgv3.Columns[2].HeaderText = "Имя";
            dgv3.Columns[3].HeaderText = "Отчество";
            dgv3.Columns[4].HeaderText = "Номер телефона";
            dgv3.Columns[5].HeaderText = "Номер паспорта";
            dgv3.Columns[6].HeaderText = "Серия паспорта";
            dgv3.Columns[7].HeaderText = "Адрес выдачи";
            dgv3.Columns[8].HeaderText = "Адрес прописки";
            dgv3.Columns[9].HeaderText = "Почта";



            dgv3.Columns[0].Width = 20;
            dgv3.Columns[1].Width = 80;
            dgv3.Columns[2].Width = 80;
            dgv3.Columns[3].Width = 80;
            dgv3.Columns[4].Width = 90;
            dgv3.Columns[5].Width = 55;
            dgv3.Columns[6].Width = 55;
            dgv3.Columns[7].Width = 100;
            dgv3.Columns[8].Width = 150;
            dgv3.Columns[9].Width = 110;

        }

        private void insertbuttonclient_Click(object sender, EventArgs e)
        {
            ClientEdit clientEdit = new ClientEdit();
            clientEdit.saveclient.Text = "Insert";
            clientEdit.Show();
        }

        private void updatebuttonclient_Click(object sender, EventArgs e)
        {
            ClientEdit clientEdit = new ClientEdit();
            clientEdit.saveclient.Text = "Update";
            clientEdit.id = (int)dataGridViewClient.CurrentRow.Cells[0].Value;
            clientEdit.lastnameTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[1].Value);
            clientEdit.firstnameTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[2].Value);
            clientEdit.patronymicTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[3].Value);
            clientEdit.numberTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[4].Value);
            clientEdit.numpasTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[5].Value);
            clientEdit.serpasTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[6].Value);
            clientEdit.adpasTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[7].Value);
            clientEdit.adpropiskiTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[8].Value);
            clientEdit.mailTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[9].Value);
            clientEdit.Show();
        }

        private void deletebuttonclient_Click(object sender, EventArgs e)
        {
            ClientEdit clientEdit = new ClientEdit();
            clientEdit.saveclient.Text = "Delete";
            clientEdit.id = (int)dataGridViewClient.CurrentRow.Cells[0].Value;
            clientEdit.lastnameTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[1].Value);
            clientEdit.firstnameTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[2].Value);
            clientEdit.patronymicTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[3].Value);
            clientEdit.numberTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[4].Value);
            clientEdit.numpasTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[5].Value);
            clientEdit.serpasTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[6].Value);
            clientEdit.adpasTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[7].Value);
            clientEdit.adpropiskiTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[8].Value);
            clientEdit.mailTextBox.Text = Convert.ToString(dataGridViewClient.CurrentRow.Cells[9].Value);
            clientEdit.Show();
        }



       

        private void serchbuttonemplo_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxserchemplo.Text.Trim()))
            {
                loadEmployee("");
            }
            else
            {
                loadEmployee(textBoxserchemplo.Text.Trim());
            }
        }

        private void loadEmployee(string keyword)
        {
            CRUD.sql = "SELECT * FROM employee " +
                "WHERE CONCAT(CAST(id as varchar), ' ', first_name, ' ', last_name, ' ', patronymic, ' ', CAST(num_pas AS varchar)," +
                " ' ', CAST(ser_pas AS varchar), ' ', address_pas, ' ', address_propiski, ' ', post, ' ',email, ' ', salon_id) LIKE @keyword::varchar " +
                "ORDER BY id ASC";

            string strKeyword = String.Format("%{0}%", keyword);

            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("keyword", strKeyword);

            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);

            if (dt.Rows.Count > 0)
            {
                intRow = Convert.ToInt32(dt.Rows.Count.ToString());
            }
            else
            {
                intRow = 0;
            }

            //toolStripStatusLabel1.Text = "Number of rows" + intRow.ToString();

            DataGridView dgv4 = dataGridViewEmplo;

            dgv4.MultiSelect = false;
            dgv4.AutoGenerateColumns = true;
            dgv4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv4.DataSource = dt;

            dgv4.Columns[0].HeaderText = "ID";
            dgv4.Columns[1].HeaderText = "Фамилия";
            dgv4.Columns[2].HeaderText = "Имя";
            dgv4.Columns[3].HeaderText = "Отчество";
            dgv4.Columns[4].HeaderText = "Номер паспорта";
            dgv4.Columns[5].HeaderText = "Серия паспорта";
            dgv4.Columns[6].HeaderText = "Адрес выдачи";
            dgv4.Columns[7].HeaderText = "Адрес прописки";
            dgv4.Columns[8].HeaderText = "Должность";
            dgv4.Columns[9].HeaderText = "Почта";
            dgv4.Columns[10].HeaderText = "Салон";



            dgv4.Columns[0].Width = 20;
            dgv4.Columns[1].Width = 80;
            dgv4.Columns[2].Width = 80;
            dgv4.Columns[3].Width = 80;
            dgv4.Columns[4].Width = 90;
            dgv4.Columns[5].Width = 55;
            dgv4.Columns[6].Width = 55;
            dgv4.Columns[7].Width = 100;
            dgv4.Columns[8].Width = 150;
            dgv4.Columns[9].Width = 100;
            dgv4.Columns[10].Width = 20;
        }


        private void insertbuttonemplo_Click(object sender, EventArgs e)
        {
            EmployeeEdit employeeEdit = new EmployeeEdit();
            employeeEdit.saveemplo.Text = "Insert";
            employeeEdit.Show();
        }

        private void updatebuttonemplo_Click_1(object sender, EventArgs e)
        {
            EmployeeEdit employeeEdit = new EmployeeEdit();
            employeeEdit.saveemplo.Text = "Update";
            employeeEdit.id = (int)(dataGridViewEmplo.CurrentRow.Cells[0].Value);
            employeeEdit.lastnameEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[1].Value);
            employeeEdit.firstnameEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[2].Value);
            employeeEdit.patronymicEmloTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[3].Value);
            employeeEdit.numpasEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[4].Value);
            employeeEdit.serpasEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[5].Value);
            employeeEdit.adpasEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[6].Value);
            employeeEdit.adpropiskiEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[7].Value);
            employeeEdit.postEmplotextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[8].Value);
            employeeEdit.mailEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[9].Value);
            employeeEdit.salonEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[10].Value);
            employeeEdit.Show();
        }

        private void deletebuttonemplo_Click_1(object sender, EventArgs e)
        {
            EmployeeEdit employeeEdit = new EmployeeEdit();
            employeeEdit.saveemplo.Text = "Delete";
            employeeEdit.id = (int)(dataGridViewEmplo.CurrentRow.Cells[0].Value);
            employeeEdit.lastnameEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[1].Value);
            employeeEdit.firstnameEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[2].Value);
            employeeEdit.patronymicEmloTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[3].Value);
            employeeEdit.numpasEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[4].Value);
            employeeEdit.serpasEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[5].Value);
            employeeEdit.adpasEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[6].Value);
            employeeEdit.adpropiskiEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[7].Value);
            employeeEdit.postEmplotextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[8].Value);
            employeeEdit.mailEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[9].Value);
            employeeEdit.salonEmploTextBox.Text = Convert.ToString(dataGridViewEmplo.CurrentRow.Cells[10].Value);
            employeeEdit.Show();
        }

        private void serchzakazbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(serchzakaztextBox.Text.Trim()))
            {
                loadZakazy("");
            }
            else
            {
                loadZakazy(serchzakaztextBox.Text.Trim());
            }
        }

        public void loadZakazy(string keyword)
        {
            CRUD.sql = "SELECT * FROM zakazy " +
                "WHERE CONCAT(CAST(id as varchar), ' ', avto_id, ' ', client_id, ' ', data_start, ' ', data_end)" +
                " LIKE @keyword::varchar ORDER BY id ASC";

            string strKeyword = String.Format("%{0}%", keyword);

            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("keyword", strKeyword);

            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);

            if (dt.Rows.Count > 0)
            {
                intRow = Convert.ToInt32(dt.Rows.Count.ToString());
            }
            else
            {
                intRow = 0;
            }

            //toolStripStatusLabel1.Text = "Number of rows" + intRow.ToString();

            DataGridView dgv5 = dataGridViewZakaz;

            dgv5.MultiSelect = false;
            dgv5.AutoGenerateColumns = true;
            dgv5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv5.DataSource = dt;

            dgv5.Columns[0].HeaderText = "ID";
            dgv5.Columns[1].HeaderText = "Авто";
            dgv5.Columns[2].HeaderText = "Клиент";
            dgv5.Columns[3].HeaderText = "Дата открытия";
            dgv5.Columns[4].HeaderText = "Дата закрытия";


            dgv5.Columns[0].Width = 20;
            dgv5.Columns[1].Width = 200;
            dgv5.Columns[2].Width = 200;
            dgv5.Columns[3].Width = 200;
            dgv5.Columns[4].Width = 200;

        }

        private void insertzakazbutton_Click(object sender, EventArgs e)
        {
            Zakaz zakaz = new Zakaz();
            zakaz.savezakaz.Text = "Insert";
            CRUD.sql = "SELECT id FROM avto";

            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();

            DataTable auto = CRUD.PerformCRUD(CRUD.cmd);

            List<Object> idAvto = new List<Object>();  
            foreach (DataRow row in auto.Rows)
            {
                object id = row.ItemArray[0];
                idAvto.Add(id);
            }

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
            zakaz.avtozakazcomboBox.Items.AddRange(idAvto.ToArray());
            zakaz.clientzakazcomboBox.Items.AddRange(idClient.ToArray());
            zakaz.Show();
        }

        private void updatezakazbutton_Click(object sender, EventArgs e)
        {
            CRUD.sql = "update zakazy set data_end=current_date WHERE id = @id::integer";
            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("id", dataGridViewZakaz.CurrentRow.Cells[0].Value.ToString().Trim());
            CRUD.PerformCRUD(CRUD.cmd);
        }

        private void deletezakazbutton_Click(object sender, EventArgs e)
        {
            CRUD.sql = "delete from zakazy WHERE id = @id::integer";
            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("id", dataGridViewZakaz.CurrentRow.Cells[0].Value.ToString().Trim());
            if (MessageBox.Show("Uveren?", "Delete Data",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                CRUD.PerformCRUD(CRUD.cmd);
            }
            
        }
    }
}
