using CMS.Tables;

namespace CMS.Constants
{
    public static class ConstantRecord
    {
        public const string LoginStatus = "LoginStatus";
        public const string LoginUserId = "LoginUserId";


        public const string DatabaseFilename = "CMSDB.db";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);

        public static Patient SelectedPatient { get; set; }
    }
}
