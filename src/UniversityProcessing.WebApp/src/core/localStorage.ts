import { ENV } from './env';

export function localStorageGetObject<T>(dataKey: string): T | null {
  try {
    const data = localStorage.getItem(dataKey);

    return (data != null && data != '')
      ? JSON.parse(data) as T
      : null;

  } catch (error) {
    if (ENV.VITE_IS_DEVELOPMENT)
      console.log(error);
    return null;
  }
}

export function localStorageGetString(dataKey: string): string | null {
  try {
    return localStorage.getItem(dataKey);
  } catch (error) {
    if (ENV.VITE_IS_DEVELOPMENT)
      console.log(error);
    return null;
  }
}

export function localStorageSetData(dataKey: string, dataToSet: any): boolean {
  try {
    if (dataToSet !== null && typeof dataToSet === 'object') {
      localStorage.setItem(dataKey, JSON.stringify(dataToSet));
    } else {
      localStorage.setItem(dataKey, dataToSet);
    }
    return true;
  } catch (error) {
    if (ENV.VITE_IS_DEVELOPMENT)
      console.log(error);
    return false;
  }
}