import { ApiPeriodsGetPeriodDto } from "src/api/backendApi";

export interface PeriodState {
    SelectedPeriod: ApiPeriodsGetPeriodDto;
    Periods: ApiPeriodsGetPeriodDto[];
}