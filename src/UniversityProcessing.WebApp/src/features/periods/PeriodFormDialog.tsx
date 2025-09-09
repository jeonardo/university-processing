import React, { useEffect, useMemo, useState } from "react";
import {
  Dialog, DialogTitle, DialogContent, DialogActions,
  TextField, Button, FormControlLabel, Switch, Box, Alert
} from "@mui/material";
import { Period } from "./period";

type Props = {
  open: boolean;
  onClose: () => void;
  onSubmit: (values: Omit<Period, "id">) => Promise<void> | void;
  initial?: Period | null;
  existing: Period[];
};

type Errors = Partial<Record<keyof Omit<Period, "id">, string>> & { general?: string };

function normalizeDate(value: string): string {
  // ожидаем YYYY-MM-DD, оставляем как есть
  return value;
}

function datesOverlap(aStart: string, aEnd: string, bStart: string, bEnd: string) {
  // [aStart, aEnd] пересекается с [bStart, bEnd], если max(start) <= min(end)
  return (aStart <= bEnd) && (bStart <= aEnd);
}

export const PeriodFormDialog: React.FC<Props> = ({ open, onClose, onSubmit, initial, existing }) => {
  const [name, setName] = useState("");
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [isActive, setIsActive] = useState<boolean>(false);
  const [errors, setErrors] = useState<Errors>({});
  const [submitting, setSubmitting] = useState(false);

  useEffect(() => {
    if (initial) {
      setName(initial.name ?? "");
      setStartDate(initial.startDate ?? "");
      setEndDate(initial.endDate ?? "");
      setIsActive(Boolean(initial.isActive));
    } else {
      setName("");
      setStartDate("");
      setEndDate("");
      setIsActive(false);
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
    if (!name.trim()) next.name = "Название обязательно";
    if (!startDate) next.startDate = "Дата начала обязательна";
    if (!endDate) next.endDate = "Дата окончания обязательна";

    if (!next.startDate && !next.endDate && startDate > endDate) {
      next.endDate = "Дата окончания не может быть раньше начала";
    }

    // Пересечения периодов
    if (!next.startDate && !next.endDate) {
      const hasOverlap = existingForValidation.some(p =>
        datesOverlap(startDate, endDate, p.startDate, p.endDate)
      );
      if (hasOverlap) {
        next.general = "Период пересекается с существующими периодами";
      }
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
        startDate: normalizeDate(startDate),
        endDate: normalizeDate(endDate),
        isActive,
      });
      onClose();
    } catch (e: any) {
      setErrors(prev => ({ ...prev, general: e?.message || "Ошибка сохранения" }));
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <Dialog open={open} onClose={onClose} fullWidth maxWidth="sm">
      <DialogTitle>{initial ? "Редактировать период" : "Добавить период"}</DialogTitle>
      <DialogContent>
        <Box sx={{ display: "grid", gap: 2, mt: 1 }}>
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
            value={startDate}
            onChange={(e) => setStartDate(e.target.value)}
            error={Boolean(errors.startDate)}
            helperText={errors.startDate || "Формат: ГГГГ-ММ-ДД"}
            InputLabelProps={{ shrink: true }}
            fullWidth
          />
          <TextField
            label="Дата окончания"
            type="date"
            value={endDate}
            onChange={(e) => setEndDate(e.target.value)}
            error={Boolean(errors.endDate)}
            helperText={errors.endDate || "Формат: ГГГГ-ММ-ДД"}
            InputLabelProps={{ shrink: true }}
            fullWidth
          />
          <FormControlLabel
            control={
              <Switch
                checked={isActive}
                onChange={(e) => setIsActive(e.target.checked)}
              />
            }
            label="Сделать активным"
          />
        </Box>
      </DialogContent>
      <DialogActions>
        <Button onClick={onClose} disabled={submitting}>Отмена</Button>
        <Button onClick={handleSubmit} variant="contained" disabled={submitting}>
          {initial ? "Сохранить" : "Создать"}
        </Button>
      </DialogActions>
    </Dialog>
  );
};
