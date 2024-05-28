import { Chip, Grid } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import PropTypes from 'prop-types';
import defaultUserImg from "./../../assets/images/logos/default_user_img.png";
import "./user.css";
import { formatDateV1 } from "../../services/utils/DatetimeUtils";

const columns = (convertStatus, convertGender) => [
    {
        field: "account",
        headerName: "Account",
        headerAlign: "center",
        flex: 6,
        align: "left",
        renderCell: (params) => {
            return (
                <Grid container
                    direction="row"
                    spacing={2}
                    justifyContent="flex-start"
                    alignItems="center" 
                    className="my-2">
                    <Grid item xs={4}>
                        <img src={params.value.pictureUrl ?? defaultUserImg} className="float-start rounded-circle" width={40} height={40} alt="User picture" />
                    </Grid>
                    <Grid item xs={8}>
                        <p className="mb-0">{params.value.fullName}</p>
                    </Grid>
                </Grid>
            );
        },
        sortable: false,
    },

    {
        field: "gender",
        headerName: "Gender",
        headerAlign: "center",
        align: "center",
        minWidth: 100,
        flex: 3,
        renderCell: (params) => {
            const data = convertGender(params.value);
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
        field: "createdDateTime",
        headerName: "Create date",
        headerAlign: "center",
        flex: 4,
        align: "center",
        sortable: false,
    },

    {
        field: "status",
        headerName: "Status",
        headerAlign: "center",
        align: "center",
        minWidth: 100,
        flex: 3,
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
    if (value === 2) return { label: "Inactive", color: "warning" };
};

const convertGender = (value) => {
    if (value === 0) return { label: "Other", color: "warning" };
    if (value === 1) return { label: "Male", color: "success" };
    if (value === 2) return { label: "Female", color: "primary" };
};

export default function UserList({
    data,
    page,
    size,
    totalPage,
    setPageOption,
}) {

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
                        rows={data.map((user) => ({
                            id: user.id,
                            account: { fullName: user.fullName, pictureUrl: user.pictureUrl },
                            gender: user.gender,
                            status: user.status,
                            createdDateTime: formatDateV1(user.createdDateTime)
                        }))}

                        getRowHeight={() => "auto"}
                        columns={columns(convertStatus, convertGender)}
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
        </>
    );
}

UserList.propTypes = {
    data: PropTypes.array.isRequired,
    page: PropTypes.number,
    size: PropTypes.number,
    totalPage: PropTypes.number,
    setPageOption: PropTypes.func,
}