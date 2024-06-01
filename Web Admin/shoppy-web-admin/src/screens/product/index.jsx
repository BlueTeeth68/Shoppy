import { useEffect, useState } from "react";
import { filterProductListApi, getCategoriesApi } from "../../services/apis/product";
import { ToastContainer, toast } from "react-toastify";
import { Box, CircularProgress, Grid, Typography } from "@mui/material";
import ProductList from "../../components/product/productList";
import { Sidebar } from "../../components/sidebar/sidebar";
import { Header } from "../../components/header/header";
import { AddNewProduct } from "../../components/product/create/create";
import { Search } from "@mui/icons-material";
import DropDownComponent from "../../components/dropdown/dropdown";

export function Product() {

    //useState
    const [name, setName] = useState();
    const [status, setStatus] = useState();
    const [categoryId, setCategoryId] = useState();
    const [sortName, setSortName] = useState();
    const [sortPrice, setSortPrice] = useState();
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
                    categoryId: categoryId, sortName: sortName, sortPrice: sortPrice,
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
    }, [categoryId, pageOption, sortName, sortPrice, status]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const data = await getCategoriesApi();
                setCategories(data?.result || []);
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
    }, []);

    const handleSearchSubmit = (e) => {
        e.preventDefault();
        const fetchData = async () => {
            try {
                setIsLoading(true);

                const data = await filterProductListApi({
                    name: name, status: status,
                    categoryId: categoryId, sortName: sortName, sortPrice: sortPrice,
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
    }

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
                                    mt={2}
                                    container
                                    direction="row"
                                    justifyContent="space-between"
                                    alignItems="center"
                                    className="w-100 container"
                                >
                                    <form onSubmit={handleSearchSubmit} className="d-flex justify-content-start align-items-center w-50 ">
                                        <input type="text" className="form-control w-75 me-1" id="name"
                                            placeholder="Search"
                                            value={name} onChange={(event) => setName(event.target.value)} />
                                        <button type="submit" className="btn btn-primary py-0 px-3" style={{ height: "39px" }}><Search /></button>
                                    </form>

                                    <DropDownComponent />
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



