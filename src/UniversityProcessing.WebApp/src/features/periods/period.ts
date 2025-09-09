export type Period = {
    id: string;
    name: string;
    startDate: string; // ISO: 'YYYY-MM-DD'
    endDate: string;   // ISO: 'YYYY-MM-DD'
    isActive?: boolean;
};