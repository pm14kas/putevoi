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
    class Car
    {
        public long id{ get; private set; }
        public float weight;
        public string gosnomer;
        public string marka;
        public float rashod;
        public long created_at { get; private set; }
        public long updated_at { get; private set; }

        private static Dictionary<String, String> columns = new Dictionary<string, string> {

                    { "weight", "REAL"},
                    { "gosnomer", "TEXT"},
                    { "marka", "TEXT"},
                    { "rashod", "REAL"},
                    { "created_at", "INTEGER"},
                    {"updated_at", "INTEGER"}
        };

        public Car()
        {
            id = 0;
            weight = 0;
            gosnomer = "";
            marka = "";
            rashod = 0;
            created_at = UnixTime.Now;
            updated_at = UnixTime.Now;
        }

        public Car (SQLiteCommand command)
        {
            SQLiteDataReader r = command.ExecuteReader();
            while (r.Read())
            {
                id = Convert.ToInt32(r["id"].ToString());
                weight = getFloat("weight", r);
                gosnomer = getString("gosnomer", r);
                marka = getString("marka", r);
                rashod = getFloat("rashod", r);
                created_at = getInt("created_at", r);
                updated_at = getInt("updated_at", r);
                break;
            }
            r.Close();
        }

        public static List<Car> GetList(SQLiteCommand command)
        {
            SQLiteDataReader r = command.ExecuteReader();
            List<Car> data = new List<Car>();
            while (r.Read())
            {
                Car car = new Car();
                car.id = Convert.ToInt32(r["id"].ToString());
                car.weight = getFloat("weight", r);
                car.gosnomer = getString("gosnomer", r);
                car.marka = getString("marka", r);
                car.rashod = getFloat("rashod", r);
                car.created_at = getInt("created_at", r);
                car.updated_at = getInt("updated_at", r);
                data.Add(car);
            }
            r.Close();
            return data;
        }

        public static Car Find(long id, SQLiteConnection conn)
        {
            SQLiteCommand commandSelect = new SQLiteCommand("SELECT * FROM cars WHERE id=@id", conn);
            commandSelect.Parameters.Add(new SQLiteParameter("id", id));
            Car car = new Car(commandSelect);
            return car;
        }

        public static List<Car> All(SQLiteConnection conn)
        {
            List<Car> car = Car.GetList(new SQLiteCommand("SELECT * FROM cars", conn));
            return car;
        }

        public void Save(SQLiteConnection conn)
        {
            this.updated_at = UnixTime.Now;
            if (this.id == 0)
            {

                string query = "INSERT INTO cars(";

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
                query += "); SELECT seq FROM sqlite_sequence WHERE name='cars';";
                SQLiteCommand commandInsert = new SQLiteCommand(query, conn);
                commandInsert.Parameters.Add(new SQLiteParameter("weight", this.weight));
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
                string query = "UPDATE cars SET ";

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
                commandUpdate.Parameters.Add(new SQLiteParameter("weight", this.weight));
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
            string table_name = "cars";
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
            return marka + " " + gosnomer +" вес "+ weight.ToString()+"т";
        }
    }
}
