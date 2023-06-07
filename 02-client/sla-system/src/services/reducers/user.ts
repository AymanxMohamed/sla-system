import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import User from "../types/Api/Entities/User";

const userSlice = createSlice({
    name: "user",
    initialState: [] as User[],
    reducers: {
        setUsers(state, action: PayloadAction<User[]>) {
            state = action.payload;
        }
    },
});

export const { setUsers } = userSlice.actions;
export default userSlice.reducer;

