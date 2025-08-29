import React, { ReactNode } from 'react';
import { Dialog, DialogContent, DialogTitle } from '@mui/material';

interface ModalFormProps {
  open: boolean;
  title: string;
  onClose: () => void;
  children: ReactNode;
  maxWidth?: 'xs' | 'sm' | 'md' | 'lg' | 'xl' | false;
}

const ModalForm: React.FC<ModalFormProps> = ({ open, title, onClose, children, maxWidth = 'sm' }) => {
  return (
    <Dialog open={open} onClose={onClose} maxWidth={maxWidth} fullWidth>
      <DialogTitle>{title}</DialogTitle>
      <DialogContent>
        {children}
      </DialogContent>
    </Dialog>
  );
};

export default ModalForm;



