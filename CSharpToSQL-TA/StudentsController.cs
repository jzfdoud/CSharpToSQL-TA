using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpToSQL_TA
{
    public class StudentsController
    {
        private Connection connection { get; set; }

        public bool Remove(int id)
        {
            var sql = $"DELETE from Student where Id = @id;";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@id", id);
            var rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected == 1;
        }

        public bool Change(Student student)
        {
            var sql = $"UPDATE Student Set " +
                "Firstname = @firstname, " +
                "Lastname = @lastname, " +
                "StateCode = @statecode, " +
                "SAT = @sat, " +
                "GPA = @gpa " +
                "where Id = @id;";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@firstname", student.Firstname);
            cmd.Parameters.AddWithValue("@lastname", student.Lastname);
            cmd.Parameters.AddWithValue("@statecode", student.StateCode);
            cmd.Parameters.AddWithValue("@sat", student.SAT);
            cmd.Parameters.AddWithValue("@gpa", student.GPA);
            cmd.Parameters.AddWithValue("@id", student.Id);
            var recsAffected = cmd.ExecuteNonQuery();
            return recsAffected == 1;
        }

        public bool Create(Student student)
        {
            var sql = $"INSERT into Student" +
                    " (Firstname, Lastname, StateCode, SAT, GPA)" +
                    $" VALUES ('{student.Firstname}', '{student.Lastname}', " +
                    $"'{student.StateCode}', {student.SAT}, {student.GPA});";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected == 1;
        }

        public Student GetByPK(int id)
        {
            var sql = $"SELECT * from Student" +
                      $" where id = {id};";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            var hasRow = reader.Read();

            if (!hasRow)
            {
                return null;
            }

            var student = new Student();
            student.Id = Convert.ToInt32(reader["Id"]);
            student.Firstname = reader["Firstname"].ToString();
            student.Lastname = reader["Lastname"].ToString();
            student.StateCode = reader["StateCode"].ToString();
            student.SAT = Convert.ToInt32(reader["SAT"]);
            student.GPA = Convert.ToDecimal(reader["GPA"]);
            //student.Major = null;
            //if (reader["Description"] != System.DBNull.Value)
            //{
            //    student.Major = reader["Description"].ToString();
            //}
            reader.Close();
            return student;
        }

        public List<Student> GetAll()
        {
            //var sql = "SELECT * from Student s" +
            //            " left join Major m on s.MajorId = m.Id" +
            //            " order by s.Lastname;";
            var sql = "SELECT * from Student";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            var students = new List<Student>();
            while (reader.Read())
            {
                var student = new Student();
                student.Id = Convert.ToInt32(reader["Id"]);
                student.Firstname = reader["Firstname"].ToString();
                student.Lastname = reader["Lastname"].ToString();
                student.StateCode = reader["StateCode"].ToString();
                student.SAT = Convert.ToInt32(reader["SAT"]);
                student.GPA = Convert.ToDecimal(reader["GPA"]);
                //student.Major = null;
                //if(reader["Description"] != System.DBNull.Value) 
                //{
                //    student.Major = reader["Description"].ToString();
                //}
                student.MajorId = null;
                if (reader["MajorId"] != System.DBNull.Value)
                {
                    student.MajorId = Convert.ToInt32(reader["MajorId"]);
                }
                students.Add(student);

            }
            reader.Close();
            return students;
        }



        public StudentsController(Connection connection)
        {
            this.connection = connection;
        }


    }
}
