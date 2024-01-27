import { Status } from "../../core/common/Status";
import { TokenData } from "./types/TokenData";

export type AuthState = {
    isAuthenticated: boolean;
    tokenData: TokenData | null;
    status: Status
    error: string | null;
  };