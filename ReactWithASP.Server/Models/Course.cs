namespace StudentCourseAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AssignedStudentId { get; set; }
    }
}
