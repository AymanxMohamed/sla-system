import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import User from "../types/Api/Entities/User";
import {getInitialState, removeStorageUserData} from "../utils/authUtils";
import AuthState from "../types/AppStates/AuthState";

const authSlice = createSlice({
    name: "auth",
    initialState: getInitialState() as AuthState,
    reducers: {
        setUser(state, action: PayloadAction<User>) {
            state.user = action.payload;
        },
        logout(state) {
            state.user = undefined;
            removeStorageUserData();
        }
    },
});

export const { setUser, logout } = authSlice.actions;
export default authSlice.reducer;

