import { InputAdornment, TextField } from '@mui/material';
import { useState } from 'react';
import { useDebouncedCallback } from 'src/core/hooks';
import { Search as SearchIcon } from '@mui/icons-material';
interface AppListSearchProps {
  label: string,
  placeholder: string,
  onSearchValueChangedDebounced: (newSearch: string) => void;
}

const AppListSearch = ({ label, onSearchValueChangedDebounced: onValueChangedDebounced, placeholder }: AppListSearchProps) => {

  const [search, setSearch] = useState('');

  const handleSearchDebounced = useDebouncedCallback((filter: string) => {
    onValueChangedDebounced(filter);
  }, 500); // Уменьшаем задержку с 1000мс до 500мс

  const handleSearch = (query: string) => {
    setSearch(query);
    handleSearchDebounced(query);
  };

  return (
    <TextField
      slotProps={{
        input: {
          startAdornment: (
            <InputAdornment position="start">
              <SearchIcon fontSize="small" />
            </InputAdornment>
          ),
        },
      }}
      id="filter"
      name="filter"
      fullWidth
      label={label}
      placeholder={placeholder}
      value={search}
      onChange={(e) => handleSearch(e.target.value)}
    />
  );
};

export default AppListSearch;