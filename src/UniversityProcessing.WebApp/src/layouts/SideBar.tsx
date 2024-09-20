import {IconButton, SvgIcon, SvgIconProps} from "@mui/material";
import {useNavigate} from "react-router-dom";

const SideBar = () => {
    const navigate = useNavigate()

    function HomeIcon(props: SvgIconProps) {
        return (
            <SvgIcon {...props}>
                <path d="M10 20v-6h4v6h5v-8h3L12 3 2 12h3v8z"/>
            </SvgIcon>
        );
    }

    return (
        <div className="flex h-full w-[50px] items-center ">
            <div className="flex flex-col h-[350px] w-full p-2 my-20 shadow-lg items-center rounded-full">
                <IconButton size="small" onClick={() => navigate("/")}>
                    <HomeIcon fontSize="medium"/>
                </IconButton>
                <IconButton size="small" onClick={() => navigate("/umt")}>
                    UMT
                </IconButton>
            </div>
        </div>)
}
export default SideBar;