import React from 'react';
import { Chip, Switch } from '@mui/material';

interface ToggleStatusProps {
  isActive: boolean;
  onToggled: () => void;
}

const ToggleStatus: React.FC<ToggleStatusProps> = ({ isActive, onToggled }) => {
  return (
    <div className="flex items-center space-x-2">
      <Chip
        label={isActive ? 'Активен' : 'Неактивен'}
        color={isActive ? 'success' : 'error'}
        variant="outlined"
        size="medium"
        sx={{ width: '6rem' }}
      />
      <Switch
        checked={isActive}
        onChange={() => onToggled()}
        color={isActive ? 'success' : 'error'}
      />
    </div>
  );
};

export default ToggleStatus;
