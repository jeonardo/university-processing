import React, { useEffect, useMemo, useState } from 'react';
import { Alert, Box, Button, Dialog, DialogActions, DialogContent, DialogTitle, TextField } from '@mui/material';
import { ApiPeriodsGetPeriodDto } from 'src/api/backendApi';

type Props = {
  open: boolean;
  onClose: () => void;
  onSubmit: (values: Omit<ApiPeriodsGetPeriodDto, 'id'>) => Promise<void> | void;
  initial?: ApiPeriodsGetPeriodDto | null;
  existing: ApiPeriodsGetPeriodDto[];
};

type Errors = Partial<Record<keyof Omit<ApiPeriodsGetPeriodDto, 'id'>, string>> & { general?: string };

function normalizeDate(value: string): string {
  return value;
}

function datesOverlap(aStart: string, aEnd: string, bStart: string, bEnd: string) {
  return (aStart <= bEnd) && (bStart <= aEnd);
}

export const PeriodFormDialog: React.FC<Props> = ({ open, onClose, onSubmit, initial, existing }) => {
  const [name, setName] = useState('');
  const [from, setStartDate] = useState('');
  const [to, setEndDate] = useState('');
  const [errors, setErrors] = useState<Errors>({});
  const [submitting, setSubmitting] = useState(false);

  useEffect(() => {
    if (initial) {
      setName(initial.name ?? '');
      setStartDate(initial.from ?? '');
      setEndDate(initial.to ?? '');
    } else {
      setName('');
      setStartDate('');
      setEndDate('');
    }
    setErrors({});
    setSubmitting(false);
  }, [initial, open]);

  const existingForValidation = useMemo(
    () => existing.filter(p => p.id !== initial?.id),
    [existing, initial?.id]
  );

  const validate = (): boolean => {
    const next: Errors = {};
    if (!name.trim()) next.name = 'Название обязательно';
    if (!from) next.from = 'Дата начала обязательна';
    if (!to) next.to = 'Дата окончания обязательна';

    if (!next.from && !next.to && from > to) {
      next.to = 'Дата окончания не может быть раньше начала';
    }

    setErrors(next);
    return Object.keys(next).length === 0;
  };

  const handleSubmit = async () => {
    if (!validate()) return;
    setSubmitting(true);
    try {
      await onSubmit({
        name: name.trim(),
        from: normalizeDate(from),
        to: normalizeDate(to)
      });
      onClose();
    } catch (e: any) {
      setErrors(prev => ({ ...prev, general: e?.message || 'Ошибка сохранения' }));
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <Dialog open={open} onClose={onClose} fullWidth maxWidth="sm">
      <DialogTitle>{initial ? 'Редактировать период' : 'Добавить период'}</DialogTitle>
      <DialogContent>
        <Box sx={{ display: 'grid', gap: 2, mt: 1 }}>
          {errors.general && <Alert severity="error">{errors.general}</Alert>}
          <TextField
            label="Название"
            value={name}
            onChange={(e) => setName(e.target.value)}
            error={Boolean(errors.name)}
            helperText={errors.name}
            fullWidth
          />
          <TextField
            label="Дата начала"
            type="date"
            value={from}
            onChange={(e) => setStartDate(e.target.value)}
            error={Boolean(errors.from)}
            helperText={errors.from || 'Формат: ГГГГ-ММ-ДД'}
            InputLabelProps={{ shrink: true }}
            fullWidth
          />
          <TextField
            label="Дата окончания"
            type="date"
            value={to}
            onChange={(e) => setEndDate(e.target.value)}
            error={Boolean(errors.to)}
            helperText={errors.to || 'Формат: ГГГГ-ММ-ДД'}
            InputLabelProps={{ shrink: true }}
            fullWidth
          />
        </Box>
      </DialogContent>
      <DialogActions>
        <Button onClick={onClose} disabled={submitting}>Отмена</Button>
        <Button onClick={handleSubmit} variant="contained" disabled={submitting}>
          {initial ? 'Сохранить' : 'Создать'}
        </Button>
      </DialogActions>
    </Dialog>
  );
};
