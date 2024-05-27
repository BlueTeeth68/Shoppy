import { Chip, Grid } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import PropTypes from 'prop-types';
import "./productList.css";
import defaultBookImg from "./../../assets/images/logos/default_book_img.png";

const columns = (convertStatus) => [
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
        field: "description",
        headerName: "Description",
        headerAlign: "center",
        flex: 2,
        align: "center",
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
];

const convertStatus = (value) => {
    if (value === 1) return { label: "Active", color: "primary" };
    if (value === 2) return { label: "Inactive", color: "success" };
    if (value === 3) return { label: "Out of stock", color: "error" };
};

export default function ProductList({
    data,
    page,
    size,
    totalPage,
    setPageOption

}) {
    const isDataEmpty = data?.length === 0;

    //log
    console.log("Call product list");
    console.log(`product list Size: ${size}`)

    return (
        <div style={{ minHeight: 400, width: "100%" }}>
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
                        status: product.status,
                    }))}

                    getRowHeight={() => "auto"}
                    columns={columns(convertStatus)}
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
                // checkboxSelection
                />
            )}
        </div>
    );
}

ProductList.propTypes = {
    data: PropTypes.array.isRequired,
    page: PropTypes.number,
    size: PropTypes.number,
    totalPage: PropTypes.number,
    setPageOption: PropTypes.func
}