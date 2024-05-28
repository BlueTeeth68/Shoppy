import { Formik } from "formik";
import * as yup from 'yup';
import { Form } from "react-bootstrap";
import { useState } from "react";
import { ToastContainer, toast } from "react-toastify";
import { Backdrop, CircularProgress, Dialog, DialogActions, DialogContent, DialogTitle, Typography } from "@mui/material";
import PropTypes from 'prop-types';
import { useEffect } from "react";
import { getCategoryByIdApi, updateCategoryApi } from "../../../services/apis/category";
import { useNavigate } from "react-router-dom";

export function UpdateCategory({ open, setOpen, id, setId }) {

    const navigate = useNavigate();

    const [isLoading, setIsLoading] = useState(false);
    const [category, setCategory] = useState();

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

        const fetchApi = async () => {
            setIsLoading(true);
            try {

                var data = await getCategoryByIdApi(id);

                //log
                console.log(`Update category: ${JSON.stringify(data, null, 2)}`)

                setCategory(data?.result);

            } catch (error) {
                //log
                console.log(`Error when get category detail : ${JSON.stringify(error, null, 2)}`);

                let message;
                if (error.response?.message) {
                    message = error.response?.data?.error?.detail || "Something wrong.";
                } else {
                    message = error.message || "Something wrong.";
                }
                notifyFail(message);
            } finally {
                setIsLoading(false);
            }
        }
        fetchApi();

    }, [id])

    const handleSubmit = async (values) => {
        setIsLoading(true);
        const { id, name, description } = values;
        try {
            const updateData = {
                id: id,
                name: name,
                description: description
            }
            await updateCategoryApi({ data: updateData });
            window.location.reload();
        } catch (error) {
            //log
            console.log(`Error when update book : ${JSON.stringify(error, null, 2)}`);

            let message;
            if (error?.status === 401 || error?.response?.status === 401) {
                localStorage.clear();
                navigate("/auth/login");
            }

            if (error?.response?.message) {
                message = error.response?.data?.error?.detail ?? "Something wrong";
            } else {
                message = error?.message;
            }
            notifyFail(message);
        } finally {
            setIsLoading(false);
        }
    }

    const handleClose = () => {
        setCategory(null);
        setId(null);
        setOpen(false);
    }

    const schema = yup.object().shape({
        id: yup.string().required("id is required"),
        name: yup.string()
            .trim()
            .max(250, "Name is too long"),
        description: yup.string().notRequired().max(250, "Too long")
    });

    return (<>
        {/* < !--Button trigger modal-- > */}
        <Backdrop
            sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 2 }}
            open={isLoading}
        >
            <CircularProgress color="primary" />
        </Backdrop>
        {category &&
            <Dialog
                open={open}
                sx={{ zIndex: (theme) => theme.zIndex.drawer + 1 }}
                onClose={handleClose}
                maxWidth="md"
                fullWidth>
                <ToastContainer />

                <DialogTitle textAlign={"center"} > <Typography variant="h4">Update</Typography></DialogTitle>
                <DialogContent>
                    <Formik
                        validationSchema={schema}
                        onSubmit={(values) => handleSubmit(values)}
                        initialValues={{
                            id: category.id,
                            name: category.name,
                            description: category.description
                        }}
                    >
                        {({ handleSubmit, handleChange, values, touched, errors }) => (
                            <Form id="updateForm" onSubmit={handleSubmit}>
                                <input type="hidden" name="id" value={category.id} />
                                <Form.Group
                                    controlId="validateName"
                                    className="position-relative mb-3"
                                >
                                    <Form.Label className="form-label" >Name</Form.Label>
                                    <Form.Control
                                        type="text"
                                        name="name"
                                        placeholder="Input name"
                                        value={values.name}
                                        onChange={handleChange}
                                        isValid={touched.name && !errors.name}
                                    />
                                    <Form.Control.Feedback type="invalid" className="d-block text-danger">
                                        {errors.name}
                                    </Form.Control.Feedback>
                                </Form.Group>

                                <Form.Group
                                    controlId="validationDescription"
                                    className="position-relative mb-3"
                                >
                                    <Form.Label className="form-label">Description</Form.Label>
                                    <Form.Control
                                        as="textarea"
                                        name="description"
                                        placeholder="Input description"
                                        value={values.description}
                                        onChange={handleChange}
                                        isValid={touched.description && !errors.description}
                                        rows={3}
                                    />
                                    <Form.Control.Feedback type="invalid" className="d-block text-danger">
                                        {errors.description}
                                    </Form.Control.Feedback>
                                </Form.Group>

                            </Form>
                        )}
                    </Formik>
                </DialogContent>

                <DialogActions>
                    <button type="button" className="btn btn-danger" onClick={handleClose}>Cancel</button>
                    <button type="submit" className="btn btn-primary" form="updateForm" autoFocus>Save</button>
                </DialogActions>

            </Dialog >
        }
    </>)

}


UpdateCategory.propTypes = {
    id: PropTypes.string.isRequired,
    open: PropTypes.bool,
    setOpen: PropTypes.func,
    setId: PropTypes.func
}