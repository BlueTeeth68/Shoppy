import { Formik } from "formik";
import * as yup from 'yup';
import { Form } from "react-bootstrap";
import { useState } from "react";
import { ToastContainer, toast } from "react-toastify";
import { Backdrop, CircularProgress, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { createCategoriesApi } from "../../../services/apis/category";

export function AddNewCategory() {

    const navigate = useNavigate();

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

    const handleSubmit = async (values) => {
        const { name, description } = values;
        setIsLoading(true);
        try {

            const createData = {
                name: name,
                description: description
            }

            await createCategoriesApi(createData);

            window.location.reload();
        } catch (error) {
            //log
            console.log(`Error when create new category: ${JSON.stringify(error, null, 2)}`);

            if (error?.status === 401 || error?.response?.status === 401) {
                localStorage.clear();
                navigate("/auth/login");
            }

            let message;
            if (error?.response?.message) {
                message = error.response?.data?.error?.detail ?? "Something wrong";
            } else {
                message = error?.message ?? "Something wrong";
            }
            notifyFail(message);
        } finally {
            setIsLoading(false);
        }
    }

    const schema = yup.object().shape({
        name: yup.string()
            .required("Name is required")
            .trim()
            .max(250, "Name is too long"),
        description: yup.string()
    });

    return (<>
        {/* < !--Button trigger modal-- > */}
        <button type="button" className="btn btn-primary admin-btn" data-bs-toggle="modal" data-bs-target="#addNew">
            <i className="fa-solid fa-circle-plus me-2"></i> Create
        </button>

        <Backdrop
            sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
            open={isLoading}
        >
            <CircularProgress color="primary" />
        </Backdrop>

        {/* <!--Modal --> */}
        <div className="modal fade" id="addNew" data-bs-backdrop="static" data-bs-keyboard="false" tabIndex="-1" aria-hidden="true">
            <ToastContainer />
            <div className="modal-dialog modal-dialog-centered modal-dialog-scrollable modal-lg">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title" ><Typography variant="h4">Add new</Typography> </h5>
                        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div className="modal-body">
                        <Formik
                            validationSchema={schema}
                            onSubmit={handleSubmit}
                            initialValues={{
                                name: "",
                                description: ""

                            }}
                        >
                            {({ handleSubmit, handleChange, values, touched, errors }) => (
                                <Form id="addNewForm" onSubmit={handleSubmit}>
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
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                        <button type="submit" className="btn btn-primary" form="addNewForm">Create</button>
                    </div>
                </div>
            </div>
        </div>
    </>
    )

}

