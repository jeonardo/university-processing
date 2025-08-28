import React, { useCallback, useMemo, useState } from 'react';
import { Autocomplete, TextField } from '@mui/material';
import { debounce } from '@mui/material/utils';
import { useLazyGetApiAuthRegistrationGetAvailableGroupsQuery } from 'src/api/backendApi';

interface GroupSelectorProps {
  value: string;
  onChange: (value: string) => void;
  disabled?: boolean;
  required?: boolean;
}

const GroupSelector: React.FC<GroupSelectorProps> = ({
  value,
  onChange,
  disabled = false,
  required = false
}) => {
  const [inputValue, setInputValue] = useState('');
  const [fetchGroups, { data: groupsData }] = useLazyGetApiAuthRegistrationGetAvailableGroupsQuery();

  const groups = useMemo(() => groupsData?.groupNumbers || [], [groupsData]);

  const debouncedFetchGroups = useCallback(
    debounce((searchValue: string) => {
      if (searchValue) {
        fetchGroups({ number: searchValue });
      }
    }, 500),
    [fetchGroups]
  );

  const handleInputChange = useCallback(
    (event: React.SyntheticEvent, newInputValue: string) => {
      setInputValue(newInputValue);
      debouncedFetchGroups(newInputValue);
    },
    [debouncedFetchGroups]
  );

  return (
    <Autocomplete
      freeSolo
      options={groups}
      inputValue={inputValue}
      onInputChange={handleInputChange}
      value={value}
      onChange={(_, newValue) => onChange(newValue || '')}
      disabled={disabled}
      renderInput={(params) => (
        <TextField {...params} label="Номер группы" required={required} />
      )}
    />
  );
};

export default GroupSelector;
