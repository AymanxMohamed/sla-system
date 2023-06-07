import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import User from "../types/User";

const authSlice = createSlice({
    name: "auth",
    initialState: {},
    reducers: {
        setTokens(
            state,
            action: PayloadAction<{ access: string; refresh: string }>
        ) {
        },
        setUser(state, action: PayloadAction<User>) {

        },
        logout(state) {

        }
    },
});

export const { setUser, setTokens, logout } = authSlice.actions;
export default authSlice.reducer;

