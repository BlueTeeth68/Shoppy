
import instance from "./base/baseApi";

export const filterProductListApi = async (filter) => {
    const nameParam = filter.name ? `name=${filter.name}&` : '';
    const statusParam = filter.status ? `status=${filter.status}&` : '';
    const categoryIdParam = filter.categoryId ? `categoryId=${filter.categoryId}&` : '';
    const sortNameParam = filter.sortName ? `sortName=${filter.sortName}&` : '';
    const sortPriceParam = filter.sortPrice ? `sortPrice=${filter.sortPrice}&` : '';
    const pageParam = `page=${filter.page ?? 1}&`;
    const sizeParam = `size=${filter.size ?? 10}`;

    // Construct the full query string
    const queryString = `${nameParam}${statusParam}${categoryIdParam}${sortNameParam}${sortPriceParam}${pageParam}${sizeParam}`;

    // Log the constructed URI for debugging
    console.log(`Constructed filter URI: products?${queryString}`);

    const response = await instance.get(`products?${queryString}`);
    return response.data;
};

export const createApi = async (data) => {
    const response = await instance.post(`products`, data);
    return response.data;
}

export const getCategoriesApi = async () => {
    const response = await instance.get(`categories`);
    return response.data;
}