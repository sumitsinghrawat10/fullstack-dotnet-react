import { useState, useEffect } from 'react';
import axios from 'axios';

// eslint-disable-next-line react/prop-types
const CoursesList = ({ studentId }) => {
  const [courses, setCourses] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5081/api/courses')
      .then(response => {
        setCourses(response.data);
      })
      .catch(error => {
        console.error('Error fetching courses:', error);
      });
  }, []);

  const filteredCourses = courses.filter(course => course.assignedStudentId === Number(studentId));
  console.log(filteredCourses,studentId  )

  return (
    <div>
      <h2>Courses List</h2>
      <ul>
        {filteredCourses.map(course => (
          <li key={course.id}>
            {course.name} - {course.assignedStudentId}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default CoursesList;
