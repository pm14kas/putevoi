using System;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Runtime.InteropServices;
using System.Collections.Generic;


namespace putevoi
{
    public partial class MainForm : Form
    {
        private SQLiteConnection conn;

        private Word.Application wordApp;
        private Word.Document templatePutevoi;

        private Excel.Application excelApp; 

        private const double version_major = 0;
        private const double version_minor = 0.1;

        public MainForm()
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
            this.Text = this.Text + " v" + version_major.ToString() + "." + version_minor.ToString().Replace(',','.');
            try
            {
                wordApp = new Word.Application();
                excelApp = new Excel.Application();
            }
            catch {
                MessageBox.Show("На компьютере не установлен Microsoft Office");
                Application.Exit();
            }
            fillComboBox();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                templatePutevoi = wordApp.Documents.Open(Application.StartupPath + "/templates/templatePutevoi.docx");
                Word.Document putevoi = new Word.Document();
                templatePutevoi.ActiveWindow.Selection.WholeStory();
                templatePutevoi.ActiveWindow.Selection.Copy();
                putevoi.ActiveWindow.Selection.PasteAndFormat(Word.WdRecoveryType.wdFormatOriginalFormatting);
                ((Word._Document)templatePutevoi).Close();

                string pattern = "[{]{2}*[}]{2}";

                Word.Range rng = putevoi.Range();
                rng.Find.ClearFormatting();



                while (rng.Find.Execute(FindText: pattern, MatchWildcards: true))
                {
                   if (rng.Text=="{{driver_name}}")
                   {
                       if (conn.State == ConnectionState.Open)
                       {
                           SQLiteCommand commandSelectAll = new SQLiteCommand("SELECT id, first_name, last_name FROM workers WHERE id = "
                               + comboSelectDriver.SelectedValue, conn);
                           try
                           {
                               SQLiteDataReader r = commandSelectAll.ExecuteReader();
                               while (r.Read())
                               {
                                   rng.Text = r["last_name"].ToString() + " " + r["first_name"].ToString().Substring(0, 1) + ".";
                               }
                               r.Close();
                           }
                           catch (SQLiteException ex)
                           {
                               Console.WriteLine(ex.Message);
                           }
                       }
                   }
                   else if (rng.Text == "{{car_name}}")
                   {
                       rng.Text = "car name by default";
                   }
                   else
                   {
                       rng.Text = "";
                   }
                   rng = putevoi.Range();
                   rng.Find.ClearFormatting();
                } 

                wordApp.Visible = true;

                if (MessageBox.Show("Сохранить в базе данных?", "Подтверждение", MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    MessageBox.Show("Сохранено");
                    try
                    {
                        putevoi.Activate();
                        ((Word._Document)putevoi).Close();
                    }
                    catch { }

                    try
                    {
                        wordApp.Visible = false;
                    }
                    catch
                    {
                        wordApp = new Word.Application();
                    }
                }
                else
                {
                    try
                    {
                        putevoi.Activate();
                        ((Word._Document)putevoi).Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                    }
                    catch { }

                    try
                    {
                        wordApp.Visible = false;
                    }
                    catch
                    {
                        wordApp = new Word.Application();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка открытия шаблона templatePutevoi.docx");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DICKS");
            conn.Dispose();
            try
            {
                ((Word._Application)wordApp).Quit();
            }
            catch { }
            try
            {
                ((Excel._Application)excelApp).Quit();
            }
            catch { }

            Marshal.ReleaseComObject((Word._Application)wordApp);
            Marshal.ReleaseComObject(excelApp);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillComboBox();
        }

        private void fillComboBox()
        {
            List<ComboItem> itemlist = new List<ComboItem>();
            if (conn.State == ConnectionState.Open)
            {
                SQLiteCommand commandSelectAll = new SQLiteCommand("SELECT id, first_name, last_name FROM `workers`", conn);
                try
                {
                    SQLiteDataReader r = commandSelectAll.ExecuteReader();
                    string line = String.Empty;
                    while (r.Read())
                    {
                        String fio = r["last_name"].ToString()+" "+r["first_name"].ToString().Substring(0,1)+".";
                        itemlist.Add(new ComboItem(Convert.ToInt32(r["id"]), fio));
                    }
                    r.Close();
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            comboSelectDriver.DataSource = itemlist;
        }

    }
}
