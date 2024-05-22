import { configureStore } from "@reduxjs/toolkit";
import themeSlice from "../stores/slices/theme.slice";
//Store in redux is used to store state of application
export const store = configureStore({
    reducer: {
        theme: themeSlice
    },
});