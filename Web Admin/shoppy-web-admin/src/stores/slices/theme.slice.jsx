import { createSlice } from "@reduxjs/toolkit"

const initialState = {
    currentMenu: "Dashboard"
}

const themeSlice = createSlice({
    name: "menu",
    data: initialState,
    reducers: {
        setCurrentMenu: (state, action) => {
            state.data.currentMenu = action.payload;
        },
        resetData: (state) => {
            state.data = initialState
        }
    }
});

export const {setCurrentMenu, resetData} = themeSlice.actions;

export default themeSlice.reducer;