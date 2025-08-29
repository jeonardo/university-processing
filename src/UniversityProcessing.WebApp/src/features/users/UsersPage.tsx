import React, { useEffect, useMemo, useState } from 'react';
import { Box, Button, Container, Paper, Typography } from '@mui/material';
import AppList from 'src/components/lists/AppList';
import AppListPagination from 'src/components/lists/AppListPagination';
import AppListSearch from 'src/components/lists/AppListSearch';
import { ContractsUserRoleType, useGetApiUsersGetAdminsQuery, useGetApiUsersGetDeaneriesQuery, useGetApiUsersGetStudentsQuery, useGetApiUsersGetTeachersQuery, useLazyGetApiUsersGetAdminsQuery, useLazyGetApiUsersGetDeaneriesQuery, useLazyGetApiUsersGetStudentsQuery, useLazyGetApiUsersGetTeachersQuery } from 'src/api/backendApi';
import { usePagedSearch } from 'src/core/usePagedSearch';
import { useRequireAdmin, useAppSelector, getAvailableRoles, canCreateUser } from 'src/core';
import RoleSwitchPanel from './RoleSwitchPanel';
import RegisterAdminForm from '../auth/components/RegisterAdminForm';
import RegisterDeaneryForm from '../auth/components/RegisterDeaneryForm';
import RegisterTeacherForm from '../auth/components/RegisterTeacherForm';
import RegisterStudentForm from '../auth/components/RegisterStudentForm';
import ModalForm from 'src/components/layout/ModalForm';
import AdminUserItem from './items/AdminUserItem';
import TeacherUserItem from './items/TeacherUserItem';
import DeaneryUserItem from './items/DeaneryUserItem';
import StudentUserItem from './items/StudentUserItem';
import { selectActiveQuery } from './selectActiveQuery';

type Role =
  | ContractsUserRoleType.Admin
  | ContractsUserRoleType.Deanery
  | ContractsUserRoleType.Teacher
  | ContractsUserRoleType.Student;

const roleToTitle = {
  [ContractsUserRoleType.Admin]: 'Администраторы',
  [ContractsUserRoleType.Deanery]: 'Деканат',
  [ContractsUserRoleType.Teacher]: 'Преподаватели',
  [ContractsUserRoleType.Student]: 'Студенты',
} as const;

const PAGE_SIZE = 25;

