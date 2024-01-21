import { Status } from "../../../core/common/Status";
import { UserTokenData } from "./UserTokenData";

export type AuthState = {
    isAuthenticated: boolean;
    basicUserInfo: UserTokenData | null;
    status: Status
    error: string | null;
  };