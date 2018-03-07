using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using InstagramAppXam.iOS;

[assembly: Dependency(typeof(SQLiteDB))]

namespace InstagramAppXam.iOS
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