const UsersPage: React.FC = () => {
  useRequireAdmin();
  const currentUser = useAppSelector(state => state.auth.user);

  const [role, setRole] = useState<Role>(ContractsUserRoleType.Admin);
  const availableRoles = useMemo(() => getAvailableRoles(currentUser?.role), [currentUser?.role]);

  useEffect(() => {
    if (availableRoles.length > 0 && !availableRoles.includes(role)) {
      setRole(availableRoles[0] as Role);
    }
  }, [availableRoles, role]);

  const [queryArgs, setQueryArgs] = useState<{ filter: string; pageNumber: number; pageSize: number }>({
    filter: '',
    pageNumber: 1,
    pageSize: PAGE_SIZE,
  });

  const { pageNumber, setPageNumber, onSearchValueChanged } = usePagedSearch({
    getData: (args: { filter: string; pageNumber: number; pageSize: number }) => setQueryArgs(args),
    pageSize: PAGE_SIZE,
  });

  const isAllowedRole = availableRoles.includes(role);
  const isAdmin = role === ContractsUserRoleType.Admin;
  const isDean = role === ContractsUserRoleType.Deanery;
  const isTeach = role === ContractsUserRoleType.Teacher;
  const isStud = role === ContractsUserRoleType.Student;

  // Активен только один useQuery
  const admins = useGetApiUsersGetAdminsQuery(queryArgs, {
    skip: !isAllowedRole || !isAdmin,
    pollingInterval: isAdmin ? 15000 : 0,
  });
  const deaneries = useGetApiUsersGetDeaneriesQuery(queryArgs, {
    skip: !isAllowedRole || !isDean,
    pollingInterval: isDean ? 15000 : 0,
  });
  const teachers = useGetApiUsersGetTeachersQuery(queryArgs, {
    skip: !isAllowedRole || !isTeach,
    pollingInterval: isTeach ? 15000 : 0,
  });
  const students = useGetApiUsersGetStudentsQuery(queryArgs, {
    skip: !isAllowedRole || !isStud,
    pollingInterval: isStud ? 15000 : 0,
  });

  // Нормализуем активное состояние
  const { data, isLoading, refetch } = selectActiveQuery(role, {
    admins,
    deaneries,
    teachers,
    students,
  });

  const [isModalOpen, setIsModalOpen] = useState(false);
  const title = roleToTitle[role];
  const items = useMemo(() => data?.list?.items ?? [], [data]);

  const handleRoleChange = (nextRole: ContractsUserRoleType) => {
    setRole(nextRole as Role);
    setPageNumber(1);
    setQueryArgs((prev) => ({ ...prev, pageNumber: 1 }));
  };

  return (
    <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="md">
      <ModalForm open={isModalOpen} onClose={() => setIsModalOpen(false)} title={"Добавить пользователя"}>
        {role === ContractsUserRoleType.Admin &&
          canCreateUser(currentUser?.role, ContractsUserRoleType.Admin) && (
            <RegisterAdminForm
              buttonLabel="Добавить"
              onSuccess={() => {
                setIsModalOpen(false);
                refetch();
              }}
            />
          )}
        {role === ContractsUserRoleType.Deanery &&
          canCreateUser(currentUser?.role, ContractsUserRoleType.Deanery) && (
            <RegisterDeaneryForm
              buttonLabel="Добавить"
              onSuccess={() => {
                setIsModalOpen(false);
                refetch();
              }}
            />
          )}
        {role === ContractsUserRoleType.Teacher &&
          canCreateUser(currentUser?.role, ContractsUserRoleType.Teacher) && (
            <RegisterTeacherForm
              buttonLabel="Добавить"
              onSuccess={() => {
                setIsModalOpen(false);
                refetch();
              }}
            />
          )}
        {role === ContractsUserRoleType.Student &&
          canCreateUser(currentUser?.role, ContractsUserRoleType.Student) && (
            <RegisterStudentForm
              buttonLabel="Добавить"
              onSuccess={() => {
                setIsModalOpen(false);
                refetch();
              }}
            />
          )}
      </ModalForm>

      <RoleSwitchPanel onChange={handleRoleChange} currentUserRole={currentUser?.role} />
      <Paper className="p-6">
        <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 3, gap: 2, alignItems: 'center' }}>
          <Typography variant="h4" component="h1" className="font-bold">
            {title}
          </Typography>
        </Box>
        <AppListSearch
          label="Поиск"
          placeholder='Введите ФИО'
          onSearchValueChangedDebounced={onSearchValueChanged} />
        <Box sx={{ display: 'flex', justifyContent: 'flex-end', mt: 2 }}>
          <Button variant="contained" onClick={() => setIsModalOpen(true)}>Добавить</Button>
        </Box>
      </Paper>
      <Paper className="p-6" sx={{ display: 'flex', flexGrow: 1, flexDirection: 'column', minHeight: 0 }}>
        <Box sx={{ flex: 1, minHeight: 0 }}>
          <AppList
            isLoading={isLoading}
            isEmpty={items?.length == 0}
            height={'55vh'}>
            {
              items?.map((item: any) => {
                if (role === ContractsUserRoleType.Admin) return <AdminUserItem key={item.id} item={item} />;
                if (role === ContractsUserRoleType.Deanery) return <DeaneryUserItem key={item.id} item={item} />;
                if (role === ContractsUserRoleType.Teacher) return <TeacherUserItem key={item.id} item={item} />;
                if (role === ContractsUserRoleType.Student) return <StudentUserItem key={item.id} item={item} />;
                return null;
              })
            }
          </AppList>
        </Box>
      </Paper>
      <Paper sx={{ p: 1.5, display: 'flex', justifyContent: 'center' }}>
        <AppListPagination
          currentPage={pageNumber}
          totalPages={data?.list?.totalPages ?? 0}
          onPageChange={setPageNumber}
        />
      </Paper>
    </Container>
  );
};

export default UsersPage;


