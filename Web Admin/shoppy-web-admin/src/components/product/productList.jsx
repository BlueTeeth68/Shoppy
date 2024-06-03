import { Chip, Grid, Rating } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import PropTypes from 'prop-types';
import "./productList.css";
import defaultBookImg from "./../../assets/images/logos/default_book_img.png";
import { UpdateProduct } from "./update/update";
import { useState } from "react";
import { convertStatus } from "../../services/utils/productUtils";

const columns = (setUpdateModal) => [
    {
        //product is {pictureUrl, name}
        field: "product",
        headerName: "Product",
        headerAlign: "center",
        flex: 8,
        align: "left",
        renderCell: (params) => {
            return (
                <Grid container spacing={0} className="my-2">
                    <Grid item xs={4}>
                        <img src={params.value.productThumbUrl ?? defaultBookImg} className="rounded float-start productList-thumb" alt="Product image" />
                    </Grid>
                    <Grid item xs={8}>
                        <p className="mb-0">{params.value.name}</p>
                    </Grid>
                </Grid>
            );
        },
        sortable: false,
    },

    {
        field: "price",
        headerName: "Price",
        headerAlign: "center",
        flex: 2,
        align: "center",
        sortable: false,
    },

    {
        field: "avgRate",
        headerName: "Average rate",
        headerAlign: "center",
        flex: 3,
        align: "center",
        sortable: false,
        renderCell: (params) => {
            const data = params.value;
            return (<Rating name="read-only" value={data} readOnly />
            );
        },

    },

    {
        field: "quantity",
        headerName: "Remain Quantity",
        headerAlign: "center",
        flex: 3,
        align: "center",
        sortable: false,
    },

    {
        field: "numberOfSale",
        headerName: "Saled",
        headerAlign: "center",
        flex: 2,
        align: "center",
        sortable: false,
    },
    {
        field: "status",
        headerName: "Status",
        headerAlign: "center",
        align: "center",
        minWidth: 100,
        flex: 2,
        renderCell: (params) => {
            const data = convertStatus(params.value);
            return (<>
                {data?.label && data?.color &&
                    <Chip label={data?.label} color={data?.color} sx={{ width: 100 }} />
                }
            </>
            );
        },
        sortable: false,
    },
    {
        field: "id",
        headerName: "Action",
        headerAlign: "center",
        align: "center",
        minWidth: 150,
        flex: 3,
        renderCell: (params) => {
            const data = params.value;
            return (<>
                {data && (
                    <Grid
                        container
                        direction="row"
                        justifyContent="space-evenly"
                        alignItems="center">
                        <button type="button" title="View" className="btn btn-secondary">
                            <i className="fa-solid fa-eye"></i>
                        </button>
                        <button type="button" onClick={() => {
                            //log
                            console.log(`Current id: ${data}`);
                            setUpdateModal({
                                open: true, 
                                currentId: data
                            })
                        }} className="btn btn-primary" title="Update" data-bs-toggle="modal"  >
                            <i className="fa-solid fa-pen-to-square"></i>
                        </button>

                    </Grid>
                )
                }
            </>
            );
        },
        sortable: false,
    },
];

export default function ProductList({
    data,
    page,
    size,
    totalPage,
    setPageOption,
    categoryList,

}) {

    // const [currentProduct, setCurrentProduct] = useState();

    const [updateModal, setUpdateModal] = useState({
        open: false,
        currentId: undefined
    })

    const isDataEmpty = data?.length === 0;

    return (
        <>
            <div style={{ minHeight: "50vh", width: "100%" }}>
                {isDataEmpty ? (
                    <h3 style={{ textAlign: "center" }}>
                        There is no product in the system
                    </h3>
                ) : (
                    <DataGrid
                        rows={data.map((product) => ({
                            id: product.id,
                            product: { name: product.name, productThumbUrl: product.productThumbUrl },
                            description: product.description,
                            price: product.price,
                            avgRate: product.avgRate,
                            quantity: product.quantity,
                            numberOfSale: product.numberOfSale,
                            status: product.status
                        }))}

                        getRowHeight={() => "auto"}
                        columns={columns(setUpdateModal)}
                        initialState={{
                            pagination: {
                                paginationModel: { page: page - 1, pageSize: size },
                            },
                        }}
                        pagination
                        paginationMode="server"
                        paginationModel={{ page: page - 1 || 0, pageSize: size || 10 }}
                        onPaginationModelChange={(newPage) => {
                            setPageOption({
                                page: newPage.page + 1,
                                size: newPage.pageSize
                            })
                        }}
                        rowSelection={false}
                        disableColumnMenu={true}
                        rowCount={totalPage}

                        pageSizeOptions={[10, 20, 30]}
                    />
                )}
            </div>

            {updateModal.open &&
                <UpdateProduct categoryList={categoryList} productId={updateModal.currentId} open={updateModal.open} setUpdateModal={setUpdateModal} />}
        </>
    );
}

ProductList.propTypes = {
    data: PropTypes.array.isRequired,
    page: PropTypes.number,
    size: PropTypes.number,
    totalPage: PropTypes.number,
    setPageOption: PropTypes.func,
    categoryList: PropTypes.array
}