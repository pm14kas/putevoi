using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace putevoi
{
    public partial class PutevoiSelectorForm : Form
    {
        public long putevoiSelected = 0;
        public PutevoiSelectorForm(long engine_id)
        {
            InitializeComponent();
            SQLiteConnection conn = new SQLiteConnection("Data Source='db/database.db'; Version=3;");
            conn.Open();

            label.Text = label.Text + " для автомобиля " + Engine.Find(engine_id, conn).Name();

            List<ComboItem> itemlist = new List<ComboItem>();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM putevoi WHERE engine_id=@engine_id ORDER BY date_end DESC;", conn);
            command.Parameters.Add(new SQLiteParameter("engine_id", engine_id));
            List<Putevoi> list = Putevoi.GetList(command);
            foreach (Putevoi putevoi in list)
            {
                string name = UnixTime.From(putevoi.date_start).ToString("dd.MM.yyyy HH:mm")
                                +" - " 
                                + UnixTime.From(putevoi.date_end).ToString("dd.MM.yyyy HH:mm")
                                + "  (Водитель: " + Driver.Find(putevoi.driver_id, conn).Name() + ")";
                itemlist.Add(new ComboItem(putevoi.id, name));
            }
            comboBox.DataSource = itemlist;
            if (itemlist.Count==0)
            {
                comboBox.SelectedText = "Нет данных";
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            putevoiSelected = Convert.ToInt64(comboBox.SelectedValue);
            this.DialogResult = DialogResult.OK;
        }
    }
}
