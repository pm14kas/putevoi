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

namespace putevoi
{
    public partial class PutevoiForm : Form
    {
        private SQLiteConnection conn;
        Putevoi putevoi;

        public PutevoiForm(long _putevoi)
        {
            InitializeComponent();

            conn = new SQLiteConnection("Data Source='db/database.db'; Version=3;");
            conn.Open();


            putevoi = Putevoi.Find(_putevoi, conn);

            List<ComboItem> itemlistdrivers = new List<ComboItem>();

            var driverlist = Driver.All(conn);
            int drivercount = -1;
            int driveriterator = 0;
            foreach (Driver driver in driverlist)
            {
                itemlistdrivers.Add(new ComboItem(driver.id, driver.Name()));
                if (driver.id != putevoi.driver_id)
                {
                    driveriterator++;
                }
                else
                {
                    drivercount = driveriterator;
                }
            }
            comboSelectDriver.DataSource = itemlistdrivers;
            if (drivercount == -1)
            {
                comboSelectDriver.SelectedValue = -1;
                comboSelectDriver.SelectedText = "Выберите водителя";
            }
            else
            {
                comboSelectDriver.SelectedItem = comboSelectDriver.Items[drivercount];
            }


            List<ComboItem> itemlistengines = new List<ComboItem>();
            var enginelist = Engine.All(conn);
            int enginecount = -1;
            int engineiterator = 0;
            foreach (Engine engine in enginelist)
            {
                itemlistengines.Add(new ComboItem(engine.id, engine.Name()));
                if (engine.id != putevoi.engine_id)
                {
                    engineiterator++;
                }
                else
                {
                    enginecount = engineiterator;
                }
            }
            comboSelectEngine.DataSource = itemlistengines;
            if (enginecount == -1)
            {
                comboSelectEngine.SelectedValue = -1;
                comboSelectEngine.SelectedText = "Выберите автомобиль";
            }
            else
            {
                comboSelectEngine.SelectedItem = comboSelectEngine.Items[enginecount];
            }


            List<ComboItem> itemlistcars = new List<ComboItem>();
            var carlist = Car.All(conn);
            int carcount = -1;
            int cariterator = 0;
            foreach (Car car in carlist)
            {
                itemlistcars.Add(new ComboItem(car.id, car.Name()));
                if (car.id != putevoi.car_id)
                {
                    cariterator++;
                }
                else
                {
                    carcount = cariterator;
                }
            }
            comboSelectCar.DataSource = itemlistcars;
            if (carcount == -1)
            {
                comboSelectCar.SelectedValue = -1;
                comboSelectCar.SelectedText = "Выберите прицеп";
            }
            else
            {
                comboSelectCar.SelectedItem = comboSelectCar.Items[carcount];
            }


            List<ComboItem> listHw = new List<ComboItem>();
            listHw.Add(new ComboItem(130, "Диз. топливо (1.3)"));
            listHw.Add(new ComboItem(200, "Бензин (2)"));
            listHw.Add(new ComboItem(264, "Нефтяной газ (2.64)"));
            listHw.Add(new ComboItem(200, "Природный газ (2)"));
            comboBoxHw.DataSource = listHw;

            textBoxFuelStart.Text = putevoi.fuel_start.ToString();
            textBoxFuelZapravka.Text = putevoi.fuel_zapravka.ToString();
            textBoxFuelKarta.Text = putevoi.fuel_karta.ToString();
            textBoxFuelCash.Text = putevoi.fuel_cash.ToString();
            textBoxFuelEnd.Text = putevoi.fuel_end.ToString();
            textBoxFuelNorma.Text = putevoi.fuel_norma.ToString();

            textBoxProbegStart.Text = putevoi.probeg_start.ToString();
            textBoxProbegSGruzom.Text = putevoi.probeg_s_gruzom.ToString();
            textBoxProbegBezGruza.Text = putevoi.probeg_bez_gruza.ToString();
            textBoxProbegEnd.Text = putevoi.probeg_end.ToString();

            dateTimePutevoiDateStart.Value = UnixTime.From(putevoi.date_start);
            dateTimePutevoiDateEnd.Value = UnixTime.From(putevoi.date_end);
            recalculateFuelNorm();
                
        }

