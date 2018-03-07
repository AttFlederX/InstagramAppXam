using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using InstagramAppXam.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDB))]

namespace InstagramAppXam.Droid
{
    public class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "SQLiteDb.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}