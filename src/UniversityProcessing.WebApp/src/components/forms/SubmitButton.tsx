import React from 'react';
import { Button, CircularProgress } from '@mui/material';

interface SubmitButtonProps {
  isLoading: boolean;
  label: string;
  disabled?: boolean;
}

const SubmitButton: React.FC<SubmitButtonProps> = ({
                                                     isLoading,
                                                     label,
                                                     disabled = false
                                                   }) => {
  return (
    <Button
      type="submit"
      fullWidth
      variant="contained"
      disabled={disabled || isLoading}
    >
      {isLoading ? (
        <CircularProgress size={25} color="inherit" />
      ) : (
        label
      )}
    </Button>
  );
};

export default SubmitButton;