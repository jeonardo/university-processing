import React, { useEffect, useMemo, useState, useCallback, lazy, Suspense } from 'react';
import { Box, Button, Container, Paper, Typography, CircularProgress } from '@mui/material';
import AppList from 'src/components/lists/AppList';
import AppListPagination from 'src/components/lists/AppListPagination';
import AppListSearch from 'src/components/lists/AppListSearch';
import { ContractsUserRoleType, useGetApiUsersGetAdminsQuery, useGetApiUsersGetDeaneriesQuery, useGetApiUsersGetStudentsQuery, useGetApiUsersGetTeachersQuery } from 'src/api/backendApi';

import { useRequireAdmin, useAppSelector, getAvailableRoles, canCreateUser } from 'src/core';
import RoleSwitchPanel from './RoleSwitchPanel';
import ModalForm from 'src/components/layout/ModalForm';
import { selectActiveQuery } from './selectActiveQuery';
import { useSearchParams } from 'react-router-dom';

// Ленивая загрузка форм регистрации
const RegisterAdminForm = lazy(() => import('../auth/components/RegisterAdminForm'));
const RegisterDeaneryForm = lazy(() => import('../auth/components/RegisterDeaneryForm'));
const RegisterTeacherForm = lazy(() => import('../auth/components/RegisterTeacherForm'));
const RegisterStudentForm = lazy(() => import('../auth/components/RegisterStudentForm'));

// Ленивая загрузка компонентов элементов списка
const AdminUserItem = lazy(() => import('./items/AdminUserItem'));
const TeacherUserItem = lazy(() => import('./items/TeacherUserItem'));
const DeaneryUserItem = lazy(() => import('./items/DeaneryUserItem'));
const StudentUserItem = lazy(() => import('./items/StudentUserItem'));

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

const RegistrationFormRenderer = React.memo(({
  role,
  currentUserRole,
  onSuccess
}: {
  role: Role;
  currentUserRole?: ContractsUserRoleType | null;
  onSuccess: () => void;
}) => {
  const canCreateAdmin = canCreateUser(currentUserRole, ContractsUserRoleType.Admin);
  const canCreateDeanery = canCreateUser(currentUserRole, ContractsUserRoleType.Deanery);
  const canCreateTeacher = canCreateUser(currentUserRole, ContractsUserRoleType.Teacher);
  const canCreateStudent = canCreateUser(currentUserRole, ContractsUserRoleType.Student);

  switch (role) {
    case ContractsUserRoleType.Admin:
      return canCreateAdmin ? (
        <Suspense fallback={<CircularProgress />}>
          <RegisterAdminForm buttonLabel="Добавить" onSuccess={onSuccess} />
        </Suspense>
      ) : null;
    case ContractsUserRoleType.Deanery:
      return canCreateDeanery ? (
        <Suspense fallback={<CircularProgress />}>
          <RegisterDeaneryForm buttonLabel="Добавить" onSuccess={onSuccess} />
        </Suspense>
      ) : null;
    case ContractsUserRoleType.Teacher:
      return canCreateTeacher ? (
        <Suspense fallback={<CircularProgress />}>
          <RegisterTeacherForm buttonLabel="Добавить" onSuccess={onSuccess} />
        </Suspense>
      ) : null;
    case ContractsUserRoleType.Student:
      return canCreateStudent ? (
        <Suspense fallback={<CircularProgress />}>
          <RegisterStudentForm buttonLabel="Добавить" onSuccess={onSuccess} />
        </Suspense>
      ) : null;
    default:
      return null;
  }
});

RegistrationFormRenderer.displayName = 'RegistrationFormRenderer';

