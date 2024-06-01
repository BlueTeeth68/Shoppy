import { ToastContainer, toast } from "react-toastify";
import { Header } from "../../components/header/header";
import { Sidebar } from "../../components/sidebar/sidebar";
import { Box, CircularProgress, Grid, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { filterUserListApi } from "../../services/apis/user";
import UserList from "../../components/user/userList";
import { useNavigate } from "react-router-dom";


export function User() {

    const navigate = useNavigate();

    const [pageOption, setPageOption] = useState({
        page: 1, size: 10
    });

    const [data, setData] = useState([]);
    const [isLoading, setIsLoading] = useState(false);

    //notification
    const notifyFail = (message) =>
        toast.error(message, {
            position: "top-right",
            autoClose: 4000,
            hideProgressBar: false,
            closeButton: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
            theme: "colored",
        });

    useEffect(() => {
        //fetch data
        const fetchData = async () => {
            try {
                setIsLoading(true);
                const data = await filterUserListApi({
                    page: pageOption.page, size: pageOption.size
                });

                setData(data?.result || {});
            } catch (error) {
                //log
                console.log(`Error: ${JSON.stringify(error, null, 2)}`);
                let message;

                if (error?.status === 401 || error?.response?.status === 401) {
                    localStorage.clear();
                    navigate("/auth/login");
                }

                if (error?.response?.message) {
                    message = error.response?.data?.error?.detail ?? "Something wrong";
                } else {
                    message = error?.message ?? "Something wrong";
                }
                notifyFail(message);
            } finally {
                setIsLoading(false);
            }
        };
        fetchData();
    }, [pageOption, navigate]);


    return (<>
        <Sidebar activeMenu={2} />
        <div className="body-wrapper">
            <Header />
            <div className="container-fluid">
                <ToastContainer />
                <div className="container-fluid">
                    <div className="card" style={{ minHeight: "50vh" }}>

                        <>
                            <div className="card-title">
                                <Grid container
                                    px={4}
                                    direction="row"
                                    justifyContent="start"
                                    alignItems="center" >
                                    <Typography variant="h4" className="my-0 mt-3">Users</Typography>
                                </Grid>
                            </div>
                            {isLoading ? (
                                <Box className="mt-3" sx={{ display: 'flex', width: "100%", justifyContent: "center", alignItems: "center" }}>
                                    <CircularProgress />
                                </Box>
                            ) : (
                                <div className="card-body">
                                    {data?.results &&
                                        <UserList
                                            data={data?.results}
                                            page={pageOption.page}
                                            size={pageOption.size}
                                            totalPage={data.totalPages}
                                            setPageOption={setPageOption} />
                                    }
                                </div>)}
                        </>
                    </div>
                </div>

            </div>
        </div>
    </>)
}