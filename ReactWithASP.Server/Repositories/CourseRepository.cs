//using Microsoft.Data.SqlClient;
//using StudentCourseAPI.Models;
//using System.Data;

//namespace StudentCourseAPI.Repositories
//{
//    public class CourseRepository
//    {
//        private readonly string _connectionString;

//        public CourseRepository(string connectionString)
//        {
//            _connectionString = connectionString;
//        }

//        public IEnumerable<Course> GetCourses()
//        {
//            var courses = new List<Course>();

//            using (var connection = new SqlConnection(_connectionString))
//            {
//                connection.Open();

//                // Assuming "GetCourseData" is the stored procedure to fetch courses
//                using (var command = new SqlCommand("GetCourseData", connection))
//                {
//                    command.CommandType = CommandType.StoredProcedure;

//                    using (var reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            courses.Add(new Course
//                            {
//                                Id = (int)reader["course_id"],
//                                Name = reader["course_name"].ToString(),
//                                AssignedStudentId = reader["assigned_student_id"] != DBNull.Value ? (int)reader["assigned_student_id"] : (int?)null
//                            });
//                        }
//                    }
//                }
//            }

//            return courses;
//        }
//    }
//}
using Microsoft.Data.SqlClient;
using StudentCourseAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace StudentCourseAPI.Repositories
{
    public class CourseRepository
    {
        private readonly string _connectionString;

        public CourseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Course> GetCourses()
        {
            var courses = new List<Course>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Using the stored procedure "GetCourseData" to fetch courses
                    using (var command = new SqlCommand("GetCourseData", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                courses.Add(new Course
                                {
                                    Id = (int)reader["course_id"],
                                    Name = reader["course_name"].ToString(),
                                    AssignedStudentId = reader["assigned_student_id"] != DBNull.Value ? (int)reader["assigned_student_id"] : (int?)null
                                });

                                // Log fetched course details to the console
                                Console.WriteLine($"Fetched course: Id={courses[^1].Id}, Name={courses[^1].Name}, AssignedStudentId={courses[^1].AssignedStudentId}");
                            }
                        }
                    }
                }

                // Log the total number of courses fetched
                Console.WriteLine($"Total courses fetched: {courses.Count}");
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
            }

            return courses;
        }
    }
}
