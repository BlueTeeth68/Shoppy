import { useEffect, useState } from "react";
import { filterProductListApi } from "../../services/apis/product";
import { ToastContainer, toast } from "react-toastify";
import { Box, CircularProgress, Typography } from "@mui/material";
import ProductList from "../../components/product/productList";
import { Sidebar } from "../../components/sidebar/sidebar";
import { Header } from "../../components/header/header";

export function Product() {

    //log
    console.log("Call product screen");

    //useState
    // const [name, setName] = useState();
    // const [status, setStatus] = useState();
    // const [categoryId, setCategoryId] = useState();
    // const [sortName, setSortName] = useState();
    // const [sortPrice, setSortPrice] = useState();
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
                //log
                console.log(`page: ${pageOption.page}`)
                console.log(`size: ${pageOption.size}`)

                // const data = await filterProductListApi({
                //     name: name, status: status,
                //     categoryId: categoryId, sortName: sortName, sortPrice: sortPrice,
                //     page: pageOption.page, size: pageOption.size
                // });
                const data = await filterProductListApi({
                    // name: name, status: status,
                    // categoryId: categoryId, sortName: sortName, sortPrice: sortPrice,
                    page: pageOption.page, size: pageOption.size
                });

                // log
                console.log(`Data: ${JSON.stringify(data?.result, null, 2)}`);

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
    }, [pageOption])

    return (
        <>
            <Sidebar />
            {/* < !--Main wrapper-- > */}
            <div className="body-wrapper">
                {/* <!--  Header Start --> */}
                <Header />
                {/* <!--  Header End --> */}
                <div className="container-fluid">
                    <ToastContainer />

                    {isLoading ? (
                        <Box sx={{ display: 'flex', width: "100%", justifyContent: "center", alignItems: "center" }}>
                            <CircularProgress />
                        </Box>
                    ) : (
                        <div className="container-fluid">
                            <div className="card">

                                <div className="card-title">
                                    <Typography variant="h4" className="ms-4 my-0 mt-3">Books</Typography>
                                </div>
                                <div className="card-body">
                                    {data?.results &&
                                        <ProductList data={data?.results}
                                            page={pageOption.page}
                                            size={pageOption.size}
                                            totalPage={data.totalPages}
                                            setPageOption={setPageOption} />
                                    }
                                </div>
                            </div>
                        </div>
                    )}
                </div>
            </div>
        </>
    )
}



