import React from 'react';
import { 
  useGetApiAuthRegistrationGetAvailableUniversityPositionsQuery,
  AuthRegistrationGetAvailableUniversityPositionsUniversityPosition
} from 'src/api/backendApi';
import AutocompleteField from 'src/components/forms/AutocompleteField';

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
    <AutocompleteField
      options={universityPositions}
      getOptionLabel={(option) => option.name || ''}
      value={value}
      onChange={onChange}
      disabled={disabled}
      required={required}
      label={'Должность'}
    />
  );
};

export default PositionSelector;
