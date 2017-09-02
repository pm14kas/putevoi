using System;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Linq;
using System.Data.Common;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;


namespace putevoi
{
    public partial class MainForm : Form
    {
        private SQLiteConnection conn;

        private const double version_major = 0;
        private const double version_minor = 5.5;


        public MainForm()
        {
            InitializeComponent();
            System.IO.Directory.CreateDirectory("db");
            System.IO.Directory.CreateDirectory("db\\backup");
            System.IO.Directory.CreateDirectory("templates");
            System.IO.Directory.CreateDirectory("documents");
            conn = new SQLiteConnection("Data Source='db/database.db'; Version=3;");
            conn.Open();

            Driver.CreateDB(conn);
            Car.CreateDB(conn);
            Engine.CreateDB(conn);
            Putevoi.CreateDB(conn);

            File.Copy(Application.StartupPath + "\\db\\database.db", Application.StartupPath + "\\db\\backup\\database " + UnixTime.Now.ToString() + ".db");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " v" + version_major.ToString() + "." + version_minor.ToString().Replace(',','.');
            fillDataGrid();
        }
      

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                fillDataGrid();
            }
            else if (tabControl.SelectedIndex==2)
            {
                List<ComboItem> itemlistengines = new List<ComboItem>();
                var enginelist = Engine.All(conn);
                foreach (Engine engine in enginelist)
                {
                    itemlistengines.Add(new ComboItem(engine.id, engine.Name()));
                }
                comboSelectEngine.DataSource = itemlistengines;
                dateTimeGSMDateEnd.Value = DateTime.Now;
            }
        }
        private void tabControlDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataGrid();
        }

        private void fillDataGrid()
        {
            dataDrivers.Rows.Clear();
            var driverlist = Driver.All(conn);
            foreach (Driver driver in driverlist)
            {
                dataDrivers.Rows.Add(
                    driver.id,
                    driver.familiya,
                    driver.imya,
                    driver.otchestvo,
                    driver.document,
                    driver.passport,
                    UnixTime.From(driver.created_at),
                    UnixTime.From(driver.updated_at)
                );
            }

            dataEngines.Rows.Clear();
            var enginelist = Engine.All(conn);
            foreach (Engine engine in enginelist)
            {
                dataEngines.Rows.Add(
                    engine.id,
                    engine.marka,
                    engine.gosnomer,
                    engine.rashod,
                    UnixTime.From(engine.created_at),
                    UnixTime.From(engine.updated_at)
                );
            }

            dataCars.Rows.Clear();
            var carlist = Car.All(conn);
            foreach (Car car in carlist)
            {
                dataCars.Rows.Add(
                    car.id,
                    car.marka,
                    car.gosnomer,
                    car.weight,
                    car.rashod,
                    UnixTime.From(car.created_at),
                    UnixTime.From(car.updated_at)
                );
            }

            dataPutevoi.Rows.Clear();
            var putevoilist = Putevoi.All(conn);
            foreach (Putevoi putevoi in putevoilist)
            {
                dataPutevoi.Rows.Add(
                    putevoi.id,
                    putevoi.nomer,
                    Driver.Find(putevoi.driver_id, conn).Name(),
                    Engine.Find(putevoi.engine_id, conn).Name(),
                    Car.Find(putevoi.car_id, conn).Name(),
                    UnixTime.From(putevoi.date_start),
                    UnixTime.From(putevoi.date_end),
                    putevoi.fuel_start,
                    putevoi.fuel_zapravka,
                    putevoi.fuel_karta,
                    putevoi.fuel_cash,
                    putevoi.fuel_zapravka+putevoi.fuel_karta+putevoi.fuel_cash,
                    putevoi.fuel_end,
                    putevoi.fuel_start + putevoi.fuel_zapravka + putevoi.fuel_karta + putevoi.fuel_cash - putevoi.fuel_end,
                    putevoi.fuel_norma,
                    putevoi.probeg_start,
                    putevoi.probeg_s_gruzom,
                    putevoi.probeg_bez_gruza,
                    putevoi.probeg_end,
                    UnixTime.From(putevoi.created_at),
                    UnixTime.From(putevoi.updated_at)
                );
            }
        }

        private void dataDrivers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataDrivers.Rows[e.RowIndex];
            string column = dataDrivers.Columns[e.ColumnIndex].Name.Replace("driver_", "");
            DataGridViewCell cell = row.Cells[e.ColumnIndex];
            string id = row.Cells[0].Value.ToString();
            SQLiteCommand commandUpdate = new SQLiteCommand("UPDATE drivers SET " + column + " = @value, updated_at = @updated_at WHERE id = @id", conn);
            commandUpdate.Parameters.Add(new SQLiteParameter("value", cell.Value));
            commandUpdate.Parameters.Add(new SQLiteParameter("id", id));
            commandUpdate.Parameters.Add(new SQLiteParameter("updated_at", UnixTime.Now));
            commandUpdate.ExecuteNonQuery();
        }
        private void dataEngines_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataEngines.Rows[e.RowIndex];
            string column = dataEngines.Columns[e.ColumnIndex].Name.Replace("engine_", "");
            DataGridViewCell cell = row.Cells[e.ColumnIndex];
            string id = row.Cells[0].Value.ToString();
            SQLiteCommand commandUpdate;
            if (column == "weight")
            {
                int weight = 0;
                int.TryParse(cell.Value.ToString(), out weight);
                commandUpdate = new SQLiteCommand("UPDATE engines SET " + column + " = @value, updated_at = @updated_at WHERE id = @id", conn);
                commandUpdate.Parameters.Add(new SQLiteParameter("value", weight));
                commandUpdate.Parameters.Add(new SQLiteParameter("id", id));
                commandUpdate.Parameters.Add(new SQLiteParameter("updated_at", UnixTime.Now));
                cell.Value = weight;
            }
            else if (column == "rashod")
            {
                float rashod = 0;
                float.TryParse(cell.Value.ToString().Replace(".", ","), out rashod);
                commandUpdate = new SQLiteCommand("UPDATE engines SET " + column + " = @value, updated_at = @updated_at WHERE id = @id", conn);
                commandUpdate.Parameters.Add(new SQLiteParameter("value", rashod));
                commandUpdate.Parameters.Add(new SQLiteParameter("id", id));
                commandUpdate.Parameters.Add(new SQLiteParameter("updated_at", UnixTime.Now));
                cell.Value = rashod;
            }
            else
            {
                commandUpdate = new SQLiteCommand("UPDATE engines SET " + column + " = @value, updated_at = @updated_at WHERE id = @id", conn);
                commandUpdate.Parameters.Add(new SQLiteParameter("value", cell.Value));
                commandUpdate.Parameters.Add(new SQLiteParameter("id", id));
                commandUpdate.Parameters.Add(new SQLiteParameter("updated_at", UnixTime.Now));
            }
            commandUpdate.ExecuteNonQuery();
        }
        private void dataCars_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataCars.Rows[e.RowIndex];
            string column = dataCars.Columns[e.ColumnIndex].Name.Replace("car_", "");
            DataGridViewCell cell = row.Cells[e.ColumnIndex];
            string id = row.Cells[0].Value.ToString();
            SQLiteCommand commandUpdate;
            if (column == "weight")
            {
                int weight = 0;
                int.TryParse(cell.Value.ToString(), out weight);
                commandUpdate = new SQLiteCommand("UPDATE cars SET " + column + " = @value, updated_at = @updated_at WHERE id = @id", conn);
                commandUpdate.Parameters.Add(new SQLiteParameter("value", weight));
                commandUpdate.Parameters.Add(new SQLiteParameter("id", id));
                commandUpdate.Parameters.Add(new SQLiteParameter("updated_at", UnixTime.Now));
                cell.Value = weight;
            }
            else if (column == "rashod")
            {
                float rashod = 0;
                float.TryParse(cell.Value.ToString().Replace(".",","), out rashod);
                commandUpdate = new SQLiteCommand("UPDATE cars SET " + column + " = @value, updated_at = @updated_at WHERE id = @id", conn);
                commandUpdate.Parameters.Add(new SQLiteParameter("value", rashod));
                commandUpdate.Parameters.Add(new SQLiteParameter("id", id));
                commandUpdate.Parameters.Add(new SQLiteParameter("updated_at", UnixTime.Now));
                cell.Value = rashod;
            }
            else
            {
                commandUpdate = new SQLiteCommand("UPDATE cars SET "+column+" = @value, updated_at = @updated_at WHERE id = @id", conn);
                commandUpdate.Parameters.Add(new SQLiteParameter("value", cell.Value));
                commandUpdate.Parameters.Add(new SQLiteParameter("id", id));
                commandUpdate.Parameters.Add(new SQLiteParameter("updated_at", UnixTime.Now));
            }
            commandUpdate.ExecuteNonQuery();
        }

        private void buttonDriverAdd_Click(object sender, EventArgs e)
        {
            Driver driver = new Driver();
            driver.Save(conn);
            fillDataGrid();
        }
        private void buttonEngineAdd_Click(object sender, EventArgs e)
        {
            Engine engine = new Engine();
            engine.Save(conn);
            fillDataGrid();
        }
        private void buttonCarAdd_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            car.Save(conn);
            fillDataGrid();
        }
        private void buttonPutevoiAdd_Click(object sender, EventArgs e)
        {
            Putevoi putevoi = new Putevoi();
            putevoi.Save(conn);
            fillDataGrid();
        }
 
        private void buttonDriverDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataDrivers.SelectedRows;
            if (rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить выбранные записи?", "Удаление записей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in rows)
                    {
                        int id = Convert.ToInt32(row.Cells[0].Value);
                        SQLiteCommand commandDelete = new SQLiteCommand("DELETE FROM drivers WHERE id=@id;", conn);
                        commandDelete.Parameters.Add(new SQLiteParameter("id", id));
                        commandDelete.ExecuteNonQuery();
                    }
                    fillDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonEngineDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataEngines.SelectedRows;
            if (rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить выбранные записи?", "Удаление записей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in rows)
                    {
                        int id = Convert.ToInt32(row.Cells[0].Value);
                        SQLiteCommand commandDelete = new SQLiteCommand("DELETE FROM engines WHERE id=@id;", conn);
                        commandDelete.Parameters.Add(new SQLiteParameter("id", id));
                        commandDelete.ExecuteNonQuery();
                    }
                    fillDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCarDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataCars.SelectedRows;
            if (rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить выбранные записи?", "Удаление записей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in rows)
                    {
                        int id = Convert.ToInt32(row.Cells[0].Value);
                        SQLiteCommand commandDelete = new SQLiteCommand("DELETE FROM cars WHERE id=@id;", conn);
                        commandDelete.Parameters.Add(new SQLiteParameter("id", id));
                        commandDelete.ExecuteNonQuery();
                    }
                    fillDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonPutevoiDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataPutevoi.SelectedRows;
            if (rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить выбранные записи?", "Удаление записей", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in rows)
                    {
                        int id = Convert.ToInt32(row.Cells[0].Value);
                        SQLiteCommand commandDelete = new SQLiteCommand("DELETE FROM putevoi WHERE id=@id;", conn);
                        commandDelete.Parameters.Add(new SQLiteParameter("id", id));
                        commandDelete.ExecuteNonQuery();
                    }
                    fillDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonPutevoiEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataPutevoi.SelectedRows;
            if (rows.Count==1)
            {
                foreach (DataGridViewRow row in rows)
                {
                    int id = Convert.ToInt32(row.Cells[0].Value);
                    PutevoiForm putevoiForm = new PutevoiForm(id);
                    putevoiForm.ShowDialog(this);
                    fillDataGrid();
                }
                
            }
            else if (rows.Count > 1)
            {
                MessageBox.Show("Выбрано более одной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            tabControl.Width = this.Size.Width - 20;
            tabControl.Height = this.Size.Height - 40;

            tabControlDatabase.Width = this.Size.Width - 35;
            tabControlDatabase.Height = this.Size.Height - 70;

            dataDrivers.Width = tabControlDatabase.Width - 30;
            dataDrivers.Height = tabControlDatabase.Height - 70;
            buttonDriverDelete.Location = new System.Drawing.Point(11, this.Height - 125);
            buttonDriverAdd.Location = new System.Drawing.Point(this.Width - 220, this.Height - 125);

            dataEngines.Width = tabControlDatabase.Width - 30;
            dataEngines.Height = tabControlDatabase.Height - 70;
            buttonEngineDelete.Location = new System.Drawing.Point(11, this.Height - 125);
            buttonEngineAdd.Location = new System.Drawing.Point(this.Width - 220, this.Height - 125);

            dataCars.Width = tabControlDatabase.Width - 30;
            dataCars.Height = tabControlDatabase.Height - 70;
            buttonCarDelete.Location = new System.Drawing.Point(11, this.Height - 125);
            buttonCarAdd.Location = new System.Drawing.Point(this.Width - 220, this.Height - 125);

            dataPutevoi.Width = this.Width - 45;
            dataPutevoi.Height = this.Height - 110;
            buttonPutevoiDelete.Location = new System.Drawing.Point(11, this.Height - 95);
            buttonPutevoiAdd.Location = new System.Drawing.Point(this.Width - 200, this.Height - 95);
            buttonPutevoiEdit.Location = new System.Drawing.Point(this.Width / 2 - buttonPutevoiEdit.Width/2, this.Height - 95);
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть программу?", "Закрытие программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                conn.Close();
            }
        }

        private void buttonGSMSingle_Click(object sender, EventArgs e)
        {
            string documentName = "\\documents\\Отчет по ГСМ " + Engine.Find(Convert.ToInt64(comboSelectEngine.SelectedValue), conn).Name() + " " + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss-ff");
            File.Copy(Application.StartupPath + "\\templates\\templateGSM.xlsx", Application.StartupPath + documentName + ".xlsx");
            SpreadsheetDocument document = SpreadsheetDocument.Open(Application.StartupPath + documentName + ".xlsx", true);



            document.Close();

            if (MessageBox.Show("Отчёт записан в каталог \"documents\"\nПуть:" + documentName + ".xlsx\nОткрыть документ?", "Открытие файла", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("\"" + Application.StartupPath + documentName + ".xlsx\"");
            }
            
        }

        private void buttonGSMAll_Click(object sender, EventArgs e)
        {

        }

    }
}
