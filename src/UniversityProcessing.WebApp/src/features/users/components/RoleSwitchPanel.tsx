import { Box, Paper } from '@mui/material';
import { styled } from '@mui/system';
import { useMemo } from 'react';
import { useNavigate } from 'react-router-dom';
import { ApiContractsUserRoleTypeDto } from 'src/api/backendApi';
import { labels, roleSetByType } from '../tools/users.contracts';

const SwitchRoot = styled(Paper)(({ theme }) => ({
  display: 'flex',
  position: 'relative',
  borderRadius: 24,
  padding: 4,
  background: theme.palette.grey[200],
  userSelect: 'none'
}));

const Thumb = styled(Box)(({ theme }) => ({
  position: 'absolute',
  top: 4,
  bottom: 4,
  borderRadius: 20,
  background: theme.palette.primary.main,
  transition: 'all 0.25s ease'
}));

const RoleSwitchPanel = (
  { availableRoles, routeRole }
    : {
    availableRoles: ApiContractsUserRoleTypeDto[],
    routeRole: ApiContractsUserRoleTypeDto
  }) => {
  const navigate = useNavigate();
  const roles = useMemo(() =>
    availableRoles.map(role => {
      return { value: role, label: labels[role] };
    }), [availableRoles]);
  const activeIndex = useMemo(() =>
    roles.findIndex(r => r.value === routeRole), [roles, routeRole]);

  const onSwitchClicked = (switchRole: ApiContractsUserRoleTypeDto) => {
    navigate(`/users/${roleSetByType[switchRole]}`, { replace: true });
  };

  return (
    <SwitchRoot elevation={0}>
      <Thumb
        sx={{
          width: `calc(100% / ${roles.length} - 8px)`,
          left: `calc(${activeIndex} * (100% / ${roles.length}) + 4px)`
        }}
      />
      {roles.map(r => (
        <Box
          key={r.value}
          onClick={() => onSwitchClicked(r.value)}
          sx={{
            flex: 1,
            textAlign: 'center',
            zIndex: 1,
            cursor: 'pointer',
            lineHeight: '32px',
            fontWeight: routeRole === r.value ? 600 : 400,
            color: routeRole === r.value ? '#fff' : 'inherit',
            transition: 'color 0.25s ease'
          }}
        >
          {r.label}
        </Box>
      ))}
    </SwitchRoot>
  );
};

export default RoleSwitchPanel;