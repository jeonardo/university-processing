import React, { useEffect, useState } from 'react';
import {
  Alert,
  Avatar,
  Box,
  Button,
  Chip,
  CircularProgress,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  Grid,
  IconButton,
  InputAdornment,
  MenuItem,
  Paper,
  Snackbar,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TablePagination,
  TableRow,
  TextField,
  Tooltip,
  Typography
} from '@mui/material';
import {
  Add as AddIcon,
  Block as BlockIcon,
  CheckCircle as CheckCircleIcon,
  Delete as DeleteIcon,
  Edit as EditIcon,
  School as SchoolIcon,
  Search as SearchIcon,
  VerifiedUser as VerifiedUserIcon,
  Work as WorkIcon
} from '@mui/icons-material';

// Типы данных
type UserRole = 'admin' | 'deanery' | 'departmentHead' | 'supervisor' | 'student' | 'commission';
type UserStatus = 'active' | 'pending' | 'blocked';

interface User {
  id: string;
  name: string;
  email: string;
  role: UserRole;
  status: UserStatus;
  faculty: string;
  department: string;
  lastLogin: Date;
  createdAt: Date;
}

interface Faculty {
  id: string;
  name: string;
}

interface Department {
  id: string;
  name: string;
  facultyId: string;
}

// Моковые данные
const mockFaculties: Faculty[] = [
  { id: 'f1', name: 'Информационные технологии' },
  { id: 'f2', name: 'Экономика и управление' },
  { id: 'f3', name: 'Гуманитарные науки' }
];

const mockDepartments: Department[] = [
  { id: 'd1', name: 'Программная инженерия', facultyId: 'f1' },
  { id: 'd2', name: 'Информационная безопасность', facultyId: 'f1' },
  { id: 'd3', name: 'Финансы и кредит', facultyId: 'f2' },
  { id: 'd4', name: 'Менеджмент', facultyId: 'f2' },
  { id: 'd5', name: 'История', facultyId: 'f3' },
  { id: 'd6', name: 'Философия', facultyId: 'f3' }
];

const mockUsers: User[] = [
  {
    id: 'u1',
    name: 'Иванов П.С.',
    email: 'ivanov@university.ru',
    role: 'student',
    status: 'active',
    faculty: 'Информационные технологии',
    department: 'Программная инженерия',
    lastLogin: new Date(Date.now() - 86400000 * 2),
    createdAt: new Date(Date.now() - 86400000 * 30)
  },
  {
    id: 'u2',
    name: 'Петрова А.И.',
    email: 'petrova@university.ru',
    role: 'supervisor',
    status: 'active',
    faculty: 'Информационные технологии',
    department: 'Программная инженерия',
    lastLogin: new Date(Date.now() - 86400000),
    createdAt: new Date(Date.now() - 86400000 * 60)
  },
  {
    id: 'u3',
    name: 'Сидоров В.М.',
    email: 'sidorov@university.ru',
    role: 'admin',
    status: 'active',
    faculty: 'Экономика и управление',
    department: 'Финансы и кредит',
    lastLogin: new Date(),
    createdAt: new Date(Date.now() - 86400000 * 90)
  },
  {
    id: 'u4',
    name: 'Козлова Е.Д.',
    email: 'kozlova@university.ru',
    role: 'deanery',
    status: 'pending',
    faculty: 'Гуманитарные науки',
    department: 'История',
    lastLogin: new Date(Date.now() - 86400000 * 10),
    createdAt: new Date(Date.now() - 86400000 * 5)
  },
  {
    id: 'u5',
    name: 'Николаев О.П.',
    email: 'nikolaev@university.ru',
    role: 'departmentHead',
    status: 'blocked',
    faculty: 'Информационные технологии',
    department: 'Информационная безопасность',
    lastLogin: new Date(Date.now() - 86400000 * 30),
    createdAt: new Date(Date.now() - 86400000 * 120)
  }
];

// Функции для работы с ролями
const getRoleLabel = (role: UserRole) => {
  switch (role) {
    case 'admin':
      return 'Администратор';
    case 'deanery':
      return 'Деканат';
    case 'departmentHead':
      return 'Руководитель кафедры';
    case 'supervisor':
      return 'Научный руководитель';
    case 'student':
      return 'Студент';
    case 'commission':
      return 'Член ГЭК';
    default:
      return role;
  }
};

