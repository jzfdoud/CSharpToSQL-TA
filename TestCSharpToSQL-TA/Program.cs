using CSharpToSQL_TA;
using Microsoft.Data.SqlClient;
using System;

namespace TestCSharpToSQL_TA
{
    class Program
    {
        static void Main(string[] args)
        {
            var sql = new EducDbLib();
            sql.Connect("EdDb");
            Console.WriteLine("Connection successful");
            sql.ExecSelect();
            sql.Disconnect();
        }
    }
}
