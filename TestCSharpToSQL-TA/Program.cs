using CSharpToSQL_TA;
using Microsoft.Data.SqlClient;
using System;

namespace TestCSharpToSQL_TA
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Day 9 C# : C# to SQL ------------------------------------------------------

            var sql = new EducDbLib();
            sql.Connect("EdDb");
            Console.WriteLine("Connection successful");
            sql.ExecSelect();
            sql.Disconnect();
            */


            /* 
             // Day 10 C# : Contd. C# to SQL ------------------------------------------------

             var conn = new Connection();
             conn.Connect("EdDb");
             var studentController = new StudentsController(conn);

            // ------------- Update() -------------------
             var updateStudent = new Student
             {
                 Id = 74,
                 Firstname = "Jane",
                 Lastname = "Doe",
                 StateCode = "DE",
                 SAT = 500,
                 GPA = 1.5m,
                 Major = null
             };
             var success = studentController.Change(updateStudent);

            // ------------- Create() -------------------

             //var newStudent = new Student
             //{
             //    Id = 0,
             //    Firstname = "John",
             //    Lastname = "Doe",
             //    StateCode = "DE",
             //    SAT = 0,
             //    GPA = 1.2m,
             //    Major = null
             //};
             //var success = studentController.Create(newStudent);

            // -------------- GetByPK() -----------------

             var student = studentController.GetByPK(74);
             Console.WriteLine($"{student.Id} | {student.Firstname} {student.Lastname}");

            // -------------- Remove() ------------------

             success = studentController.Remove(75);
             Console.WriteLine($"Remove worked! {success}");

             // ------------- GetAll() ------------------
             
             var students = studentController.GetAll();
             foreach (var s in students)
             {
                 Console.WriteLine($"{s.Id} | {s.Firstname} {s.Lastname} | {s.Major}");
             }
            */

            // Day #11 C# to SQL contd. --------------------------------------------------------

            var conn = new Connection();
            conn.Connect("EdDb");
            var majorsController = new MajorsController(conn);

            // ------------- Create() ------------------------
            //var major = new Major { Code = "BAR", Description = "Bar Critic", MinSAT = 800 };
            //var rc = majorsController.Create(major);
            //Console.WriteLine($"Create worked: {rc}");

            // ------------- Update() ------------------------



            // ------------- GetAll() ------------------------

            var majors = majorsController.GetAll();
            foreach(var m in majors)
            {
                Console.WriteLine($"{m.Code} | {m.Description} | MinSAT: {m.MinSAT}");
            }



            conn.Disconnect();


        }
    }
}
