export type LoginRequest = {
    Email: string;
    Password: string;
    TwoFactorCode: null | string;
    TwoFactorRecoveryCode: null | string; 
};