import { Button } from "@mui/material";

const HomePage = () => {

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