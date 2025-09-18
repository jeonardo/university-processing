import React from 'react';
import {
  ApiRegistrationGetAvailableDepartmentsDepartmentDto,
  useLazyGetApiRegistrationGetAvailableDepartmentsQuery
} from 'src/api/backendApi';
import AutocompleteField from 'src/components/forms/AutocompleteField';

interface DepartmentSelectorProps {
  value: ApiRegistrationGetAvailableDepartmentsDepartmentDto | null;
  onChange: (value: ApiRegistrationGetAvailableDepartmentsDepartmentDto | null) => void;
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
  const [fetchDepartments, { data: departmentsData }] = useLazyGetApiRegistrationGetAvailableDepartmentsQuery();

  const departments = React.useMemo(() =>
    departmentsData?.departments || [], [departmentsData]);

  React.useEffect(() => {
    if (facultyId) {
      fetchDepartments({ facultyId });
    }
  }, [facultyId, fetchDepartments]);

  return (
    <AutocompleteField
      options={departments}
      getOptionLabel={(option) => option.name || ''}
      value={value}
      onChange={onChange}
      disabled={disabled || !facultyId}
      required={required}
      label={'Кафедра'}
    />
  );
};

export default DepartmentSelector;
