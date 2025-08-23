import { SerializedError } from '@reduxjs/toolkit';
import { FetchBaseQueryError } from '@reduxjs/toolkit/query';
import { enqueueSnackbar } from 'notistack';
import { logDebug } from './logger';

export interface UnprocessableEntityError {
  type: string;
  title: string;
  status: number;
  errors: any;
}

export function enqueueSnackbarError(error: FetchBaseQueryError | SerializedError | String) {
  if (isFetchBaseQueryError(error)) {
    logDebug('FetchBaseQueryError', error);
    'One or more validation errors occurred.';// you can access all properties of `FetchBaseQueryError` here
    const errMsg = 'error' in error
      ? error.error
      : error.data
        && typeof error.data === 'object'
        && 'errors' in error.data
        ? JSON.stringify(error.data.errors)
        : JSON.stringify(error.data);
    enqueueSnackbar(errMsg, { variant: 'error' });
  } else if (isErrorWithMessage(error)) {
    logDebug('FetchBaseQueryError', error);
    // you can access a string 'message' property here
    enqueueSnackbar(error.message, { variant: 'error' });
  } else if (typeof error === 'string') {
    logDebug('error', error);
    enqueueSnackbar(error, { variant: 'error' });
  }
}

/**
 * Type predicate to narrow an unknown error to `FetchBaseQueryError`
 */
export function isFetchBaseQueryError(
  error: unknown
): error is FetchBaseQueryError {
  return typeof error === 'object' && error != null && 'status' in error;
}

/**
 * Type predicate to narrow an unknown error to an object with a string 'message' property
 */
export function isErrorWithMessage(
  error: unknown
): error is { message: string } {
  return (
    typeof error === 'object' &&
    error != null &&
    'message' in error &&
    typeof (error as any).message === 'string'
  );
}