import { debounce, TextField } from '@mui/material';
import { useCallback, useState } from 'react';

interface AppListSearchProps {
  label: string,
  onSearchValueChangedDebounced: (newSearch: string) => void;
}

const AppListSearch = ({ label, onSearchValueChangedDebounced: onValueChangedDebounced }: AppListSearchProps) => {

  const [search, setSearch] = useState('');

  const handleSearchDebounced = useCallback(debounce((filter: string) => {
    onValueChangedDebounced(filter);
  }, 1000), []);

  const handleSearch = (query: string) => {
    setSearch(query);
    handleSearchDebounced(query);
  };

  return (
    <TextField
      id="filter"
      name="filter"
      fullWidth
      label={label}
      value={search}
      onChange={(e) => handleSearch(e.target.value)}
    />
  );
};

export default AppListSearch;