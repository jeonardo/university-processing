import { Button } from "@mui/material";

const HomePage = () => {
  // const dispatch = useAppDispatch();
  // const navigate = useNavigate();

  // const basicUserInfo = useAppSelector((state) => state.auth.basicUserInfo);
  // const userProfileInfo = useAppSelector((state) => state.auth.userProfileData);

  // useEffect(() => {
  //   if (basicUserInfo) {
  //     dispatch(getUser(basicUserInfo.id));
  //   }
  // }, [basicUserInfo]);

  // const handleLogout = async () => {
  //   try {
  //     await dispatch(logout()).unwrap();
  //     navigate("/login");
  //   } catch (e) {
  //     console.error(e);
  //   }
  // };

  return (
    <>    
      <h1>Home</h1>
      <Button variant="contained" sx={{ mt: 3, mb: 2 }}>
        Logout
      </Button>
    </>
  );
};

export default HomePage;