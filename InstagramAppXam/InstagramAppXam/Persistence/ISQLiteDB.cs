using SQLite;

namespace InstagramAppXam
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
