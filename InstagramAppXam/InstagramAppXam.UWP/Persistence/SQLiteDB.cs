using System;
using System.IO;
using SQLite;
using Windows.Storage;
using Xamarin.Forms;
using InstagramAppXam.UWP;

[assembly: Dependency(typeof(SQLiteDB))]

namespace InstagramAppXam.UWP
{
    public class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(documentsPath, "SQLiteDb.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}
