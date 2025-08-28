// Общие компоненты
export { default as CommonFormFields } from './CommonFormFields';
export { default as FormContainer } from './FormContainer';
export { default as PositionSelector } from './PositionSelector';
export { default as FacultySelector } from './FacultySelector';
export { default as DepartmentSelector } from './DepartmentSelector';
export { default as GroupSelector } from './GroupSelector';

// Общие хуки
export { useFormValidation } from './useFormValidation';
export { useFormSubmission } from './useFormSubmission';
export { useFormState } from './useFormState';

// Типы
export type { CommonFormData, ExtendedFormData } from './CommonFormFields';
export type { ValidationRules } from './useFormValidation';
export type { FormSubmissionConfig } from './useFormSubmission';

// Существующие компоненты
export { default as RegisterAdminForm } from './RegisterAdminForm';
export { default as RegisterDeaneryForm } from './RegisterDeaneryForm';
export { default as RegisterStudentForm } from './RegisterStudentForm';
export { default as RegisterTeacherForm } from './RegisterTeacherForm';
export { default as RegisterResultModal } from './RegisterResultModal';
export { default as TestUsersCard } from './TestUsersCard';
