using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace smartcurd
{
    internal class CRUD
    {

        private static string getConnectionString()
        {
            string host = "Host=localhost;";
            string port = "Port=5432;";
            string db = "Database=avtosalon;";
            string user = "Username=admin;";
            string pass = "Password=1009;";

            string conString = string.Format("{0}{1}{2}{3}{4}", host, port, db, user, pass);

            return conString;
        }

        public static NpgsqlConnection con = new NpgsqlConnection(getConnectionString());
        public static NpgsqlCommand conCommand = default(NpgsqlCommand);
        public static string sql = string.Empty;
        internal static NpgsqlCommand cmd;

        public static DataTable PerformCRUD(NpgsqlCommand com)
        {
            NpgsqlDataAdapter da = default(NpgsqlDataAdapter);
            DataTable dt = new DataTable();

            try
            {
                da = new NpgsqlDataAdapter();
                da.SelectCommand = com;
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сервер не отвечает " + ex.Message, "Ошибка подключения",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt = null;

            }

            return dt;
        }

    }
}
