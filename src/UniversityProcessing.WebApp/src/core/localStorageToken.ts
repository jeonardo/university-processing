import { AuthTokens } from 'src/features/auth/auth.contracts';
import { localStorageGetObject, localStorageSetData } from './localStorage';

const TOKEN_KEY: string = 'bntu_token';

const GetAuthTokens = (): AuthTokens | null => {
  return localStorageGetObject<AuthTokens>(TOKEN_KEY);
};

const SetAuthTokens = (authTokens: AuthTokens) => {
  localStorageSetData(TOKEN_KEY, authTokens);
};

const ClearAuthTokens = () => {
  localStorageSetData(TOKEN_KEY, null);
};

export { GetAuthTokens, SetAuthTokens, ClearAuthTokens };