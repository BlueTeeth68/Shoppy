import { ToastContainer, toast } from "react-toastify";
import { Header } from "../../components/header/header";
import { Sidebar } from "../../components/sidebar/sidebar";
import { Box, CircularProgress, Grid, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { filterUserListApi } from "../../services/apis/user";
import UserList from "../../components/user/userList";
import { useNavigate } from "react-router-dom";
import DropdownCustomComponent from "../../components/dropdowncomponent/dropdown";
import { Gender, UserStatus } from "../../services/utils/userUtils";
import { North, Search, South } from "@mui/icons-material";


export function User() {

    const navigate = useNavigate();

    const [name, setName] = useState("");
    const [query, setQuery] = useState("");
    const [gender, setGender] = useState(undefined);
    const [status, setStatus] = useState(undefined);
    const [sortFilter, setSortFilter] = useState({
        sortName: undefined,
        sortCreatedDate: undefined
    })

    const [pageOption, setPageOption] = useState({
        page: 1, size: 10
    });

    const [data, setData] = useState([]);
    const [isLoading, setIsLoading] = useState(false);

    const handleSearchSubmit = () => {
        setName(query);
    }

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
                    page: pageOption.page, size: pageOption.size,
                    name: name,
                    gender: gender,
                    status: status,
                    sortName: sortFilter.sortName,
                    sortCreatedDate: sortFilter.sortCreatedDate
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
    }, [pageOption, name, status, gender, sortFilter, navigate]);

    const genderOptions = [
        {
            title: "All",
            handleClick: () => {
                setGender(undefined);
            }
        },
        ...Gender.map((item) => (
            {
                title: item.normalName,
                handleClick: () => {
                    setGender(item.value);
                }
            }
        ))
    ]

    const statusOptions = [
        {
            title: "All",
            handleClick: () => {
                setStatus(undefined);
            }
        },
        ...UserStatus.map((item) => ({
            title: item.normalName,
            handleClick: () => {
                setStatus(item.value);
            }
        }))
    ];

    const sortOptions = [
        {
            title: <div className="d-flex justify-content-start align-items-center "><span>Default</span></div>,
            handleClick: () => {
                setSortFilter(values => ({ ...values, sortName: undefined, sortCreatedDate: undefined }))
            }
        },
        {
            title: <div className="d-flex justify-content-start align-items-center "> <South className="me-2" /><span>Name ascending</span></div>,
            handleClick: () => {
                setSortFilter(values => ({ ...values, sortName: "asc", sortCreatedDate: undefined }))
            }
        },
        {
            title: <div className="d-flex justify-content-start align-items-center "> <North className="me-2" /><span>Name descending</span></div>,
            handleClick: () => {
                setSortFilter(values => ({ ...values, sortName: "desc", sortCreatedDate: undefined }))
            },
        },
        {
            title: <div className="d-flex justify-content-start align-items-center "> <South className="me-2" /><span>Create date ascending</span></div>,
            handleClick: () => {
                setSortFilter(values => ({ ...values, sortName: undefined, sortCreatedDate: "asc" }))
            }
        },
        {
            title: <div className="d-flex justify-content-start align-items-center "> <North className="me-2" /><span>Create date descending</span></div>,
            handleClick: () => {
                setSortFilter(values => ({ ...values, sortName: undefined, sortCreatedDate: "desc" }))
            }
        },
    ];


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

                                <Grid
                                    px={4}
                                    width={"100%"}
                                    container
                                    direction="row"
                                    justifyContent="space-between"
                                    alignItems="center"
                                >
                                    <form onSubmit={handleSearchSubmit} className="d-flex justify-content-start align-items-center w-50 w-sm-100 w-md-50 mt-2">
                                        <input type="text" className="form-control w-75 me-1" id="name"
                                            placeholder="Search"
                                            value={query} onChange={(event) => setQuery(event.target.value)} />
                                        <button type="submit" className="btn btn-primary py-0 px-3" style={{ height: "39px" }}><Search /></button>
                                    </form>
                                    <Grid
                                        container
                                        width={"50%"}
                                        mx={0}
                                        direction="row"
                                        justifyContent="flex-end"
                                        alignItems="center"
                                        className="mt-2">
                                        <DropdownCustomComponent title="Gender" options={genderOptions} className={' d-none d-md-block '} />

                                        <DropdownCustomComponent title="Status" options={statusOptions} className={' d-none d-md-block '} />
                                        <DropdownCustomComponent title="Sorting" options={sortOptions} className={' d-none d-md-block '} />
                                    </Grid>
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