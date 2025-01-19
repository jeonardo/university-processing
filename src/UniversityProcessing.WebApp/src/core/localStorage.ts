import { logDebug } from './logger';

export function localStorageGetObject<T>(dataKey: string): T | null {
  try {
    const data = localStorage.getItem(dataKey);
    if (data) {
      return JSON.parse(data) as T;
    }
  } catch (error) {
    logDebug(error);
  }

  return null;
}

export function localStorageGetString(dataKey: string): string | null {
  try {
    const data = localStorage.getItem(dataKey);
    if (data) {
      return data;
    }
  } catch (error) {
    logDebug(error);
  }

  return null;
}

export function localStorageSetData(dataKey: string, dataToSet: any): boolean {
  try {
    if (dataToSet && typeof dataToSet === 'object') {
      localStorage.setItem(dataKey, JSON.stringify(dataToSet));
    } else {
      localStorage.setItem(dataKey, dataToSet);
    }
    return true;
  } catch (error) {
    logDebug(error);
  }

  return false;
}