import React from 'react';
import { DatePicker } from '@mui/x-date-pickers';
import { Dayjs } from 'dayjs';

interface DatePickerFieldProps {
  label: string;
  value: Dayjs | null;
  onChange: (date: Dayjs | null) => void;
  disabled?: boolean;
  error?: boolean;
  helperText?: string;
  required?: boolean;
}

const DatePickerField: React.FC<DatePickerFieldProps> = ({
  label,
  value,
  onChange,
  disabled = false,
  error = false,
  helperText,
  required = false
}) => {
  return (
    <DatePicker
      label={label}
      value={value}
      onChange={onChange}
      disabled={disabled}
      slotProps={{
        textField: {
          fullWidth: true,
          error,
          helperText,
          required
        }
      }}
    />
  );
};

export default DatePickerField;