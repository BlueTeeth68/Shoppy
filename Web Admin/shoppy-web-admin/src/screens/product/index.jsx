import { useEffect, useState } from "react";
import { filterProductListApi, getCategoriesApi } from "../../services/apis/product";
import { ToastContainer, toast } from "react-toastify";
import { Box, CircularProgress, Grid, Typography } from "@mui/material";
import ProductList from "../../components/product/productList";
import { Sidebar } from "../../components/sidebar/sidebar";
import { Header } from "../../components/header/header";
import { AddNewProduct } from "../../components/product/create/create";
import { FilterNone, North, Search, South } from "@mui/icons-material";
import DropdownCustomComponent from "../../components/dropdowncomponent/dropdown";
import { ProductStatuses } from "../../services/utils/productUtils";

export function Product() {

    //log
    console.log("Call product list");

    //useState
    const [name, setName] = useState(undefined);
    const [query, setQuery] = useState("");
    const [status, setStatus] = useState(undefined);
    const [categoryId, setCategoryId] = useState(undefined);
    const [categoryOptions, setCategoryOptions] = useState([]);

    const [sortFilter, setSortFilter] = useState({
        sortName: undefined,
        sortPrice: undefined
    });

    const [pageOption, setPageOption] = useState({
        page: 1, size: 10
    });

    const [categories, setCategories] = useState([]);

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

                const data = await filterProductListApi({
                    name: name, status: status,
                    categoryId: categoryId, sortName: sortFilter.sortName, sortPrice: sortFilter.sortPrice,
                    page: pageOption.page, size: pageOption.size
                });

                setData(data?.result || {});
            } catch (error) {
                //log
                console.log(`Error: ${JSON.stringify(error, null, 2)}`);
                let message;
                if (error.response) {
                    message = error.response?.data?.error?.detail ?? "Something wrong";
                } else {
                    message = error.message;
                }
                notifyFail(message);
            } finally {
                setIsLoading(false);
            }
        };
        fetchData();
    }, [categoryId, name, pageOption, sortFilter, status]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await getCategoriesApi();
                const categoriesData = data?.result ?? [];
                let options = [
                    {
                        title: "All",
                        handleClick: () => setCategoryId(undefined)
                    },
                    ...categories.map((item) => ({
                        title: item.name,
                        handleClick: () => setCategoryId(item.id)
                    }))
                ];
                setCategoryOptions(options);

                setCategories(categoriesData);
            } catch (error) {
                //log
                console.log(`Error: ${JSON.stringify(error, null, 2)}`);
                let message;
                if (error.response) {
                    message = error.response?.data?.error?.detail ?? "Something wrong";
                } else {
                    message = error.message;
                }
                notifyFail(message);
            }
        }

        fetchData();
    }, [categories]);

    const handleSearchSubmit = (e) => {
        e.preventDefault();
        setName(query);
    }

    const sortOptions = [
        {
            title: <div className="d-flex justify-content-start align-items-center "><span>Default</span></div>,
            handleClick: () => {
                // setSortName(undefined);
                // setSortPrice(undefined);
                setSortFilter(values => ({ ...values, sortName: undefined, sortPrice: undefined }))
            }
        },
        {
            title: <div className="d-flex justify-content-start align-items-center "> <South className="me-2" /><span>Name ascending</span></div>,
            handleClick: () => {
                setSortFilter(values => ({ ...values, sortName: "asc", sortPrice: undefined }))
            }
        },
        {
            title: <div className="d-flex justify-content-start align-items-center "> <North className="me-2" /><span>Name descending</span></div>,
            handleClick: () => {
                setSortFilter(values => ({ ...values, sortName: "desc", sortPrice: undefined }))
            },
        },
        {
            title: <div className="d-flex justify-content-start align-items-center "> <South className="me-2" /><span>Price ascending</span></div>,
            handleClick: () => {
                setSortFilter(values => ({ ...values, sortName: undefined, sortPrice: "asc" }))
            }
        },
        {
            title: <div className="d-flex justify-content-start align-items-center "> <North className="me-2" /><span>Price descending</span></div>,
            handleClick: () => {
                setSortFilter(values => ({ ...values, sortName: undefined, sortPrice: "desc" }))
            }
        },
    ];

    const statusOptions = ProductStatuses.map((item) => ({
        title: item.normalName,
        handleClick: () => {
            setStatus(item.value);
        }
    }));

    return (
        <>
            <Sidebar activeMenu={4} />
            <div className="body-wrapper">
                <Header />
                <div className="container-fluid">
                    <ToastContainer />
                    <div className="container-fluid">
                        <div className="card" style={{ minHeight: "50vh" }}>
                            <div className="card-title">
                                <Grid container
                                    px={4}
                                    direction="row"
                                    justifyContent="space-between"
                                    alignItems="center" >
                                    <Typography variant="h4" className="my-0 mt-3">Books</Typography>
                                    <AddNewProduct categoryList={categories ?? []} />
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
                                        {categoryOptions && categoryOptions.length > 0 &&
                                            <DropdownCustomComponent title="Category" options={categoryOptions} className={' d-none d-md-block '} />
                                        }
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
                                        <ProductList data={data?.results}
                                            page={pageOption.page}
                                            size={pageOption.size}
                                            totalPage={data.totalPages}
                                            setPageOption={setPageOption}
                                            categoryList={categories} />
                                    }
                                </div>

                            )}
                        </div>
                    </div>

                </div>
            </div>
        </>
    )
}



