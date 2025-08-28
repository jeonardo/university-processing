import React from 'react';
import { Autocomplete, TextField } from '@mui/material';
import { AuthRegistrationGetAvailableFacultiesFaculty } from 'src/api/backendApi';
import { useGetApiAuthRegistrationGetAvailableFacultiesQuery } from 'src/api/backendApi';

interface FacultySelectorProps {
  value: AuthRegistrationGetAvailableFacultiesFaculty | null;
  onChange: (value: AuthRegistrationGetAvailableFacultiesFaculty | null) => void;
  disabled?: boolean;
  required?: boolean;
}

const FacultySelector: React.FC<FacultySelectorProps> = ({
  value,
  onChange,
  disabled = false,
  required = false
}) => {
  const { data: facultiesData } = useGetApiAuthRegistrationGetAvailableFacultiesQuery();

  const faculties = React.useMemo(() =>
    facultiesData?.faculties || [], [facultiesData]);

  return (
    <Autocomplete
      options={faculties}
      getOptionLabel={(option) => option.name || ''}
      value={value}
      onChange={(_, newValue) => onChange(newValue)}
      disabled={disabled}
      renderInput={(params) => (
        <TextField {...params} label="Факультет" required={required} />
      )}
    />
  );
};

export default FacultySelector;
