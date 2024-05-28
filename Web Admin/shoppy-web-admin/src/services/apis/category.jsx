import instance from "./base/baseApi";

export const getCategoriesApi = async () => {
    const response = await instance.get(`categories`);
    return response.data;
}

export const createCategoriesApi = async (data) => {
    const response = await instance.post(`categories`, data);
    return response.data;
}

export const getCategoryByIdApi = async (id) => {
    const response = await instance.get(`categories/${id}`);
    return response.data;
}

export const updateCategoryApi = async ({data}) => {
    const response = await instance.put(`categories/${data?.id}`, data);
    return response.data;
}