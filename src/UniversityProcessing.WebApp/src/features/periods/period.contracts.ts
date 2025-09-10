import { PeriodsGetPeriod } from "src/api/backendApi";

export interface PeriodState {
    SelectedPeriod: PeriodsGetPeriod;
    Periods: PeriodsGetPeriod[];
}