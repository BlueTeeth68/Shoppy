import axios from "axios";


//api production
// const url = "https://localhost:7061/api/v1/";
const url = "https://localhost:44301/api/v1";

const instance = axios.create({
    baseURL: url,
    headers: {
        "Content-Type": "application/json",
    },
});

// config request Authenticate header
instance.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem("accessToken");
        if (token) {
            config.headers["Authorization"] = `Bearer ${token}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

export default instance;
