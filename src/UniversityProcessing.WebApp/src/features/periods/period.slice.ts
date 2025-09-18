import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { PeriodState } from './period.contracts';
import { ApiPeriodsGetPeriodDto } from 'src/api/backendApi';

const initialState: PeriodState = {
  SelectedPeriod: { id: '', name: '', from: '', to: '' },
  Periods: []
};

const periodSlice = createSlice({
  name: 'period',
  initialState,
  reducers: {
    setPeriod: (state: PeriodState, action: PayloadAction<ApiPeriodsGetPeriodDto>) => {
      state.SelectedPeriod = action.payload;
    },
    setPeriods: (state: PeriodState, action: PayloadAction<ApiPeriodsGetPeriodDto[]>) => {
      state.Periods = action.payload;
    }
  }
});

export const { setPeriod, setPeriods } = periodSlice.actions;

export default periodSlice.reducer;