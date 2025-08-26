import { debounce, InputAdornment, TextField } from '@mui/material';
import { useCallback, useState } from 'react';
import {
  Add as AddIcon,
  Block as BlockIcon,
  CheckCircle as CheckCircleIcon,
  Delete as DeleteIcon,
  Edit as EditIcon,
  School as SchoolIcon,
  Search as SearchIcon,
  VerifiedUser as VerifiedUserIcon,
  Work as WorkIcon
} from '@mui/icons-material';
interface AppListSearchProps {
  label: string,
  placeholder: string,
  onSearchValueChangedDebounced: (newSearch: string) => void;
}

const AppListSearch = ({ label, onSearchValueChangedDebounced: onValueChangedDebounced, placeholder }: AppListSearchProps) => {

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