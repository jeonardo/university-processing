import React from 'react';
import { 
  useGetApiRegistrationGetAvailableUniversityPositionsQuery,
  ApiRegistrationGetAvailableUniversityPositionsUniversityPositionDto
} from 'src/api/backendApi';
import AutocompleteField from 'src/components/forms/AutocompleteField';

interface PositionSelectorProps {
  value: ApiRegistrationGetAvailableUniversityPositionsUniversityPositionDto | null;
  onChange: (value: ApiRegistrationGetAvailableUniversityPositionsUniversityPositionDto | null) => void;
  disabled?: boolean;
  required?: boolean;
}

const PositionSelector: React.FC<PositionSelectorProps> = ({
  value,
  onChange,
  disabled = false,
  required = false
}) => {
  const { data: positionsData } = useGetApiRegistrationGetAvailableUniversityPositionsQuery();

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
