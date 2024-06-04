import { Formik } from "formik";
import * as yup from 'yup';
import { Form } from "react-bootstrap";
import { useState } from "react";
import { createApi } from "../../../services/apis/product";
import { ToastContainer, toast } from "react-toastify";
import PropTypes from 'prop-types';
import { Backdrop, CircularProgress, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";

export function AddNewProduct({ categoryList }) {

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
        const { name, description, authorName, publisher, numberOfPage,
            dateOfPublication, price, quantity, categoryId, productThumb
        } = values;
        setIsLoading(true);
        try {

            const createData = {
                name: name,
                description: description,
                authorName: authorName, publisher: publisher,
                numberOfPage: numberOfPage,
                dateOfPublication: dateOfPublication, price: price,
                quantity: quantity, categoryId: categoryId,
                productThumb: productThumb
            }

            await createApi(createData);

            // notifySuccess("Add book success");
            window.location.reload();
        } catch (error) {
            //log
            console.log(`Error when create new product: ${JSON.stringify(error, null, 2)}`);

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
        description: yup.string(),
        productThumb: yup.mixed()
            .test('fileRequired', 'Product thumbnail is required', (value) => {
                return value instanceof File;
            })
            .test('fileSize', 'File size should be less than 5MB', (value) => {
                return value && value.size <= 5 * 1024 * 1024;
            })
            .test('fileType', 'Only image files are allowed', (value) => {
                return value && ['image/jpeg', 'image/png', 'image/jpg', 'image/svg', 'image/webp', 'image/heic', 'image/gif'].includes(value.type);
            })
            .required('Product thumbnail is required'),
        authorName: yup.string()
            .max(100, "Too long"),
        publisher: yup.string()
            .max(100, "Too long"),
        numberOfPage: yup.number()
            .min(0)
            .max(100000),
        dateOfPublication: yup.date()
            .max(new Date()),
        price: yup.number()
            .min(0),
        quantity: yup.number()
            .min(0)
            .required(),
        categoryId: yup.string()
            .required()
    });

    return (<>
        {/* < !--Button trigger modal-- > */}
        <button type="button" className="btn btn-primary admin-btn" data-bs-toggle="modal" data-bs-target="#addNew">
            <i className="fa-solid fa-circle-plus me-2"></i>Create
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
                        <p ><Typography variant="h4">Add new</Typography> </p>
                        <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div className="modal-body">
                        <Formik
                            validationSchema={schema}
                            onSubmit={handleSubmit}
                            initialValues={{
                                name: "",
                                description: "",
                                authorName: undefined,
                                publisher: undefined,
                                numberOfPage: undefined,
                                dateOfPublication: undefined,
                                price: 10,
                                quantity: 1000,
                                categoryId: categoryList[0]?.id ?? "",
                                productThumb: undefined

                            }}
                        >
                            {({ handleSubmit, handleChange, setFieldValue, values, touched, errors }) => (
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

                                    <Form.Group
                                        controlId="validationProductThumb"
                                        className="position-relative mb-3"
                                    >
                                        <Form.Label className="form-label">Product Thumbnail</Form.Label>
                                        <Form.Control
                                            type="file"
                                            name="productThumb"
                                            placeholder="Choose product thumbnail"
                                            onChange={(event) => {
                                                setFieldValue('productThumb', event.currentTarget.files[0]);
                                            }}
                                            isValid={touched.productThumb && !errors.productThumb}
                                            isInvalid={touched.productThumb && !!errors.productThumb}
                                        />
                                        <Form.Control.Feedback type="invalid" className="d-block text-danger">
                                            {errors.productThumb}
                                        </Form.Control.Feedback>
                                    </Form.Group>

                                    <Form.Group
                                        controlId="validationAuthorName"
                                        className="position-relative mb-3"
                                    >
                                        <Form.Label className="form-label">Author name</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="authorName"
                                            placeholder="Input authorName"
                                            value={values.authorName}
                                            onChange={handleChange}
                                            isValid={touched.authorName && !errors.authorName}
                                        />
                                        <Form.Control.Feedback type="invalid" className="d-block text-danger">
                                            {errors.authorName}
                                        </Form.Control.Feedback>
                                    </Form.Group>

                                    <Form.Group
                                        controlId="validationPublisher"
                                        className="position-relative mb-3"
                                    >
                                        <Form.Label className="form-label">Publisher</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="publisher"
                                            placeholder="Input publisher"
                                            value={values.publisher}
                                            onChange={handleChange}
                                            isValid={touched.publisher && !errors.publisher}
                                        />
                                        <Form.Control.Feedback type="invalid" className="d-block text-danger">
                                            {errors.publisher}
                                        </Form.Control.Feedback>
                                    </Form.Group>

                                    <Form.Group
                                        controlId="validationNumberOfPage"
                                        className="position-relative mb-3"
                                    >
                                        <Form.Label className="form-label">Number of page</Form.Label>
                                        <Form.Control
                                            type="number"
                                            name="numberOfPage"
                                            min={1}
                                            max={10000}
                                            placeholder="Input numberOfPage"
                                            value={values.numberOfPage}
                                            onChange={handleChange}
                                            isValid={touched.numberOfPage && !errors.numberOfPage}
                                        />
                                        <Form.Control.Feedback type="invalid" className="d-block text-danger">
                                            {errors.numberOfPage}
                                        </Form.Control.Feedback>
                                    </Form.Group>

                                    <Form.Group
                                        controlId="validationDateOfPublication"
                                        className="position-relative mb-3"
                                    >
                                        <Form.Label className="form-label">Date of publication</Form.Label>
                                        <Form.Control
                                            type="date"
                                            name="dateOfPublication"
                                            max={new Date().toISOString().split('T')[0]}
                                            placeholder="Input dateOfPublication"
                                            value={values.dateOfPublication}
                                            onChange={handleChange}
                                            isValid={touched.dateOfPublication && !errors.dateOfPublication}
                                        />
                                        <Form.Control.Feedback type="invalid" className="d-block text-danger">
                                            {errors.dateOfPublication}
                                        </Form.Control.Feedback>
                                    </Form.Group>

                                    <Form.Group
                                        controlId="validationPrice"
                                        className="position-relative mb-3"
                                    >
                                        <Form.Label className="form-label">Price</Form.Label>
                                        <Form.Control
                                            type="number"
                                            name="price"
                                            min={0}
                                            step={0.1}
                                            placeholder="Input price"
                                            value={values.price}
                                            onChange={handleChange}
                                            isValid={touched.price && !errors.price}
                                        />
                                        <Form.Control.Feedback type="invalid" className="d-block text-danger">
                                            {errors.price}
                                        </Form.Control.Feedback>
                                    </Form.Group>

                                    <Form.Group
                                        controlId="validationQuantity"
                                        className="position-relative mb-3"
                                    >
                                        <Form.Label className="form-label">Quantity</Form.Label>
                                        <Form.Control
                                            type="number"
                                            name="quantity"
                                            min={0}
                                            placeholder="Input quantity"
                                            value={values.quantity}
                                            onChange={handleChange}
                                            isValid={touched.quantity && !errors.quantity}
                                        />
                                        <Form.Control.Feedback type="invalid" className="d-block text-danger">
                                            {errors.quantity}
                                        </Form.Control.Feedback>
                                    </Form.Group>

                                    <Form.Group
                                        controlId="validationCategoryId"
                                        className="position-relative mb-3"
                                    >
                                        <Form.Label className="form-label">Category Id</Form.Label>
                                        <Form.Control
                                            as="select"
                                            name="categoryId"
                                            placeholder="Select categoryId"
                                            value={values.categoryId}
                                            onChange={handleChange}
                                            isValid={touched.categoryId && !errors.categoryId}
                                        >
                                            {categoryList && categoryList.map((tmp, index) => (
                                                <option key={index} value={tmp.id}>{tmp.name} </option>
                                            ))}
                                            {/* Add more options as needed */}
                                        </Form.Control>
                                        <Form.Control.Feedback type="invalid" className="d-block text-danger">
                                            {errors.categoryId}
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

AddNewProduct.propTypes = {
    categoryList: PropTypes.array.isRequired
}

