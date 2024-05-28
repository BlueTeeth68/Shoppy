import PropTypes from 'prop-types';
import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, styled, tableCellClasses } from "@mui/material";
import { useState } from 'react';
import { UpdateCategory } from './update/update';

const StyledTableCell = styled(TableCell)(({ theme }) => ({
    [`&.${tableCellClasses.head}`]: {
        backgroundColor: theme.palette.common.black,
        color: theme.palette.common.white,
    },
    [`&.${tableCellClasses.body}`]: {
        fontSize: 14,
    },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
    '&:nth-of-type(odd)': {
        backgroundColor: theme.palette.action.hover,
    },
    '&:last-child td, &:last-child th': {
        border: 0,
    },
}));

export default function CategoryList({
    data
}) {
    const [currentId, setCurrentId] = useState();
    const [open, setOpen] = useState(false);
    const isDataEmpty = data?.length === 0;

    return (
        <>
            <div style={{ minHeight: "50vh", width: "100%" }}>
                {isDataEmpty ? (
                    <h3 style={{ textAlign: "center" }}>
                        There is no category in the system
                    </h3>
                ) : (
                    <TableContainer component={Paper}>
                        <Table sx={{ minWidth: 700 }} aria-label="customized table">
                            <TableHead>
                                <TableRow>
                                    <StyledTableCell align='center'>Name</StyledTableCell>
                                    <StyledTableCell align='center'>Description</StyledTableCell>
                                    <StyledTableCell align='center'>Action</StyledTableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {data.map((row, index) => (
                                    <StyledTableRow key={index}>
                                        {/* <StyledTableCell component="th" scope="row">
                                            {row.name}
                                        </StyledTableCell> */}
                                        <StyledTableCell width={"25%"}>{row.name}</StyledTableCell>
                                        <StyledTableCell width={"60%"}>{row.description}</StyledTableCell>
                                        <StyledTableCell width={"15%"} align='center'>
                                            <button type="button" onClick={() => {
                                                //log
                                                console.log(`Current id: ${row.id}`)
                                                setCurrentId(row.id);
                                                setOpen(true);
                                            }} className="btn btn-primary" title="Update" data-bs-toggle="modal"  >
                                                <i className="fa-solid fa-pen-to-square"></i>
                                            </button></StyledTableCell>
                                    </StyledTableRow>
                                ))}
                            </TableBody>
                        </Table>
                    </TableContainer>
                )}
            </div>

            {currentId &&
                <UpdateCategory id={currentId} open={open} setOpen={setOpen} setId={setCurrentId} />}
        </>
    );
}

CategoryList.propTypes = {
    data: PropTypes.array.isRequired
}



