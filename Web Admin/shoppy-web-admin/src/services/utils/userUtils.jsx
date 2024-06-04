
export const convertGender = (value) => {
    if (value === 0) return { label: "Other", color: "warning" };
    if (value === 1) return { label: "Male", color: "success" };
    if (value === 2) return { label: "Female", color: "primary" };
};

export const Gender = [
    {
        name: "Other",
        normalName: "Other",
        value: 0
    },
    {
        name: "Male",
        normalName: "Male",
        value: 1
    },
    {
        name: "Female",
        normalName: "Female",
        value: 2
    },
]

export const UserStatus = [
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
]