const UsersPage: React.FC = () => {
  useRequireAdmin();
  const currentUser = useAppSelector(state => state.auth.user);
  const [searchParams, setSearchParams] = useSearchParams();

  // Получаем параметры из URL
  const paramRole = searchParams.get('role') as Role;
  const pageParam = searchParams.get('page');
  const searchParam = searchParams.get('search') || '';

  // Валидируем и устанавливаем значения по умолчанию
  const pageNumber = useMemo(() =>
    pageParam && !isNaN(parseInt(pageParam)) ? Math.max(1, parseInt(pageParam)) : 1,
    [pageParam]
  );
  const search = searchParam;

  const availableRoles = useMemo(() => getAvailableRoles(currentUser?.role), [currentUser?.role]);

  // Определяем текущую роль из URL или устанавливаем первую доступную
  const currentRole = useMemo(() => {
    if (paramRole && availableRoles.includes(paramRole)) {
      return paramRole;
    }
    return availableRoles[0] as Role;
  }, [paramRole, availableRoles]);

  // Стабилизируем функцию setSearchParams
  const stableSetSearchParams = useCallback(setSearchParams, []);

  // Инициализируем URL параметры только при первой загрузке
  useEffect(() => {
    // Проверяем, нужно ли обновлять URL параметры
    const needsUpdate =
      !paramRole ||
      !availableRoles.includes(paramRole as any);

    if (needsUpdate) {
      const newSearchParams = new URLSearchParams(searchParams);

      // Устанавливаем роль только если она невалидна
      if (!paramRole || !availableRoles.includes(paramRole as any)) {
        newSearchParams.set('role', currentRole);
      }

      // Устанавливаем страницу только если она невалидна
      if (!pageParam || isNaN(parseInt(pageParam)) || parseInt(pageParam) < 1) {
        newSearchParams.set('page', '1');
      }

      stableSetSearchParams(newSearchParams, { replace: true });
    }
  }, [availableRoles, currentRole, paramRole, pageParam, searchParams, stableSetSearchParams]);

  // Создаем queryArgs напрямую из URL параметров
  const queryArgs = useMemo(() => ({
    filter: search,
    pageNumber: pageNumber,
    pageSize: PAGE_SIZE,
  }), [search, pageNumber]);

  const onSearchValueChanged = useCallback((value: string) => {
    const newSearchParams = new URLSearchParams(searchParams);
    newSearchParams.set('page', '1');
    newSearchParams.set('search', value);
    setSearchParams(newSearchParams);
  }, [searchParams, setSearchParams]);

  // Мемоизируем проверки ролей
  const roleChecks = useMemo(() => ({
    isAllowedRole: availableRoles.includes(currentRole),
    isAdmin: currentRole === ContractsUserRoleType.Admin,
    isDean: currentRole === ContractsUserRoleType.Deanery,
    isTeach: currentRole === ContractsUserRoleType.Teacher,
    isStud: currentRole === ContractsUserRoleType.Student,
  }), [availableRoles, currentRole]);

  // Активен только один useQuery с оптимизированными опциями
  const admins = useGetApiUsersGetAdminsQuery(queryArgs, {
    skip: !roleChecks.isAllowedRole || !roleChecks.isAdmin,
    pollingInterval: 15000,
    refetchOnMountOrArgChange: true,
    refetchOnFocus: false,
    refetchOnReconnect: true,
  });
  const deaneries = useGetApiUsersGetDeaneriesQuery(queryArgs, {
    skip: !roleChecks.isAllowedRole || !roleChecks.isDean,
    pollingInterval: 15000,
    refetchOnMountOrArgChange: true,
    refetchOnFocus: false,
    refetchOnReconnect: true,
  });
  const teachers = useGetApiUsersGetTeachersQuery(queryArgs, {
    skip: !roleChecks.isAllowedRole || !roleChecks.isTeach,
    pollingInterval: 15000,
    refetchOnMountOrArgChange: true,
    refetchOnFocus: false,
    refetchOnReconnect: true,
  });
  const students = useGetApiUsersGetStudentsQuery(queryArgs, {
    skip: !roleChecks.isAllowedRole || !roleChecks.isStud,
    pollingInterval: 15000,
    refetchOnMountOrArgChange: true,
    refetchOnFocus: false,
    refetchOnReconnect: true,
  });

  // Нормализуем активное состояние
  const { data, isLoading, refetch } = selectActiveQuery(currentRole, {
    admins,
    deaneries,
    teachers,
    students,
  });

  const [isModalOpen, setIsModalOpen] = useState(false);
  const title = roleToTitle[currentRole];
  const items = useMemo(() => data?.list?.items ?? [], [data]);

  const onPageChange = useCallback((newPage: number) => {
    // Проверяем, что номер страницы валидный
    if (newPage >= 1 && (!data?.list?.totalPages || newPage <= data.list.totalPages)) {
      const newSearchParams = new URLSearchParams(searchParams);
      newSearchParams.set('page', newPage.toString());
      setSearchParams(newSearchParams);
    }
  }, [searchParams, setSearchParams, data?.list?.totalPages]);

  const handleRoleChange = useCallback((nextRole: ContractsUserRoleType) => {
    // Сбрасываем URL параметры при смене роли
    const newSearchParams = new URLSearchParams();
    newSearchParams.set('role', nextRole);
    newSearchParams.set('page', '1');
    newSearchParams.set('search', '');
    setSearchParams(newSearchParams);
  }, [setSearchParams]);

  const handleModalClose = useCallback(() => {
    setIsModalOpen(false);
  }, []);

  const handleModalSuccess = useCallback(() => {
    setIsModalOpen(false);
    refetch();
  }, [refetch]);

  const handleAddButtonClick = useCallback(() => {
    setIsModalOpen(true);
  }, []);

  return (
    <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="md">
      <ModalForm open={isModalOpen} onClose={handleModalClose} title={"Добавить пользователя"}>
        <RegistrationFormRenderer
          role={currentRole}
          currentUserRole={currentUser?.role}
          onSuccess={handleModalSuccess}
        />
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
          <Button variant="contained" onClick={handleAddButtonClick}>Добавить</Button>
        </Box>
      </Paper>
      <Paper className="p-6" sx={{ display: 'flex', flexGrow: 1, flexDirection: 'column', minHeight: 0 }}>
        <Box sx={{ flex: 1, minHeight: 0 }}>
          <AppList
            isLoading={isLoading}
            isEmpty={items?.length == 0}
            height={'55vh'}>
            {
              paramRole == ContractsUserRoleType.Admin && items?.map((item: any) => (
                <AdminUserItem key={item.id} item={item} />
              ))
              || paramRole == ContractsUserRoleType.Deanery && items?.map((item: any) => (
                <DeaneryUserItem key={item.id} item={item} />
              ))
              || paramRole == ContractsUserRoleType.Teacher && items?.map((item: any) => (
                <TeacherUserItem key={item.id} item={item} />
              ))
              || paramRole == ContractsUserRoleType.Student && items?.map((item: any) => (
                <StudentUserItem key={item.id} item={item} />
              ))
            }
          </AppList>
        </Box>
      </Paper>
      {
        !isLoading
        && data
        && data.list.totalPages > 1
        && <Paper sx={{ p: 1.5, display: 'flex', justifyContent: 'center' }}>
          <AppListPagination
            currentPage={pageNumber}
            totalPages={data.list.totalPages}
            onPageChange={onPageChange}
          />
        </Paper>
      }
    </Container>
  );
};

export default React.memo(UsersPage);


