import React from 'react';
import { Outlet, NavLink, useParams, useNavigate } from 'react-router-dom';
import { Box, Button, Container, Tab, Tabs, Typography } from '@mui/material';

const tabs = [
  { label: 'Комитеты', path: 'committees' },
  { label: 'Сессии защиты', path: 'sessions' },
  { label: 'Дипломы', path: 'diplomas' },
  { label: 'Группы', path: 'groups' },
  { label: 'Преподаватели', path: 'teachers' }
];

const DiplomaProcessLayout: React.FC = () => {
  const params = useParams();
  const navigate = useNavigate();
  const id = params.id as string;

  const currentIndex = React.useMemo(() => {
    const current = window.location.pathname.split('/').pop();
    const idx = tabs.findIndex(t => t.path === current);
    return idx >= 0 ? idx : 0;
  }, [window.location.pathname]);

  return (
    <Container sx={{ display: 'flex', flexDirection: 'column', gap: 1 }} maxWidth="lg">
      <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
        <Typography variant="h4" component="h1" className="font-bold">Дипломный процесс</Typography>
        <Button onClick={() => navigate(-1)}>Назад</Button>
      </Box>

      <Tabs value={currentIndex} onChange={(_, i) => navigate(`/diploma-processes/${id}/${tabs[i].path}`)} sx={{ mb: 1 }}>
        {tabs.map(t => (
          <Tab key={t.path} label={t.label} />
        ))}
      </Tabs>

      <Outlet />
    </Container>
  );
};

export default DiplomaProcessLayout;



