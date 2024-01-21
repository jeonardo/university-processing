export type ResetPasswordRequest = {
    Email: string;
    ResetCode: string;
    NewPassword: string;
};