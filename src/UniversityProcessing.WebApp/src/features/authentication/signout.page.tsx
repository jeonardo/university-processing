import {useAppDispatch} from "src/core/hooks";
import {logout} from "./auth.slice";

const SignoutPage = () => {
    const dispatch = useAppDispatch();
    dispatch(logout())
    return <></>
}

export default SignoutPage;