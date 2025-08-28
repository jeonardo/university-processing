import React from 'react';
import { Autocomplete, TextField } from '@mui/material';
import { 
  useGetApiAuthRegistrationGetAvailableUniversityPositionsQuery,
  AuthRegistrationGetAvailableUniversityPositionsUniversityPosition
} from 'src/api/backendApi';

interface PositionSelectorProps {
  value: AuthRegistrationGetAvailableUniversityPositionsUniversityPosition | null;
  onChange: (value: AuthRegistrationGetAvailableUniversityPositionsUniversityPosition | null) => void;
  disabled?: boolean;
  required?: boolean;
}

const PositionSelector: React.FC<PositionSelectorProps> = ({
  value,
  onChange,
  disabled = false,
  required = false
}) => {
  const { data: positionsData } = useGetApiAuthRegistrationGetAvailableUniversityPositionsQuery();

  const universityPositions = React.useMemo(() =>
    positionsData?.list || [], [positionsData]);

  return (
    <Autocomplete
      options={universityPositions}
      getOptionLabel={(option) => option.name || ''}
      value={value}
      onChange={(_, newValue) => onChange(newValue)}
      disabled={disabled}
      renderInput={(params) => (
        <TextField {...params} label="Должность" required={required} />
      )}
    />
  );
};

export default PositionSelector;
