using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace putevoi
{
    class Driver
    {
        public long id;
        public string familiya;
        public string imya;
        public string otchestvo;
        public string passport;
        public string document;
        public long created_at { get; private set; }
        public long updated_at { get; private set; }

        public Driver()
        {
            id = 0;
            familiya = "";
            imya = "";
            otchestvo = "";
            passport = "";
            document = "";
            created_at = UnixTime.Now;
            updated_at = UnixTime.Now;
        }
        public Driver(ref SQLiteDataReader r)
        {
            while (r.Read())
            {
                id = Convert.ToInt32(r["id"]);
                familiya = r["familiya"].ToString();
                imya = r["imya"].ToString();
                otchestvo = r["otchestvo"].ToString();
                passport = r["passport"].ToString();
                document = r["document"].ToString();
                created_at = getInt("created_at", r);
                updated_at = getInt("updated_at", r);
                break;
            }
            r.Close();
        }

        public static List<Driver> GetList(ref SQLiteDataReader r)
        {
            List<Driver> data = new List<Driver>();
            while (r.Read())
            {
                Driver driver = new Driver();
                driver.id = Convert.ToInt32(r["id"]);
                driver.familiya = r["familiya"].ToString();
                driver.imya = r["imya"].ToString();
                driver.otchestvo = r["otchestvo"].ToString();
                driver.passport = r["passport"].ToString();
                driver.document = r["document"].ToString();
                driver.created_at = getInt("created_at", r);
                driver.updated_at = getInt("updated_at", r);
                data.Add(driver);
            }
            r.Close();
            return data;
        }

        public static Driver Find(long id, SQLiteConnection conn)
        {
            SQLiteCommand commandSelect = new SQLiteCommand("SELECT * FROM drivers WHERE id=@id", conn);
            commandSelect.Parameters.Add(new SQLiteParameter("id", id));
            SQLiteDataReader r = commandSelect.ExecuteReader();
            Driver driver = new Driver(ref r);
            return driver;
        }

        public static List<Driver> All(SQLiteConnection conn)
        {
            SQLiteCommand commandSelect = new SQLiteCommand("SELECT * FROM drivers", conn);
            SQLiteDataReader r = commandSelect.ExecuteReader();
            List<Driver> driver = Driver.GetList(ref r);
            return driver;
        }

        public void Save(SQLiteConnection conn)
        {
            this.updated_at = UnixTime.Now;
            if (this.id == 0)
            {
                SQLiteCommand commandInsert = new SQLiteCommand("INSERT INTO `drivers`(familiya, imya, otchestvo, passport, document, created_at, updated_at) VALUES(@familiya, @imya, @otchestvo, @passport, @document, @created_at, @updated_at);"
                + "SELECT seq FROM sqlite_sequence WHERE name='drivers';", conn);
                commandInsert.Parameters.Add(new SQLiteParameter("familiya", this.familiya));
                commandInsert.Parameters.Add(new SQLiteParameter("imya", this.imya));
                commandInsert.Parameters.Add(new SQLiteParameter("otchestvo", this.otchestvo));
                commandInsert.Parameters.Add(new SQLiteParameter("passport", this.passport));
                commandInsert.Parameters.Add(new SQLiteParameter("document", this.document));
                commandInsert.Parameters.Add(new SQLiteParameter("created_at",  this.created_at));
                commandInsert.Parameters.Add(new SQLiteParameter("updated_at", this.updated_at));
                this.id = Convert.ToInt32(commandInsert.ExecuteScalar());
            }
            else
            {
                SQLiteCommand commandUpdate = new SQLiteCommand("UPDATE drivers SET familiya=@familiya, imya=@imya, otchestvo=@otchestvo, passport=@passport, document=@document, updated_at=@updated_at WHERE id = @id;", conn);
                commandUpdate.Parameters.Add(new SQLiteParameter("familiya", this.familiya));
                commandUpdate.Parameters.Add(new SQLiteParameter("imya", this.imya));
                commandUpdate.Parameters.Add(new SQLiteParameter("otchestvo", this.otchestvo));
                commandUpdate.Parameters.Add(new SQLiteParameter("passport", this.passport));
                commandUpdate.Parameters.Add(new SQLiteParameter("document", this.document));
                commandUpdate.Parameters.Add(new SQLiteParameter("updated_at", this.updated_at));
                commandUpdate.ExecuteNonQuery();
            }
        }

        public static void CreateDB(SQLiteConnection conn)
        {
            SQLiteCommand tableCreate = new SQLiteCommand(
                "CREATE TABLE IF NOT EXISTS `drivers` ("
                    +" id INTEGER PRIMARY KEY AUTOINCREMENT, "
                    + "familiya TEXT, "
                    + "imya TEXT, "
                    + "otchestvo TEXT, "
                    + "passport TEXT, "
                    + "document TEXT,"
                    + "created_at INTEGER,"
                    + "updated_at INTEGER);", conn);
            tableCreate.ExecuteNonQuery();

            try
            {
                SQLiteCommand updateTable = new SQLiteCommand("ALTER TABLE drivers ADD COLUMN familiya TEXT", conn);
                tableCreate.ExecuteNonQuery();
            }
            catch { }
            try
            {
                SQLiteCommand updateTable = new SQLiteCommand("ALTER TABLE drivers ADD COLUMN imya TEXT", conn);
                tableCreate.ExecuteNonQuery();
            }
            catch { }
            try
            {
                SQLiteCommand updateTable = new SQLiteCommand("ALTER TABLE drivers ADD COLUMN otchestvo TEXT", conn);
                tableCreate.ExecuteNonQuery();
            }
            catch { }
            try
            {
                SQLiteCommand updateTable = new SQLiteCommand("ALTER TABLE drivers ADD COLUMN passport TEXT", conn);
                tableCreate.ExecuteNonQuery();
            }
            catch { }
            try
            {
                SQLiteCommand updateTable = new SQLiteCommand("ALTER TABLE drivers ADD COLUMN document TEXT", conn);
                tableCreate.ExecuteNonQuery();
            }
            catch { }
            try
            {
                SQLiteCommand updateTable = new SQLiteCommand("ALTER TABLE drivers ADD COLUMN created_at INTEGER", conn);
                tableCreate.ExecuteNonQuery();
            }
            catch { }
            try
            {
                SQLiteCommand updateTable = new SQLiteCommand("ALTER TABLE drivers ADD COLUMN updated_at INTEGER", conn);
                tableCreate.ExecuteNonQuery();
            }
            catch { }
        }
        private static long getInt(string column, SQLiteDataReader r)
        {
            return Convert.ToInt32((r[column] is DBNull) ? 0 : r[column]);
        }

        private static string getString(string column, SQLiteDataReader r)
        {
            return ((r[column] is DBNull) ? "" : r[column]).ToString();
        }

        public string Name()
        {
            string tempimya = imya ?? "";
            string tempfamiliya = familiya ?? "";
            string tempotchestvo = otchestvo ?? "";
            if (tempimya.Length > 1) tempimya = tempimya.Substring(0, 1);
            if (tempotchestvo.Length > 1) tempotchestvo = tempotchestvo.Substring(0, 1);
            return tempfamiliya + " " + tempimya + "." + tempotchestvo + ".";
        }
    }
}
