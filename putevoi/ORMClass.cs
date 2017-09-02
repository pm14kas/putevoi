using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;


namespace System.Data.SQLite.ORM
{
    class ORMClass //Basic ORM class
    {
        public long id //Primary key of object
        {
            get
            {
                return Convert.ToInt64(this.values["id"]);
            }
            private set{
                this.values["id"] = value.ToString();
            }
        }

        public DateTime created_at //DateTime of object creation
        {
            get
            {
                return UnixTime.From(Convert.ToInt64(this.values["created_at"]));
            }
            private set
            {
                this.values["created_at"] = UnixTime.To(value).ToString();
            }
        }
        public DateTime updated_at //DateTime of last object edit
        {
            get
            {
                return UnixTime.From(Convert.ToInt64(this.values["updated_at"]));
            }
            private set
            {
                this.values["updated_at"] = UnixTime.To(value).ToString();
            }
        }

        protected static Dictionary<String, String> columns; //Column names stored in related table
        protected static string table_name; //Model table name
        protected static SQLiteConnection conn; //SQLite connection
        protected Dictionary<String, String> values = new Dictionary<string,string>(); //Object Properties

        public ORMClass() //Empty object constructor
        {
            foreach (var column in columns)
            {
                if ((column.Key == "created_at") || (column.Key == "updated_at"))
                {
                    this.values.Add(column.Key, UnixTime.Now.ToString());

                }
                else
                {
                    if (column.Value == "TEXT")
                    {
                        this.values.Add(column.Key, "");
                    }
                    else
                    {
                        this.values.Add(column.Key, "0");
                    }
                }
            }
        }

        public ORMClass(SQLiteCommand command) //Returns first object from command query
        {
            SQLiteDataReader r = command.ExecuteReader();
            while (r.Read())
            {
                foreach (var column in columns)
                {
                    if (column.Value == "TEXT")
                    {
                        this.values.Add(column.Key, ((r[column.Key] is DBNull) ? default(string) : r[column.Key]).ToString());
                    }
                    else
                    {
                        this.values.Add(column.Key, ((r[column.Key] is DBNull) ? default(long) : r[column.Key]).ToString());
                    }
                }
                break;
            }
            r.Close();
        }
        public static List<ORMClass> GetList(SQLiteCommand command) //Returns List containing objects from command query
        {
            SQLiteDataReader r = command.ExecuteReader();
            List<ORMClass> data = new List<ORMClass>();
            while (r.Read())
            {
                ORMClass o = new ORMClass();
                foreach (var column in columns)
                {
                    if (column.Value == "TEXT")
                    {
                        o[column.Key] = ((r[column.Key] is DBNull) ? default(string) : r[column.Key]).ToString();
                    }
                    else
                    {
                        o[column.Key] = ((r[column.Key] is DBNull) ? default(long) : r[column.Key]).ToString();
                    }
                }
                data.Add(o);
            }
            r.Close();
            return data;
        }

        public static ORMClass Find(long id) //Returns object with given id if exists. If not, returns new object
        {
            ORMClass o = new ORMClass(new SQLiteCommand("SELECT * FROM putevoi WHERE id=@id", conn));
            return o;
        }

        public static List<ORMClass> All()//Returns List containing all objects
        {
            List<ORMClass> putevoi = ORMClass.GetList(new SQLiteCommand("SELECT * FROM " + table_name, conn));
            return putevoi;
        }

        public void Save() //Creates record in database or updates an existing one
        {
            this.updated_at = DateTime.Now;
            if (this.id == 0)
            {

                string query = "INSERT INTO "+table_name+"(";

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

                foreach (var column in columns)
                {
                    commandInsert.Parameters.Add(new SQLiteParameter(column.Key, this.values[column.Key]));
                }

                this.values["id"] = commandInsert.ExecuteScalar().ToString();
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
                foreach (var column in columns)
                {
                    commandUpdate.Parameters.Add(new SQLiteParameter(column.Key, this.values[column.Key]));
                }
                commandUpdate.ExecuteNonQuery();
            }
        }


        public static void CreateTable(SQLiteConnection _conn/* ,Dictionary<String, String> _columns*/) //Creates table for model and adds missing columns, must be called as soon as application starts
        {
            //columns = _columns;
            if (columns.ContainsKey("id")){columns["id"] = "INTEGER PRIMARY KEY AUTOINCREMENT";} 
            else {columns.Add("id", "INTEGER PRIMARY KEY AUTOINCREMENT");}

            if (columns.ContainsKey("created_at")){columns["created_at"] = "INTEGER";}
            else{columns.Add("created_at", "INTEGER");}

            if (columns.ContainsKey("updated_at")){columns["updated_at"] = "INTEGER";}
            else{columns.Add("updated_at", "INTEGER");}

            conn = _conn;
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


        public T Get<T>(string column) //returns value of given attribute
        {
            return (T) Convert.ChangeType(values[column], typeof(T));
        } 

        public string this[string column] //returns value of given attribute as string
        {
            get
            {
                return values[column];
            }
            set
            {
                values[column] = value;
            }
        }

        public Dictionary<string, string> getValues()
        {
            return values;
        }



    }
}
