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
    class Engine
    {
        public long id;
        public string marka;
        public string gosnomer;
        public float rashod;
        public long created_at { get; private set; }
        public long updated_at { get; private set; }

         private static Dictionary<String, String> columns = new Dictionary<string, string> {
                    { "gosnomer", "TEXT"},
                    { "marka", "TEXT"},
                    { "rashod", "REAL"},
                    { "created_at", "INTEGER"},
                    {"updated_at", "INTEGER"}
        };

        public Engine()
        {
            id = 0;
            gosnomer = "";
            marka = "";
            rashod = 0;
            created_at = UnixTime.Now;
            updated_at = UnixTime.Now;
        }

        public Engine (SQLiteCommand command)
        {
            SQLiteDataReader r = command.ExecuteReader();
            while (r.Read())
            {
                id = Convert.ToInt32(r["id"].ToString());
                gosnomer = getString("gosnomer", r);
                marka = getString("marka", r);
                rashod = getFloat("rashod", r);
                created_at = getInt("created_at", r);
                updated_at = getInt("updated_at", r);
                break;
            }
            r.Close();
        }

        public static List<Engine> GetList(SQLiteCommand command)
        {
            SQLiteDataReader r = command.ExecuteReader();
            List<Engine> data = new List<Engine>();
            while (r.Read())
            {
                Engine engine = new Engine();
                engine.id = Convert.ToInt32(r["id"].ToString());
                engine.gosnomer = getString("gosnomer", r);
                engine.marka = getString("marka", r);
                engine.rashod = getFloat("rashod", r);
                engine.created_at = getInt("created_at", r);
                engine.updated_at = getInt("updated_at", r);
                data.Add(engine);
            }
            r.Close();
            return data;
        }

        public static Engine Find(long id, SQLiteConnection conn)
        {
            SQLiteCommand commandSelect = new SQLiteCommand("SELECT * FROM engines WHERE id=@id", conn);
            commandSelect.Parameters.Add(new SQLiteParameter("id", id));
            Engine engine = new Engine(commandSelect);
            return engine;
        }

        public static List<Engine> All(SQLiteConnection conn)
        {
            List<Engine> engine = Engine.GetList(new SQLiteCommand("SELECT * FROM engines", conn));
            return engine;
        }

        public void Save(SQLiteConnection conn)
        {
            this.updated_at = UnixTime.Now;
            if (this.id == 0)
            {

                string query = "INSERT INTO engines(";

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
                query += "); SELECT seq FROM sqlite_sequence WHERE name='engines';";
                SQLiteCommand commandInsert = new SQLiteCommand(query, conn);
                commandInsert.Parameters.Add(new SQLiteParameter("gosnomer", this.gosnomer));
                commandInsert.Parameters.Add(new SQLiteParameter("marka", this.marka));
                commandInsert.Parameters.Add(new SQLiteParameter("rashod", this.rashod));
                commandInsert.Parameters.Add(new SQLiteParameter("created_at", this.created_at));
                commandInsert.Parameters.Add(new SQLiteParameter("updated_at", this.updated_at));
                System.Diagnostics.Debug.WriteLine(commandInsert.CommandText);
                this.id = Convert.ToInt32(commandInsert.ExecuteScalar());
            }
            else
            {
                string query = "UPDATE engines SET ";

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
                commandUpdate.Parameters.Add(new SQLiteParameter("gosnomer", this.gosnomer));
                commandUpdate.Parameters.Add(new SQLiteParameter("marka", this.marka));
                commandUpdate.Parameters.Add(new SQLiteParameter("rashod", this.rashod));
                commandUpdate.Parameters.Add(new SQLiteParameter("updated_at", this.updated_at));
                commandUpdate.Parameters.Add(new SQLiteParameter("created_at", this.created_at));
                commandUpdate.ExecuteNonQuery();
            }
        }


        public static void CreateDB(SQLiteConnection conn)
        {
            string table_name = "engines";
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

        private static float getFloat(string column, SQLiteDataReader r)
        {
            return Convert.ToSingle((r[column] is DBNull) ? 0: r[column]);
        }

        private static string getString(string column, SQLiteDataReader r)
        {
            return ((r[column] is DBNull) ? "" : r[column]).ToString();
        }

        public string Name()
        {
            return marka + " " + gosnomer;
        }
        
    }
}
