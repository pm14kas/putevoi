using System;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;


namespace putevoi
{
    public partial class Form1 : Form
    {
        private SQLiteConnection conn;
        public Form1()
        {
            InitializeComponent();
            System.IO.Directory.CreateDirectory("db");
            conn = new SQLiteConnection("Data Source='db/database.db'; Version=3;");
            try
            {
                conn.Open();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (conn.State == ConnectionState.Open)
            {
                SQLiteCommand createTable = new SQLiteCommand("CREATE TABLE IF NOT EXISTS `workers` ("
                +" id INTEGER PRIMARY KEY AUTOINCREMENT, "
                  + "first_name TEXT, "
                  + "last_name TEXT, "
                  + "sex INTEGER, "
                  + "birth_date INTEGER);"
                  + "INSERT INTO workers(first_name, last_name, sex, birth_date) "
                  + "VALUES ('John', 'Doe', 0, strftime('%s', '1979-12-10'));"
                  + "INSERT INTO workers(first_name, last_name, sex, birth_date) "
                  + "VALUES ('Vanessa', 'Maison', 1, strftime('%s', '1977-12-10'));"
                  + "INSERT INTO workers(first_name, last_name, sex, birth_date) "
                  + "VALUES ('Ivan', 'Vasiliev', 0, strftime('%s', '1987-01-06'));"
                  + "INSERT INTO workers(first_name, last_name, sex, birth_date) "
                  + "VALUES ('Kevin', 'Drago', 0, strftime('%s', '1991-06-11'));"
                  + "INSERT INTO workers(first_name, last_name, sex, birth_date) "
                  + "VALUES ('Angel', 'Vasco', 1, strftime('%s', '1987-10-09'));",
                conn );
                try
                {
                    createTable.ExecuteNonQuery();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        ~Form1()
        {
            conn.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;

            ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);

            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];

            ObjWorkSheet.Range["A1", "Z1"].Merge();
            ObjWorkSheet.Cells[1, 1] = "Выборка из бд";

            int cell = 5;
            if (conn.State == ConnectionState.Open)
            {
                SQLiteCommand commandSelectAll = new SQLiteCommand("SELECT * FROM `workers`", conn);
                try
                {
                    SQLiteDataReader r = commandSelectAll.ExecuteReader();
                    string line = String.Empty;
                    while (r.Read())
                    {
                        ObjWorkSheet.Cells[cell,1] = r["id"].ToString();
                        ObjWorkSheet.Cells[cell,2] = r["first_name"].ToString();
                        ObjWorkSheet.Cells[cell,3] = r["last_name"].ToString();
                        ObjWorkSheet.Cells[cell,4] = r["sex"].ToString();
                        ObjWorkSheet.Cells[cell,5] = r["birth_date"].ToString();
                        ObjWorkSheet.Cells[cell,6] = r["id"].ToString();

                        cell++;
                    }
                    r.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