const getRoleColor = (role: UserRole) => {
  switch (role) {
    case 'admin':
      return 'error';
    case 'deanery':
      return 'primary';
    case 'departmentHead':
      return 'secondary';
    case 'supervisor':
      return 'success';
    case 'student':
      return 'info';
    case 'commission':
      return 'warning';
    default:
      return 'default';
  }
};

const getStatusLabel = (status: UserStatus) => {
  switch (status) {
    case 'active':
      return 'Активен';
    case 'pending':
      return 'Ожидает подтверждения';
    case 'blocked':
      return 'Заблокирован';
    default:
      return status;
  }
};

const getStatusColor = (status: UserStatus) => {
  switch (status) {
    case 'active':
      return 'success';
    case 'pending':
      return 'warning';
    case 'blocked':
      return 'error';
    default:
      return 'default';
  }
};

// Компонент страницы администратора
const AdminUsersPage = () => {
  const [users, setUsers] = useState<User[]>(mockUsers);
  const [filteredUsers, setFilteredUsers] = useState<User[]>(mockUsers);
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);
  const [openDialog, setOpenDialog] = useState(false);
  const [currentUser, setCurrentUser] = useState<User | null>(null);
  const [searchTerm, setSearchTerm] = useState('');
  const [faculties] = useState<Faculty[]>(mockFaculties);
  const [departments] = useState<Department[]>(mockDepartments);
  const [snackbarOpen, setSnackbarOpen] = useState(false);
  const [snackbarMessage, setSnackbarMessage] = useState('');
  const [snackbarSeverity, setSnackbarSeverity] = useState<'success' | 'error'>('success');
  const [loading, setLoading] = useState(false);

  // Фильтрация пользователей
  useEffect(() => {
    const filtered = users.filter(user =>
      user.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
      user.email.toLowerCase().includes(searchTerm.toLowerCase()) ||
      user.role.toLowerCase().includes(searchTerm.toLowerCase()) ||
      user.faculty.toLowerCase().includes(searchTerm.toLowerCase()) ||
      user.department.toLowerCase().includes(searchTerm.toLowerCase())
    );
    setFilteredUsers(filtered);
  }, [searchTerm, users]);

  // Обработчики изменения страницы и количества строк
  const handleChangePage = (event: unknown, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event: React.ChangeEvent<HTMLInputElement>) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  // Открытие диалога для создания/редактирования
  const handleOpenDialog = (user: User | null) => {
    setCurrentUser(user);
    setOpenDialog(true);
  };

  // Закрытие диалога
  const handleCloseDialog = () => {
    setOpenDialog(false);
    setCurrentUser(null);
  };

  // Обработчик сохранения пользователя
  const handleSaveUser = (userData: User) => {
    setLoading(true);
    // Имитация запроса к API
    setTimeout(() => {
      if (userData.id) {
        // Редактирование существующего пользователя
        setUsers(users.map(u => u.id === userData.id ? userData : u));
        setSnackbarMessage('Пользователь успешно обновлен');
      } else {
        // Создание нового пользователя
        const newUser = {
          ...userData,
          id: `u${users.length + 1}`,
          createdAt: new Date(),
          lastLogin: new Date()
        };
        setUsers([...users, newUser]);
        setSnackbarMessage('Пользователь успешно создан');
      }
      setSnackbarSeverity('success');
      setSnackbarOpen(true);
      setLoading(false);
      handleCloseDialog();
    }, 1000);
  };

  // Обработчик удаления пользователя
  const handleDeleteUser = (userId: string) => {
    setLoading(true);
    // Имитация запроса к API
    setTimeout(() => {
      setUsers(users.filter(u => u.id !== userId));
      setSnackbarMessage('Пользователь успешно удален');
      setSnackbarSeverity('success');
      setSnackbarOpen(true);
      setLoading(false);
    }, 800);
  };

  // Обработчик верификации пользователя
  const handleVerifyUser = (userId: string) => {
    setLoading(true);
    // Имитация запроса к API
    setTimeout(() => {
      setUsers(users.map(u => u.id === userId ? { ...u, status: 'active' } : u));
      setSnackbarMessage('Пользователь успешно верифицирован');
      setSnackbarSeverity('success');
      setSnackbarOpen(true);
      setLoading(false);
    }, 800);
  };

  // Обработчик блокировки/разблокировки пользователя
  const handleToggleBlockUser = (userId: string, currentStatus: UserStatus) => {
    setLoading(true);
    const newStatus = currentStatus === 'blocked' ? 'active' : 'blocked';
    // Имитация запроса к API
    setTimeout(() => {
      setUsers(users.map(u => u.id === userId ? { ...u, status: newStatus } : u));
      setSnackbarMessage(
        newStatus === 'blocked'
          ? 'Пользователь заблокирован'
          : 'Пользователь разблокирован'
      );
      setSnackbarSeverity('success');
      setSnackbarOpen(true);
      setLoading(false);
    }, 800);
  };

  // Закрытие снекбара
  const handleCloseSnackbar = () => {
    setSnackbarOpen(false);
  };

  // Статистика пользователей
  const userStats = {
    total: users.length,
    active: users.filter(u => u.status === 'active').length,
    pending: users.filter(u => u.status === 'pending').length,
    blocked: users.filter(u => u.status === 'blocked').length
  };

  return (
    <Box sx={{ p: 3 }}>
      <Typography variant="h4" gutterBottom sx={{ fontWeight: 600, mb: 3 }}>
        Управление пользователями
      </Typography>

      {/* Статистика */}
      <Grid container spacing={3} sx={{ mb: 4 }}>
        <Grid item xs={12} md={3}>
          <Paper sx={{ p: 2, borderRadius: 3, textAlign: 'center' }}>
            <Typography variant="h6" color="text.secondary">Всего пользователей</Typography>
            <Typography variant="h3" sx={{ fontWeight: 700 }}>{userStats.total}</Typography>
          </Paper>
        </Grid>
        <Grid item xs={12} md={3}>
          <Paper sx={{ p: 2, borderRadius: 3, textAlign: 'center', bgcolor: 'success.light' }}>
            <Typography variant="h6" color="text.secondary">Активные</Typography>
            <Typography variant="h3" sx={{ fontWeight: 700, color: 'success.dark' }}>{userStats.active}</Typography>
          </Paper>
        </Grid>
        <Grid item xs={12} md={3}>
          <Paper sx={{ p: 2, borderRadius: 3, textAlign: 'center', bgcolor: 'warning.light' }}>
            <Typography variant="h6" color="text.secondary">Ожидают подтверждения</Typography>
            <Typography variant="h3" sx={{ fontWeight: 700, color: 'warning.dark' }}>{userStats.pending}</Typography>
          </Paper>
        </Grid>
        <Grid item xs={12} md={3}>
          <Paper sx={{ p: 2, borderRadius: 3, textAlign: 'center', bgcolor: 'error.light' }}>
            <Typography variant="h6" color="text.secondary">Заблокированные</Typography>
            <Typography variant="h3" sx={{ fontWeight: 700, color: 'error.dark' }}>{userStats.blocked}</Typography>
          </Paper>
        </Grid>
      </Grid>

      {/* Панель управления */}
      <Box sx={{ display: 'flex', justifyContent: 'space-between', mb: 3 }}>
        <TextField
          variant="outlined"
          placeholder="Поиск пользователей..."
          size="small"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          sx={{ width: 300 }}
          InputProps={{
            startAdornment: (
              <InputAdornment position="start">
                <SearchIcon />
              </InputAdornment>
            )
          }}
        />
        <Button
          variant="contained"
          startIcon={<AddIcon />}
          onClick={() => handleOpenDialog(null)}
          sx={{ borderRadius: 2 }}
        >
          Добавить пользователя
        </Button>
      </Box>

      {/* Таблица пользователей */}
      <Paper sx={{ borderRadius: 3, overflow: 'hidden', boxShadow: '0 8px 16px rgba(0,0,0,0.04)' }}>
        <TableContainer>
          <Table>
            <TableHead sx={{ bgcolor: 'background.default' }}>
              <TableRow>
                <TableCell>Пользователь</TableCell>
                <TableCell>Email</TableCell>
                <TableCell>Роль</TableCell>
                <TableCell>Факультет / Кафедра</TableCell>
                <TableCell>Статус</TableCell>
                <TableCell>Дата регистрации</TableCell>
                <TableCell align="center">Действия</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {filteredUsers
                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                .map((user) => (
                  <TableRow key={user.id} hover>
                    <TableCell>
                      <Box sx={{ display: 'flex', alignItems: 'center' }}>
                        <Avatar sx={{ bgcolor: 'primary.main', mr: 2 }}>
                          {user.name.charAt(0)}
                        </Avatar>
                        <Typography fontWeight={500}>{user.name}</Typography>
                      </Box>
                    </TableCell>
                    <TableCell>{user.email}</TableCell>
                    <TableCell>
                      <Chip
                        label={getRoleLabel(user.role)}
                        color={getRoleColor(user.role)}
                        size="small"
                        variant="outlined"
                      />
                    </TableCell>
                    <TableCell>
                      <Box>
                        <Typography variant="body2" sx={{ display: 'flex', alignItems: 'center' }}>
                          <SchoolIcon fontSize="small" sx={{ mr: 1, color: 'text.secondary' }} />
                          {user.faculty}
                        </Typography>
                        <Typography variant="body2" sx={{ display: 'flex', alignItems: 'center' }}>
                          <WorkIcon fontSize="small" sx={{ mr: 1, color: 'text.secondary' }} />
                          {user.department}
                        </Typography>
                      </Box>
                    </TableCell>
                    <TableCell>
                      <Chip
                        label={getStatusLabel(user.status)}
                        color={getStatusColor(user.status)}
                        size="small"
                      />
                    </TableCell>
                    <TableCell>
                      {user.createdAt.toLocaleDateString('ru-RU')}
                    </TableCell>
                    <TableCell align="center">
                      <Box sx={{ display: 'flex', justifyContent: 'center', gap: 1 }}>
                        {user.status === 'pending' && (
                          <Tooltip title="Верифицировать">
                            <IconButton
                              color="success"
                              onClick={() => handleVerifyUser(user.id)}
                              disabled={loading}
                            >
                              <VerifiedUserIcon />
                            </IconButton>
                          </Tooltip>
                        )}

                        <Tooltip title="Редактировать">
                          <IconButton
                            color="primary"
                            onClick={() => handleOpenDialog(user)}
                            disabled={loading}
                          >
                            <EditIcon />
                          </IconButton>
                        </Tooltip>

                        <Tooltip title={user.status === 'blocked' ? 'Разблокировать' : 'Заблокировать'}>
                          <IconButton
                            color={user.status === 'blocked' ? 'success' : 'error'}
                            onClick={() => handleToggleBlockUser(user.id, user.status)}
                            disabled={loading}
                          >
                            {user.status === 'blocked' ? <CheckCircleIcon /> : <BlockIcon />}
                          </IconButton>
                        </Tooltip>

                        {user.role !== 'admin' && (
                          <Tooltip title="Удалить">
                            <IconButton
                              color="error"
                              onClick={() => handleDeleteUser(user.id)}
                              disabled={loading}
                            >
                              <DeleteIcon />
                            </IconButton>
                          </Tooltip>
                        )}
                      </Box>
                    </TableCell>
                  </TableRow>
                ))}
            </TableBody>
          </Table>
        </TableContainer>
        <TablePagination
          rowsPerPageOptions={[5, 10, 25]}
          component="div"
          count={filteredUsers.length}
          rowsPerPage={rowsPerPage}
          page={page}
          onPageChange={handleChangePage}
          onRowsPerPageChange={handleChangeRowsPerPage}
          labelRowsPerPage="Строк на странице:"
          labelDisplayedRows={({ from, to, count }) => `${from}-${to} из ${count}`}
          sx={{ borderTop: '1px solid rgba(224, 224, 224, 0.5)' }}
        />
      </Paper>

      {/* Диалог создания/редактирования пользователя */}
      <UserFormDialog
        open={openDialog}
        onClose={handleCloseDialog}
        onSave={handleSaveUser}
        user={currentUser}
        faculties={faculties}
        departments={departments}
        loading={loading}
      />

      {/* Уведомления */}
      <Snackbar
        open={snackbarOpen}
        autoHideDuration={3000}
        onClose={handleCloseSnackbar}
        anchorOrigin={{ vertical: 'top', horizontal: 'right' }}
      >
        <Alert
          onClose={handleCloseSnackbar}
          severity={snackbarSeverity}
          sx={{ width: '100%' }}
        >
          {snackbarMessage}
        </Alert>
      </Snackbar>
    </Box>
  );
};

