export type ConfirmEmailRequest = {
    UserId: string;
    Code: string;
    ChangedEmail: null | string;
};