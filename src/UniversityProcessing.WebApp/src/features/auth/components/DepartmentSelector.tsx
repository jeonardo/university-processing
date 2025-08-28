import React from 'react';
import { Autocomplete, TextField } from '@mui/material';
import { AuthRegistrationGetAvailableDepartmentsDepartment } from 'src/api/backendApi';
import { useLazyGetApiAuthRegistrationGetAvailableDepartmentsQuery } from 'src/api/backendApi';

interface DepartmentSelectorProps {
  value: AuthRegistrationGetAvailableDepartmentsDepartment | null;
  onChange: (value: AuthRegistrationGetAvailableDepartmentsDepartment | null) => void;
  facultyId?: string;
  disabled?: boolean;
  required?: boolean;
}

const DepartmentSelector: React.FC<DepartmentSelectorProps> = ({
  value,
  onChange,
  facultyId,
  disabled = false,
  required = false
}) => {
  const [fetchDepartments, { data: departmentsData }] = useLazyGetApiAuthRegistrationGetAvailableDepartmentsQuery();

  const departments = React.useMemo(() =>
    departmentsData?.departments || [], [departmentsData]);

  React.useEffect(() => {
    if (facultyId) {
      fetchDepartments({ facultyId });
    }
  }, [facultyId, fetchDepartments]);

  return (
    <Autocomplete
      options={departments}
      getOptionLabel={(option) => option.name || ''}
      value={value}
      onChange={(_, newValue) => onChange(newValue)}
      disabled={disabled || !facultyId}
      renderInput={(params) => (
        <TextField {...params} label="Кафедра" required={required} />
      )}
    />
  );
};

export default DepartmentSelector;
