import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { PeriodState } from './period.contracts';

const initialState: PeriodState = {
    id: '',
    name: ''
};

const periodSlice = createSlice({
    name: 'period',
    initialState,
    reducers: {
        setPeriod: (state: PeriodState, action: PayloadAction<PeriodState>) => {
            state.id = action.payload.id;
            state.name = action.payload.name;
        }
    }
});

export const { setPeriod } = periodSlice.actions;

export default periodSlice.reducer;