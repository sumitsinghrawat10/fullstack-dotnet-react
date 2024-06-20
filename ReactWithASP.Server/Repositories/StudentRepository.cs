
using Microsoft.Data.SqlClient;
using StudentCourseAPI.Models;
using System.Data;

namespace StudentCourseAPI.Repositories
{
    public class StudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Student> GetStudents()
        {
            var students = new List<Student>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Assuming "GetStudentData" is the stored procedure to fetch students
                    using (var command = new SqlCommand("GetStudentData", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                students.Add(new Student
                                {
                                    StudentId = (int)reader["student_id"],
                                    StudentName = reader["student_name"].ToString(),
                                    Course = reader["course"].ToString()
                                });

                           
                                Console.WriteLine($"Fetched student: Id={students[^1].StudentId}, Name={students[^1].StudentName}, Course={students[^1].Course}");
                            }
                        }
                    }
                }

              
                Console.WriteLine($"Total students fetched: {students.Count}");
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL error: {sqlEx.Message}");
          
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
           
            }

            return students;
        }
    }
}
