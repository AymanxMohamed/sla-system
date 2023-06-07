import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import User from "../types/Api/Entities/User";

const userSlice = createSlice({
    name: "user",
    initialState: [] as User[],
    reducers: {
        setUsers(state, action: PayloadAction<User[]>) {
            state = action.payload;
        },
        adduser(state, action: PayloadAction<User>) {
            state.push(action.payload);
        },
    },
});

export const { setUsers, adduser } = userSlice.actions;
export default userSlice.reducer;

