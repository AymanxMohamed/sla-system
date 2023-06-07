import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import Sla from "../types/Api/Entities/Sla";

const slaSlice = createSlice({
    name: "sla",
    initialState: [] as Sla[],
    reducers: {
        setSlas(state, action: PayloadAction<Sla[]>) {
            state = action.payload;
        },
        addSla(state, action: PayloadAction<Sla>) {
            state.push(action.payload);
        }
    },
});

export const { setSlas, addSla } = slaSlice.actions;
export default slaSlice.reducer;

