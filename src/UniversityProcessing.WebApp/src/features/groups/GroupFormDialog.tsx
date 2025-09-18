import React, { useState } from 'react';
import {
  Box,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  Stack,
  TextField,
  Typography
} from '@mui/material';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { Dayjs } from 'dayjs';
import { ApiGroupsCreateRequestDto, useGetApiPeriodsGetQuery, useGetApiSpecialtiesGetQuery } from 'src/api/backendApi';
import { AuthUser } from '../auth/auth.contracts';

interface GroupFormDialogProps {
  open: boolean;
  onClose: () => void;
  onSubmit: (data: ApiGroupsCreateRequestDto) => void;
  user: AuthUser;
}

const GroupFormDialog: React.FC<GroupFormDialogProps> = ({
                                                           open,
                                                           onClose,
                                                           onSubmit,
                                                           user
                                                         }) => {
  const [formData, setFormData] = useState<ApiGroupsCreateRequestDto>({
    groupNumber: '',
    startDate: '',
    endDate: '',
    specialtyId: '',
    periodId: ''
  });

  const [startDate, setStartDate] = useState<Dayjs | null>(null);
  const [endDate, setEndDate] = useState<Dayjs | null>(null);

  const [errors, setErrors] = useState<Partial<ApiGroupsCreateRequestDto>>({});

  const { data: periodsData } = useGetApiPeriodsGetQuery();

  const { data: specialtiesData } = useGetApiSpecialtiesGetQuery({
    pageNumber: 1,
    pageSize: 100,
    departmentId: user?.departmentId ?? ''
  });

  const isLoading = false;

  const handleInputChange = (field: keyof ApiGroupsCreateRequestDto) => (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement> | any
  ) => {
    const value = event.target?.value || event;
    setFormData(prev => ({ ...prev, [field]: value }));

    // Очищаем ошибку при изменении поля
    if (errors[field]) {
      setErrors(prev => ({ ...prev, [field]: undefined }));
    }
  };

  const handleDateChange = (field: 'startDate' | 'endDate') => (date: Dayjs | null) => {
    if (date) {
      const isoString = date.format('YYYY-MM-DD');
      setFormData(prev => ({ ...prev, [field]: isoString }));

      if (field === 'startDate') {
        setStartDate(date);
      } else {
        setEndDate(date);
      }
    }
  };

  const validateForm = (): boolean => {
    const newErrors: Partial<ApiGroupsCreateRequestDto> = {};

    if (!formData.groupNumber.trim()) {
      newErrors.groupNumber = 'Номер группы обязателен';
    }

    if (!formData.startDate) {
      newErrors.startDate = 'Дата начала обязательна';
    }

    if (!formData.endDate) {
      newErrors.endDate = 'Дата окончания обязательна';
    }

    if (!formData.specialtyId) {
      newErrors.specialtyId = 'Специальность обязательна';
    }

    if (!formData.periodId) {
      newErrors.periodId = 'Период обязателен';
    }

    // Проверяем, что дата окончания больше даты начала
    if (formData.startDate && formData.endDate && formData.startDate >= formData.endDate) {
      newErrors.endDate = 'Дата окончания должна быть больше даты начала';
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = (event: React.FormEvent) => {
    event.preventDefault();

    if (validateForm()) {
      onSubmit(formData);
    }
  };

  const handleClose = () => {
    setFormData({
      groupNumber: '',
      startDate: '',
      endDate: '',
      specialtyId: '',
      periodId: ''
    });
    setStartDate(null);
    setEndDate(null);
    setErrors({});
    onClose();
  };

  return (
    <Dialog open={open} onClose={handleClose} maxWidth="sm" fullWidth>
      <DialogTitle>Создать новую группу</DialogTitle>
      <form onSubmit={handleSubmit}>
        <DialogContent>
          <Stack spacing={3} sx={{ pt: 2 }}>
            <TextField
              label="Номер группы"
              value={formData.groupNumber}
              onChange={handleInputChange('groupNumber')}
              error={!!errors.groupNumber}
              helperText={errors.groupNumber}
              fullWidth
              required
              disabled={isLoading}
            />

            <Box sx={{ display: 'flex', gap: 2 }}>
              <DatePicker
                label="Дата начала"
                value={startDate}
                onChange={handleDateChange('startDate')}
                disabled={isLoading}
                slotProps={{
                  textField: {
                    fullWidth: true,
                    error: !!errors.startDate,
                    helperText: errors.startDate,
                    required: true
                  }
                }}
              />

              <DatePicker
                label="Дата окончания"
                value={endDate}
                onChange={handleDateChange('endDate')}
                disabled={isLoading}
                slotProps={{
                  textField: {
                    fullWidth: true,
                    error: !!errors.endDate,
                    helperText: errors.endDate,
                    required: true
                  }
                }}
              />
            </Box>

            <FormControl fullWidth required error={!!errors.specialtyId}>
              <InputLabel>Специальность</InputLabel>
              <Select
                value={formData.specialtyId}
                onChange={handleInputChange('specialtyId')}
                label="Специальность"
                disabled={isLoading}
              >
                {specialtiesData?.items?.map((specialty) => (
                  <MenuItem key={specialty.id} value={specialty.id}>
                    {specialty.name} ({specialty.code})
                  </MenuItem>
                ))}
              </Select>
              {errors.specialtyId && (
                <Typography variant="caption" color="error" sx={{ mt: 0.5, ml: 1.75 }}>
                  {errors.specialtyId}
                </Typography>
              )}
            </FormControl>

            <FormControl fullWidth required error={!!errors.periodId}>
              <InputLabel>Период</InputLabel>
              <Select
                value={formData.periodId}
                onChange={handleInputChange('periodId')}
                label="Период"
                disabled={isLoading}
              >
                {periodsData?.list?.map((period) => (
                  <MenuItem key={period.id} value={period.id}>
                    {period.name} ({period.from} - {period.to})
                  </MenuItem>
                ))}
              </Select>
              {errors.periodId && (
                <Typography variant="caption" color="error" sx={{ mt: 0.5, ml: 1.75 }}>
                  {errors.periodId}
                </Typography>
              )}
            </FormControl>
          </Stack>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} disabled={isLoading}>
            Отмена
          </Button>
          <Button
            type="submit"
            variant="contained"
            disabled={isLoading}
          >
            {isLoading ? 'Создание...' : 'Создать'}
          </Button>
        </DialogActions>
      </form>
    </Dialog>
  );
};

export default GroupFormDialog;
