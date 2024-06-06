import { Form } from "react-bootstrap";
import * as formik from "formik";
import * as yup from 'yup';
import { loginApi } from "../../services/apis/auth";
import { useState } from "react";
import { ToastContainer, toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
import { Backdrop, CircularProgress } from "@mui/material";
import { jwtDecode } from "jwt-decode";

export function Login() {

    const [isLoading, setIsLoading] = useState(false);
    const navigate = useNavigate();

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

    const { Formik } = formik;

    const handleSubmit = async (values) => {
        const { email, password } = values;
        setIsLoading(true);
        try {
            const data = await loginApi({ email, password });
            const user = {
                id: data.result.id,
                email: data.result.email,
                fullName: data.result.fullName,
                pictureUrl: data.result.pictureUrl,
            }
            const accessToken = data.result.accessToken;

            const decodedToken = jwtDecode(accessToken ?? "");
            const roles = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
            if (!roles?.includes("Admin")) {
                throw Error("Access denied");
            }

            localStorage.setItem("user", JSON.stringify(user));
            localStorage.setItem("accessToken", accessToken);

            navigate("/home");
            console.log(JSON.stringify(data, null, 2));
        } catch (error) {
            //log
            console.log(`Error when login: ${JSON.stringify(error, null, 2)}`);

            let message;
            if (error.response) {
                message = error.response?.data?.error?.detail || "Something wrong.";
            } else {
                message = error.message || "Something wrong.";
            }
            notifyFail(message);
        } finally {
            setIsLoading(false);
        }
    }

    const schema = yup.object().shape({
        email: yup
            .string()
            .email("Invalid email")
            .required("Email name is required")
            .trim(),
        password: yup
            .string()
            .required("Password is required")
            .trim()
            .min(8, "Password must have at least 8 character")
    });

    return (
        // < !--Body Wrapper-- >
        <div className="">
            <Backdrop
                sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
                open={isLoading}
            >
                <CircularProgress color="inherit" />
            </Backdrop>
            <ToastContainer />
            <div className="page-wrapper" id="main-wrapper" data-layout="vertical" data-navbarbg="skin6" data-sidebartype="full"
                data-sidebar-position="fixed" data-header-position="fixed">
                <div
                    className="position-relative overflow-hidden radial-gradient min-vh-100 d-flex align-items-center justify-content-center">
                    <div className="d-flex align-items-center justify-content-center w-100">
                        <div className="row justify-content-center w-100">
                            <div className="col-md-8 col-lg-6 col-xxl-3">
                                <div className="card mb-0">
                                    <div className="card-body">
                                        <h1 className="text-nowrap logo-img text-center d-block py-3 w-100">
                                            <p className="text-uppercase text-primary fw-bold mb-0">Shoppy</p>
                                        </h1>
                                        <Formik
                                            validationSchema={schema}
                                            onSubmit={handleSubmit}
                                            initialValues={{
                                                email: "",
                                                password: ""
                                            }}
                                        >
                                            {({ handleSubmit, handleChange, values, touched, errors }) => (
                                                <Form id="loginForm" onSubmit={handleSubmit}>
                                                    <Form.Group
                                                        controlId="validationEmail"
                                                        className="position-relative mb-3"
                                                    >
                                                        <Form.Label className="form-label" >Email</Form.Label>
                                                        <Form.Control
                                                            type="email"
                                                            name="email"
                                                            placeholder="Input email"
                                                            value={values.email}
                                                            onChange={handleChange}
                                                            isValid={touched.email && !errors.email}
                                                        />
                                                        <Form.Control.Feedback type="invalid" className="d-block text-danger">
                                                            {errors.email}
                                                        </Form.Control.Feedback>
                                                    </Form.Group>

                                                    <Form.Group
                                                        controlId="validationPassword"
                                                        className="position-relative mb-3"
                                                    >
                                                        <Form.Label className="form-label" >Password</Form.Label>
                                                        <Form.Control
                                                            type="password"
                                                            name="password"
                                                            placeholder="Input strong password"
                                                            value={values.password}
                                                            onChange={handleChange}
                                                            isValid={touched.password && !errors.password}
                                                        />
                                                        <Form.Control.Feedback type="invalid" className="d-block text-danger">
                                                            {errors.password}
                                                        </Form.Control.Feedback>
                                                    </Form.Group>

                                                    <button type="submit" form="loginForm" className="btn btn-primary w-100 py-8 fs-4 mb-4 rounded-2">
                                                        Sign In
                                                    </button>
                                                </Form>
                                            )}
                                        </Formik>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}