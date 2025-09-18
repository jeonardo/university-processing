import React, { useCallback, useMemo, useState } from 'react';
import { useLazyGetApiRegistrationGetAvailableGroupsQuery } from 'src/api/backendApi';
import AutocompleteField from 'src/components/forms/AutocompleteField';
import { useDebouncedCallback } from 'src/core/hooks';

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
  const [fetchGroups, { data: groupsData }] = useLazyGetApiRegistrationGetAvailableGroupsQuery();

  const groups = useMemo(() => groupsData?.groupNumbers || [], [groupsData]);

  const debouncedFetchGroups = useDebouncedCallback((searchValue: string) => {
    if (searchValue) {
      fetchGroups({ number: searchValue });
    }
  }, 500);

  const handleInputChange = useCallback(
    (event: React.SyntheticEvent, newInputValue: string) => {
      setInputValue(newInputValue);
      debouncedFetchGroups(newInputValue);
    },
    [debouncedFetchGroups]
  );

  return (
    <AutocompleteField
      freeSolo
      options={groups}
      inputValue={inputValue}
      onInputChange={handleInputChange}
      value={value as any}
      onChange={(newValue) => onChange((newValue as string) || '')}
      disabled={disabled}
      required={required}
      label={'Номер группы'}
      placeholder={'Введите номер для поиска'}
      getOptionLabel={(option) => (typeof option === 'string' ? option : String(option))}
    />
  );
};

export default GroupSelector;
