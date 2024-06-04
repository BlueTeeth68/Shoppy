import instance from "./base/baseApi";

export const filterUserListApi = async (filter) => {
    const nameParam = filter.name ? `name=${filter.name}&` : '';
    const genderParam = filter.gender !== undefined && filter.gender !== null ? `gender=${filter.gender}&` : '';
    const statusParam = filter.status ? `status=${filter.status}&` : '';

    const sortNameParam = filter.sortName ? `sortName=${filter.sortName}&` : '';
    const sortCreatedDateParam = filter.sortCreatedDate ? `sortCreatedDate=${filter.sortCreatedDate}&` : '';
    const pageParam = `page=${filter.page ?? 1}&`;
    const sizeParam = `size=${filter.size ?? 10}`;

    const queryString = `${nameParam}${statusParam}${genderParam}${sortNameParam}${sortCreatedDateParam}${pageParam}${sizeParam}`;

    //log
    console.log(`query string: ${queryString}`);

    const response = await instance.get(`users?${queryString}`);
    return response.data;
};