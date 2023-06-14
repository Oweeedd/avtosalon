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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            String loginuser = loginTextBox.Text;
            String passuser = passTextBox.Text;

            CRUD.sql = "SELECT * FROM DataUser WHERE login = @ul AND pass = @up";

            CRUD.cmd = new NpgsqlCommand(CRUD.sql, CRUD.con);
            CRUD.cmd.Parameters.Clear();
            CRUD.cmd.Parameters.AddWithValue("ul", loginuser);
            CRUD.cmd.Parameters.AddWithValue("up", passuser);
            
            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);
            if (dt is null) 
            {
                
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Подключение успешно. Авторизация выполнена");
                    Form1 main = new Form1();
                    this.Opacity = 0;
                    main.ShowDialog();
                    this.Opacity = 1;
                }
                else
                {
                    MessageBox.Show("В доступе отказано");
                }
            }
        }
    }
}
