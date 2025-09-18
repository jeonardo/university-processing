import { LockOutlined } from '@mui/icons-material';
import { Avatar, Box, Container, FormControl, InputLabel, MenuItem, Select, Typography } from '@mui/material';
import { useState } from 'react';
import RegisterAdminForm from './components/RegisterAdminForm';
import RegisterStudentForm from './components/RegisterStudentForm';
import { Link } from 'react-router-dom';
import { ApiContractsUserRoleTypeDto as ContractsUserRoleType } from 'src/api/backendApi';
import RegisterTeacherForm from './components/RegisterTeacherForm';
import RegisterDeaneryForm from './components/RegisterDeaneryForm';
import { RoleLocalizationLabel } from 'src/core/labelStore';

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
            setUserRole(e.target.value as ContractsUserRoleType);
          }}
        >
          <MenuItem disabled
            value={ContractsUserRoleType.None}>{RoleLocalizationLabel(ContractsUserRoleType.None)}</MenuItem>
          <MenuItem value={ContractsUserRoleType.Admin}>{RoleLocalizationLabel(ContractsUserRoleType.Admin)}</MenuItem>
          <MenuItem
            value={ContractsUserRoleType.Deanery}>{RoleLocalizationLabel(ContractsUserRoleType.Deanery)}</MenuItem>
          <MenuItem
            value={ContractsUserRoleType.Teacher}>{RoleLocalizationLabel(ContractsUserRoleType.Teacher)}</MenuItem>
          <MenuItem
            value={ContractsUserRoleType.Student}>{RoleLocalizationLabel(ContractsUserRoleType.Student)}</MenuItem>
        </Select>
      </FormControl>

      {
        userRole == 'Student'
          ? <RegisterStudentForm redirectToLogin={true} />
          : <></>
      }
      {
        userRole == 'Admin'
          ? <RegisterAdminForm redirectToLogin={true} />
          : <></>
      }
      {
        userRole == 'Teacher'
          ? <RegisterTeacherForm redirectToLogin={true} />
          : <></>
      }
      {
        userRole == 'Deanery'
          ? <RegisterDeaneryForm redirectToLogin={true} />
          : <></>
      }

      <Box sx={{ p: 3, textAlign: 'center' }}>
        <Link to="/signin">Уже есть аккаунт? Авторизоваться</Link>
      </Box>

    </Container>
  );
};

export default RegisterPage;