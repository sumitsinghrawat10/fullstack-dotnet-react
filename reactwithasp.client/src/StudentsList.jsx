import { useState, useEffect } from 'react';
import CoursesList from './CoursesList';
import axios from 'axios';

const StudentsList = () => {
  const [students, setStudents] = useState([]);
  const [selectedStudent, setSelectedStudent] = useState(null);

  useEffect(() => {
    axios.get('http://localhost:5081/api/students')
      .then(response => {
        setStudents(response.data);
      })
      .catch(error => {
        console.error('Error fetching students:', error);
      });
  }, []);

  const handleStudentChange = (event) => {
    const studentId = event.target.value;
    setSelectedStudent(studentId);
  };

  return (
    <div>
      <h2>Students List</h2>
      <select onChange={handleStudentChange}>
        <option value="">Select a student</option>
        {students.map(student => (
          <option key={student.studentId} value={student.studentId}>
            {student.studentName}
          </option>
        ))}
      </select>

      {selectedStudent && <CoursesList studentId={selectedStudent} />}
    </div>
  );
};

export default StudentsList;
