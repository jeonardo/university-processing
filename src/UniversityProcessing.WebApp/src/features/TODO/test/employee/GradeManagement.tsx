import type React from 'react';
import { useState } from 'react';
import {
  Button,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  TextField,
  Typography
} from '@mui/material';

interface StudentGrade {
  id: number;
  studentName: string;
  topicTitle: string;
  supervisorName: string;
  grade: string;
}

const GradeManagement: React.FC = () => {
  const [grades, setGrades] = useState<StudentGrade[]>([
    {
      id: 1,
      studentName: 'Alice Johnson',
      topicTitle: 'Machine Learning in Healthcare',
      supervisorName: 'Dr. John Doe',
      grade: ''
    },
    {
      id: 2,
      studentName: 'Bob Smith',
      topicTitle: 'Blockchain for Supply Chain Management',
      supervisorName: 'Prof. Jane Smith',
      grade: ''
    },
    {
      id: 3,
      studentName: 'Charlie Brown',
      topicTitle: 'Sustainable Energy Solutions',
      supervisorName: 'Dr. Michael Johnson',
      grade: ''
    }
  ]);

  const handleGradeChange = (id: number, newGrade: string) => {
    const updatedGrades = grades.map((grade) => (grade.id === id ? { ...grade, grade: newGrade } : grade));
    setGrades(updatedGrades);
  };

  const handleSubmit = () => {
    // Here you would typically send the grades to your backend
    console.log('Submitted grades:', grades);
    // You might want to show a success message or handle errors here
  };

  return (
    <div className="space-y-4">
      <Typography variant="h6" gutterBottom>
        Grade Management
      </Typography>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Student Name</TableCell>
              <TableCell>Topic Title</TableCell>
              <TableCell>Supervisor Name</TableCell>
              <TableCell>Grade</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {grades.map((grade) => (
              <TableRow key={grade.id}>
                <TableCell>{grade.studentName}</TableCell>
                <TableCell>{grade.topicTitle}</TableCell>
                <TableCell>{grade.supervisorName}</TableCell>
                <TableCell>
                  <TextField
                    value={grade.grade}
                    onChange={(e) => handleGradeChange(grade.id, e.target.value)}
                    type="number"
                    inputProps={{ min: '0', max: '100', step: '1' }}
                  />
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <Button variant="contained" color="primary" onClick={handleSubmit}>
        Submit Grades
      </Button>
    </div>
  );
};

export default GradeManagement;

