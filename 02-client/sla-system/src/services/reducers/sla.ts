import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import Sla from "../types/Api/Entities/Sla";

const slaSlice = createSlice({
    name: "sla",
    initialState: [] as Sla[],
    reducers: {
        setSlas(state, action: PayloadAction<Sla[]>) {
            state = action.payload;
        }
    },
});

export const { setSlas } = slaSlice.actions;
export default slaSlice.reducer;