        private void comboSelectEngine_TextUpdate(object sender, EventArgs e)
        {
           
        }

        private void buttonPutevoiCancel_Click(object sender, EventArgs e)
        {

        }

        private void buttonPutevoiSave_Click(object sender, EventArgs e)
        {
            putevoi.driver_id = Convert.ToInt64(comboSelectDriver.SelectedValue);
            putevoi.engine_id = Convert.ToInt64(comboSelectEngine.SelectedValue);
            putevoi.car_id = Convert.ToInt64(comboSelectCar.SelectedValue);
            putevoi.fuel_start = Convert.ToInt64(textBoxFuelStart.Text);
            putevoi.fuel_zapravka = Convert.ToInt64(textBoxFuelZapravka.Text);
            putevoi.fuel_cash = Convert.ToInt64(textBoxFuelCash.Text);
            putevoi.fuel_karta = Convert.ToInt64(textBoxFuelKarta.Text);
            putevoi.fuel_end = Convert.ToInt64(textBoxFuelEnd.Text);
            putevoi.fuel_norma = Convert.ToSingle(textBoxFuelNorma.Text.Replace(".",","));
            putevoi.probeg_s_gruzom = Convert.ToInt64(textBoxProbegSGruzom.Text);
            putevoi.probeg_bez_gruza = Convert.ToInt64(textBoxProbegBezGruza.Text);
            putevoi.probeg_start = Convert.ToInt64(textBoxProbegStart.Text);
            putevoi.probeg_end = Convert.ToInt64(textBoxProbegEnd.Text);
            putevoi.date_start = UnixTime.To(dateTimePutevoiDateStart.Value);
            putevoi.date_end = UnixTime.To(dateTimePutevoiDateEnd.Value);
            try
            {
                putevoi.Save(conn);
                MessageBox.Show("Путевой лист сохранен в базе данных", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить в базу данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void buttonPutevoiFinal_Click(object sender, EventArgs e)
        {
            Driver driver;
            Engine engine;
            Car car;
            if (comboSelectDriver.SelectedValue == null)
            {
                driver = new Driver();
            }
            else
            {
                SQLiteCommand commandSelectAll = new SQLiteCommand("SELECT * FROM `drivers` WHERE id = " + comboSelectDriver.SelectedValue, conn);
                SQLiteDataReader r = commandSelectAll.ExecuteReader();
                driver = new Driver(ref r);
            }
            if (comboSelectEngine.SelectedValue == null)
            {
                engine = new Engine();
            }
            else
            {
                SQLiteCommand commandSelectAll = new SQLiteCommand("SELECT * FROM `engines` WHERE id = @id;", conn);
                commandSelectAll.Parameters.Add(new SQLiteParameter("id", comboSelectEngine.SelectedValue));
                engine = new Engine(commandSelectAll);
            }
            if (comboSelectCar.SelectedValue == null)
            {
                car = new Car();
            }
            else
            {
                SQLiteCommand commandSelectAll = new SQLiteCommand("SELECT * FROM `cars` WHERE id = @id;", conn);
                commandSelectAll.Parameters.Add(new SQLiteParameter("id", comboSelectCar.SelectedValue));
                car = new Car(commandSelectAll);
            }

            string documentName = "\\documents\\Путевой лист " + driver.Name().Replace(".","") + " " + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss-ff");

            File.Copy(Application.StartupPath + "\\templates\\templatePutevoi.docx", Application.StartupPath + documentName + ".docx");
            WordprocessingDocument putevoi = WordprocessingDocument.Open(Application.StartupPath + documentName + ".docx", true);

            try
            {
                BookmarkReplace(putevoi, "driver_name", driver.Name());
                BookmarkReplace(putevoi, "driver_document", driver.document);
                BookmarkReplace(putevoi, "engine_marka", engine.marka);
                BookmarkReplace(putevoi, "engine_gosnomer", engine.gosnomer);
                BookmarkReplace(putevoi, "car_marka", car.marka);
                BookmarkReplace(putevoi, "car_gosnomer", car.gosnomer);
                BookmarkReplace(putevoi, "fuel_start", textBoxFuelStart.Text);
                BookmarkReplace(putevoi, "fuel_zapravka", textBoxFuelZapravka.Text);
                BookmarkReplace(putevoi, "fuel_cash", textBoxFuelCash.Text);
                BookmarkReplace(putevoi, "fuel_karta", textBoxFuelKarta.Text);
                BookmarkReplace(putevoi, "fuel_end", textBoxFuelEnd.Text);
                BookmarkReplace(putevoi, "fuel_rashod", textBoxFuelRashod.Text);
                BookmarkReplace(putevoi, "fuel_rashod_norma", textBoxFuelNorma.Text);
                BookmarkReplace(putevoi, "fuel_itogo", textBoxFuelItogo.Text);
                BookmarkReplace(putevoi, "probeg_s_gruzom", textBoxProbegSGruzom.Text);
                BookmarkReplace(putevoi, "probeg_bez_gruza", textBoxProbegBezGruza.Text);
                BookmarkReplace(putevoi, "probeg_summa", textBoxProbegSumma.Text);
                BookmarkReplace(putevoi, "probeg_start", textBoxProbegStart.Text);
                BookmarkReplace(putevoi, "probeg_end", textBoxProbegEnd.Text);
                BookmarkReplace(putevoi, "date_start", dateTimePutevoiDateStart.Value.ToString(dateTimePutevoiDateStart.CustomFormat));
                BookmarkReplace(putevoi, "date_end", dateTimePutevoiDateEnd.Value.ToString(dateTimePutevoiDateEnd.CustomFormat));
                putevoi.Close();
                if (MessageBox.Show("Путевой лист записан в каталог \"documents\"\nПуть:" + documentName + ".docx\nОткрыть документ?", "Открытие файла", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("\"" + Application.StartupPath + documentName + ".docx\"");
                }
            }
            catch
            {
                putevoi.Close();
                File.Delete(Application.StartupPath + documentName + ".docx");
                MessageBox.Show("Ошибка формирования документа");
            }    
        }



        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            double temp = 0;
            if (!double.TryParse(textBox.Text.Replace(".", ","), out temp))
            {
                textBox.Text = "0";
            }

            try
            {
                textBoxProbegSumma.Text = (Convert.ToInt64(textBoxProbegSGruzom.Text) + Convert.ToInt64(textBoxProbegBezGruza.Text)).ToString();
                textBoxProbegEnd.Text = (Convert.ToInt64(textBoxProbegSumma.Text) + Convert.ToInt64(textBoxProbegStart.Text)).ToString();
                textBoxFuelItogo.Text = (Convert.ToInt64(textBoxFuelZapravka.Text) + Convert.ToInt64(textBoxFuelKarta.Text) + Convert.ToInt64(textBoxFuelCash.Text)).ToString();
                textBoxFuelRashod.Text = (Convert.ToInt64(textBoxFuelStart.Text) + Convert.ToInt64(textBoxFuelItogo.Text) - Convert.ToInt64(textBoxFuelEnd.Text)).ToString();
                recalculateFuelNorm();
            }
            catch
            {
                MessageBox.Show("Введено слишком большое число. Удалите излишки и попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void recalculateFuelNorm()
        {
            Car car = Car.Find(Convert.ToInt64(comboSelectCar.SelectedValue), conn);
            Engine engine = Engine.Find(Convert.ToInt64(comboSelectEngine.SelectedValue), conn);
            double Qn; //нормативный расход топлива
            double S = Convert.ToInt64(textBoxProbegEnd.Text)-Convert.ToInt64(textBoxProbegStart.Text); //пробег
            double Hsan; //норма расхода топлива на пробег автомобиля или автопоезда в снаряженном состоянии без груза
            double Hs = engine.rashod; //Hs - базовая норма расхода топлива на пробег автомобиля (тягача) в снаряженном состоянии, л/100 км
            double Hg = car.rashod; //Hg - норма расхода топлива на дополнительную массу прицепа или полуприцепа, л/100 т.км
            double Gpr = car.weight; //Gпр - собственная масса прицепа или полуприцепа
            double Hw = Convert.ToDouble(comboBoxHw.SelectedValue) * 0.01; ; //Hw - норма расхода топлива на транспортную работу, л/100 т.км
            double Ggr = Convert.ToDouble(textBoxGruzMassa.Text.Replace(".", ","));
            double Sgr = Convert.ToInt64(textBoxProbegSGruzom.Text);
            double W ; //W - объем транспортной работы, т.км: 
            double D = Convert.ToDouble(textBoxCoef.Text.Replace(".", ",")); ; //D - поправочный коэффициент (суммарная относительная надбавка или снижение) к норме в процентах.
            //Для грузовых бортовых автомобилей и автопоездов, выполняющих работу, учитываемую в тонно-км, дополнительно к базовой норме, норма расхода топлива увеличивается (из расчета в литрах на каждую тонну груза на 100 км пробега) в зависимости от вида используемого топлива в следующих размерах: для бензина - до 2 л; дизельного топлива - до 1,3 л; сжиженного нефтяного газа (снг) - до 2,64 л; сжатого природного газа (спг) - до 2 куб. м; при газодизельном питании ориентировочно - до 1,2 куб. м природного газа и до 0,25 л дизельного топлива.
            
            W = Ggr * Sgr;
            Hsan = Hs + Hg * Gpr;
            Qn = 0.01 * (Hsan * S + Hw * W) * (1 + 0.01 * D);

            textBoxFuelNorma.Text = Qn.ToString();
            if (S < 0.0001)
            {
                textBoxFuelNorma100.Text = "Ошибка деления";
            }
            else
            {
                textBoxFuelNorma100.Text = Math.Round(Qn * 100 / S, 3).ToString();
            }
        }




        private void BookmarkReplace(WordprocessingDocument document, string bookmarkname, string value)
        {
            var bookmarkStartList = document.MainDocumentPart.Document.Descendants<BookmarkStart>();
            var bookmarkEndList = document.MainDocumentPart.Document.Descendants<BookmarkEnd>();

            BookmarkStart bookmarkStart = null;
            BookmarkEnd bookmarkEnd = null;
            foreach (BookmarkStart temp in bookmarkStartList)//нужно переписать под Linq, но пока и так все работает
            {
                if (temp.Name == bookmarkname)
                {
                    bookmarkStart = temp;
                    break;
                }
            }

            if (bookmarkStart == null) return;

            foreach (BookmarkEnd temp in bookmarkEndList)
            {
                if (temp.Id.Value == bookmarkStart.Id.Value)
                {
                    bookmarkEnd = temp;
                    break;
                }
            }

            if (bookmarkEnd == null) return;

            OpenXmlElement elem = bookmarkStart.NextSibling();

            while (elem != null && !((elem is BookmarkEnd) && ((BookmarkEnd)elem == bookmarkEnd)))
            {
                OpenXmlElement nextElem = elem.NextSibling();
                elem.Remove();
                elem = nextElem;
            }

            bookmarkStart.Parent.InsertAfter<Run>(new Run(new Text(value)), bookmarkStart);

        }

        private void buttonPutevoiGetData_Click(object sender, EventArgs e)
        {
            PutevoiSelectorForm selector = new PutevoiSelectorForm(Convert.ToInt64(comboSelectEngine.SelectedValue));
            DialogResult result = selector.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Putevoi previous = Putevoi.Find(selector.putevoiSelected, conn);
                textBoxFuelStart.Text = previous.fuel_end.ToString();
                textBoxProbegStart.Text = (previous.probeg_end).ToString();
                textBoxFuelZapravka.Text = "0";
                textBoxFuelKarta.Text = "0";
                textBoxFuelCash.Text = "0";
                textBoxFuelEnd.Text = "0";
                textBoxProbegSGruzom.Text = "0";
                textBoxProbegBezGruza.Text = "0";
                recalculateFuelNorm();
            }
        }


        private void label22_Click(object sender, EventArgs e)
        {
            recalculateFuelNorm();
        }


    }
}
