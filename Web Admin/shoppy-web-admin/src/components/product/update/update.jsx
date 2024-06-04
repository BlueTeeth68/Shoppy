import { Formik } from "formik";
import * as yup from 'yup';
import { Form } from "react-bootstrap";
import { useEffect, useState } from "react";
import { getByIdApi, updateApi } from "../../../services/apis/product";
import { ToastContainer, toast } from "react-toastify";
import PropTypes from 'prop-types';
import { Backdrop, CircularProgress, Dialog, DialogActions, DialogContent, DialogTitle, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";


export function UpdateProduct({ categoryList, open, productId, setUpdateModal }) {

    const navigate = useNavigate();

    const [isLoading, setIsLoading] = useState(false);
    const [product, setProduct] = useState();

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

                var data = await getByIdApi(productId);
                setProduct(data?.result);

            } catch (error) {
                //log
                console.log(`Error when get book detail : ${JSON.stringify(error, null, 2)}`);

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

    }, [productId])

    const handleSubmit = async (values) => {
        setIsLoading(true);
        const { id, name, description, authorName, publisher, numberOfPage,
            dateOfPublication, price, quantity, categoryId,
            productThumb
        } = values;
        try {
            const updateData = {
                id: id,
                name: name,
                description: description,
                authorName: authorName, publisher: publisher,
                numberOfPage: numberOfPage,
                dateOfPublication: dateOfPublication, price: price,
                quantity: quantity, categoryId: categoryId,
                productThumb: productThumb
            }

            await updateApi({ id: updateData.id, data: updateData });

            // notifySuccess("Update success");
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
        setProduct(null);
        setUpdateModal({
            open: false,
            currentId: null
        })
    }

    const schema = yup.object().shape({
        id: yup.string().required(),
        name: yup.string()
            .trim()
            .max(250, "Name is too long"),
        description: yup.string().notRequired(),
        productThumb: yup.mixed()
            .test('fileSize', 'File size should be less than 5MB', (value) => {
                return !value || value.size <= 5 * 1024 * 1024;
            })
            .test('fileType', 'Only image files are allowed', (value) => {
                return !value || ['image/jpeg', 'image/png', 'image/jpg', 'image/svg', 'image/webp', 'image/heic', 'image/gif'].includes(value.type);
            })
            .notRequired(),
        authorName: yup.string()
            .max(100, "Too long").notRequired(),
        publisher: yup.string()
            .max(100, "Too long").notRequired(),
        numberOfPage: yup.number()
            .min(0)
            .max(100000).notRequired(),
        dateOfPublication: yup.date()
            .max(new Date()).notRequired(),
        price: yup.number()
            .min(0).notRequired(),
        quantity: yup.number()
            .min(0).notRequired(),
        categoryId: yup.string().notRequired()
    });

    return (<>
        {/* < !--Button trigger modal-- > */}
        <Backdrop
            sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 4 }}
            open={isLoading}
        >
            <CircularProgress color="primary" />
        </Backdrop>
        {product &&
            <Dialog
                open={open}
                sx={{ zIndex: (theme) => theme.zIndex.drawer + 3 }}
                onClose={handleClose}
                maxWidth="md"
                fullWidth>
                <ToastContainer />

                <DialogTitle textAlign={"center"} > <Typography>Update</Typography></DialogTitle>
                <DialogContent>
                    <Formik
                        validationSchema={schema}
                        onSubmit={(values) => handleSubmit(values)}
                        initialValues={{
                            id: product.id,
                            name: product.name,
                            description: product.description ?? undefined,
                            authorName: product.authorName,
                            publisher: product.publisher,
                            numberOfPage: product.numberOfPage,
                            dateOfPublication: product.dateOfPublication ? new Date(product.dateOfPublication + 'Z')?.toISOString().slice(0, 10) : "",
                            price: product.price,
                            quantity: product.quantity,
                            categoryId: product.categoryId,
                            productThumb: undefined
                        }}
                    >
                        {({ handleSubmit, handleChange, setFieldValue, values, touched, errors }) => (
                            <Form id="updateForm" onSubmit={handleSubmit}>
                                <input type="hidden" name="id" value={product.id} />
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
                </DialogContent>

                <DialogActions>
                    <button type="button" className="btn btn-danger" onClick={handleClose}>Cancel</button>
                    <button type="submit" className="btn btn-primary" form="updateForm" autoFocus>Save</button>
                </DialogActions>

            </Dialog >
        }
    </>)

}

UpdateProduct.propTypes = {
    categoryList: PropTypes.array.isRequired,
    productId: PropTypes.string.isRequired,
    open: PropTypes.bool,
    setUpdateModal: PropTypes.func.isRequired
}