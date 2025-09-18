import React from 'react';
import { ApiRegistrationGetAvailableFacultiesFacultyDto } from 'src/api/backendApi';
import { useGetApiRegistrationGetAvailableFacultiesQuery } from 'src/api/backendApi';
import AutocompleteField from 'src/components/forms/AutocompleteField';

interface FacultySelectorProps {
  value: ApiRegistrationGetAvailableFacultiesFacultyDto | null;
  onChange: (value: ApiRegistrationGetAvailableFacultiesFacultyDto | null) => void;
  disabled?: boolean;
  required?: boolean;
}

const FacultySelector: React.FC<FacultySelectorProps> = ({
  value,
  onChange,
  disabled = false,
  required = false
}) => {
  const { data: facultiesData } = useGetApiRegistrationGetAvailableFacultiesQuery();

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
