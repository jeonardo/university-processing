import { appEnv } from './appEnv';

export function logDebug(message?: any, ...optionalParams: any[]) {
  if (appEnv.VITE_IS_DEVELOPMENT)
    console.log(message, ...optionalParams);
}