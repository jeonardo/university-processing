import React from 'react';
import { Autocomplete, CircularProgress, TextField } from '@mui/material';

interface BaseProps<TOption> {
  options: TOption[];
  value: TOption | null;
  onChange: (value: TOption | null) => void;
  getOptionLabel: (option: TOption) => string;
  label: string;
  disabled?: boolean;
  required?: boolean;
  loading?: boolean;
  freeSolo?: boolean;
  inputValue?: string;
  placeholder?: string;
  onInputChange?: (event: React.SyntheticEvent, value: string) => void;
}

function AutocompleteField<TOption>(props: BaseProps<TOption>) {
  const {
    options,
    value,
    onChange,
    getOptionLabel,
    label,
    disabled = false,
    required = false,
    loading = false,
    freeSolo,
    inputValue,
    onInputChange
  } = props;

  return (
    <Autocomplete
      freeSolo={freeSolo}
      options={options}
      getOptionLabel={getOptionLabel as any}
      value={value as any}
      onChange={(_, newValue) => onChange(newValue as any)}
      disabled={disabled}
      inputValue={inputValue}
      onInputChange={onInputChange}
      renderInput={(params) => (
        <TextField
          {...params}
          label={label}
          required={required}
          placeholder={props.placeholder}
          InputProps={{
            ...params.InputProps,
            endAdornment: (
              <>
                {loading ? <CircularProgress color="inherit" size={16} /> : null}
                {params.InputProps.endAdornment}
              </>
            ),
          }}
        />
      )}
    />
  );
}

export default AutocompleteField;





