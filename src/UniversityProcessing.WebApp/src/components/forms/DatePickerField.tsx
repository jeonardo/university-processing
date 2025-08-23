import React from 'react';
import { DatePicker } from '@mui/x-date-pickers';
import { Dayjs } from 'dayjs';

interface DatePickerFieldProps {
    label: string;
    value: Dayjs;
    onChange: (date: Dayjs | null) => void;
    disabled?: boolean;
}

const DatePickerField: React.FC<DatePickerFieldProps> = ({
    label,
    value,
    onChange,
    disabled = false,
}) => {
    return (
        <DatePicker
            label={label}
            value={value}
            onChange={onChange}
            disabled={disabled}
        />
    );
};

export default DatePickerField;