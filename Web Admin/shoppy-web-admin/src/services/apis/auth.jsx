import instance from "./base/baseApi";

export const loginApi = async (data) => {
    const response = await instance.post(
        `auth/login`,
        data
    );
    return response.data;
};