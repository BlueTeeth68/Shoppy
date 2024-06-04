// eslint-disable-next-line react-refresh/only-export-components
export const convertStatus = (value) => {
    if (value === 1) return { label: "Active", color: "primary" };
    if (value === 2) return { label: "Inactive", color: "success" };
    if (value === 3) return { label: "Out of stock", color: "error" };
};

export const ProductStatuses = [
    {
        name: "All",
        normalName: "All",
        value: undefined
    },
    {
        name: "Active",
        normalName: "Active",
        value: 1
    },
    {
        name: "Inactive",
        normalName: "Inactive",
        value: 2
    },
    {
        name: "OutOfStock",
        normalName: "Out Of Stock",
        value: 3
    }
]
