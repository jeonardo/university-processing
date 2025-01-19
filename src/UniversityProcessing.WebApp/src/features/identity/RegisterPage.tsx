import { LockOutlined } from '@mui/icons-material';
import { Avatar, Box, Container, FormControl, InputLabel, MenuItem, Select, Typography } from '@mui/material';
import { useState } from 'react';
import RegisterAdminForm from './RegisterAdminForm';
import RegisterEmployeeForm from './RegisterEmployeeForm';
import RegisterStudentForm from './RegisterStudentForm';
import { Link } from 'react-router-dom';
import { ContractsUserRoleType } from 'src/api/backendApi';

const RegisterPage = () => {
  const [userRole, setUserRole] = useState<ContractsUserRoleType>(ContractsUserRoleType.None);

  return (
    <Container
      className="flex flex-col max-h-full place-items-center"
      maxWidth="xs">

      <Avatar sx={{ bgcolor: 'primary.light' }}>
        <LockOutlined />
      </Avatar>

      <Typography sx={{ p: 2 }} variant="h5">Форма регистрации</Typography>

      <FormControl fullWidth>
        <InputLabel id="user-role-label">Роль</InputLabel>
        <Select
          labelId="user-role-label"
          id="user-role-select"
          value={userRole}
          label="Роль"
          onChange={(e) => {
            switch (e.target.value) {
              case ContractsUserRoleType.Student:
                setUserRole(ContractsUserRoleType.Student);
                break;
              case ContractsUserRoleType.Admin:
                setUserRole(ContractsUserRoleType.Admin);
                break;
              case ContractsUserRoleType.Employee:
                setUserRole(ContractsUserRoleType.Employee);
                break;
              default:
                setUserRole(ContractsUserRoleType.None);
                break;
            }
          }}
        >
          <MenuItem disabled value={ContractsUserRoleType.None}>Не выбрана</MenuItem>
          <MenuItem value={ContractsUserRoleType.Student}>Студент</MenuItem>
          <MenuItem value={ContractsUserRoleType.Admin}>Администратор</MenuItem>
          <MenuItem value={ContractsUserRoleType.Employee}>Сотрудник университета</MenuItem>
        </Select>
      </FormControl>

      {
        userRole == 'Admin'
          ? <RegisterAdminForm />
          : userRole == 'Employee'
            ? <RegisterEmployeeForm />
            : userRole == 'Student'
              ? <RegisterStudentForm />
              : <></>
      }

      <Box sx={{ p: 3, textAlign: 'center' }}>
        <Link to="/signin">Уже есть аккаунт? Авторизоваться</Link>
      </Box>

    </Container>
  );
};

export default RegisterPage;