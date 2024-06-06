import { useLocation, Navigate } from "react-router-dom";
import {
    AdminPages,
    PublicPages,
    UnauthenticatedPages,
} from "../../services/auth/authPage";
import PropTypes from 'prop-types';
import { jwtDecode } from "jwt-decode";

const PrivateRoute = ({ page: page, component: Component }) => {
    const location = useLocation();

    const userString = localStorage.getItem("user");
    const accessTokenn = localStorage.getItem("accessToken");

    let isAdmin = false;

    if(accessTokenn){
        const decodedToken = jwtDecode(accessTokenn ?? "");
        //log
        console.log(`Decoded token: ${JSON.stringify(decodedToken, null,2)}}`);
        const roles = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    
         isAdmin = roles?.includes("Admin") ?? false;
    }

    let user;

    try {
        user = JSON.parse(userString ?? "");
    } catch (error) {
        user = undefined;
    }

    if (!page) {
        return <Navigate to="/not-found" state={{ from: location }} replace />;
    } else {
        if (!user || !isAdmin) {
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

PrivateRoute.propTypes = {
    page: PropTypes.string,
    component: PropTypes.element
}