// Компонент формы пользователя
interface UserFormDialogProps {
  open: boolean;
  onClose: () => void;
  onSave: (user: User) => void;
  user: User | null;
  faculties: Faculty[];
  departments: Department[];
  loading: boolean;
}

const UserFormDialog: React.FC<UserFormDialogProps> = ({
                                                         open, onClose, onSave, user, faculties, departments, loading
                                                       }) => {
  const [formData, setFormData] = useState<User>({
    id: '',
    name: '',
    email: '',
    role: 'student',
    status: 'pending',
    faculty: '',
    department: '',
    lastLogin: new Date(),
    createdAt: new Date()
  });

  const [selectedFaculty, setSelectedFaculty] = useState('');
  const [filteredDepartments, setFilteredDepartments] = useState<Department[]>([]);

  // Инициализация формы при открытии
  useEffect(() => {
    if (user) {
      setFormData(user);
      setSelectedFaculty(user.faculty);
    } else {
      setFormData({
        id: '',
        name: '',
        email: '',
        role: 'student',
        status: 'pending',
        faculty: '',
        department: '',
        lastLogin: new Date(),
        createdAt: new Date()
      });
      setSelectedFaculty('');
    }
  }, [user, open]);

  // Фильтрация кафедр по выбранному факультету
  useEffect(() => {
    if (selectedFaculty) {
      const facultyId = faculties.find(f => f.name === selectedFaculty)?.id || '';
      const depts = departments.filter(d => d.facultyId === facultyId);
      setFilteredDepartments(depts);

      // Сбросить кафедру, если она не принадлежит выбранному факультету
      if (formData.department && !depts.some(d => d.name === formData.department)) {
        setFormData({ ...formData, department: '' });
      }
    } else {
      setFilteredDepartments([]);
    }
  }, [selectedFaculty, departments, faculties]);

  // Обработчик изменения полей формы
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });

    if (name === 'faculty') {
      setSelectedFaculty(value);
    }
  };

  // Обработчик отправки формы
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSave(formData);
  };

  return (
    <Dialog open={open} onClose={onClose} maxWidth="sm" fullWidth>
      <DialogTitle sx={{ fontWeight: 600 }}>
        {user ? 'Редактировать пользователя' : 'Создать нового пользователя'}
      </DialogTitle>
      <DialogContent dividers>
        <form onSubmit={handleSubmit}>
          <Grid container spacing={2} sx={{ pt: 1 }}>
            <Grid item xs={12}>
              <TextField
                name="name"
                label="ФИО"
                value={formData.name}
                onChange={handleChange}
                fullWidth
                required
                margin="normal"
              />
            </Grid>

            <Grid item xs={12}>
              <TextField
                name="email"
                label="Email"
                type="email"
                value={formData.email}
                onChange={handleChange}
                fullWidth
                required
                margin="normal"
              />
            </Grid>

            <Grid item xs={12} md={6}>
              <TextField
                name="role"
                label="Роль"
                value={formData.role}
                onChange={handleChange}
                select
                fullWidth
                required
                margin="normal"
              >
                <MenuItem value="admin">Администратор</MenuItem>
                <MenuItem value="deanery">Деканат</MenuItem>
                <MenuItem value="departmentHead">Руководитель кафедры</MenuItem>
                <MenuItem value="supervisor">Научный руководитель</MenuItem>
                <MenuItem value="student">Студент</MenuItem>
                <MenuItem value="commission">Член ГЭК</MenuItem>
              </TextField>
            </Grid>

            <Grid item xs={12} md={6}>
              <TextField
                name="status"
                label="Статус"
                value={formData.status}
                onChange={handleChange}
                select
                fullWidth
                required
                margin="normal"
              >
                <MenuItem value="active">Активен</MenuItem>
                <MenuItem value="pending">Ожидает подтверждения</MenuItem>
                <MenuItem value="blocked">Заблокирован</MenuItem>
              </TextField>
            </Grid>

            <Grid item xs={12} md={6}>
              <TextField
                name="faculty"
                label="Факультет"
                value={formData.faculty}
                onChange={handleChange}
                select
                fullWidth
                required
                margin="normal"
              >
                {faculties.map((faculty) => (
                  <MenuItem key={faculty.id} value={faculty.name}>
                    {faculty.name}
                  </MenuItem>
                ))}
              </TextField>
            </Grid>

            <Grid item xs={12} md={6}>
              <TextField
                name="department"
                label="Кафедра"
                value={formData.department}
                onChange={handleChange}
                select
                fullWidth
                required
                margin="normal"
                disabled={!selectedFaculty}
              >
                {filteredDepartments.map((department) => (
                  <MenuItem key={department.id} value={department.name}>
                    {department.name}
                  </MenuItem>
                ))}
              </TextField>
            </Grid>
          </Grid>
        </form>
      </DialogContent>
      <DialogActions sx={{ p: 2 }}>
        <Button onClick={onClose} color="inherit" disabled={loading}>
          Отмена
        </Button>
        <Button
          onClick={handleSubmit}
          variant="contained"
          disabled={loading}
          startIcon={loading ? <CircularProgress size={20} /> : null}
        >
          {user ? 'Сохранить изменения' : 'Создать пользователя'}
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default AdminUsersPage;