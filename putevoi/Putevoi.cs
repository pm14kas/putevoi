using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace putevoi
{
    class Putevoi
    {
        public long id{ get; private set; }
        public long nomer;
        public long driver_id;
        public long engine_id;
        public long car_id;
        public long fuel_start;
        public long fuel_end;
        public long fuel_zapravka;
        public long fuel_karta;
        public long fuel_cash;
        public float fuel_norma;
        public long probeg_s_gruzom;
        public long probeg_bez_gruza;
        public long probeg_start;
        public long probeg_end;
        public long date_start;
        public long date_end;
        public long created_at { get; private set; }
        public long updated_at { get; private set; }

        private static Dictionary<String, String> columns = new Dictionary<string, string> {

                    { "nomer", "INTEGER"},
                    { "driver_id", "INTEGER"},
                    { "engine_id", "INTEGER"},
                    { "car_id", "INTEGER"},
                    { "fuel_start", "INTEGER"},
                    { "fuel_end", "INTEGER"},
                    { "fuel_zapravka", "INTEGER"},
                    { "fuel_karta", "INTEGER"},
                    { "fuel_cash", "INTEGER"},
                    { "fuel_norma", "REAL"},
                    { "probeg_s_gruzom", "INTEGER"},
                    { "probeg_bez_gruza", "INTEGER"},
                    { "probeg_start", "INTEGER"}, 
                    { "probeg_end", "INTEGER"}, 
                    { "date_start", "INTEGER"},
                    { "date_end", "INTEGER"},
                    { "created_at", "INTEGER"},
                    {"updated_at", "INTEGER"}
        };

        public Putevoi()
        {
            id = 0;
            nomer = 0; 
            driver_id = 0;
            engine_id = 0;
            car_id = 0;
            fuel_start = 0;
            fuel_end = 0;
            fuel_zapravka = 0;
            fuel_karta = 0;
            fuel_cash = 0;
            fuel_norma = 0;
            probeg_s_gruzom = 0;
            probeg_bez_gruza = 0;
            probeg_start = 0;
            probeg_end = 0;
            date_start = UnixTime.Now;
            date_end = UnixTime.Now;
            created_at = UnixTime.Now;
            updated_at = UnixTime.Now;
        }

        public Putevoi (SQLiteCommand command)
        {
            SQLiteDataReader r = command.ExecuteReader();
            while (r.Read())
            {
                id = Convert.ToInt32(r["id"].ToString());
                nomer = getInt("nomer", r);
                driver_id = getInt("driver_id", r);
                engine_id = getInt("engine_id", r);
                car_id = getInt("car_id", r);
                fuel_start = getInt("fuel_start", r);
                fuel_end = getInt("fuel_end", r);
                fuel_zapravka = getInt("fuel_zapravka", r);
                fuel_karta = getInt("fuel_karta", r);
                fuel_cash = getInt("fuel_cash", r);
                fuel_norma = getFloat("fuel_norma", r);
                probeg_s_gruzom = getInt("probeg_s_gruzom", r);
                probeg_bez_gruza = getInt("probeg_bez_gruza", r);
                probeg_start = getInt("probeg_start", r);
                probeg_end = getInt("probeg_end", r);
                date_start = getInt("date_start", r);
                date_end = getInt("date_end", r);
                created_at = getInt("created_at", r);
                updated_at = getInt("updated_at", r);
                break;
            }
            r.Close();
        }

        public static List<Putevoi> GetList(SQLiteCommand command)
        {
            SQLiteDataReader r = command.ExecuteReader();
            List<Putevoi> data = new List<Putevoi>();
            while (r.Read())
            {
                Putevoi putevoi = new Putevoi();
                putevoi.id = Convert.ToInt32(r["id"].ToString());
                putevoi.nomer = getInt("nomer", r);
                putevoi.driver_id = getInt("driver_id", r);
                putevoi.engine_id = getInt("engine_id", r);
                putevoi.car_id = getInt("car_id", r);
                putevoi.fuel_start = getInt("fuel_start", r);
                putevoi.fuel_end = getInt("fuel_end", r);
                putevoi.fuel_zapravka = getInt("fuel_zapravka", r);
                putevoi.fuel_karta = getInt("fuel_karta", r);
                putevoi.fuel_cash = getInt("fuel_cash", r);
                putevoi.fuel_norma = getFloat("fuel_norma", r);
                putevoi.probeg_s_gruzom = getInt("probeg_s_gruzom", r);
                putevoi.probeg_bez_gruza = getInt("probeg_bez_gruza", r);
                putevoi.probeg_start = getInt("probeg_start", r);
                putevoi.probeg_end = getInt("probeg_end", r);
                putevoi.date_start = getInt("date_start", r);
                putevoi.date_end = getInt("date_end", r);
                putevoi.created_at = getInt("created_at", r);
                putevoi.updated_at = getInt("updated_at", r);
                data.Add(putevoi);
            }
            r.Close();
            return data;
        }

        public static Putevoi Find(long id, SQLiteConnection conn)
        {
            SQLiteCommand commandSelect = new SQLiteCommand("SELECT * FROM putevoi WHERE id=@id", conn);
            commandSelect.Parameters.Add(new SQLiteParameter("id", id));
            Putevoi putevoi = new Putevoi(commandSelect);
            return putevoi;
        }

        public static List<Putevoi> All(SQLiteConnection conn)
        {
            List<Putevoi> putevoi = Putevoi.GetList(new SQLiteCommand("SELECT * FROM putevoi", conn));
            return putevoi;
        }

        public void Save(SQLiteConnection conn)
        {
            this.updated_at = UnixTime.Now;
            if (this.id == 0)
            {

                string query = "INSERT INTO putevoi(";

                var lastcolumn = columns.Last();
                foreach (var column in columns)
                {
                    query += column.Key;
                    if (column.Key != lastcolumn.Key)
                    {
                        query += ", ";
                    }
                }
                query += ") VALUES (";
                foreach (var column in columns)
                {
                    query += "@"+column.Key;
                    if (column.Key != lastcolumn.Key)
                    {
                        query += ", ";
                    }
                }
                query += "); SELECT seq FROM sqlite_sequence WHERE name='putevoi';";
                SQLiteCommand commandInsert = new SQLiteCommand(query, conn);

                commandInsert.Parameters.Add(new SQLiteParameter("nomer", this.nomer));
                commandInsert.Parameters.Add(new SQLiteParameter("driver_id", this.driver_id));
                commandInsert.Parameters.Add(new SQLiteParameter("engine_id", this.engine_id));
                commandInsert.Parameters.Add(new SQLiteParameter("car_id", this.car_id));
                commandInsert.Parameters.Add(new SQLiteParameter("fuel_start", this.fuel_start));
                commandInsert.Parameters.Add(new SQLiteParameter("fuel_end", this.fuel_end));
                commandInsert.Parameters.Add(new SQLiteParameter("fuel_zapravka", this.fuel_zapravka));
                commandInsert.Parameters.Add(new SQLiteParameter("fuel_karta", this.fuel_karta));
                commandInsert.Parameters.Add(new SQLiteParameter("fuel_cash", this.fuel_cash));
                commandInsert.Parameters.Add(new SQLiteParameter("fuel_norma", this.fuel_norma));
                commandInsert.Parameters.Add(new SQLiteParameter("probeg_start", this.probeg_start));
                commandInsert.Parameters.Add(new SQLiteParameter("probeg_end", this.probeg_end));
                commandInsert.Parameters.Add(new SQLiteParameter("probeg_s_gruzom", this.probeg_s_gruzom));
                commandInsert.Parameters.Add(new SQLiteParameter("probeg_bez_gruza", this.probeg_bez_gruza));
                commandInsert.Parameters.Add(new SQLiteParameter("date_start", this.date_start));
                commandInsert.Parameters.Add(new SQLiteParameter("date_end", this.date_end));
                commandInsert.Parameters.Add(new SQLiteParameter("created_at", this.created_at));
                commandInsert.Parameters.Add(new SQLiteParameter("updated_at", this.updated_at));
                this.id = Convert.ToInt32(commandInsert.ExecuteScalar());
            }
            else
            {
                string query = "UPDATE putevoi SET ";

                var lastcolumn = columns.Last();
                foreach (var column in columns)
                {
                    query += column.Key + "=@" + column.Key;
                    if (column.Key != lastcolumn.Key)
                    {
                        query += ", ";
                    }
                }
                query += " WHERE id = @id;";


                SQLiteCommand commandUpdate = new SQLiteCommand(query, conn);
                commandUpdate.Parameters.Add(new SQLiteParameter("id", this.id));
                commandUpdate.Parameters.Add(new SQLiteParameter("nomer", this.nomer));
                commandUpdate.Parameters.Add(new SQLiteParameter("driver_id", this.driver_id));
                commandUpdate.Parameters.Add(new SQLiteParameter("engine_id", this.engine_id));
                commandUpdate.Parameters.Add(new SQLiteParameter("car_id", this.car_id));
                commandUpdate.Parameters.Add(new SQLiteParameter("fuel_start", this.fuel_start));
                commandUpdate.Parameters.Add(new SQLiteParameter("fuel_end", this.fuel_end));
                commandUpdate.Parameters.Add(new SQLiteParameter("fuel_zapravka", this.fuel_zapravka));
                commandUpdate.Parameters.Add(new SQLiteParameter("fuel_karta", this.fuel_karta));
                commandUpdate.Parameters.Add(new SQLiteParameter("fuel_cash", this.fuel_cash));
                commandUpdate.Parameters.Add(new SQLiteParameter("fuel_norma", this.fuel_norma));
                commandUpdate.Parameters.Add(new SQLiteParameter("probeg_start", this.probeg_start));
                commandUpdate.Parameters.Add(new SQLiteParameter("probeg_end", this.probeg_end));
                commandUpdate.Parameters.Add(new SQLiteParameter("probeg_s_gruzom", this.probeg_s_gruzom));
                commandUpdate.Parameters.Add(new SQLiteParameter("probeg_bez_gruza", this.probeg_bez_gruza));
                commandUpdate.Parameters.Add(new SQLiteParameter("date_start", this.date_start));
                commandUpdate.Parameters.Add(new SQLiteParameter("date_end", this.date_end));
                commandUpdate.Parameters.Add(new SQLiteParameter("updated_at", this.updated_at));
                commandUpdate.Parameters.Add(new SQLiteParameter("created_at", this.created_at));
                commandUpdate.ExecuteNonQuery();
            }
        }


        public static void CreateDB(SQLiteConnection conn)
        {
            string table_name = "putevoi";
            string query = "CREATE TABLE IF NOT EXISTS "+table_name+" (id INTEGER PRIMARY KEY AUTOINCREMENT,";
            var lastcolumn = columns.Last();
            foreach(var column in columns)
            {
                query += column.Key + " " + column.Value;
                if (column.Key != lastcolumn.Key)
                {
                    query += ", ";
                }
            }
            query += ");";

            SQLiteCommand tableCreate = new SQLiteCommand(query, conn);
            tableCreate.ExecuteNonQuery();

            foreach (var column in columns)
            {
                try
                {
                    SQLiteCommand updateTable = new SQLiteCommand("ALTER TABLE " + table_name + " ADD COLUMN " + column.Key + " " + column.Value, conn);
                    updateTable.ExecuteNonQuery();
                }
                catch { }
               
            }
        }

        private static long getInt(string column, SQLiteDataReader r)
        {
            return Convert.ToInt32((r[column] is DBNull) ? 0 : r[column]);
        }

        private static string getString(string column, SQLiteDataReader r)
        {
            return ((r[column] is DBNull) ? "" : r[column]).ToString();
        }

        private static float getFloat(string column, SQLiteDataReader r)
        {
            return Convert.ToSingle((r[column] is DBNull) ? 0 : r[column]);
        }
    }
}
