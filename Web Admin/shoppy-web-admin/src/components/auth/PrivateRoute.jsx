import { useLocation, Navigate } from "react-router-dom";
import {
    AdminPages,
    PublicPages,
    UnauthenticatedPages,
} from "../../services/auth/authPage";

// eslint-disable-next-line react/prop-types
const PrivateRoute = ({ page, component: Component }) => {
    const location = useLocation();

    const userString = localStorage.getItem("user");
    let user;

    try {
        user = JSON.parse(userString ?? "");
    } catch (error) {
        user = undefined;
    }

    if (!page) {
        return <Navigate to="/not-found" state={{ from: location }} replace />;
    } else {
        if (!user) {
            //Check case user have not logged in
            if (!PublicPages.includes(page) && !UnauthenticatedPages.includes(page)) {
                return <Navigate to="/auth/login" state={{ from: location }} replace />;
            } else {
                return Component;
            }
        } else {
            if (UnauthenticatedPages.includes(page)) {
                //navigate to home page
                return <Navigate to="/home" state={{ from: location }} replace />;
            } else {
                if (
                    !PublicPages.includes(page) &&
                    !AdminPages.includes(page)
                ) {
                    return (
                        <Navigate to="/not-found" state={{ from: location }} replace />
                    );
                } else {
                    if (page === "home")
                        return (
                            <Navigate
                                to="/home"
                                state={{ from: location }}
                                replace
                            />
                        );
                    return Component;
                }
            }
        }
    }
};

export default PrivateRoute;
