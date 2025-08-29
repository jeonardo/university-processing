import React from 'react';
import { AuthRegistrationGetAvailableFacultiesFaculty } from 'src/api/backendApi';
import { useGetApiAuthRegistrationGetAvailableFacultiesQuery } from 'src/api/backendApi';
import AutocompleteField from 'src/components/forms/AutocompleteField';

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
    <AutocompleteField
      options={faculties}
      getOptionLabel={(option) => option.name || ''}
      value={value}
      onChange={onChange}
      disabled={disabled}
      required={required}
      label={'Факультет'}
    />
  );
};

export default FacultySelector;
