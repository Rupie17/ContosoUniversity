/* The #if SQLiteVersion preprocessor directive isolates the differences in the SQLite and SQL Server versions and helps:
The author maintain one code base for both versions.
SQLite developers deploy the app to Azure and use SQL Azure. */

#if SQLiteVersion
using System;

namespace ContosoUniversity
{
    public static class Utility
    {
        public static string GetLastChars(Guid token)
        {
            return token.ToString().Substring(
                                    token.ToString().Length - 3);
        }
    }
}
#else
namespace ContosoUniversity
{
    public static class Utility
    {
        public static string GetLastChars(byte[] token)
        {
            return token[7].ToString();
        }
    }
}
#endif
